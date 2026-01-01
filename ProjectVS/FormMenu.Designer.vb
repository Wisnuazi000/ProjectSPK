<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormMenu
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
        Me.NilaiKaryawanToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnSuperAdvisor = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnAdminHR = New System.Windows.Forms.ToolStripMenuItem()
        Me.RankingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LogoutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.lblUser = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DataKaryawanToolStripMenuItem, Me.NilaiKaryawanToolStripMenuItem, Me.RankingToolStripMenuItem, Me.ReportToolStripMenuItem, Me.lblUser, Me.LogoutToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(783, 28)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'DataKaryawanToolStripMenuItem
        '
        Me.DataKaryawanToolStripMenuItem.Name = "DataKaryawanToolStripMenuItem"
        Me.DataKaryawanToolStripMenuItem.Size = New System.Drawing.Size(123, 24)
        Me.DataKaryawanToolStripMenuItem.Text = "Data Karyawan"
        '
        'NilaiKaryawanToolStripMenuItem
        '
        Me.NilaiKaryawanToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnSuperAdvisor, Me.mnAdminHR})
        Me.NilaiKaryawanToolStripMenuItem.Name = "NilaiKaryawanToolStripMenuItem"
        Me.NilaiKaryawanToolStripMenuItem.Size = New System.Drawing.Size(122, 24)
        Me.NilaiKaryawanToolStripMenuItem.Text = "Nilai Karyawan"
        '
        'mnSuperAdvisor
        '
        Me.mnSuperAdvisor.Name = "mnSuperAdvisor"
        Me.mnSuperAdvisor.Size = New System.Drawing.Size(180, 26)
        Me.mnSuperAdvisor.Text = "SuperAdvisor"
        '
        'mnAdminHR
        '
        Me.mnAdminHR.Name = "mnAdminHR"
        Me.mnAdminHR.Size = New System.Drawing.Size(180, 26)
        Me.mnAdminHR.Text = "Admin HR"
        '
        'RankingToolStripMenuItem
        '
        Me.RankingToolStripMenuItem.Name = "RankingToolStripMenuItem"
        Me.RankingToolStripMenuItem.Size = New System.Drawing.Size(76, 24)
        Me.RankingToolStripMenuItem.Text = "Ranking"
        '
        'ReportToolStripMenuItem
        '
        Me.ReportToolStripMenuItem.Name = "ReportToolStripMenuItem"
        Me.ReportToolStripMenuItem.Size = New System.Drawing.Size(68, 24)
        Me.ReportToolStripMenuItem.Text = "Report"
        '
        'LogoutToolStripMenuItem
        '
        Me.LogoutToolStripMenuItem.Name = "LogoutToolStripMenuItem"
        Me.LogoutToolStripMenuItem.Size = New System.Drawing.Size(70, 24)
        Me.LogoutToolStripMenuItem.Text = "Logout"
        '
        'lblUser
        '
        Me.lblUser.Name = "lblUser"
        Me.lblUser.Size = New System.Drawing.Size(50, 24)
        Me.lblUser.Text = "user"
        '
        'FormMenu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.ProjectVS.My.Resources.Resources.pexels_binyaminmellish_106399
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(783, 554)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "FormMenu"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Menu Data Master"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents DataKaryawanToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents NilaiKaryawanToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RankingToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents mnAdminHR As ToolStripMenuItem
    Friend WithEvents mnSuperAdvisor As ToolStripMenuItem
    Friend WithEvents ReportToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents LogoutToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents lblUser As ToolStripMenuItem
End Class
