Imports MySql.Data.MySqlClient
Public Class Form4
    Sub KondisiAwal()
        txtId.Clear()
        txtKode.Clear()
        txtNama.Clear()
        txtBobot.Clear()
        cboTipe.SelectedIndex = -1

        txtId.Enabled = False
        txtKode.Focus()
    End Sub

    Sub TampilData()
        Call OpenConn()
        Dim da As New MySqlDataAdapter("SELECT * FROM kriteria", conn)
        Dim dt As New DataTable
        da.Fill(dt)
        dgvKriteria.DataSource = dt
        conn.Close()

        dgvKriteria.Columns("id_kriteria").HeaderText = "ID"
        dgvKriteria.Columns("kode_kriteria").HeaderText = "Kode"
        dgvKriteria.Columns("nama_kriteria").HeaderText = "Nama Kriteria"
        dgvKriteria.Columns("bobot").HeaderText = "Bobot"
        dgvKriteria.Columns("tipe").HeaderText = "Tipe"
    End Sub

    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click

        If txtKode.Text = "" Or txtNama.Text = "" Or txtBobot.Text = "" Or cboTipe.Text = "" Then
            MessageBox.Show("Data belum lengkap")
            Exit Sub
        End If

        Call OpenConn()
        Dim cmd As New MySqlCommand(
            "INSERT INTO kriteria (kode_kriteria, nama_kriteria, bobot, tipe)
             VALUES (@kode,@nama,@bobot,@tipe)", conn)

        cmd.Parameters.AddWithValue("@kode", txtKode.Text)
        cmd.Parameters.AddWithValue("@nama", txtNama.Text)
        cmd.Parameters.AddWithValue("@bobot", CDbl(txtBobot.Text))
        cmd.Parameters.AddWithValue("@tipe", cboTipe.Text.ToLower())

        cmd.ExecuteNonQuery()
        conn.Close()

        MessageBox.Show("Kriteria berhasil disimpan")
        KondisiAwal()
        TampilData()
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If txtId.Text = "" Then Exit Sub

        Call OpenConn()
        Dim cmd As New MySqlCommand(
            "UPDATE kriteria SET 
             kode_kriteria=@kode,
             nama_kriteria=@nama,
             bobot=@bobot,
             tipe=@tipe
             WHERE id_kriteria=@id", conn)

        cmd.Parameters.AddWithValue("@id", txtId.Text)
        cmd.Parameters.AddWithValue("@kode", txtKode.Text)
        cmd.Parameters.AddWithValue("@nama", txtNama.Text)
        cmd.Parameters.AddWithValue("@bobot", CDbl(txtBobot.Text))
        cmd.Parameters.AddWithValue("@tipe", cboTipe.Text)

        cmd.ExecuteNonQuery()
        conn.Close()

        MessageBox.Show("Kriteria berhasil diubah")
        KondisiAwal()
        TampilData()
    End Sub

    Private Sub btnHapus_Click(sender As Object, e As EventArgs) Handles btnHapus.Click
        If txtId.Text = "" Then Exit Sub

        If MessageBox.Show("Hapus kriteria ini?", "Konfirmasi",
                           MessageBoxButtons.YesNo) = DialogResult.No Then Exit Sub

        Call OpenConn()
        Dim cmd As New MySqlCommand(
            "DELETE FROM kriteria WHERE id_kriteria=@id", conn)
        cmd.Parameters.AddWithValue("@id", txtId.Text)
        cmd.ExecuteNonQuery()
        conn.Close()

        MessageBox.Show("Kriteria berhasil dihapus")
        KondisiAwal()
        TampilData()
    End Sub

    Private Sub dgvKriteria_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvKriteria.CellClick
        If e.RowIndex >= 0 Then
            txtId.Text = dgvKriteria.Rows(e.RowIndex).Cells("id_kriteria").Value.ToString()
            txtKode.Text = dgvKriteria.Rows(e.RowIndex).Cells("kode_kriteria").Value.ToString()
            txtNama.Text = dgvKriteria.Rows(e.RowIndex).Cells("nama_kriteria").Value.ToString()
            txtBobot.Text = dgvKriteria.Rows(e.RowIndex).Cells("bobot").Value.ToString()
            cboTipe.Text = dgvKriteria.Rows(e.RowIndex).Cells("tipe").Value.ToString()
        End If
    End Sub

    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TampilData()
        KondisiAwal()
    End Sub

    Private Sub btnMenu_Click(sender As Object, e As EventArgs) Handles btnMenu.Click
        Form2.Show()
        Me.Hide()
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        KondisiAwal()
    End Sub
End Class