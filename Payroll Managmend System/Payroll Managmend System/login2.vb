Public Class login2
    Private Sub TabPage1_Click(sender As Object, e As EventArgs) Handles TabPage1.Click

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            My.Settings.Username = txtUsername.Text
            My.Settings.Password = txtPassword.Text
            My.Settings.Retype = txtRetype.Text
            My.Settings.Fullname = txtFullname.Text
            My.Settings.NIC = txtNIC.Text







        Catch ex As Exception

        End Try
    End Sub
End Class