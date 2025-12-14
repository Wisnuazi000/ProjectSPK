Imports MySql.Data.MySqlClient

Public Class Form3
    Sub KondisiAwal()
        ' Clear semua input
        txtId.Clear()
        txtNik.Clear()
        txtNama.Clear()
        txtJabatan.Clear()
        txtDivisi.Clear()
        txtHP.Clear()
        txtAlamat.Clear()

        ' Reset ComboBox
        cboJK.SelectedIndex = -1
        cboStatus.SelectedIndex = -1

        ' Reset DateTimePicker
        dtpMasuk.Value = DateTime.Now

        ' Setting Enable / Disable
        txtId.Enabled = False      ' ID auto increment
        txtNik.Enabled = True
        txtNama.Enabled = True
        txtJabatan.Enabled = True
        txtDivisi.Enabled = True
        txtHP.Enabled = True
        txtAlamat.Enabled = True

        cboJK.Enabled = True
        cboStatus.Enabled = True
        dtpMasuk.Enabled = True

        ' Fokus awal
        txtNik.Focus()
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        KondisiAwal()
    End Sub

    Sub TampilData()
        Call OpenConn()
        Dim da As New MySqlDataAdapter("SELECT * FROM karyawan", conn)
        Dim dt As New DataTable
        da.Fill(dt)
        dgvKaryawan.DataSource = dt

        dgvKaryawan.Columns("id_karyawan").HeaderText = "ID Karyawan"
        dgvKaryawan.Columns("nama_karyawan").HeaderText = "Nama Karyawan"
        dgvKaryawan.Columns("jenis_kelamin").HeaderText = "Jenis Kelamin"
        dgvKaryawan.Columns("no_hp").HeaderText = "No HP"
        dgvKaryawan.Columns("tanggal_masuk").HeaderText = "Tanggal Masuk"
        dgvKaryawan.Columns("status_karyawan").HeaderText = "Status Karyawan"

        conn.Close()
    End Sub


    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        Call OpenConn()

        Dim query As String =
    "INSERT INTO karyawan 
    (nik, nama_karyawan, jenis_kelamin, jabatan, divisi, tanggal_masuk, status_karyawan, no_hp, alamat)
    VALUES
    (@nik,@nama,@jk,@jabatan,@divisi,@tgl,@status,@hp,@alamat)"

        Dim cmd As New MySqlCommand(query, conn)
        cmd.Parameters.AddWithValue("@nik", txtNik.Text)
        cmd.Parameters.AddWithValue("@nama", txtNama.Text)
        cmd.Parameters.AddWithValue("@jk", cboJK.Text)
        cmd.Parameters.AddWithValue("@jabatan", txtJabatan.Text)
        cmd.Parameters.AddWithValue("@divisi", txtDivisi.Text)
        cmd.Parameters.AddWithValue("@tgl", dtpMasuk.Value)
        cmd.Parameters.AddWithValue("@status", cboStatus.Text)
        cmd.Parameters.AddWithValue("@hp", txtHP.Text)
        cmd.Parameters.AddWithValue("@alamat", txtAlamat.Text)

        cmd.ExecuteNonQuery()
        conn.Close()

        MessageBox.Show("Data karyawan berhasil disimpan")
        TampilData()
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        Call OpenConn()

        Dim query As String =
    "UPDATE karyawan SET
    nik=@nik,
    nama_karyawan=@nama,
    jenis_kelamin=@jk,
    jabatan=@jabatan,
    divisi=@divisi,
    tanggal_masuk=@tgl,
    status_karyawan=@status,
    no_hp=@hp,
    alamat=@alamat
    WHERE id_karyawan=@id"

        Dim cmd As New MySqlCommand(query, conn)
        cmd.Parameters.AddWithValue("@id", txtId.Text)
        cmd.Parameters.AddWithValue("@nik", txtNik.Text)
        cmd.Parameters.AddWithValue("@nama", txtNama.Text)
        cmd.Parameters.AddWithValue("@jk", cboJK.Text)
        cmd.Parameters.AddWithValue("@jabatan", txtJabatan.Text)
        cmd.Parameters.AddWithValue("@divisi", txtDivisi.Text)
        cmd.Parameters.AddWithValue("@tgl", dtpMasuk.Value)
        cmd.Parameters.AddWithValue("@status", cboStatus.Text)
        cmd.Parameters.AddWithValue("@hp", txtHP.Text)
        cmd.Parameters.AddWithValue("@alamat", txtAlamat.Text)

        cmd.ExecuteNonQuery()
        conn.Close()

        MessageBox.Show("Data karyawan berhasil diubah")
        TampilData()
    End Sub

    Private Sub btnHapus_Click(sender As Object, e As EventArgs) Handles btnHapus.Click
        Call OpenConn()

        Dim query As String = "DELETE FROM karyawan WHERE id_karyawan=@id"
        Dim cmd As New MySqlCommand(query, conn)
        cmd.Parameters.AddWithValue("@id", txtId.Text)

        cmd.ExecuteNonQuery()
        conn.Close()

        MessageBox.Show("Data karyawan berhasil dihapus")
        TampilData()
    End Sub

    Private Sub dgvKaryawan_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvKaryawan.CellClick
        If e.RowIndex >= 0 Then
            txtId.Text = dgvKaryawan.Rows(e.RowIndex).Cells("id_karyawan").Value.ToString()
            txtNik.Text = dgvKaryawan.Rows(e.RowIndex).Cells("nik").Value.ToString()
            txtNama.Text = dgvKaryawan.Rows(e.RowIndex).Cells("nama_karyawan").Value.ToString()
            cboJK.Text = dgvKaryawan.Rows(e.RowIndex).Cells("jenis_kelamin").Value.ToString()
            txtJabatan.Text = dgvKaryawan.Rows(e.RowIndex).Cells("jabatan").Value.ToString()
            txtDivisi.Text = dgvKaryawan.Rows(e.RowIndex).Cells("divisi").Value.ToString()
            dtpMasuk.Value = Convert.ToDateTime(dgvKaryawan.Rows(e.RowIndex).Cells("tanggal_masuk").Value)
            cboStatus.Text = dgvKaryawan.Rows(e.RowIndex).Cells("status_karyawan").Value.ToString()
            txtHP.Text = dgvKaryawan.Rows(e.RowIndex).Cells("no_hp").Value.ToString()
            txtAlamat.Text = dgvKaryawan.Rows(e.RowIndex).Cells("alamat").Value.ToString()
        End If
    End Sub


    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TampilData()
        KondisiAwal()
    End Sub

    Private Sub btnMenu_Click(sender As Object, e As EventArgs) Handles btnMenu.Click
        Form2.Show()
        Me.Hide()
    End Sub
End Class