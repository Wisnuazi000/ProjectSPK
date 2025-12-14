<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form5
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.nudNilai = New System.Windows.Forms.NumericUpDown()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dgvNilai = New System.Windows.Forms.DataGridView()
        Me.cboKaryawan = New System.Windows.Forms.ComboBox()
        Me.cboKriteria = New System.Windows.Forms.ComboBox()
        Me.btnMenu = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnHapus = New System.Windows.Forms.Button()
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.btnSimpan = New System.Windows.Forms.Button()
        Me.label11 = New System.Windows.Forms.Label()
        Me.txtId = New System.Windows.Forms.TextBox()
        CType(Me.nudNilai, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvNilai, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(42, 91)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Karyawan"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(42, 140)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 16)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Kriteria"
        '
        'nudNilai
        '
        Me.nudNilai.Location = New System.Drawing.Point(164, 196)
        Me.nudNilai.Name = "nudNilai"
        Me.nudNilai.Size = New System.Drawing.Size(204, 22)
        Me.nudNilai.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(42, 198)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(34, 16)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Nilai"
        '
        'dgvNilai
        '
        Me.dgvNilai.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvNilai.Location = New System.Drawing.Point(43, 316)
        Me.dgvNilai.Name = "dgvNilai"
        Me.dgvNilai.RowHeadersWidth = 51
        Me.dgvNilai.RowTemplate.Height = 24
        Me.dgvNilai.Size = New System.Drawing.Size(681, 150)
        Me.dgvNilai.TabIndex = 4
        '
        'cboKaryawan
        '
        Me.cboKaryawan.FormattingEnabled = True
        Me.cboKaryawan.Location = New System.Drawing.Point(164, 88)
        Me.cboKaryawan.Name = "cboKaryawan"
        Me.cboKaryawan.Size = New System.Drawing.Size(204, 24)
        Me.cboKaryawan.TabIndex = 5
        '
        'cboKriteria
        '
        Me.cboKriteria.FormattingEnabled = True
        Me.cboKriteria.Location = New System.Drawing.Point(164, 137)
        Me.cboKriteria.Name = "cboKriteria"
        Me.cboKriteria.Size = New System.Drawing.Size(204, 24)
        Me.cboKriteria.TabIndex = 6
        '
        'btnMenu
        '
        Me.btnMenu.Location = New System.Drawing.Point(649, 251)
        Me.btnMenu.Name = "btnMenu"
        Me.btnMenu.Size = New System.Drawing.Size(75, 40)
        Me.btnMenu.TabIndex = 46
        Me.btnMenu.Text = "Menu"
        Me.btnMenu.UseVisualStyleBackColor = True
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(504, 251)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(75, 40)
        Me.btnClear.TabIndex = 45
        Me.btnClear.Text = "Clear"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'btnHapus
        '
        Me.btnHapus.Location = New System.Drawing.Point(352, 251)
        Me.btnHapus.Name = "btnHapus"
        Me.btnHapus.Size = New System.Drawing.Size(75, 40)
        Me.btnHapus.TabIndex = 44
        Me.btnHapus.Text = "Hapus"
        Me.btnHapus.UseVisualStyleBackColor = True
        '
        'btnEdit
        '
        Me.btnEdit.Location = New System.Drawing.Point(197, 251)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(75, 40)
        Me.btnEdit.TabIndex = 43
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.UseVisualStyleBackColor = True
        '
        'btnSimpan
        '
        Me.btnSimpan.Location = New System.Drawing.Point(45, 251)
        Me.btnSimpan.Name = "btnSimpan"
        Me.btnSimpan.Size = New System.Drawing.Size(75, 40)
        Me.btnSimpan.TabIndex = 42
        Me.btnSimpan.Text = "Simpan"
        Me.btnSimpan.UseVisualStyleBackColor = True
        '
        'label11
        '
        Me.label11.AutoSize = True
        Me.label11.Location = New System.Drawing.Point(42, 40)
        Me.label11.Name = "label11"
        Me.label11.Size = New System.Drawing.Size(20, 16)
        Me.label11.TabIndex = 48
        Me.label11.Text = "ID"
        '
        'txtId
        '
        Me.txtId.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtId.Enabled = False
        Me.txtId.Location = New System.Drawing.Point(164, 40)
        Me.txtId.Multiline = True
        Me.txtId.Name = "txtId"
        Me.txtId.ReadOnly = True
        Me.txtId.Size = New System.Drawing.Size(10, 21)
        Me.txtId.TabIndex = 47
        '
        'Form5
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(753, 501)
        Me.Controls.Add(Me.label11)
        Me.Controls.Add(Me.txtId)
        Me.Controls.Add(Me.btnMenu)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.btnHapus)
        Me.Controls.Add(Me.btnEdit)
        Me.Controls.Add(Me.btnSimpan)
        Me.Controls.Add(Me.cboKriteria)
        Me.Controls.Add(Me.cboKaryawan)
        Me.Controls.Add(Me.dgvNilai)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.nudNilai)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "Form5"
        Me.Text = "Form5"
        CType(Me.nudNilai, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvNilai, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents nudNilai As NumericUpDown
    Friend WithEvents Label3 As Label
    Friend WithEvents dgvNilai As DataGridView
    Friend WithEvents cboKaryawan As ComboBox
    Friend WithEvents cboKriteria As ComboBox
    Friend WithEvents btnMenu As Button
    Friend WithEvents btnClear As Button
    Friend WithEvents btnHapus As Button
    Friend WithEvents btnEdit As Button
    Friend WithEvents btnSimpan As Button
    Friend WithEvents label11 As Label
    Friend WithEvents txtId As TextBox
End Class
