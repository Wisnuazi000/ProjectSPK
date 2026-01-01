<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormHasil
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.pnlMain = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnHapus = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnMenu = New System.Windows.Forms.Button()
        Me.grpHasil = New System.Windows.Forms.GroupBox()
        Me.dgvHasil = New System.Windows.Forms.DataGridView()
        Me.grpMatriks = New System.Windows.Forms.GroupBox()
        Me.dgvAwal = New System.Windows.Forms.DataGridView()
        Me.grpNormalisasi = New System.Windows.Forms.GroupBox()
        Me.dgvNormalisasi = New System.Windows.Forms.DataGridView()
        Me.grpKriteria = New System.Windows.Forms.GroupBox()
        Me.dgvKriteria = New System.Windows.Forms.DataGridView()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.pnlMain.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.grpHasil.SuspendLayout()
        CType(Me.dgvHasil, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpMatriks.SuspendLayout()
        CType(Me.dgvAwal, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpNormalisasi.SuspendLayout()
        CType(Me.dgvNormalisasi, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpKriteria.SuspendLayout()
        CType(Me.dgvKriteria, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlMain
        '
        Me.pnlMain.AutoScroll = True
        Me.pnlMain.BackColor = System.Drawing.Color.Transparent
        Me.pnlMain.Controls.Add(Me.Panel1)
        Me.pnlMain.Controls.Add(Me.grpHasil)
        Me.pnlMain.Controls.Add(Me.grpMatriks)
        Me.pnlMain.Controls.Add(Me.grpNormalisasi)
        Me.pnlMain.Controls.Add(Me.grpKriteria)
        Me.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlMain.Location = New System.Drawing.Point(0, 0)
        Me.pnlMain.Name = "pnlMain"
        Me.pnlMain.Size = New System.Drawing.Size(1473, 739)
        Me.pnlMain.TabIndex = 52
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnHapus)
        Me.Panel1.Controls.Add(Me.btnClear)
        Me.Panel1.Controls.Add(Me.btnMenu)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 670)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1473, 69)
        Me.Panel1.TabIndex = 56
        '
        'btnHapus
        '
        Me.btnHapus.Location = New System.Drawing.Point(1028, 17)
        Me.btnHapus.Name = "btnHapus"
        Me.btnHapus.Size = New System.Drawing.Size(171, 40)
        Me.btnHapus.TabIndex = 63
        Me.btnHapus.Text = "Hapus Penilaian terpilih"
        Me.btnHapus.UseVisualStyleBackColor = True
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(1214, 17)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(121, 40)
        Me.btnClear.TabIndex = 62
        Me.btnClear.Text = "Clear Penilaian"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'btnMenu
        '
        Me.btnMenu.Location = New System.Drawing.Point(1358, 17)
        Me.btnMenu.Name = "btnMenu"
        Me.btnMenu.Size = New System.Drawing.Size(75, 40)
        Me.btnMenu.TabIndex = 61
        Me.btnMenu.Text = "Menu"
        Me.btnMenu.UseVisualStyleBackColor = True
        '
        'grpHasil
        '
        Me.grpHasil.Controls.Add(Me.dgvHasil)
        Me.grpHasil.Location = New System.Drawing.Point(745, 343)
        Me.grpHasil.Name = "grpHasil"
        Me.grpHasil.Size = New System.Drawing.Size(688, 321)
        Me.grpHasil.TabIndex = 55
        Me.grpHasil.TabStop = False
        Me.grpHasil.Text = "Hasil Akhir dan Ranking"
        '
        'dgvHasil
        '
        Me.dgvHasil.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvHasil.Location = New System.Drawing.Point(28, 33)
        Me.dgvHasil.Name = "dgvHasil"
        Me.dgvHasil.RowHeadersWidth = 51
        Me.dgvHasil.RowTemplate.Height = 24
        Me.dgvHasil.Size = New System.Drawing.Size(632, 282)
        Me.dgvHasil.TabIndex = 0
        '
        'grpMatriks
        '
        Me.grpMatriks.Controls.Add(Me.dgvAwal)
        Me.grpMatriks.Location = New System.Drawing.Point(745, 52)
        Me.grpMatriks.Name = "grpMatriks"
        Me.grpMatriks.Size = New System.Drawing.Size(688, 270)
        Me.grpMatriks.TabIndex = 53
        Me.grpMatriks.TabStop = False
        Me.grpMatriks.Text = "Matriks Keputusan (Nilai Rata-rata Sub Kriteria)"
        '
        'dgvAwal
        '
        Me.dgvAwal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvAwal.Location = New System.Drawing.Point(28, 32)
        Me.dgvAwal.Name = "dgvAwal"
        Me.dgvAwal.RowHeadersWidth = 51
        Me.dgvAwal.RowTemplate.Height = 24
        Me.dgvAwal.Size = New System.Drawing.Size(632, 232)
        Me.dgvAwal.TabIndex = 0
        '
        'grpNormalisasi
        '
        Me.grpNormalisasi.Controls.Add(Me.dgvNormalisasi)
        Me.grpNormalisasi.Location = New System.Drawing.Point(24, 343)
        Me.grpNormalisasi.Name = "grpNormalisasi"
        Me.grpNormalisasi.Size = New System.Drawing.Size(688, 321)
        Me.grpNormalisasi.TabIndex = 54
        Me.grpNormalisasi.TabStop = False
        Me.grpNormalisasi.Text = "Matriks Normalisasi"
        '
        'dgvNormalisasi
        '
        Me.dgvNormalisasi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvNormalisasi.Location = New System.Drawing.Point(28, 32)
        Me.dgvNormalisasi.Name = "dgvNormalisasi"
        Me.dgvNormalisasi.RowHeadersWidth = 51
        Me.dgvNormalisasi.RowTemplate.Height = 24
        Me.dgvNormalisasi.Size = New System.Drawing.Size(632, 283)
        Me.dgvNormalisasi.TabIndex = 0
        '
        'grpKriteria
        '
        Me.grpKriteria.Controls.Add(Me.dgvKriteria)
        Me.grpKriteria.Location = New System.Drawing.Point(24, 52)
        Me.grpKriteria.Name = "grpKriteria"
        Me.grpKriteria.Size = New System.Drawing.Size(688, 270)
        Me.grpKriteria.TabIndex = 52
        Me.grpKriteria.TabStop = False
        Me.grpKriteria.Text = "Data Kriteria dan Bobot"
        '
        'dgvKriteria
        '
        Me.dgvKriteria.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvKriteria.Location = New System.Drawing.Point(28, 32)
        Me.dgvKriteria.Name = "dgvKriteria"
        Me.dgvKriteria.RowHeadersWidth = 51
        Me.dgvKriteria.RowTemplate.Height = 24
        Me.dgvKriteria.Size = New System.Drawing.Size(632, 232)
        Me.dgvKriteria.TabIndex = 0
        '
        'FormHasil
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1473, 739)
        Me.Controls.Add(Me.pnlMain)
        Me.Name = "FormHasil"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form Data Hasil"
        Me.pnlMain.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.grpHasil.ResumeLayout(False)
        CType(Me.dgvHasil, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpMatriks.ResumeLayout(False)
        CType(Me.dgvAwal, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpNormalisasi.ResumeLayout(False)
        CType(Me.dgvNormalisasi, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpKriteria.ResumeLayout(False)
        CType(Me.dgvKriteria, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlMain As Panel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents btnMenu As Button
    Friend WithEvents grpHasil As GroupBox
    Friend WithEvents dgvHasil As DataGridView
    Friend WithEvents grpMatriks As GroupBox
    Friend WithEvents dgvAwal As DataGridView
    Friend WithEvents grpNormalisasi As GroupBox
    Friend WithEvents dgvNormalisasi As DataGridView
    Friend WithEvents grpKriteria As GroupBox
    Friend WithEvents dgvKriteria As DataGridView
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents btnClear As Button
    Friend WithEvents btnHapus As Button
End Class
