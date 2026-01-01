Imports MySql.Data.MySqlClient

Public Class FormPenilaian



    ' ================= KONEKSI =================
    Dim conn As New MySqlConnection(
        "server=localhost;user id=root;password=;database=spk_karyawan")

    ' ================= FORM LOAD =================
    Private Sub Form5_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If RoleUser = "SUPERADVISOR" Then
            EnableIndikator123(True)
            EnableIndikator4(False)

        ElseIf RoleUser = "HR" Then
            EnableIndikator123(False)
            EnableIndikator4(True)

        Else
            MessageBox.Show("Anda tidak memiliki akses ke form ini")
            Me.Close()
        End If


        LoadKaryawan()
        LoadSkalaNilai()
        AturHakAkses()

        ' ================= UI STYLE =================


        ' Judul
        lblTitle.Font = New Font("Segoe UI", 14, FontStyle.Bold)
        lblTitle.ForeColor = Color.FromArgb(45, 62, 80)

        ' Role label
        lblRole.Text = "Login sebagai : " & RoleUser
        lblRole.ForeColor = Color.Gray
        lblRole.Font = New Font("Segoe UI", 9, FontStyle.Italic)



        ' Tombol
        StyleButtons()
    End Sub


    ' ================= LOAD KARYAWAN =================
    Sub LoadKaryawan()
        Using da As New MySqlDataAdapter(
            "SELECT id_karyawan, nama_karyawan, nik FROM karyawan", conn)
            Dim dt As New DataTable
            da.Fill(dt)
            cboKaryawan.DataSource = dt
            cboKaryawan.DisplayMember = "nama_karyawan"
            cboKaryawan.ValueMember = "id_karyawan"
            cboKaryawan.SelectedIndex = -1
        End Using
    End Sub

    Private Sub cboKaryawan_SelectedIndexChanged(
    sender As Object,
    e As EventArgs
) Handles cboKaryawan.SelectedIndexChanged

        If cboKaryawan.SelectedIndex = -1 Then Exit Sub
        If TypeOf cboKaryawan.SelectedValue Is DataRowView Then Exit Sub

        Dim drv As DataRowView = CType(cboKaryawan.SelectedItem, DataRowView)
        txtNik.Text = drv("nik").ToString()

        LoadNilaiKaryawan(CInt(cboKaryawan.SelectedValue))
    End Sub




    ' ================= ROLE =================
    Sub AturHakAkses()
        If RoleUser = "SUPERADVISOR" Then
            EnableIndikator123(True)
            EnableIndikator4(False)
        ElseIf RoleUser = "ADMIN HR" Then
            EnableIndikator123(False)
            EnableIndikator4(True)
        End If
    End Sub

    Sub EnableIndikator123(status As Boolean)
        cmbPt1.Enabled = status : cmbPt2.Enabled = status : cmbPt3.Enabled = status
        cmbPp1.Enabled = status : cmbPp2.Enabled = status : cmbPp3.Enabled = status : cmbPp4.Enabled = status
        cmbPs1.Enabled = status : cmbPs2.Enabled = status : cmbPs3.Enabled = status
    End Sub

    Sub EnableIndikator4(status As Boolean)
        cmbDk1.Enabled = status : cmbDk2.Enabled = status : cmbDk3.Enabled = status
    End Sub

    ' ================= HELPER =================
    Sub AddItem(cmb As ComboBox, teks As String, nilai As Integer)
        cmb.Items.Add(New With {.Text = teks, .Value = nilai})
        cmb.DisplayMember = "Text"
        cmb.ValueMember = "Value"
        cmb.SelectedIndex = -1
    End Sub

    Function Nilai(cmb As ComboBox) As Integer
        If cmb.SelectedIndex = -1 Then Return 0
        Return CInt(cmb.SelectedItem.Value)
    End Function

    ' ================= LOAD SKALA =================
    Sub LoadSkalaNilai()
        SkalaPersentaseTarget(cmbPt1)
        SkalaClosingDeal(cmbPt2)
        SkalaNilaiTransaksi(cmbPt3)

        SkalaFollowUp(cmbPp1)
        SkalaConversion(cmbPp2)
        SkalaRespon(cmbPp3)
        SkalaPipeline(cmbPp4)

        SkalaKomunikasi(cmbPs1)
        SkalaProduk(cmbPs2)
        SkalaProfesional(cmbPs3)

        SkalaKehadiran(cmbDk1)
        SkalaLaporan(cmbDk2)
        SkalaKepatuhan(cmbDk3)
    End Sub

    ' ================= SKALA DEFINISI =================
    Sub SkalaPersentaseTarget(cmb As ComboBox)
        cmb.Items.Clear()
        AddItem(cmb, "1 = <60%", 1)
        AddItem(cmb, "2 = 60–79%", 2)
        AddItem(cmb, "3 = 80–94%", 3)
        AddItem(cmb, "4 = 95–99%", 4)
        AddItem(cmb, "5 = ≥100%", 5)
    End Sub

    Sub SkalaClosingDeal(cmb As ComboBox)
        cmb.Items.Clear()
        AddItem(cmb, "1 = <50%", 1)
        AddItem(cmb, "2 = 50–69%", 2)
        AddItem(cmb, "3 = 70–89%", 3)
        AddItem(cmb, "4 = 90–99%", 4)
        AddItem(cmb, "5 = ≥100%", 5)
    End Sub

    Sub SkalaNilaiTransaksi(cmb As ComboBox)
        cmb.Items.Clear()
        AddItem(cmb, "1 = Jauh di bawah", 1)
        AddItem(cmb, "2 = Di bawah", 2)
        AddItem(cmb, "3 = Standar", 3)
        AddItem(cmb, "4 = Di atas", 4)
        AddItem(cmb, "5 = Jauh di atas", 5)
    End Sub

    Sub SkalaFollowUp(cmb As ComboBox)
        cmb.Items.Clear()
        AddItem(cmb, "1 = <50%", 1)
        AddItem(cmb, "2 = 50–69%", 2)
        AddItem(cmb, "3 = 70–89%", 3)
        AddItem(cmb, "4 = 90–99%", 4)
        AddItem(cmb, "5 = ≥100%", 5)
    End Sub

    Sub SkalaConversion(cmb As ComboBox)
        cmb.Items.Clear()
        AddItem(cmb, "1 = <10%", 1)
        AddItem(cmb, "2 = 10–19%", 2)
        AddItem(cmb, "3 = 20–29%", 3)
        AddItem(cmb, "4 = 30–39%", 4)
        AddItem(cmb, "5 = ≥40%", 5)
    End Sub

    Sub SkalaRespon(cmb As ComboBox)
        cmb.Items.Clear()
        AddItem(cmb, "1 = >24 jam", 1)
        AddItem(cmb, "2 = 12–24 jam", 2)
        AddItem(cmb, "3 = 6–12 jam", 3)
        AddItem(cmb, "4 = 1–6 jam", 4)
        AddItem(cmb, "5 = <1 jam", 5)
    End Sub

    Sub SkalaPipeline(cmb As ComboBox)
        cmb.Items.Clear()
        AddItem(cmb, "1 = Buruk", 1)
        AddItem(cmb, "2 = Kurang", 2)
        AddItem(cmb, "3 = Cukup", 3)
        AddItem(cmb, "4 = Baik", 4)
        AddItem(cmb, "5 = Sangat Baik", 5)
    End Sub

    Sub SkalaKomunikasi(cmb As ComboBox)
        cmb.Items.Clear()
        AddItem(cmb, "1 = Buruk", 1)
        AddItem(cmb, "2 = Kurang", 2)
        AddItem(cmb, "3 = Cukup", 3)
        AddItem(cmb, "4 = Baik", 4)
        AddItem(cmb, "5 = Sangat Baik", 5)
    End Sub

    Sub SkalaProduk(cmb As ComboBox)
        cmb.Items.Clear()
        AddItem(cmb, "1 = Tidak paham", 1)
        AddItem(cmb, "2 = Sebagian", 2)
        AddItem(cmb, "3 = Fitur utama", 3)
        AddItem(cmb, "4 = Solusi", 4)
        AddItem(cmb, "5 = Mendalam", 5)
    End Sub

    Sub SkalaProfesional(cmb As ComboBox)
        cmb.Items.Clear()
        AddItem(cmb, "1 = Tidak profesional", 1)
        AddItem(cmb, "2 = Kurang", 2)
        AddItem(cmb, "3 = Standar", 3)
        AddItem(cmb, "4 = Profesional", 4)
        AddItem(cmb, "5 = Sangat profesional", 5)
    End Sub

    Sub SkalaKehadiran(cmb As ComboBox)
        cmb.Items.Clear()
        AddItem(cmb, "1 = Sering telat", 1)
        AddItem(cmb, "2 = Cukup sering", 2)
        AddItem(cmb, "3 = Standar", 3)
        AddItem(cmb, "4 = Hampir selalu", 4)
        AddItem(cmb, "5 = Selalu tepat", 5)
    End Sub

    Sub SkalaLaporan(cmb As ComboBox)
        cmb.Items.Clear()
        AddItem(cmb, "1 = Tidak lengkap", 1)
        AddItem(cmb, "2 = Sering telat", 2)
        AddItem(cmb, "3 = Lengkap telat", 3)
        AddItem(cmb, "4 = Tepat waktu", 4)
        AddItem(cmb, "5 = Rapi & tepat", 5)
    End Sub

    Sub SkalaKepatuhan(cmb As ComboBox)
        cmb.Items.Clear()
        AddItem(cmb, "1 = Tidak patuh", 1)
        AddItem(cmb, "2 = Jarang update", 2)
        AddItem(cmb, "3 = Sebagian", 3)
        AddItem(cmb, "4 = Patuh", 4)
        AddItem(cmb, "5 = Sangat disiplin", 5)
    End Sub

    ' ================= CEK SA =================
    Function NilaiSuperAdvisorAda(idKaryawan As Integer) As Boolean
        Dim cmd As New MySqlCommand(
            "SELECT COUNT(*) FROM nilai WHERE id_karyawan=@id", conn)
        cmd.Parameters.AddWithValue("@id", idKaryawan)
        Return CInt(cmd.ExecuteScalar()) > 0
    End Function

    ' ================= HITUNG SAW =================
    Function Norm(nilai As Integer) As Double
        Return nilai / 5.0
    End Function

    Function HitungSAW() As Double

        ' === Pencapaian Target (40%) ===
        Dim PT As Double =
        ((Norm(Nilai(cmbPt1)) * 0.25) +
         (Norm(Nilai(cmbPt2)) * 0.1) +
         (Norm(Nilai(cmbPt3)) * 0.05)) / 0.4

        ' === Proses Penjualan (30%) ===
        Dim PP As Double =
        ((Norm(Nilai(cmbPp1)) * 0.1) +
         (Norm(Nilai(cmbPp2)) * 0.1) +
         (Norm(Nilai(cmbPp3)) * 0.05) +
         (Norm(Nilai(cmbPp4)) * 0.05)) / 0.3

        ' === Perilaku & Soft Skill (20%) ===
        Dim PS As Double =
        ((Norm(Nilai(cmbPs1)) * 0.08) +
         (Norm(Nilai(cmbPs2)) * 0.05) +
         (Norm(Nilai(cmbPs3)) * 0.04)) / 0.2

        ' === Disiplin & Kepatuhan (10%) ===
        Dim DK As Double =
        ((Norm(Nilai(cmbDk1)) * 0.04) +
         (Norm(Nilai(cmbDk2)) * 0.03) +
         (Norm(Nilai(cmbDk3)) * 0.03)) / 0.1

        Dim nilaiSAW As Double =
        (0.4 * PT) + (0.3 * PP) + (0.2 * PS) + (0.1 * DK)

        Return Math.Round(nilaiSAW * 100, 2) ' skala 0–100
    End Function




    Sub ResetForm()
        For Each ctrl As Control In pnlMain.Controls
            ResetComboRecursive(ctrl)
        Next
    End Sub

    Sub ResetComboRecursive(ctrl As Control)
        If TypeOf ctrl Is ComboBox Then
            CType(ctrl, ComboBox).SelectedIndex = -1
        End If

        For Each c As Control In ctrl.Controls
            ResetComboRecursive(c)
        Next
    End Sub

    Sub LoadNilaiKaryawan(idKaryawan As Integer)

        ' Reset dulu semua combo
        ResetCombo()

        Dim cmd As New MySqlCommand(
        "SELECT id_kriteria, nilai 
         FROM nilai 
         WHERE id_karyawan=@id", conn)

        cmd.Parameters.AddWithValue("@id", idKaryawan)

        conn.Open()
        Dim rd = cmd.ExecuteReader()

        While rd.Read()
            Dim idKriteria = CInt(rd("id_kriteria"))
            Dim nilai = CInt(rd("nilai"))

            Select Case idKriteria
            ' === PENCAPAIAN TARGET ===
                Case 1 : SetCombo(cmbPt1, nilai)
                Case 2 : SetCombo(cmbPt2, nilai)
                Case 3 : SetCombo(cmbPt3, nilai)

            ' === PROSES PENJUALAN ===
                Case 4 : SetCombo(cmbPp1, nilai)
                Case 5 : SetCombo(cmbPp2, nilai)
                Case 6 : SetCombo(cmbPp3, nilai)
                Case 7 : SetCombo(cmbPp4, nilai)

            ' === PERILAKU & SOFT SKILL ===
                Case 8 : SetCombo(cmbPs1, nilai)
                Case 9 : SetCombo(cmbPs2, nilai)
                Case 10 : SetCombo(cmbPs3, nilai)

            ' === DISIPLIN & KEPATUHAN (HR) ===
                Case 11 : SetCombo(cmbDk1, nilai)
                Case 12 : SetCombo(cmbDk2, nilai)
                Case 13 : SetCombo(cmbDk3, nilai)
            End Select
        End While

        rd.Close()
        conn.Close()
    End Sub
    Sub SetCombo(cmb As ComboBox, nilai As Integer)
        For i As Integer = 0 To cmb.Items.Count - 1
            If cmb.Items(i).Value = nilai Then
                cmb.SelectedIndex = i
                Exit Sub
            End If
        Next
    End Sub

    Sub ResetCombo()
        For Each ctrl As Control In Me.Controls
            If TypeOf ctrl Is ComboBox Then
                CType(ctrl, ComboBox).SelectedIndex = -1
            End If
        Next
    End Sub



    ' ================= button =================


    Private Sub btnMenu_Click_1(sender As Object, e As EventArgs) Handles btnMenu.Click
        FormMenu.Show()
        Me.Close()
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        If cboKaryawan.SelectedIndex = -1 Then
            MessageBox.Show("Pilih karyawan terlebih dahulu")
            Exit Sub
        End If

        Try
            conn.Open()

            ' ==================================================
            ' SUPERADVISOR
            ' ==================================================
            If RoleUser = "SUPERADVISOR" Then

                Dim cmd As New MySqlCommand("
            INSERT INTO nilai (id_karyawan,id_kriteria,nilai)
            VALUES
            (@id,1,@pt1),(@id,2,@pt2),(@id,3,@pt3),
            (@id,4,@pp1),(@id,5,@pp2),(@id,6,@pp3),(@id,7,@pp4),
            (@id,8,@ps1),(@id,9,@ps2),(@id,10,@ps3)
            ON DUPLICATE KEY UPDATE nilai=VALUES(nilai)", conn)

                cmd.Parameters.AddWithValue("@id", cboKaryawan.SelectedValue)
                cmd.Parameters.AddWithValue("@pt1", Nilai(cmbPt1))
                cmd.Parameters.AddWithValue("@pt2", Nilai(cmbPt2))
                cmd.Parameters.AddWithValue("@pt3", Nilai(cmbPt3))
                cmd.Parameters.AddWithValue("@pp1", Nilai(cmbPp1))
                cmd.Parameters.AddWithValue("@pp2", Nilai(cmbPp2))
                cmd.Parameters.AddWithValue("@pp3", Nilai(cmbPp3))
                cmd.Parameters.AddWithValue("@pp4", Nilai(cmbPp4))
                cmd.Parameters.AddWithValue("@ps1", Nilai(cmbPs1))
                cmd.Parameters.AddWithValue("@ps2", Nilai(cmbPs2))
                cmd.Parameters.AddWithValue("@ps3", Nilai(cmbPs3))
                cmd.ExecuteNonQuery()

                MessageBox.Show("Nilai SuperAdvisor berhasil disimpan")

                ' ==================================================
                ' HR
                ' ==================================================
            ElseIf RoleUser = "HR" Then

                ' Cek nilai SuperAdvisor
                If Not NilaiSuperAdvisorAda(cboKaryawan.SelectedValue) Then
                    MessageBox.Show("Nilai SuperAdvisor belum tersedia")
                    Exit Sub
                End If

                ' ================= SIMPAN C4 (DISIPLIN & KEPATUHAN) =================
                Dim cmdNilai As New MySqlCommand("
            INSERT INTO nilai (id_karyawan,id_kriteria,nilai)
            VALUES
            (@id,11,@dk1),
            (@id,12,@dk2),
            (@id,13,@dk3)
            ON DUPLICATE KEY UPDATE nilai = VALUES(nilai)", conn)

                cmdNilai.Parameters.AddWithValue("@id", cboKaryawan.SelectedValue)
                cmdNilai.Parameters.AddWithValue("@dk1", Nilai(cmbDk1))
                cmdNilai.Parameters.AddWithValue("@dk2", Nilai(cmbDk2))
                cmdNilai.Parameters.AddWithValue("@dk3", Nilai(cmbDk3))
                cmdNilai.ExecuteNonQuery()

                ' ================= HITUNG NILAI AKHIR SAW =================
                Dim nilaiAkhir As Double = HitungSAW()

                Dim cmdHasil As New MySqlCommand("
            INSERT INTO hasil (id_karyawan,nilai_akhir)
            VALUES (@id,@nilai)
            ON DUPLICATE KEY UPDATE nilai_akhir=@nilai", conn)

                cmdHasil.Parameters.AddWithValue("@id", cboKaryawan.SelectedValue)
                cmdHasil.Parameters.AddWithValue("@nilai", nilaiAkhir)
                cmdHasil.ExecuteNonQuery()

                ' ================= HITUNG RANKING =================
                Dim dt As New DataTable
                Dim da As New MySqlDataAdapter(
                "SELECT id_hasil FROM hasil ORDER BY nilai_akhir DESC", conn)
                da.Fill(dt)

                Dim rank As Integer = 1
                For Each row As DataRow In dt.Rows
                    Dim cmdRank As New MySqlCommand(
                    "UPDATE hasil SET ranking=@rank WHERE id_hasil=@id", conn)
                    cmdRank.Parameters.AddWithValue("@rank", rank)
                    cmdRank.Parameters.AddWithValue("@id", row("id_hasil"))
                    cmdRank.ExecuteNonQuery()
                    rank += 1
                Next

                MessageBox.Show("Nilai HR, nilai akhir, dan ranking berhasil disimpan")

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        ResetForm()
    End Sub

    Private Sub btnHapus_Click(sender As Object, e As EventArgs) Handles btnHapus.Click
        If MessageBox.Show("Hapus data penilaian?", "Konfirmasi",
                   MessageBoxButtons.YesNo) = DialogResult.Yes Then
            Try
                conn.Open()
                Dim cmd As New MySqlCommand(
                    "DELETE FROM hasil WHERE id_karyawan=@id", conn)
                cmd.Parameters.AddWithValue("@id", cboKaryawan.SelectedValue)
                cmd.ExecuteNonQuery()
                MessageBox.Show("Data berhasil dihapus")
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            Finally
                conn.Close()
            End Try
        End If
    End Sub

    Sub StyleButtons()
        btnSimpan.BackColor = Color.FromArgb(46, 204, 113)
        btnSimpan.ForeColor = Color.White

        btnClear.BackColor = Color.Gainsboro
        btnClear.ForeColor = Color.Black

        btnHapus.BackColor = Color.FromArgb(231, 76, 60)
        btnHapus.ForeColor = Color.White

        btnMenu.BackColor = Color.FromArgb(52, 152, 219)
        btnMenu.ForeColor = Color.Black
    End Sub

End Class
