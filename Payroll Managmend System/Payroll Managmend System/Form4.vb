Imports MySql.Data.MySqlClient
Public Class Form4
    Dim conn As New MySqlConnection("server=localhost;user id=root;password=sasna1234;database=employee")
    Dim cmd As New MySqlCommand
    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        displaydate()
        Timer1.Enabled = True
        DateTimePicker3.Value = DateTime.Now.ToShortDateString()
        DateTimePicker2.Value = DateTime.Now.ToShortDateString()
    End Sub
    Public Sub displaydate()
        If conn.State = ConnectionState.Open Then
            conn.Close()
        End If
        conn.Open()

        cmd = conn.CreateCommand()
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "Select * From attendence"
        cmd.ExecuteNonQuery()
        Dim dt As New DataTable()
        Dim da As New MySqlDataAdapter(cmd)
        da.Fill(dt)
        DataGridView1.DataSource = dt


    End Sub
    Public Sub FilterData(valueToSearch As String)
        Dim searchQuery As String = "SELECT * From attendence WHERE NIC like '%" & valueToSearch & "%' "
        Dim cmd As New MySqlCommand(searchQuery, conn)
        Dim da As New MySqlDataAdapter(cmd)
        Dim dt As New DataTable()

        da.Fill(dt)
        DataGridView1.DataSource = dt

    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnInsert.Click
        Dim ask As MsgBoxResult
        ask = MsgBox("Are you sure want to ADD this details?", MsgBoxStyle.YesNo, "Message")


        Try
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
            conn.Open()


            cmd = conn.CreateCommand()
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "insert into attendence(Date,NIC,Firstname,Department,Attendence,ClockIn,ClockOut,OverTime) values ('" & DateTimePicker1.Text & "','" & txtNIC.Text & "','" & txtFirstname.Text & "','" & cboDepartment.Text & "','" & cboAttendence.Text & "','" & DateTimePicker3.Text & "','" & DateTimePicker2.Text & "','" + cboOverTime.Text + "')"
            cmd.ExecuteNonQuery()
            displaydate()
            MessageBox.Show("Data Inserted", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
            DateTimePicker1.Text = ""
            txtNIC.Text = ""
            txtFirstname.Text = ""
            cboDepartment.Text = ""
            cboAttendence.Text = ""
            DateTimePicker3.Text = ""
            DateTimePicker2.Text = ""
            cboOverTime.Text = ""


            conn.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message)

        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Dim ask As MsgBoxResult
        ask = MsgBox("Are you sure want to Delete this person details?", MsgBoxStyle.YesNo, "Message")
        If ask = MsgBoxResult.Yes Then

            If conn.State = ConnectionState.Open Then
                conn.Close()

            End If
            conn.Open()

            cmd = conn.CreateCommand()
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "Delete from attendence where NIC='" + txtNIC.Text + "'"
            cmd.ExecuteNonQuery()
            displaydate()
            MessageBox.Show("Person Detail was Deleted", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information)

        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnExite.Click
        txtNIC.Clear()
        txtFirstname.Clear()
        DateTimePicker1.Text = ""
        DateTimePicker2.Text = ""
        DateTimePicker3.Text = ""
        cboAttendence.Text = ""
        cboDepartment.Text = ""
        cboOverTime.Text = ""


    End Sub



    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Dim ask As MsgBoxResult
        ask = MsgBox("Are you sure want to change the Person details?", MsgBoxStyle.YesNo, "Message")

        Try
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If

            conn.Open()

            cmd = conn.CreateCommand()
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "update attendence set Date='" + DateTimePicker1.Text + "',NIC='" + txtNIC.Text + "',Firstname='" + txtFirstname.Text + "',Department='" + cboDepartment.Text + "',Attendence='" + cboAttendence.Text + "',ClockIn='" + DateTimePicker3.Text + "',ClockOut='" + DateTimePicker2.Text + "',OverTime='" + cboOverTime.Text + "' where NIC=" & txtNIC.Text & ""
            cmd.ExecuteNonQuery()
            displaydate()
            MessageBox.Show("Person details changed", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information)



        Catch ex As Exception
            MessageBox.Show("Data Not Update", "Messsage", MessageBoxButtons.OK, MessageBoxIcon.Question)


        End Try

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        lbldate.Text = Date.Now.ToString("dd-MM-yyy")
        lbltime.Text = Date.Now.ToString("hh-mm-ss")
    End Sub

    Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs) Handles txtsearch.TextChanged
        FilterData(txtsearch.Text)
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged
        DateTimePicker1.Text = Format(DateTimePicker1.Value, "yyyy-MM-dd")
    End Sub





    Private Sub txt1ID_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNIC.KeyPress
        If (Asc(e.KeyChar) >= 48 And Asc(e.KeyChar) <= 57) Or Asc(e.KeyChar) = 46 Or Asc(e.KeyChar) = 8 Then
        Else
            e.Handled = True
        End If
        If txtNIC.Text.Length >= 10 Then
            MessageBox.Show("Only Type 10 Numbers", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtNIC.Text = txtNIC.Text
        End If
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
            cmd.CommandText = "select  NIC,Firstname from attendence where NIC=" & i & ""
            cmd.ExecuteNonQuery()

            Dim dt As New DataTable()
            Dim da As New MySqlDataAdapter(cmd)
            da.Fill(dt)
            Dim dr As MySqlDataReader
            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            While dr.Read

                txtNIC.Text = dr.GetValue(0).ToString()
                txtFirstname.Text = dr.GetValue(0).ToString()


            End While

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Label13_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label12_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub txtOverTime_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub txtFirstname_TextChanged(sender As Object, e As EventArgs) Handles txtFirstname.TextChanged

    End Sub

    Private Sub DateTimePicker3_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker3.ValueChanged
        DateTimePicker3.CustomFormat = "hh:mm:ss"
        DateTimePicker3.ShowUpDown = True
        'DateTimePicker3.Text = Format(DateTimePicker3.Value, "HH:MM:ss")
    End Sub

    Private Sub DateTimePicker2_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker2.ValueChanged
        ' DateTimePicker2.Text = Format(DateTimePicker2.Value, "hh:MM:ss")
        DateTimePicker2.CustomFormat = "hh:mm:ss"
        DateTimePicker2.ShowUpDown = True
    End Sub

    Private Sub lbldate_Click(sender As Object, e As EventArgs) Handles lbldate.Click

    End Sub

    Private Sub lbltime_Click(sender As Object, e As EventArgs) Handles lbltime.Click

    End Sub

    Private Sub Label9_Click(sender As Object, e As EventArgs) 

    End Sub

    Private Sub MaskedTextBox1_MaskInputRejected(sender As Object, e As MaskInputRejectedEventArgs)


    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        FilterData(txtSearch.Text)
    End Sub

    Private Sub cboOverTime_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboOverTime.SelectedIndexChanged

    End Sub
End Class