
Public Class Form8


    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        sql = "SELECT * FROM login WHERE username = '" & txtusername.Text & "' AND password = '" & txtpassword.Text & "' "
        connect()

        If dr.Read Then

            MsgBox("Login Successfuly")
            Me.Hide()
            Form3.Show()

        Else
            MsgBox("Invalid Username or Password")
        End If
        conn.Close()

    End Sub

    Private Sub Form8_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        conn.ConnectionString = "Server=localhost;user id=root;port=3306;password=sasna1234;database=employee"
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Form16.Show()
        Me.Hide()
    End Sub

    Private Sub txtusername_TextChanged(sender As Object, e As EventArgs) Handles txtusername.TextChanged

    End Sub
End Class