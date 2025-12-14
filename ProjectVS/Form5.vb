Imports MySql.Data.MySqlClient

Public Class Form5
    Sub LoadKaryawan()
        Call OpenConn()
        Dim da As New MySqlDataAdapter(
        "SELECT id_karyawan, nama_karyawan FROM karyawan", conn)
        Dim dt As New DataTable
        da.Fill(dt)

        cboKaryawan.DataSource = dt
        cboKaryawan.DisplayMember = "nama_karyawan"
        cboKaryawan.ValueMember = "id_karyawan"

        conn.Close()
    End Sub

    Sub LoadKriteria()
        Call OpenConn()
        Dim da As New MySqlDataAdapter(
        "SELECT id_kriteria, nama_kriteria FROM kriteria", conn)
        Dim dt As New DataTable
        da.Fill(dt)

        cboKriteria.DataSource = dt
        cboKriteria.DisplayMember = "nama_kriteria"
        cboKriteria.ValueMember = "id_kriteria"

        conn.Close()
    End Sub

    Sub KondisiAwal()
        txtId.Clear()

        ' Reset NumericUpDown
        nudNilai.Value = nudNilai.Minimum

        ' Reset ComboBox
        cboKaryawan.SelectedIndex = -1
        cboKriteria.SelectedIndex = -1

        txtId.Enabled = False
    End Sub


    Sub TampilData()
        Call OpenConn()
        Dim query As String =
    "SELECT n.id_nilai, k.nama_karyawan, kr.nama_kriteria, n.nilai
     FROM nilai n
     JOIN karyawan k ON n.id_karyawan = k.id_karyawan
     JOIN kriteria kr ON n.id_kriteria = kr.id_kriteria"

        Dim da As New MySqlDataAdapter(query, conn)
        Dim dt As New DataTable
        da.Fill(dt)
        dgvNilai.DataSource = dt
        conn.Close()
    End Sub

    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        If cboKaryawan.Text = "" Or cboKriteria.Text = "" Then
            MessageBox.Show("Karyawan dan Kriteria wajib dipilih")
            Exit Sub
        End If

        Call OpenConn()

        Dim query As String =
    "INSERT INTO nilai (id_karyawan, id_kriteria, nilai)
     VALUES (@karyawan, @kriteria, @nilai)"

        Dim cmd As New MySqlCommand(query, conn)
        cmd.Parameters.AddWithValue("@karyawan", cboKaryawan.SelectedValue)
        cmd.Parameters.AddWithValue("@kriteria", cboKriteria.SelectedValue)
        cmd.Parameters.AddWithValue("@nilai", nudNilai.Value)

        cmd.ExecuteNonQuery()
        conn.Close()

        MessageBox.Show("Nilai berhasil disimpan")
        TampilData()
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If txtId.Text = "" Then
            MessageBox.Show("Pilih data yang akan diedit")
            Exit Sub
        End If

        Call OpenConn()
        Dim query As String =
        "UPDATE nilai SET
         id_karyawan=@karyawan,
         id_kriteria=@kriteria,
         nilai=@nilai
         WHERE id_nilai=@id"

        Dim cmd As New MySqlCommand(query, conn)
        cmd.Parameters.AddWithValue("@id", txtId.Text)
        cmd.Parameters.AddWithValue("@karyawan", cboKaryawan.SelectedValue)
        cmd.Parameters.AddWithValue("@kriteria", cboKriteria.SelectedValue)
        cmd.Parameters.AddWithValue("@nilai", nudNilai.Text)

        cmd.ExecuteNonQuery()
        conn.Close()

        MessageBox.Show("Nilai berhasil diubah")
        KondisiAwal()
        TampilData()
    End Sub

    Private Sub btnHapus_Click(sender As Object, e As EventArgs) Handles btnHapus.Click
        If txtId.Text = "" Then
            MessageBox.Show("Pilih data yang akan dihapus")
            Exit Sub
        End If

        Call OpenConn()
        Dim cmd As New MySqlCommand(
            "DELETE FROM nilai WHERE id_nilai=@id", conn)
        cmd.Parameters.AddWithValue("@id", txtId.Text)
        cmd.ExecuteNonQuery()
        conn.Close()

        MessageBox.Show("Nilai berhasil dihapus")
        KondisiAwal()
        TampilData()
    End Sub

    Private Sub dgvNilai_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvNilai.CellClick
        If e.RowIndex >= 0 Then
            txtId.Text = dgvNilai.Rows(e.RowIndex).Cells("id_nilai").Value.ToString()
            cboKaryawan.Text = dgvNilai.Rows(e.RowIndex).Cells("nama_karyawan").Value.ToString()
            cboKriteria.Text = dgvNilai.Rows(e.RowIndex).Cells("nama_kriteria").Value.ToString()
            nudNilai.Text = dgvNilai.Rows(e.RowIndex).Cells("nilai").Value.ToString()
        End If
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        KondisiAwal()
    End Sub


    Private Sub Form5_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadKaryawan()
        LoadKriteria()
        TampilData()
        KondisiAwal()
    End Sub

    Private Sub btnMenu_Click(sender As Object, e As EventArgs) Handles btnMenu.Click
        Form2.Show()
        Me.Hide()
    End Sub
End Class