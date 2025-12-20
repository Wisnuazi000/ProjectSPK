<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form3
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
        Me.txtNik = New System.Windows.Forms.TextBox()
        Me.txtNama = New System.Windows.Forms.TextBox()
        Me.txtJabatan = New System.Windows.Forms.TextBox()
        Me.txtDivisi = New System.Windows.Forms.TextBox()
        Me.txtHP = New System.Windows.Forms.TextBox()
        Me.cboJK = New System.Windows.Forms.ComboBox()
        Me.dtpMasuk = New System.Windows.Forms.DateTimePicker()
        Me.cboStatus = New System.Windows.Forms.ComboBox()
        Me.btnSimpan = New System.Windows.Forms.Button()
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.btnHapus = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.label11 = New System.Windows.Forms.Label()
        Me.label12 = New System.Windows.Forms.Label()
        Me.label13 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtAlamat = New System.Windows.Forms.TextBox()
        Me.dgvKaryawan = New System.Windows.Forms.DataGridView()
        Me.txtId = New System.Windows.Forms.TextBox()
        Me.btnMenu = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        CType(Me.dgvKaryawan, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtNik
        '
        Me.txtNik.Location = New System.Drawing.Point(171, 72)
        Me.txtNik.Name = "txtNik"
        Me.txtNik.Size = New System.Drawing.Size(188, 22)
        Me.txtNik.TabIndex = 0
        '
        'txtNama
        '
        Me.txtNama.Location = New System.Drawing.Point(171, 116)
        Me.txtNama.Name = "txtNama"
        Me.txtNama.Size = New System.Drawing.Size(188, 22)
        Me.txtNama.TabIndex = 1
        '
        'txtJabatan
        '
        Me.txtJabatan.Location = New System.Drawing.Point(171, 206)
        Me.txtJabatan.Name = "txtJabatan"
        Me.txtJabatan.Size = New System.Drawing.Size(188, 22)
        Me.txtJabatan.TabIndex = 3
        '
        'txtDivisi
        '
        Me.txtDivisi.Location = New System.Drawing.Point(171, 250)
        Me.txtDivisi.Name = "txtDivisi"
        Me.txtDivisi.Size = New System.Drawing.Size(188, 22)
        Me.txtDivisi.TabIndex = 4
        '
        'txtHP
        '
        Me.txtHP.Location = New System.Drawing.Point(565, 162)
        Me.txtHP.Name = "txtHP"
        Me.txtHP.Size = New System.Drawing.Size(200, 22)
        Me.txtHP.TabIndex = 5
        '
        'cboJK
        '
        Me.cboJK.FormattingEnabled = True
        Me.cboJK.Items.AddRange(New Object() {"Laki-Laki", "Perempuan"})
        Me.cboJK.Location = New System.Drawing.Point(171, 160)
        Me.cboJK.Name = "cboJK"
        Me.cboJK.Size = New System.Drawing.Size(188, 24)
        Me.cboJK.TabIndex = 6
        '
        'dtpMasuk
        '
        Me.dtpMasuk.Location = New System.Drawing.Point(565, 72)
        Me.dtpMasuk.Name = "dtpMasuk"
        Me.dtpMasuk.Size = New System.Drawing.Size(200, 22)
        Me.dtpMasuk.TabIndex = 7
        '
        'cboStatus
        '
        Me.cboStatus.FormattingEnabled = True
        Me.cboStatus.Items.AddRange(New Object() {"Laki-Laki", "Perempuan"})
        Me.cboStatus.Location = New System.Drawing.Point(565, 116)
        Me.cboStatus.Name = "cboStatus"
        Me.cboStatus.Size = New System.Drawing.Size(200, 24)
        Me.cboStatus.TabIndex = 8
        '
        'btnSimpan
        '
        Me.btnSimpan.Location = New System.Drawing.Point(33, 314)
        Me.btnSimpan.Name = "btnSimpan"
        Me.btnSimpan.Size = New System.Drawing.Size(75, 40)
        Me.btnSimpan.TabIndex = 9
        Me.btnSimpan.Text = "Simpan"
        Me.btnSimpan.UseVisualStyleBackColor = True
        '
        'btnEdit
        '
        Me.btnEdit.Location = New System.Drawing.Point(195, 314)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(75, 40)
        Me.btnEdit.TabIndex = 10
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.UseVisualStyleBackColor = True
        '
        'btnHapus
        '
        Me.btnHapus.Location = New System.Drawing.Point(358, 314)
        Me.btnHapus.Name = "btnHapus"
        Me.btnHapus.Size = New System.Drawing.Size(75, 40)
        Me.btnHapus.TabIndex = 11
        Me.btnHapus.Text = "Hapus"
        Me.btnHapus.UseVisualStyleBackColor = True
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(527, 314)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(75, 40)
        Me.btnClear.TabIndex = 12
        Me.btnClear.Text = "Clear"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'label11
        '
        Me.label11.AutoSize = True
        Me.label11.Location = New System.Drawing.Point(36, 75)
        Me.label11.Name = "label11"
        Me.label11.Size = New System.Drawing.Size(28, 16)
        Me.label11.TabIndex = 13
        Me.label11.Text = "NIK"
        '
        'label12
        '
        Me.label12.AutoSize = True
        Me.label12.Location = New System.Drawing.Point(36, 119)
        Me.label12.Name = "label12"
        Me.label12.Size = New System.Drawing.Size(106, 16)
        Me.label12.TabIndex = 14
        Me.label12.Text = "Nama Karyawan"
        '
        'label13
        '
        Me.label13.AutoSize = True
        Me.label13.Location = New System.Drawing.Point(36, 165)
        Me.label13.Name = "label13"
        Me.label13.Size = New System.Drawing.Size(90, 16)
        Me.label13.TabIndex = 15
        Me.label13.Text = "Jenis Kelamin"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(36, 209)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 16)
        Me.Label2.TabIndex = 16
        Me.Label2.Text = "Jabatan"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(36, 253)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 16)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "Divisi"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(430, 75)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(101, 16)
        Me.Label3.TabIndex = 18
        Me.Label3.Text = "Tanggal Masuk"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(430, 119)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(106, 16)
        Me.Label4.TabIndex = 19
        Me.Label4.Text = "Status Karyawan"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(430, 165)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(46, 16)
        Me.Label5.TabIndex = 20
        Me.Label5.Text = "No Hp"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(430, 209)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(49, 16)
        Me.Label6.TabIndex = 21
        Me.Label6.Text = "Alamat"
        '
        'txtAlamat
        '
        Me.txtAlamat.Location = New System.Drawing.Point(565, 206)
        Me.txtAlamat.Multiline = True
        Me.txtAlamat.Name = "txtAlamat"
        Me.txtAlamat.Size = New System.Drawing.Size(200, 66)
        Me.txtAlamat.TabIndex = 22
        '
        'dgvKaryawan
        '
        Me.dgvKaryawan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvKaryawan.Location = New System.Drawing.Point(33, 386)
        Me.dgvKaryawan.Name = "dgvKaryawan"
        Me.dgvKaryawan.RowHeadersWidth = 51
        Me.dgvKaryawan.RowTemplate.Height = 24
        Me.dgvKaryawan.Size = New System.Drawing.Size(726, 150)
        Me.dgvKaryawan.TabIndex = 23
        '
        'txtId
        '
        Me.txtId.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtId.Enabled = False
        Me.txtId.Location = New System.Drawing.Point(171, 28)
        Me.txtId.Multiline = True
        Me.txtId.Name = "txtId"
        Me.txtId.ReadOnly = True
        Me.txtId.Size = New System.Drawing.Size(10, 21)
        Me.txtId.TabIndex = 24
        '
        'btnMenu
        '
        Me.btnMenu.Location = New System.Drawing.Point(684, 314)
        Me.btnMenu.Name = "btnMenu"
        Me.btnMenu.Size = New System.Drawing.Size(75, 40)
        Me.btnMenu.TabIndex = 25
        Me.btnMenu.Text = "Menu"
        Me.btnMenu.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(36, 28)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(20, 16)
        Me.Label7.TabIndex = 26
        Me.Label7.Text = "ID"
        '
        'Form3
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 567)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.btnMenu)
        Me.Controls.Add(Me.txtId)
        Me.Controls.Add(Me.dgvKaryawan)
        Me.Controls.Add(Me.txtAlamat)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.label13)
        Me.Controls.Add(Me.label12)
        Me.Controls.Add(Me.label11)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.btnHapus)
        Me.Controls.Add(Me.btnEdit)
        Me.Controls.Add(Me.btnSimpan)
        Me.Controls.Add(Me.cboStatus)
        Me.Controls.Add(Me.dtpMasuk)
        Me.Controls.Add(Me.cboJK)
        Me.Controls.Add(Me.txtHP)
        Me.Controls.Add(Me.txtDivisi)
        Me.Controls.Add(Me.txtJabatan)
        Me.Controls.Add(Me.txtNama)
        Me.Controls.Add(Me.txtNik)
        Me.Name = "Form3"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form Data Karyawan"
        CType(Me.dgvKaryawan, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtNik As TextBox
    Friend WithEvents txtNama As TextBox
    Friend WithEvents txtJabatan As TextBox
    Friend WithEvents txtDivisi As TextBox
    Friend WithEvents txtHP As TextBox
    Friend WithEvents cboJK As ComboBox
    Friend WithEvents dtpMasuk As DateTimePicker
    Friend WithEvents cboStatus As ComboBox
    Friend WithEvents btnSimpan As Button
    Friend WithEvents btnEdit As Button
    Friend WithEvents btnHapus As Button
    Friend WithEvents btnClear As Button
    Friend WithEvents label11 As Label
    Friend WithEvents label12 As Label
    Friend WithEvents label13 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents txtAlamat As TextBox
    Friend WithEvents dgvKaryawan As DataGridView
    Friend WithEvents txtId As TextBox
    Friend WithEvents btnMenu As Button
    Friend WithEvents Label7 As Label
End Class
