Public Class Form3
    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles PanelDs.Paint

    End Sub

    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        With Form6
            .TopLevel = False
            Panel3.Controls.Add(Form6)
            .BringToFront()
            .Show()
        End With

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        With Form1
            .TopLevel = False
            Panel3.Controls.Add(Form1)
            .BringToFront()
            .Show()


        End With
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        With Form14
            .TopLevel = False
            Panel3.Controls.Add(Form14)
            .BringToFront()
            .Show()


        End With

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        With Form9
            .TopLevel = False
            Panel3.Controls.Add(Form9)
            .BringToFront()
            .Show()


        End With

    End Sub

    Private Sub Panel3_Paint(sender As Object, e As PaintEventArgs) Handles Panel3.Paint

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        With Form4
            .TopLevel = False
            Panel3.Controls.Add(Form4)
            .BringToFront()
            .Show()


        End With

    End Sub

    Private Sub Panel4_Paint(sender As Object, e As PaintEventArgs) Handles Panel4.Paint

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        With Form1
            .TopLevel = False
            Panel3.Controls.Add(Form1)
            .BringToFront()
            .Show()


        End With
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        With Form7
            .TopLevel = False
            Panel3.Controls.Add(Form7)
            .BringToFront()
            .Show()


        End With
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        With Form4
            .TopLevel = False
            Panel3.Controls.Add(Form4)
            .BringToFront()
            .Show()


        End With
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        Form16.Show()
    End Sub
End Class