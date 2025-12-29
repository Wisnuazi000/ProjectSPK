Imports MySql.Data.MySqlClient

Public Class FormDataKaryawan

    ' ================= FORM LOAD =================
    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtId.ReadOnly = True
        LoadCombo()
        KondisiAwal()
        TampilData()
        AturHakAkses()
        StyleButton()
    End Sub

    ' ================= ROLE =================
    Sub AturHakAkses()
        If RoleUser <> "HR" Then
            btnSimpan.Enabled = False
            btnHapus.Enabled = False
        End If
    End Sub

    ' ================= STYLE BUTTON =================
    Sub StyleButton()
        btnSimpan.BackColor = Color.FromArgb(46, 204, 113)
        btnSimpan.ForeColor = Color.White

        btnClear.BackColor = Color.Gainsboro
        btnClear.ForeColor = Color.Black

        btnHapus.BackColor = Color.FromArgb(231, 76, 60)
        btnHapus.ForeColor = Color.White

        btnMenu.BackColor = Color.FromArgb(52, 152, 219)
        btnMenu.ForeColor = Color.White
    End Sub

    ' ================= KONDISI AWAL =================
    Sub KondisiAwal()
        txtId.Clear()
        txtNik.Clear()
        txtNama.Clear()
        txtJabatan.Clear()
        txtDivisi.Clear()
        txtHP.Clear()
        txtAlamat.Clear()

        cboJK.SelectedIndex = -1
        cboStatus.SelectedIndex = -1
        dtpMasuk.Value = DateTime.Now

        btnHapus.Enabled = False
        txtNik.Focus()
    End Sub

    ' ================= LOAD COMBO =================
    Sub LoadCombo()
        cboJK.Items.Clear()
        cboJK.Items.AddRange({"Laki-Laki", "Perempuan"})

        cboStatus.Items.Clear()
        cboStatus.Items.AddRange({"Aktif", "Non Aktif"})
    End Sub

    ' ================= TAMPIL DATA =================
    Sub TampilData()
        Call OpenConn()

        Dim da As New MySqlDataAdapter(
            "SELECT * FROM karyawan ORDER BY id_karyawan DESC", conn)
        Dim dt As New DataTable
        da.Fill(dt)
        dgvKaryawan.DataSource = dt

        dgvKaryawan.Columns("id_karyawan").HeaderText = "ID"
        dgvKaryawan.Columns("nik").HeaderText = "NIK"
        dgvKaryawan.Columns("nama_karyawan").HeaderText = "Nama"
        dgvKaryawan.Columns("jenis_kelamin").HeaderText = "JK"
        dgvKaryawan.Columns("jabatan").HeaderText = "Jabatan"
        dgvKaryawan.Columns("divisi").HeaderText = "Divisi"
        dgvKaryawan.Columns("tanggal_masuk").HeaderText = "Tanggal Masuk"
        dgvKaryawan.Columns("status_karyawan").HeaderText = "Status"
        dgvKaryawan.Columns("no_hp").HeaderText = "No HP"

        dgvKaryawan.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvKaryawan.ReadOnly = True

        conn.Close()
    End Sub

    ' ================= SIMPAN =================
    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click

        If RoleUser <> "HR" Then
            MessageBox.Show("Anda tidak memiliki hak akses", "Akses Ditolak")
            Exit Sub
        End If

        If txtNik.Text = "" Or txtNama.Text = "" Then
            MessageBox.Show("NIK dan Nama wajib diisi", "Validasi")
            Exit Sub
        End If

        Call OpenConn()

        Dim query As String =
        "INSERT INTO karyawan
        (nik,nama_karyawan,jenis_kelamin,jabatan,divisi,tanggal_masuk,status_karyawan,no_hp,alamat)
        VALUES
        (@nik,@nama,@jk,@jabatan,@divisi,@tgl,@status,@hp,@alamat)
        ON DUPLICATE KEY UPDATE
        nama_karyawan=@nama,
        jenis_kelamin=@jk,
        jabatan=@jabatan,
        divisi=@divisi,
        tanggal_masuk=@tgl,
        status_karyawan=@status,
        no_hp=@hp,
        alamat=@alamat"

        Using cmd As New MySqlCommand(query, conn)
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
        End Using

        conn.Close()

        MessageBox.Show("Data karyawan berhasil disimpan")
        KondisiAwal()
        TampilData()
    End Sub

    ' ================= HAPUS =================
    Private Sub btnHapus_Click(sender As Object, e As EventArgs) Handles btnHapus.Click

        If txtId.Text = "" Then Exit Sub

        If MessageBox.Show("Yakin hapus data ini?", "Konfirmasi",
                           MessageBoxButtons.YesNo) = DialogResult.No Then Exit Sub

        Call OpenConn()
        Dim cmd As New MySqlCommand(
            "DELETE FROM karyawan WHERE id_karyawan=@id", conn)
        cmd.Parameters.AddWithValue("@id", txtId.Text)
        cmd.ExecuteNonQuery()
        conn.Close()

        MessageBox.Show("Data berhasil dihapus")
        KondisiAwal()
        TampilData()
    End Sub

    ' ================= GRID CLICK =================
    Private Sub dgvKaryawan_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvKaryawan.CellClick
        If e.RowIndex < 0 Then Exit Sub

        Dim r = dgvKaryawan.Rows(e.RowIndex)
        txtId.Text = r.Cells("id_karyawan").Value.ToString()
        txtNik.Text = r.Cells("nik").Value.ToString()
        txtNama.Text = r.Cells("nama_karyawan").Value.ToString()
        cboJK.Text = r.Cells("jenis_kelamin").Value.ToString()
        txtJabatan.Text = r.Cells("jabatan").Value.ToString()
        txtDivisi.Text = r.Cells("divisi").Value.ToString()
        dtpMasuk.Value = CDate(r.Cells("tanggal_masuk").Value)
        cboStatus.Text = r.Cells("status_karyawan").Value.ToString()
        txtHP.Text = r.Cells("no_hp").Value.ToString()
        txtAlamat.Text = r.Cells("alamat").Value.ToString()

        If RoleUser = "HR" Then btnHapus.Enabled = True
    End Sub

    ' ================= CLEAR =================
    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        KondisiAwal()
    End Sub

    ' ================= MENU =================
    Private Sub btnMenu_Click(sender As Object, e As EventArgs) Handles btnMenu.Click
        FormMenu.Show()
        Me.Close()
    End Sub

End Class
