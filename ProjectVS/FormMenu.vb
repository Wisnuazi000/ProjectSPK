Public Class FormMenu
    Private Sub DataKaryawanToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DataKaryawanToolStripMenuItem.Click
        FormDataKaryawan.Show()
        Me.Hide()
    End Sub

    Private Sub DataKriteriaToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Form4.Show()
        Me.Hide()
    End Sub

    Private Sub NilaiKaryawanToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NilaiKaryawanToolStripMenuItem.Click

    End Sub

    Private Sub RankingToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RankingToolStripMenuItem.Click
        If RoleUser <> "HR" Then
            MessageBox.Show("Menu Ranking hanya untuk HR")
            Exit Sub
        End If

        FormHasil.Show()
        Me.Hide()
    End Sub

    Private Sub AdminHRToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles mnAdminHR.Click
        If RoleUser <> "HR" Then
            MessageBox.Show(
            "Akses ditolak." & vbCrLf &
            "Menu ini hanya untuk Admin HR.",
            "Hak Akses",
            MessageBoxButtons.OK,
            MessageBoxIcon.Warning)
            Exit Sub
        End If

        FormPenilaian.Show()
        Me.Hide()
    End Sub

    Private Sub mnSuperAdvisor_Click(sender As Object, e As EventArgs) Handles mnSuperAdvisor.Click
        If RoleUser <> "SUPERADVISOR" Then
            MessageBox.Show(
            "Akses ditolak." & vbCrLf &
            "Menu ini hanya untuk SuperAdvisor.",
            "Hak Akses",
            MessageBoxButtons.OK,
            MessageBoxIcon.Warning)
            Exit Sub
        End If

        FormPenilaian.Show()
        Me.Hide()
    End Sub

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblUser.Text = $"Login sebagai: {Username} ({RoleUser})"

    End Sub

    Private Sub ReportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReportToolStripMenuItem.Click
        If RoleUser <> "MANAGER" Then
            MessageBox.Show("Menu Report hanya untuk Manager")
            Exit Sub
        End If

        FormReport.Show()
        Me.Hide()
    End Sub

    Private Sub LogoutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LogoutToolStripMenuItem.Click
        If MessageBox.Show(
        "Apakah Anda yakin ingin logout?",
        "Konfirmasi Logout",
        MessageBoxButtons.YesNo,
        MessageBoxIcon.Question) = DialogResult.Yes Then

            ' === RESET SESSION USER ===
            UserID = 0
            Username = ""
            RoleUser = ""

            ' === KEMBALI KE LOGIN ===
            FormLogin.Show()

            ' Tutup menu
            Me.Close()
        End If
    End Sub
End Class