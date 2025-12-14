Public Class Form2
    Private Sub DataKaryawanToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DataKaryawanToolStripMenuItem.Click
        Form3.Show()
        Me.Hide()
    End Sub

    Private Sub DataKriteriaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DataKriteriaToolStripMenuItem.Click
        Form4.Show()
        Me.Hide()
    End Sub

    Private Sub NilaiKaryawanToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NilaiKaryawanToolStripMenuItem.Click
        Form5.Show()
        Me.Hide()
    End Sub

    Private Sub RrankingToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RrankingToolStripMenuItem.Click
        Form6.Show()
        Me.Hide()
    End Sub
End Class