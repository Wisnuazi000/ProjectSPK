<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form2
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.DataKaryawanToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DataKriteriaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NilaiKaryawanToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RrankingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DataKaryawanToolStripMenuItem, Me.DataKriteriaToolStripMenuItem, Me.NilaiKaryawanToolStripMenuItem, Me.RrankingToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(800, 28)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'DataKaryawanToolStripMenuItem
        '
        Me.DataKaryawanToolStripMenuItem.Name = "DataKaryawanToolStripMenuItem"
        Me.DataKaryawanToolStripMenuItem.Size = New System.Drawing.Size(123, 24)
        Me.DataKaryawanToolStripMenuItem.Text = "Data Karyawan"
        '
        'DataKriteriaToolStripMenuItem
        '
        Me.DataKriteriaToolStripMenuItem.Name = "DataKriteriaToolStripMenuItem"
        Me.DataKriteriaToolStripMenuItem.Size = New System.Drawing.Size(107, 24)
        Me.DataKriteriaToolStripMenuItem.Text = "Data Kriteria"
        '
        'NilaiKaryawanToolStripMenuItem
        '
        Me.NilaiKaryawanToolStripMenuItem.Name = "NilaiKaryawanToolStripMenuItem"
        Me.NilaiKaryawanToolStripMenuItem.Size = New System.Drawing.Size(122, 24)
        Me.NilaiKaryawanToolStripMenuItem.Text = "Nilai Karyawan"
        '
        'RrankingToolStripMenuItem
        '
        Me.RrankingToolStripMenuItem.Name = "RrankingToolStripMenuItem"
        Me.RrankingToolStripMenuItem.Size = New System.Drawing.Size(81, 24)
        Me.RrankingToolStripMenuItem.Text = "Rranking"
        '
        'Form2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Form2"
        Me.Text = "Menu Data Master"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents DataKaryawanToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DataKriteriaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents NilaiKaryawanToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RrankingToolStripMenuItem As ToolStripMenuItem
End Class
