Imports System.Data.SqlClient
Imports MySql.Data.MySqlClient
Module Koneksi
    Public conn As MySqlConnection
    Public Sub OpenConn()
        conn = New MySqlConnection(
            "server=localhost;user id=root;password=;database=spk_karyawan"
        )
        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If
    End Sub
End Module
