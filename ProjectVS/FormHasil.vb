Imports MySql.Data.MySqlClient

Public Class FormHasil

    Dim conn As New MySqlConnection(
        "server=localhost;user id=root;password=;database=spk_karyawan")

    ' ================= FORM LOAD =================
    Private Sub FormHasil_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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

        ReHitungRanking()   ' <<< WAJIB
        LoadHasilAkhir()
    End Sub

    ' ================= HELPER =================
    Function ToDoubleSafe(val As Object) As Double
        If IsDBNull(val) OrElse val Is Nothing Then Return 0
        Return CDbl(val)
    End Function

    ' ================= REKOMENDASI =================
    Function GetRekomendasi(nilai As Double) As String
        If nilai >= 70 Then
            Return "✔ Dipertahankan"
        ElseIf nilai >= 55 Then
            Return "⚠ Pembinaan"
        Else
            Return "❌ Punishment"
        End If
    End Function

    Function GetRekomendasiFinal(rank As Integer, nilai As Double) As String
        If rank = 1 Then
            Return "🏆 Reward"
        Else
            Return GetRekomendasi(nilai)
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
        COALESCE(AVG(CASE WHEN kr.kode_kriteria LIKE 'PT%' THEN n.nilai END),0) AS C1,
        COALESCE(AVG(CASE WHEN kr.kode_kriteria LIKE 'PP%' THEN n.nilai END),0) AS C2,
        COALESCE(AVG(CASE WHEN kr.kode_kriteria LIKE 'PS%' THEN n.nilai END),0) AS C3,
        COALESCE(AVG(CASE WHEN kr.kode_kriteria LIKE 'DK%' THEN n.nilai END),0) AS C4
        FROM nilai n
        JOIN karyawan k ON n.id_karyawan = k.id_karyawan
        JOIN kriteria kr ON n.id_kriteria = kr.id_kriteria
        GROUP BY k.nama_karyawan
        ORDER BY k.nama_karyawan
    "

        Dim da As New MySqlDataAdapter(sql, conn)
        Dim dt As New DataTable
        da.Fill(dt)

        For Each r As DataRow In dt.Rows
            dgvAwal.Rows.Add(
            r("nama_karyawan").ToString(),
            Math.Round(ToDoubleSafe(r("C1")), 2),
            Math.Round(ToDoubleSafe(r("C2")), 2),
            Math.Round(ToDoubleSafe(r("C3")), 2),
            Math.Round(ToDoubleSafe(r("C4")), 2)
        )
        Next

        ' === RAPIKAN TAMPILAN ANGKA ===
        For i As Integer = 1 To 4
            dgvAwal.Columns(i).DefaultCellStyle.Alignment =
            DataGridViewContentAlignment.MiddleRight
            dgvAwal.Columns(i).DefaultCellStyle.Format = "N2"
        Next
    End Sub


    ' ================= NORMALISASI =================
    Sub LoadMatriksNormalisasi()
        dgvNormalisasi.Rows.Clear()
        If dgvAwal.Rows.Count = 0 Then Exit Sub

        Dim maxC1 = dgvAwal.Rows.Cast(Of DataGridViewRow).Max(Function(r) CDbl(r.Cells(1).Value))
        Dim maxC2 = dgvAwal.Rows.Cast(Of DataGridViewRow).Max(Function(r) CDbl(r.Cells(2).Value))
        Dim maxC3 = dgvAwal.Rows.Cast(Of DataGridViewRow).Max(Function(r) CDbl(r.Cells(3).Value))
        Dim maxC4 = dgvAwal.Rows.Cast(Of DataGridViewRow).Max(Function(r) CDbl(r.Cells(4).Value))

        For Each r As DataGridViewRow In dgvAwal.Rows
            dgvNormalisasi.Rows.Add(
                r.Cells(0).Value,
                If(maxC1 = 0, 0, Math.Round(r.Cells(1).Value / maxC1, 3)),
                If(maxC2 = 0, 0, Math.Round(r.Cells(2).Value / maxC2, 3)),
                If(maxC3 = 0, 0, Math.Round(r.Cells(3).Value / maxC3, 3)),
                If(maxC4 = 0, 0, Math.Round(r.Cells(4).Value / maxC4, 3))
            )
        Next
    End Sub

    ' ================= RE-HITUNG RANKING =================
    Sub ReHitungRanking()
        Dim dt As New DataTable
        Dim da As New MySqlDataAdapter(
            "SELECT id_hasil FROM hasil ORDER BY nilai_akhir DESC", conn)
        da.Fill(dt)

        conn.Open()
        Dim rank As Integer = 1
        For Each r As DataRow In dt.Rows
            Dim cmd As New MySqlCommand(
                "UPDATE hasil SET ranking=@r WHERE id_hasil=@id", conn)
            cmd.Parameters.AddWithValue("@r", rank)
            cmd.Parameters.AddWithValue("@id", r("id_hasil"))
            cmd.ExecuteNonQuery()
            rank += 1
        Next
        conn.Close()
    End Sub

    ' ================= HASIL & RANKING =================
    Sub LoadHasilAkhir()
        dgvHasil.Rows.Clear()

        Dim da As New MySqlDataAdapter("
            SELECT h.id_hasil, k.nama_karyawan, h.nilai_akhir, h.ranking
            FROM hasil h
            JOIN karyawan k ON h.id_karyawan = k.id_karyawan
            ORDER BY h.ranking ASC", conn)

        Dim dt As New DataTable
        da.Fill(dt)

        conn.Open()
        For Each r As DataRow In dt.Rows
            Dim nilai = ToDoubleSafe(r("nilai_akhir"))
            Dim rank = CInt(r("ranking"))
            Dim rek = GetRekomendasiFinal(rank, nilai)

            Dim cmd As New MySqlCommand(
                "UPDATE hasil SET rekomendasi=@rek WHERE id_hasil=@id", conn)
            cmd.Parameters.AddWithValue("@rek", rek)
            cmd.Parameters.AddWithValue("@id", r("id_hasil"))
            cmd.ExecuteNonQuery()

            dgvHasil.Rows.Add(r("nama_karyawan"), Math.Round(nilai, 0), rank, rek)
        Next
        conn.Close()

        WarnaiDgvHasil()
    End Sub

    ' ================= WARNA =================
    Sub WarnaiDgvHasil()
        For Each row As DataGridViewRow In dgvHasil.Rows
            If row.IsNewRow Then Continue For

            Dim rek = row.Cells(3).Value.ToString()

            If rek.Contains("Reward") Then row.DefaultCellStyle.BackColor = Color.LightGreen
            If rek.Contains("Dipertahankan") Then row.DefaultCellStyle.BackColor = Color.LightBlue
            If rek.Contains("Pembinaan") Then row.DefaultCellStyle.BackColor = Color.Khaki
            If rek.Contains("Punishment") Then row.DefaultCellStyle.BackColor = Color.LightCoral

            If CInt(row.Cells(2).Value) = 1 Then
                row.DefaultCellStyle.Font = New Font("Segoe UI", 9, FontStyle.Bold)
            End If
        Next
    End Sub

    ' ================= HAPUS 1 PENILAIAN =================
    Private Sub btnHapus_Click(sender As Object, e As EventArgs) Handles btnHapus.Click

        If dgvHasil.SelectedRows.Count = 0 Then
            MessageBox.Show("Pilih karyawan terlebih dahulu")
            Exit Sub
        End If

        Dim nama = dgvHasil.SelectedRows(0).Cells(0).Value.ToString()

        If MessageBox.Show($"Hapus penilaian untuk {nama}?",
            "Konfirmasi", MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning) = DialogResult.No Then Exit Sub

        Try
            conn.Open()

            Dim cmd1 As New MySqlCommand("
                DELETE n FROM nilai n
                JOIN karyawan k ON n.id_karyawan = k.id_karyawan
                WHERE k.nama_karyawan=@nama", conn)
            cmd1.Parameters.AddWithValue("@nama", nama)
            cmd1.ExecuteNonQuery()

            Dim cmd2 As New MySqlCommand("
                DELETE h FROM hasil h
                JOIN karyawan k ON h.id_karyawan = k.id_karyawan
                WHERE k.nama_karyawan=@nama", conn)
            cmd2.Parameters.AddWithValue("@nama", nama)
            cmd2.ExecuteNonQuery()

            conn.Close()

            ReHitungRanking()

            MessageBox.Show("Penilaian berhasil dihapus")

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            If conn.State = ConnectionState.Open Then conn.Close()
        End Try

        LoadMatriksKeputusan()
        LoadMatriksNormalisasi()
        LoadHasilAkhir()
    End Sub

    ' ================= CLEAR SEMUA =================
    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        If MessageBox.Show(
          "Hapus semua penilaian?",
          "Konfirmasi",
          MessageBoxButtons.YesNo,
          MessageBoxIcon.Warning) = DialogResult.No Then

            Exit Sub
        End If

        Try
            conn.Open()

            Dim cmd1 As New MySqlCommand("DELETE FROM nilai", conn)
            cmd1.ExecuteNonQuery()

            Dim cmd2 As New MySqlCommand("DELETE FROM hasil", conn)
            cmd2.ExecuteNonQuery()

            MessageBox.Show("Semua penilaian berhasil dihapus",
                            "Sukses",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information)

            dgvAwal.Rows.Clear()
            dgvNormalisasi.Rows.Clear()
            dgvHasil.Rows.Clear()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub btnMenu_Click(sender As Object, e As EventArgs) Handles btnMenu.Click
        FormMenu.Show()
        Me.Close()
    End Sub
End Class
