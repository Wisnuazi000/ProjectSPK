<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form6
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
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.grpHasil = New System.Windows.Forms.GroupBox()
        Me.dgvHasil = New System.Windows.Forms.DataGridView()
        Me.btnMenu = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnProses = New System.Windows.Forms.Button()
        Me.btnSimpan = New System.Windows.Forms.Button()
        Me.dgvAwal = New System.Windows.Forms.DataGridView()
        Me.grpMatriks = New System.Windows.Forms.GroupBox()
        Me.dgvNormalisasi = New System.Windows.Forms.DataGridView()
        Me.grpNormalisasi = New System.Windows.Forms.GroupBox()
        Me.dgvKriteria = New System.Windows.Forms.DataGridView()
        Me.grpKriteria = New System.Windows.Forms.GroupBox()
        Me.grpHasil.SuspendLayout()
        CType(Me.dgvHasil, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvAwal, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpMatriks.SuspendLayout()
        CType(Me.dgvNormalisasi, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpNormalisasi.SuspendLayout()
        CType(Me.dgvKriteria, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpKriteria.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpHasil
        '
        Me.grpHasil.Controls.Add(Me.dgvHasil)
        Me.grpHasil.Location = New System.Drawing.Point(48, 697)
        Me.grpHasil.Name = "grpHasil"
        Me.grpHasil.Size = New System.Drawing.Size(688, 261)
        Me.grpHasil.TabIndex = 3
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
        Me.dgvHasil.Size = New System.Drawing.Size(632, 193)
        Me.dgvHasil.TabIndex = 0
        '
        'btnMenu
        '
        Me.btnMenu.Location = New System.Drawing.Point(643, 964)
        Me.btnMenu.Name = "btnMenu"
        Me.btnMenu.Size = New System.Drawing.Size(75, 40)
        Me.btnMenu.TabIndex = 51
        Me.btnMenu.Text = "Menu"
        Me.btnMenu.UseVisualStyleBackColor = True
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(498, 964)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(75, 40)
        Me.btnClear.TabIndex = 50
        Me.btnClear.Text = "Clear"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'btnProses
        '
        Me.btnProses.Location = New System.Drawing.Point(62, 964)
        Me.btnProses.Name = "btnProses"
        Me.btnProses.Size = New System.Drawing.Size(75, 40)
        Me.btnProses.TabIndex = 48
        Me.btnProses.Text = "Proses SAW"
        Me.btnProses.UseVisualStyleBackColor = True
        '
        'btnSimpan
        '
        Me.btnSimpan.Location = New System.Drawing.Point(196, 964)
        Me.btnSimpan.Name = "btnSimpan"
        Me.btnSimpan.Size = New System.Drawing.Size(75, 40)
        Me.btnSimpan.TabIndex = 47
        Me.btnSimpan.Text = "Simpan"
        Me.btnSimpan.UseVisualStyleBackColor = True
        '
        'dgvAwal
        '
        Me.dgvAwal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvAwal.Location = New System.Drawing.Point(28, 32)
        Me.dgvAwal.Name = "dgvAwal"
        Me.dgvAwal.RowHeadersWidth = 51
        Me.dgvAwal.RowTemplate.Height = 24
        Me.dgvAwal.Size = New System.Drawing.Size(632, 170)
        Me.dgvAwal.TabIndex = 0
        '
        'grpMatriks
        '
        Me.grpMatriks.Controls.Add(Me.dgvAwal)
        Me.grpMatriks.Location = New System.Drawing.Point(48, 222)
        Me.grpMatriks.Name = "grpMatriks"
        Me.grpMatriks.Size = New System.Drawing.Size(688, 230)
        Me.grpMatriks.TabIndex = 1
        Me.grpMatriks.TabStop = False
        Me.grpMatriks.Text = "Matiks Keputusan ( Nilai Awal )"
        '
        'dgvNormalisasi
        '
        Me.dgvNormalisasi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvNormalisasi.Location = New System.Drawing.Point(28, 32)
        Me.dgvNormalisasi.Name = "dgvNormalisasi"
        Me.dgvNormalisasi.RowHeadersWidth = 51
        Me.dgvNormalisasi.RowTemplate.Height = 24
        Me.dgvNormalisasi.Size = New System.Drawing.Size(632, 162)
        Me.dgvNormalisasi.TabIndex = 0
        '
        'grpNormalisasi
        '
        Me.grpNormalisasi.Controls.Add(Me.dgvNormalisasi)
        Me.grpNormalisasi.Location = New System.Drawing.Point(48, 458)
        Me.grpNormalisasi.Name = "grpNormalisasi"
        Me.grpNormalisasi.Size = New System.Drawing.Size(688, 220)
        Me.grpNormalisasi.TabIndex = 2
        Me.grpNormalisasi.TabStop = False
        Me.grpNormalisasi.Text = "Matriks Normalisasi"
        '
        'dgvKriteria
        '
        Me.dgvKriteria.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvKriteria.Location = New System.Drawing.Point(28, 32)
        Me.dgvKriteria.Name = "dgvKriteria"
        Me.dgvKriteria.RowHeadersWidth = 51
        Me.dgvKriteria.RowTemplate.Height = 24
        Me.dgvKriteria.Size = New System.Drawing.Size(632, 137)
        Me.dgvKriteria.TabIndex = 0
        '
        'grpKriteria
        '
        Me.grpKriteria.Controls.Add(Me.dgvKriteria)
        Me.grpKriteria.Location = New System.Drawing.Point(48, 24)
        Me.grpKriteria.Name = "grpKriteria"
        Me.grpKriteria.Size = New System.Drawing.Size(688, 192)
        Me.grpKriteria.TabIndex = 0
        Me.grpKriteria.TabStop = False
        Me.grpKriteria.Text = "Data Kriteria dan Bobot"
        '
        'Form6
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 1038)
        Me.Controls.Add(Me.btnMenu)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.btnProses)
        Me.Controls.Add(Me.btnSimpan)
        Me.Controls.Add(Me.grpHasil)
        Me.Controls.Add(Me.grpNormalisasi)
        Me.Controls.Add(Me.grpMatriks)
        Me.Controls.Add(Me.grpKriteria)
        Me.Name = "Form6"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form6"
        Me.grpHasil.ResumeLayout(False)
        CType(Me.dgvHasil, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvAwal, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpMatriks.ResumeLayout(False)
        CType(Me.dgvNormalisasi, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpNormalisasi.ResumeLayout(False)
        CType(Me.dgvKriteria, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpKriteria.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents grpHasil As GroupBox
    Friend WithEvents dgvHasil As DataGridView
    Friend WithEvents btnMenu As Button
    Friend WithEvents btnClear As Button
    Friend WithEvents btnProses As Button
    Friend WithEvents btnSimpan As Button
    Friend WithEvents dgvAwal As DataGridView
    Friend WithEvents grpMatriks As GroupBox
    Friend WithEvents dgvNormalisasi As DataGridView
    Friend WithEvents grpNormalisasi As GroupBox
    Friend WithEvents dgvKriteria As DataGridView
    Friend WithEvents grpKriteria As GroupBox
End Class
