Imports System.Reflection.Emit
Imports MySql.Data.MySqlClient

Public Class Form6
    Sub TampilHasil()
        Try
            Call OpenConn()
            If conn.State <> ConnectionState.Open Then
                MessageBox.Show("Gagal membuka koneksi database", "Error")
                Return
            End If

            Dim da As New MySqlDataAdapter(
            "SELECT k.nama_karyawan, h.nilai_akhir, h.ranking
             FROM hasil h
             JOIN karyawan k ON h.id_karyawan = k.id_karyawan
             ORDER BY h.ranking ASC", conn)

            Dim dt As New DataTable
            da.Fill(dt)
            dgvHasil.DataSource = dt

            ' Tampilkan jumlah baris untuk debugging
            'Label1.Text = "Jumlah hasil: " & dt.Rows.Count ' (Tambahkan Label1 di form jika perlu)

        Catch ex As Exception
            MessageBox.Show("Error saat menampilkan hasil: " & ex.Message, "Error")
        Finally
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
        End Try
    End Sub

    Private Sub btnProses_Click(sender As Object, e As EventArgs) Handles btnProses.Click
        Call OpenConn()


        ' HAPUS HASIL LAMA
        Dim cmdClear As New MySqlCommand("DELETE FROM hasil", conn)
        cmdClear.ExecuteNonQuery()

        ' 1. Ambil Kriteria
        Dim dtKriteria As New DataTable
        Dim daKriteria As New MySqlDataAdapter(
        "SELECT id_kriteria, bobot, tipe FROM kriteria", conn)
        daKriteria.Fill(dtKriteria)

        ' 2. Ambil Nilai
        Dim dtNilai As New DataTable
        Dim daNilai As New MySqlDataAdapter(
        "SELECT id_karyawan, id_kriteria, nilai FROM nilai", conn)
        daNilai.Fill(dtNilai)

        If dtNilai.Rows.Count = 0 Then
            MessageBox.Show("Data nilai masih kosong!", "Peringatan")
            conn.Close()
            Exit Sub
        End If

        ' 3. Cari Max & Min
        Dim maxNilai As New Dictionary(Of Integer, Double)
        Dim minNilai As New Dictionary(Of Integer, Double)

        For Each k As DataRow In dtKriteria.Rows
            Dim idKriteria = k("id_kriteria")
            Dim rows = dtNilai.Select("id_kriteria=" & idKriteria)

            If rows.Length > 0 Then
                maxNilai(idKriteria) = rows.Max(Function(r) CDbl(r("nilai")))
                minNilai(idKriteria) = rows.Min(Function(r) CDbl(r("nilai")))
            End If
        Next

        ' 4. Hitung Nilai Akhir
        Dim hasil As New Dictionary(Of Integer, Double)

        For Each r As DataRow In dtNilai.Rows
            Dim idKaryawan = r("id_karyawan")
            Dim idKriteria = r("id_kriteria")
            Dim nilai = CDbl(r("nilai"))

            Dim k = dtKriteria.Select("id_kriteria=" & idKriteria)(0)
            Dim bobot = CDbl(k("bobot"))
            Dim tipe = k("tipe").ToString()

            Dim normalisasi As Double
            If tipe = "benefit" Then
                normalisasi = nilai / maxNilai(idKriteria)
            Else
                normalisasi = minNilai(idKriteria) / nilai
            End If

            If Not hasil.ContainsKey(idKaryawan) Then
                hasil(idKaryawan) = 0
            End If

            hasil(idKaryawan) += normalisasi * bobot
        Next

        ' 5. Ranking + Simpan
        Dim ranking = hasil.OrderByDescending(Function(x) x.Value).ToList()
        Dim rank As Integer = 1

        For Each h In ranking
            Dim cmd As New MySqlCommand(
            "INSERT INTO hasil (id_karyawan, nilai_akhir, ranking)
             VALUES (@id, @nilai, @rank)", conn)

            cmd.Parameters.AddWithValue("@id", h.Key)
            cmd.Parameters.AddWithValue("@nilai", h.Value)
            cmd.Parameters.AddWithValue("@rank", rank)
            cmd.ExecuteNonQuery()
            rank += 1
        Next

        conn.Close()

        MessageBox.Show("Proses SAW berhasil", "Informasi")
        TampilHasil()
    End Sub


    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        dgvKriteria.DataSource = Nothing
        dgvMatriks.DataSource = Nothing
        dgvNormalisasi.DataSource = Nothing
        dgvHasil.DataSource = Nothing

        dgvKriteria.Rows.Clear()
        dgvMatriks.Rows.Clear()
        dgvNormalisasi.Rows.Clear()
        dgvHasil.Rows.Clear()

        MessageBox.Show("Data berhasil dibersihkan", "Informasi",
                    MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub btnMenu_Click(sender As Object, e As EventArgs) Handles btnMenu.Click
        Form2.Show()
        Me.Close()
    End Sub

    Private Sub Form6_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TampilHasil()
    End Sub
End Class