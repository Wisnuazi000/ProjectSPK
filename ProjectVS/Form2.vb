Public Class Form2
    Private Sub DataKaryawanToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DataKaryawanToolStripMenuItem.Click
        Form3.Show()
        Me.Hide()
    End Sub

    Private Sub DataKriteriaToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Form4.Show()
        Me.Hide()
    End Sub

    Private Sub NilaiKaryawanToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NilaiKaryawanToolStripMenuItem.Click

    End Sub

    Private Sub RrankingToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RrankingToolStripMenuItem.Click
        Form6.Show()
        Me.Hide()
    End Sub

    Private Sub AdminHRToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles mnAdminHR.Click
        RoleUser = "HR"
        Form5.Show()
        Me.Hide()
    End Sub

    Private Sub mnSuperAdvisor_Click(sender As Object, e As EventArgs) Handles mnSuperAdvisor.Click
        RoleUser = "SUPERADVISOR"
        Form5.Show()
        Me.Hide()
    End Sub
End Class