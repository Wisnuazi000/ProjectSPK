Imports System.Data.SqlClient
Imports MySql.Data.MySqlClient

Public Class FormLogin

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click

        If txtUsername.Text.Trim() = "" Or txtPassword.Text.Trim() = "" Then
            MessageBox.Show("Username dan Password wajib diisi", "Peringatan",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Try
            Call OpenConn()

            Dim query As String =
            "SELECT * FROM users 
             WHERE TRIM(username)=@username 
             AND TRIM(password)=@password"

            Dim cmd As New MySqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@username", txtUsername.Text.Trim())
            cmd.Parameters.AddWithValue("@password", txtPassword.Text.Trim())

            Dim dr As MySqlDataReader = cmd.ExecuteReader()

            If dr.HasRows Then
                dr.Read()

                MessageBox.Show("Login berhasil", "Informasi",
                                MessageBoxButtons.OK, MessageBoxIcon.Information)

                Form2.Show()
                Me.Hide()
            Else
                MessageBox.Show("Username atau Password salah", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

            dr.Close()
            conn.Close()

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
    End Sub

End Class
