Imports System.Data.SqlClient
Imports MySql.Data.MySqlClient
Imports OfficeOpenXml

Public Class FormLogin

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click

        If txtUsername.Text.Trim() = "" Or txtPassword.Text.Trim() = "" Then
            MessageBox.Show("Username dan Password wajib diisi")
            Exit Sub
        End If

        Try
            Call OpenConn()

            Dim query As String =
            "SELECT id_user, username, role 
         FROM users 
         WHERE username=@username 
         AND password=@password"

            Dim cmd As New MySqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@username", txtUsername.Text.Trim())
            cmd.Parameters.AddWithValue("@password", txtPassword.Text.Trim())

            Dim dr As MySqlDataReader = cmd.ExecuteReader()

            If dr.Read() Then
                ' ===== SIMPAN SESSION =====
                UserID = CInt(dr("id_user"))
                Username = dr("username").ToString()
                RoleUser = dr("role").ToString().ToUpper()

                MessageBox.Show("Login berhasil sebagai " & RoleUser)

                ' === INIT EPPLUS SEKALI SAJA ===

                FormMenu.Show()
                Me.Hide()
            Else
                MessageBox.Show("Username atau Password salah")
            End If

            dr.Close()
            conn.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub piceye_Click(sender As Object, e As EventArgs) Handles piceye.Click
        If txtPassword.PasswordChar = ChrW(0) Then
            txtPassword.PasswordChar = "•"c
            piceye.Image = My.Resources.eye_close
        Else
            txtPassword.PasswordChar = ChrW(0)
            piceye.Image = My.Resources.eye_open
        End If
    End Sub

    Private Sub FormLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ExcelPackage.LicenseContext = LicenseContext.NonCommercial
        txtPassword.PasswordChar = "•"c
        piceye.Image = My.Resources.eye_close


    End Sub
    Private Sub txtPassword_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPassword.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnLogin.PerformClick()
        End If
    End Sub

End Class
