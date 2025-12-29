Imports MySql.Data.MySqlClient

Public Class FormHasil

    Dim conn As New MySqlConnection(
        "server=localhost;user id=root;password=;database=spk_karyawan")

    ' ================= FORM LOAD =================
    Private Sub Form6_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetupDgvKriteria()
        SetupDgvAwal()
        SetupDgvNormalisasi()
        SetupDgvHasil()

        StylingGrid(dgvKriteria)
        StylingGrid(dgvAwal)
        StylingGrid(dgvNormalisasi)
        StylingGrid(dgvHasil)

        LoadKriteriaBobot()
        LoadMatriksKeputusan()
        LoadMatriksNormalisasi()
        LoadHasilAkhir()
    End Sub

    ' ================= HELPER =================
    Function ToDoubleSafe(val As Object) As Double
        If IsDBNull(val) OrElse val Is Nothing Then Return 0
        Return CDbl(val)
    End Function

    Function GetRekomendasi(nilai As Double) As String
        If nilai >= 85 Then
            Return "🏆 Reward"
        ElseIf nilai >= 70 Then
            Return "✔ Dipertahankan"
        ElseIf nilai >= 55 Then
            Return "⚠ Pembinaan"
        Else
            Return "❌ Punishment"
        End If
    End Function

    ' ================= STYLE GRID =================
    Sub StylingGrid(dgv As DataGridView)
        With dgv
            .BorderStyle = BorderStyle.None
            .CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
            .GridColor = Color.LightGray

            .EnableHeadersVisualStyles = False
            .ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(45, 45, 48)
            .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            .ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 9, FontStyle.Bold)

            .DefaultCellStyle.Font = New Font("Segoe UI", 9)
            .AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245)

            .RowHeadersVisible = False
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .MultiSelect = False
        End With
    End Sub

    ' ================= SETUP GRID =================
    Sub SetupDgvKriteria()
        dgvKriteria.Columns.Clear()
        dgvKriteria.Columns.Add("Kode", "Kode")
        dgvKriteria.Columns.Add("Nama", "Nama Kriteria")
        dgvKriteria.Columns.Add("Bobot", "Bobot")
        dgvKriteria.Columns.Add("Tipe", "Tipe")
        dgvKriteria.ReadOnly = True
    End Sub

    Sub SetupDgvAwal()
        dgvAwal.Columns.Clear()
        dgvAwal.Columns.Add("Nama", "Nama Karyawan")
        dgvAwal.Columns.Add("C1", "C1")
        dgvAwal.Columns.Add("C2", "C2")
        dgvAwal.Columns.Add("C3", "C3")
        dgvAwal.Columns.Add("C4", "C4")
        dgvAwal.ReadOnly = True
    End Sub

    Sub SetupDgvNormalisasi()
        dgvNormalisasi.Columns.Clear()
        dgvNormalisasi.Columns.Add("Nama", "Nama Karyawan")
        dgvNormalisasi.Columns.Add("C1", "C1")
        dgvNormalisasi.Columns.Add("C2", "C2")
        dgvNormalisasi.Columns.Add("C3", "C3")
        dgvNormalisasi.Columns.Add("C4", "C4")
        dgvNormalisasi.ReadOnly = True
    End Sub

    Sub SetupDgvHasil()
        dgvHasil.Columns.Clear()
        dgvHasil.Columns.Add("Nama", "Nama Karyawan")
        dgvHasil.Columns.Add("Nilai", "Nilai Akhir")
        dgvHasil.Columns.Add("Rank", "Ranking")
        dgvHasil.Columns.Add("Rek", "Rekomendasi")
        dgvHasil.ReadOnly = True
    End Sub

    ' ================= DATA KRITERIA =================
    Sub LoadKriteriaBobot()
        dgvKriteria.Rows.Clear()
        dgvKriteria.Rows.Add("C1", "Pencapaian Target", "40%", "Benefit")
        dgvKriteria.Rows.Add("C2", "Proses Penjualan", "30%", "Benefit")
        dgvKriteria.Rows.Add("C3", "Perilaku & Soft Skill", "20%", "Benefit")
        dgvKriteria.Rows.Add("C4", "Disiplin & Kepatuhan", "10%", "Benefit")
    End Sub

    ' ================= MATRIKS KEPUTUSAN =================
    Sub LoadMatriksKeputusan()
        dgvAwal.Rows.Clear()

        Dim sql As String = "
        SELECT k.nama_karyawan,
        AVG(CASE WHEN kr.kode_kriteria LIKE 'PT%' THEN n.nilai END) C1,
        AVG(CASE WHEN kr.kode_kriteria LIKE 'PP%' THEN n.nilai END) C2,
        AVG(CASE WHEN kr.kode_kriteria LIKE 'PS%' THEN n.nilai END) C3,
        AVG(CASE WHEN kr.kode_kriteria LIKE 'DK%' THEN n.nilai END) C4
        FROM nilai n
        JOIN karyawan k ON n.id_karyawan = k.id_karyawan
        JOIN kriteria kr ON n.id_kriteria = kr.id_kriteria
        GROUP BY k.nama_karyawan
        "

        Dim da As New MySqlDataAdapter(sql, conn)
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

    ' ================= NORMALISASI =================
    Sub LoadMatriksNormalisasi()
        dgvNormalisasi.Rows.Clear()

        Dim maxC1 = dgvAwal.Rows.Cast(Of DataGridViewRow).Max(Function(r) CDbl(r.Cells(1).Value))
        Dim maxC2 = dgvAwal.Rows.Cast(Of DataGridViewRow).Max(Function(r) CDbl(r.Cells(2).Value))
        Dim maxC3 = dgvAwal.Rows.Cast(Of DataGridViewRow).Max(Function(r) CDbl(r.Cells(3).Value))
        Dim maxC4 = dgvAwal.Rows.Cast(Of DataGridViewRow).Max(Function(r) CDbl(r.Cells(4).Value))

        For Each r As DataGridViewRow In dgvAwal.Rows
            dgvNormalisasi.Rows.Add(
                r.Cells(0).Value,
                Math.Round(r.Cells(1).Value / maxC1, 3),
                Math.Round(r.Cells(2).Value / maxC2, 3),
                Math.Round(r.Cells(3).Value / maxC3, 3),
                Math.Round(r.Cells(4).Value / maxC4, 3)
            )
        Next
    End Sub

    ' ================= HASIL & RANKING =================
    Sub LoadHasilAkhir()
        dgvHasil.Rows.Clear()

        Dim sql As String = "
        SELECT h.id_hasil, k.nama_karyawan, h.nilai_akhir, h.ranking
        FROM hasil h
        JOIN karyawan k ON h.id_karyawan = k.id_karyawan
        ORDER BY h.ranking ASC"

        Dim da As New MySqlDataAdapter(sql, conn)
        Dim dt As New DataTable
        da.Fill(dt)

        conn.Open()

        For Each r As DataRow In dt.Rows
            Dim nilai = ToDoubleSafe(r("nilai_akhir"))
            Dim rek = GetRekomendasi(nilai)

            Dim cmd As New MySqlCommand(
                "UPDATE hasil SET rekomendasi=@r WHERE id_hasil=@id", conn)
            cmd.Parameters.AddWithValue("@r", rek)
            cmd.Parameters.AddWithValue("@id", r("id_hasil"))
            cmd.ExecuteNonQuery()

            dgvHasil.Rows.Add(
                r("nama_karyawan"),
                Math.Round(nilai, 0),
                r("ranking"),
                rek)
        Next

        conn.Close()
        WarnaiDgvHasil()
    End Sub

    ' ================= WARNA HASIL =================
    Sub WarnaiDgvHasil()
        For Each row As DataGridViewRow In dgvHasil.Rows

            ' Lewati baris kosong / new row
            If row.IsNewRow Then Continue For
            If row.Cells(3).Value Is Nothing Then Continue For

            Dim rek As String = row.Cells(3).Value.ToString()

            ' ===== WARNA BERDASARKAN REKOMENDASI =====
            If rek.Contains("Reward") Then
                row.DefaultCellStyle.BackColor = Color.FromArgb(200, 255, 200)
                row.DefaultCellStyle.ForeColor = Color.Black

            ElseIf rek.Contains("Dipertahankan") Then
                row.DefaultCellStyle.BackColor = Color.FromArgb(200, 220, 255)
                row.DefaultCellStyle.ForeColor = Color.Black

            ElseIf rek.Contains("Pembinaan") Then
                row.DefaultCellStyle.BackColor = Color.FromArgb(255, 240, 200)
                row.DefaultCellStyle.ForeColor = Color.Black

            ElseIf rek.Contains("Punishment") Then
                row.DefaultCellStyle.BackColor = Color.FromArgb(255, 200, 200)
                row.DefaultCellStyle.ForeColor = Color.Black
            End If

            ' ===== TEBALKAN RANKING 1 =====
            If row.Cells(2).Value IsNot Nothing AndAlso CInt(row.Cells(2).Value) = 1 Then
                row.DefaultCellStyle.Font = New Font("Segoe UI", 9, FontStyle.Bold)
            End If

        Next
    End Sub

    Private Sub btnMenu_Click(sender As Object, e As EventArgs) Handles btnMenu.Click
        FormMenu.Show()
        Me.Close()
    End Sub
End Class
