Imports MySql.Data.MySqlClient

Public Class Form6

    Dim conn As New MySqlConnection(
        "server=localhost;user id=root;password=;database=spk_karyawan")

    ' ================= FORM LOAD =================
    Private Sub Form6_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetupDgvKriteria()
        SetupDgvAwal()
        SetupDgvNormalisasi()
        SetupDgvHasil()

        LoadKriteriaBobot()
        LoadMatriksKeputusan()
        LoadMatriksNormalisasi()
        LoadHasilAkhir()
    End Sub

    ' =====================================================
    ' HELPER ANTI-DBNULL
    ' =====================================================
    Function ToDoubleSafe(val As Object) As Double
        If IsDBNull(val) OrElse val Is Nothing Then
            Return 0
        Else
            Return CDbl(val)
        End If
    End Function

    ' =====================================================
    ' SETUP DATA GRID VIEW
    ' =====================================================
    Sub SetupDgvKriteria()
        With dgvKriteria
            .Columns.Clear()
            .AllowUserToAddRows = False
            .ReadOnly = True

            .Columns.Add("colKode", "Kode")
            .Columns.Add("colNama", "Nama Kriteria")
            .Columns.Add("colBobot", "Bobot")
            .Columns.Add("colTipe", "Tipe")
        End With
    End Sub

    Sub SetupDgvAwal()
        With dgvAwal
            .Columns.Clear()
            .AllowUserToAddRows = False
            .ReadOnly = True

            .Columns.Add("colNama", "Nama Karyawan")
            .Columns.Add("colC1", "C1")
            .Columns.Add("colC2", "C2")
            .Columns.Add("colC3", "C3")
            .Columns.Add("colC4", "C4")
        End With
    End Sub

    Sub SetupDgvNormalisasi()
        With dgvNormalisasi
            .Columns.Clear()
            .AllowUserToAddRows = False
            .ReadOnly = True

            .Columns.Add("colNama", "Nama Karyawan")
            .Columns.Add("colC1", "C1")
            .Columns.Add("colC2", "C2")
            .Columns.Add("colC3", "C3")
            .Columns.Add("colC4", "C4")
        End With
    End Sub

    Sub SetupDgvHasil()
        With dgvHasil
            .Columns.Clear()
            .AllowUserToAddRows = False
            .ReadOnly = True

            .Columns.Add("colNama", "Nama Karyawan")
            .Columns.Add("colNilai", "Nilai Akhir")
            .Columns.Add("colRank", "Ranking")
        End With
    End Sub

    ' =====================================================
    ' 1. DATA KRITERIA DAN BOBOT
    ' =====================================================
    Sub LoadKriteriaBobot()
        dgvKriteria.Rows.Clear()
        dgvKriteria.Rows.Add("C1", "Pencapaian Target", "40%", "Benefit")
        dgvKriteria.Rows.Add("C2", "Proses Penjualan", "30%", "Benefit")
        dgvKriteria.Rows.Add("C3", "Perilaku & Soft Skill", "20%", "Benefit")
        dgvKriteria.Rows.Add("C4", "Disiplin & Kepatuhan", "10%", "Benefit")
    End Sub

    ' =====================================================
    ' 2. MATRIKS KEPUTUSAN (NILAI AWAL)
    ' =====================================================
    Sub LoadMatriksKeputusan()
        dgvAwal.Rows.Clear()

        Dim sql As String = "
        SELECT k.nama_karyawan,
        COALESCE(AVG(CASE WHEN kr.kode_kriteria LIKE 'PT%' THEN n.nilai END),0) AS C1,
        COALESCE(AVG(CASE WHEN kr.kode_kriteria LIKE 'PP%' THEN n.nilai END),0) AS C2,
        COALESCE(AVG(CASE WHEN kr.kode_kriteria LIKE 'PS%' THEN n.nilai END),0) AS C3,
        COALESCE(AVG(CASE WHEN kr.kode_kriteria LIKE 'DK%' THEN n.nilai END),0) AS C4
        FROM nilai n
        JOIN karyawan k ON n.id_karyawan = k.id_karyawan
        JOIN kriteria kr ON n.id_kriteria = kr.id_kriteria
        GROUP BY k.nama_karyawan
        "

        Using da As New MySqlDataAdapter(sql, conn)
            Dim dt As New DataTable
            da.Fill(dt)

            For Each r As DataRow In dt.Rows
                dgvAwal.Rows.Add(
                    r("nama_karyawan"),
                    Math.Round(ToDoubleSafe(r("C1")), 2),
                    Math.Round(ToDoubleSafe(r("C2")), 2),
                    Math.Round(ToDoubleSafe(r("C3")), 2),
                    Math.Round(ToDoubleSafe(r("C4")), 2)
                )
            Next
    End Sub

    ' =====================================================
    ' 3. MATRIKS NORMALISASI (SAW)
    ' =====================================================
    Sub LoadMatriksNormalisasi()
        dgvNormalisasi.Rows.Clear()

        Dim maxC1 = dgvAwal.Rows.Cast(Of DataGridViewRow).Max(Function(r) CDbl(r.Cells(1).Value))
        Dim maxC2 = dgvAwal.Rows.Cast(Of DataGridViewRow).Max(Function(r) CDbl(r.Cells(2).Value))
        Dim maxC3 = dgvAwal.Rows.Cast(Of DataGridViewRow).Max(Function(r) CDbl(r.Cells(3).Value))
        Dim maxC4 = dgvAwal.Rows.Cast(Of DataGridViewRow).Max(Function(r) CDbl(r.Cells(4).Value))

        For Each row As DataGridViewRow In dgvAwal.Rows
            dgvNormalisasi.Rows.Add(
                row.Cells(0).Value,
                Math.Round(CDbl(row.Cells(1).Value) / maxC1, 3),
                Math.Round(CDbl(row.Cells(2).Value) / maxC2, 3),
                Math.Round(CDbl(row.Cells(3).Value) / maxC3, 3),
                Math.Round(CDbl(row.Cells(4).Value) / maxC4, 3)
            )
        Next
    End Sub

    ' =====================================================
    ' 4. HASIL AKHIR DAN RANKING
    ' =====================================================
    Sub LoadHasilAkhir()
        dgvHasil.Rows.Clear()

        Dim sql As String = "
        SELECT k.nama_karyawan, h.nilai_akhir, h.ranking
        FROM hasil h
        JOIN karyawan k ON h.id_karyawan = k.id_karyawan
        ORDER BY h.ranking ASC
        "

        Using da As New MySqlDataAdapter(sql, conn)
            Dim dt As New DataTable
            da.Fill(dt)

            For Each r As DataRow In dt.Rows
                dgvHasil.Rows.Add(
                    r("nama_karyawan"),
                    Math.Round(ToDoubleSafe(r("nilai_akhir")), 0),
                    r("ranking")
                )
            Next
    End Sub

End Class
