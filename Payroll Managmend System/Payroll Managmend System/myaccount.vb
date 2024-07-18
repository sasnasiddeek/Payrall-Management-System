Public Class myaccount
    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub myaccount_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label2.Text = My.Settings.Fullname
        Label3.Text = My.Settings.NIC
        PictureBox1.ImageLocation = My.Settings.Avatar()




    End Sub

    Private Sub Panel1_Paint_1(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        With Form17
            .TopLevel = False
            Panel2.Controls.Add(Form17)
            .BringToFront()
            .Show()


        End With
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        With Form18
            .TopLevel = False
            Panel2.Controls.Add(Form18)
            .BringToFront()
            .Show()


        End With
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        login.Show()

    End Sub
End Class