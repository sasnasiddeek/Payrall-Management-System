Imports MySql.Data.MySqlClient
Public Class Form7
    Dim conn As New MySqlConnection("server=localhost;user id=root;password=sasna1234;database=employee")
    Dim cmd As New MySqlCommand
    Private Sub Form7_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        displaydate()

    End Sub
    Public Sub displaydate()
        If conn.State = ConnectionState.Open Then
            conn.Close()
        End If
        conn.Open()

        cmd = conn.CreateCommand()
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "Select * From department"
        cmd.ExecuteNonQuery()
        Dim dt As New DataTable()
        Dim da As New MySqlDataAdapter(cmd)
        da.Fill(dt)
        DataGridView1.DataSource = dt


    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick


    End Sub

    Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs) Handles txtNIC.TextChanged

    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click

    End Sub

    Private Sub TextBox7_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub TextBox6_TextChanged(sender As Object, e As EventArgs) Handles txtname.TextChanged

    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click

    End Sub

    Private Sub Label4_Click_1(sender As Object, e As EventArgs) Handles Label4.Click

    End Sub

    Private Sub TextBox8_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim ask As MsgBoxResult
        ask = MsgBox("Are you sure want to ADD this details?", MsgBoxStyle.YesNo, "Message")


        Try
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
            conn.Open()


            cmd = conn.CreateCommand()
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "insert into department(NIC,EmployeeName,Department,Designation,DepartmentId) values ('" & txtNIC.Text & "','" & txtname.Text & "','" & cboDepartment.Text & "','" & cboDesignation.Text & "','" + txtdeid.Text + "')"
            cmd.ExecuteNonQuery()
            displaydate()
            MessageBox.Show("Data Inserted", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information)

            txtNIC.Text = ""
            txtname.Text = ""
            cboDepartment.Text = ""
            cboDesignation.Text = ""
            txtdeid.Text = ""


            conn.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message)

        End Try
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim ask As MsgBoxResult
        ask = MsgBox("Are you sure want to change the Person details?", MsgBoxStyle.YesNo, "Message")

        Try
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If

            conn.Open()

            cmd = conn.CreateCommand()
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "update department set NIC='" + txtNIC.Text + "',EmployeeName='" + txtname.Text + "',Department='" + cboDepartment.Text + "',Designation='" + cboDepartment.Text + "',DepartmentId='" + txtdeid.Text + "' where NIC=" & txtNIC.Text & ""
            cmd.ExecuteNonQuery()
            displaydate()
            MessageBox.Show("Person details changed", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information)



        Catch ex As Exception
            MessageBox.Show("Data Not Update", "Messsage", MessageBoxButtons.OK, MessageBoxIcon.Question)


        End Try


    End Sub



    Private Sub Button4_Click_1(sender As Object, e As EventArgs) Handles Button4.Click
        Dim ask As MsgBoxResult
        ask = MsgBox("Are you sure want to Delete this person details?", MsgBoxStyle.YesNo, "Message")
        If ask = MsgBoxResult.Yes Then

            If conn.State = ConnectionState.Open Then
                conn.Close()

            End If
            conn.Open()

            cmd = conn.CreateCommand()
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "Delete from department where NIC='" + txtNIC.Text + "'"
            cmd.ExecuteNonQuery()
            displaydate()
            MessageBox.Show("Person Detail was Deleted", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information)

        End If
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        txtNIC.Clear()
        txtname.Clear()
        cboDepartment.Text = ""
        cboDesignation.Text = ""
        txtdeid.Clear()

    End Sub

    Private Sub cboDepartment_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboDepartment.SelectedIndexChanged

    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick

        Try
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
            conn.Open()
            Dim i As Integer
            i = Convert.ToInt32(DataGridView1.SelectedCells.Item(0).Value.ToString())

            cmd = conn.CreateCommand()
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "select  NIC,EmployeeName from department where NIC=" & i & ""
            cmd.ExecuteNonQuery()

            Dim dt As New DataTable()
            Dim da As New MySqlDataAdapter(cmd)
            da.Fill(dt)
            Dim dr As MySqlDataReader
            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            While dr.Read

                txtNIC.Text = dr.GetValue(0).ToString()
                txtname.Text = dr.GetValue(0).ToString()


            End While

        Catch ex As Exception

        End Try
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub txtNIC_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNIC.KeyPress
        If (Asc(e.KeyChar) >= 48 And Asc(e.KeyChar) <= 57) Or Asc(e.KeyChar) = 46 Or Asc(e.KeyChar) = 8 Then
        Else
            e.Handled = True
        End If
        If txtNIC.Text.Length >= 10 Then
            MessageBox.Show("Only Type 10 Numbers", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtNIC.Text = txtNIC.Text
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)

    End Sub
End Class