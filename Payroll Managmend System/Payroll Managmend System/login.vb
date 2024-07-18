Public Class login
    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)

    End Sub

    Private Sub login_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub txtNIC_TextChanged(sender As Object, e As EventArgs) Handles txtNIC.TextChanged

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            My.Settings.Username = txtUsername.Text
            My.Settings.Password = txtPassword.Text
            My.Settings.Retype = txtRetype.Text
            My.Settings.Fullname = txtFullname.Text
            My.Settings.NIC = txtNIC.Text
            My.Settings.Avatar = OpenFileDialog1.FileName
            My.Settings.Status = False
            My.Settings.Save()
            MsgBox("Your account has been created", MsgBoxStyle.Information)
            Application.Restart()


        Catch ex As Exception
            MsgBox("Your account has not been created... ", MsgBoxStyle.Critical)

        End Try












    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Try
            OpenFileDialog1.Title = "Open Picture"
            OpenFileDialog1.FileName = ".png"
            OpenFileDialog1.Filter = "all files|*.*"
            OpenFileDialog1.ShowDialog()
            PictureBox1.Image = System.Drawing.Image.FromFile(OpenFileDialog1.FileName)
        Catch ex As Exception
            'Do  nothing

        End Try
    End Sub

    Private Sub txtRetype_TextChanged(sender As Object, e As EventArgs) Handles txtRetype.TextChanged
        If Not txtRetype.Text = txtPassword.Text Then
            Label6.Text = "Password not matched"
        Else
            Label6.Text = ""
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        End
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If txtUsername1.Text = My.Settings.Username And txtPassword1.Text = My.Settings.Password Then
            myaccount.Show()
            Me.Hide()
        Else
            MsgBox("Invalid Username & Password...... try again 1", MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles txtUsername1.TextChanged

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Form16.Show()
        Me.Hide()
    End Sub

    Private Sub TabPage1_Click(sender As Object, e As EventArgs) Handles TabPage1.Click

    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub Label10_Click(sender As Object, e As EventArgs) Handles Label10.Click

    End Sub

    Private Sub TabPage2_Click(sender As Object, e As EventArgs) Handles TabPage2.Click

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Form16.Show()

    End Sub
End Class