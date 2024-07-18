Public Class Form11
    Private Sub Form11_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        conn.ConnectionString = "Server=localhost;user id=root;port=3306;password=sasna1234;database=employee"

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        sql = "SELECT * FROM emlogin WHERE Username = '" & txtusername.Text & "' AND Password = '" & txtpassword.Text & "' "
        connect()

        If dr.Read Then

            MsgBox("Login Successfuly")
            Me.Close()


        Else
            MsgBox("Invalid Username or Password")
        End If
        conn.Close()
    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

    End Sub

    Private Sub txtpassword_TextChanged(sender As Object, e As EventArgs) Handles txtpassword.TextChanged

    End Sub
End Class