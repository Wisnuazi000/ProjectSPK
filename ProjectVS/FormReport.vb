Imports MySql.Data.MySqlClient

Public Class FormReport
    Private Sub FormReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' === ROLE CHECK ===
        If RoleUser <> "MANAGER" Then
            MessageBox.Show("Form ini hanya dapat diakses oleh Manager", "Akses Ditolak",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.Close()
            Exit Sub
        End If

        SetupDGV()
        LoadHasil()
        StyleButton()
    End Sub
    Sub SetupDGV()
        dgvHasil.Columns.Clear()
        dgvHasil.AllowUserToAddRows = False
        dgvHasil.ReadOnly = True
        dgvHasil.SelectionMode = DataGridViewSelectionMode.FullRowSelect

        dgvHasil.Columns.Add("nama", "Nama Karyawan")
        dgvHasil.Columns.Add("nilai", "Nilai Akhir")
        dgvHasil.Columns.Add("rank", "Ranking")
        dgvHasil.Columns.Add("rek", "Rekomendasi")
        dgvHasil.Columns.Add("status", "Status Approval")
    End Sub

    ' ================= LOAD HASIL =================
    Sub LoadHasil()
        dgvHasil.Rows.Clear()

        Dim sql As String = "
        SELECT k.nama_karyawan, h.nilai_akhir, h.ranking,
               h.rekomendasi, h.status_approval
        FROM hasil h
        JOIN karyawan k ON h.id_karyawan = k.id_karyawan
        ORDER BY h.ranking ASC"

        Using da As New MySqlDataAdapter(sql, conn)
            Dim dt As New DataTable
            da.Fill(dt)

            For Each r As DataRow In dt.Rows
                dgvHasil.Rows.Add(
                    r("nama_karyawan"),
                    Math.Round(CDbl(r("nilai_akhir")), 0),
                    r("ranking"),
                    r("rekomendasi"),
                    r("status_approval")
                )
            Next
        End Using

        WarnaiRow()
    End Sub

    ' ================= WARNA ROW =================
    Sub WarnaiRow()
        For Each row As DataGridViewRow In dgvHasil.Rows
            Dim status As String = row.Cells("status").Value.ToString()

            Select Case status
                Case "Approved"
                    row.DefaultCellStyle.BackColor = Color.PaleGreen
                Case "Rejected"
                    row.DefaultCellStyle.BackColor = Color.MistyRose
                Case Else
                    row.DefaultCellStyle.BackColor = Color.White
            End Select

            ' Highlight Rank 1
            If CInt(row.Cells("rank").Value) = 1 Then
                row.DefaultCellStyle.Font =
                    New Font("Segoe UI", 9, FontStyle.Bold)
            End If
        Next
    End Sub

    ' ================= STYLE BUTTON =================
    Sub StyleButton()
        btnApprove.BackColor = Color.FromArgb(46, 204, 113)
        btnApprove.ForeColor = Color.White

        btnExport.BackColor = Color.FromArgb(52, 152, 219)
        btnExport.ForeColor = Color.Black

        btnReject.BackColor = Color.FromArgb(231, 76, 60)
        btnReject.ForeColor = Color.White

        btnMenu.BackColor = Color.Gainsboro
        btnMenu.ForeColor = Color.White
    End Sub

    ' ================= APPROVE PERIODE =================
    Private Sub btnApprove_Click(sender As Object, e As EventArgs) Handles btnApprove.Click

        If MessageBox.Show("Approve hasil penilaian periode ini?",
                           "Konfirmasi", MessageBoxButtons.YesNo,
                           MessageBoxIcon.Question) = DialogResult.No Then Exit Sub

        Call OpenConn()

        Dim cmd As New MySqlCommand("
        UPDATE hasil SET
        status_approval='Approved',
        catatan_manager=@catatan,
        approved_at=NOW()", conn)

        cmd.Parameters.AddWithValue("@catatan", txtCatatan.Text)
        cmd.ExecuteNonQuery()

        conn.Close()

        MessageBox.Show("Hasil periode berhasil di-APPROVE", "Informasi")
        LoadHasil()
    End Sub

    ' ================= REJECT PERIODE =================
    Private Sub btnReject_Click(sender As Object, e As EventArgs) Handles btnReject.Click

        If txtCatatan.Text.Trim = "" Then
            MessageBox.Show("Catatan wajib diisi untuk Reject",
                            "Validasi", MessageBoxButtons.OK,
                            MessageBoxIcon.Warning)
            Exit Sub
        End If

        Call OpenConn()

        Dim cmd As New MySqlCommand("
        UPDATE hasil SET
        status_approval='Rejected',
        catatan_manager=@catatan,
        approved_at=NOW()", conn)

        cmd.Parameters.AddWithValue("@catatan", txtCatatan.Text)
        cmd.ExecuteNonQuery()

        conn.Close()

        MessageBox.Show("Hasil periode berhasil di-REJECT", "Informasi")
        LoadHasil()
    End Sub

    ' ================= MENU =================
    Private Sub btnMenu_Click(sender As Object, e As EventArgs) Handles btnMenu.Click
        FormMenu.Show()
        Me.Close()
    End Sub
End Class