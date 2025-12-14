<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form4
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
        Me.txtId = New System.Windows.Forms.TextBox()
        Me.txtKode = New System.Windows.Forms.TextBox()
        Me.txtNama = New System.Windows.Forms.TextBox()
        Me.txtBobot = New System.Windows.Forms.TextBox()
        Me.cboTipe = New System.Windows.Forms.ComboBox()
        Me.dgvKriteria = New System.Windows.Forms.DataGridView()
        Me.label11 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnMenu = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnHapus = New System.Windows.Forms.Button()
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.btnSimpan = New System.Windows.Forms.Button()
        CType(Me.dgvKriteria, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtId
        '
        Me.txtId.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtId.Enabled = False
        Me.txtId.Location = New System.Drawing.Point(135, 33)
        Me.txtId.Multiline = True
        Me.txtId.Name = "txtId"
        Me.txtId.ReadOnly = True
        Me.txtId.Size = New System.Drawing.Size(10, 21)
        Me.txtId.TabIndex = 25
        '
        'txtKode
        '
        Me.txtKode.Location = New System.Drawing.Point(135, 81)
        Me.txtKode.Name = "txtKode"
        Me.txtKode.Size = New System.Drawing.Size(188, 22)
        Me.txtKode.TabIndex = 26
        '
        'txtNama
        '
        Me.txtNama.Location = New System.Drawing.Point(135, 134)
        Me.txtNama.Name = "txtNama"
        Me.txtNama.Size = New System.Drawing.Size(188, 22)
        Me.txtNama.TabIndex = 27
        '
        'txtBobot
        '
        Me.txtBobot.Location = New System.Drawing.Point(135, 190)
        Me.txtBobot.Name = "txtBobot"
        Me.txtBobot.Size = New System.Drawing.Size(188, 22)
        Me.txtBobot.TabIndex = 28
        '
        'cboTipe
        '
        Me.cboTipe.FormattingEnabled = True
        Me.cboTipe.Items.AddRange(New Object() {"Benefit", "Cost"})
        Me.cboTipe.Location = New System.Drawing.Point(135, 244)
        Me.cboTipe.Name = "cboTipe"
        Me.cboTipe.Size = New System.Drawing.Size(188, 24)
        Me.cboTipe.TabIndex = 30
        '
        'dgvKriteria
        '
        Me.dgvKriteria.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvKriteria.Location = New System.Drawing.Point(43, 369)
        Me.dgvKriteria.Name = "dgvKriteria"
        Me.dgvKriteria.RowHeadersWidth = 51
        Me.dgvKriteria.RowTemplate.Height = 24
        Me.dgvKriteria.Size = New System.Drawing.Size(725, 150)
        Me.dgvKriteria.TabIndex = 31
        '
        'label11
        '
        Me.label11.AutoSize = True
        Me.label11.Location = New System.Drawing.Point(41, 33)
        Me.label11.Name = "label11"
        Me.label11.Size = New System.Drawing.Size(20, 16)
        Me.label11.TabIndex = 32
        Me.label11.Text = "ID"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(41, 84)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 16)
        Me.Label1.TabIndex = 33
        Me.Label1.Text = "Kode"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(41, 137)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 16)
        Me.Label2.TabIndex = 34
        Me.Label2.Text = "Nama"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(41, 193)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(43, 16)
        Me.Label3.TabIndex = 35
        Me.Label3.Text = "Bobot"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(41, 247)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(35, 16)
        Me.Label4.TabIndex = 36
        Me.Label4.Text = "Tipe"
        '
        'btnMenu
        '
        Me.btnMenu.Location = New System.Drawing.Point(693, 296)
        Me.btnMenu.Name = "btnMenu"
        Me.btnMenu.Size = New System.Drawing.Size(75, 40)
        Me.btnMenu.TabIndex = 41
        Me.btnMenu.Text = "Menu"
        Me.btnMenu.UseVisualStyleBackColor = True
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(536, 296)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(75, 40)
        Me.btnClear.TabIndex = 40
        Me.btnClear.Text = "Clear"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'btnHapus
        '
        Me.btnHapus.Location = New System.Drawing.Point(367, 296)
        Me.btnHapus.Name = "btnHapus"
        Me.btnHapus.Size = New System.Drawing.Size(75, 40)
        Me.btnHapus.TabIndex = 39
        Me.btnHapus.Text = "Hapus"
        Me.btnHapus.UseVisualStyleBackColor = True
        '
        'btnEdit
        '
        Me.btnEdit.Location = New System.Drawing.Point(204, 296)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(75, 40)
        Me.btnEdit.TabIndex = 38
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.UseVisualStyleBackColor = True
        '
        'btnSimpan
        '
        Me.btnSimpan.Location = New System.Drawing.Point(43, 296)
        Me.btnSimpan.Name = "btnSimpan"
        Me.btnSimpan.Size = New System.Drawing.Size(75, 40)
        Me.btnSimpan.TabIndex = 37
        Me.btnSimpan.Text = "Simpan"
        Me.btnSimpan.UseVisualStyleBackColor = True
        '
        'Form4
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 559)
        Me.Controls.Add(Me.btnMenu)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.btnHapus)
        Me.Controls.Add(Me.btnEdit)
        Me.Controls.Add(Me.btnSimpan)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.label11)
        Me.Controls.Add(Me.dgvKriteria)
        Me.Controls.Add(Me.cboTipe)
        Me.Controls.Add(Me.txtBobot)
        Me.Controls.Add(Me.txtNama)
        Me.Controls.Add(Me.txtKode)
        Me.Controls.Add(Me.txtId)
        Me.Name = "Form4"
        Me.Text = "Form Data Kriteria"
        CType(Me.dgvKriteria, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtId As TextBox
    Friend WithEvents txtKode As TextBox
    Friend WithEvents txtNama As TextBox
    Friend WithEvents txtBobot As TextBox
    Friend WithEvents cboTipe As ComboBox
    Friend WithEvents dgvKriteria As DataGridView
    Friend WithEvents label11 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents btnMenu As Button
    Friend WithEvents btnClear As Button
    Friend WithEvents btnHapus As Button
    Friend WithEvents btnEdit As Button
    Friend WithEvents btnSimpan As Button
End Class
