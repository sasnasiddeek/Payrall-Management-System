Imports MySql.Data.MySqlClient
Public Class Form1
    Dim conn As New MySqlConnection("server=localhost;user id=root;password=sasna1234;database=employee")
    Dim cmd As New MySqlCommand
    ' Dim result As Integer
    'Dim imgpath As String
    'Dim arrimage() As Byte
    'Dim sql As String

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        displaydate()
        Timer1.Enabled = True
    End Sub
    Public Sub displaydate()
        If conn.State = ConnectionState.Open Then
            conn.Close()
        End If
        conn.Open()

        cmd = conn.CreateCommand()
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "Select * From employee"
        cmd.ExecuteNonQuery()
        Dim dt As New DataTable()
        Dim da As New MySqlDataAdapter(cmd)
        da.Fill(dt)
        DataGridView1.DataSource = dt


    End Sub
    Public Sub FilterData(valueToSearch As String)
        Dim searchQuery As String = "SELECT * From employee WHERE NIC like '%" & valueToSearch & "%' "
        Dim cmd As New MySqlCommand(searchQuery, conn)
        Dim da As New MySqlDataAdapter(cmd)
        Dim dt As New DataTable()

        da.Fill(dt)
        DataGridView1.DataSource = dt

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label3_Click_1(sender As Object, e As EventArgs) Handles rty.Click

    End Sub

    Private Sub Label3_Click_2(sender As Object, e As EventArgs) Handles tMobi.Click

    End Sub

    Private Sub Label3_Click_3(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub btnInsert_Click(sender As Object, e As EventArgs) Handles btnInsert.Click
        Dim ask As MsgBoxResult
        ask = MsgBox("Are you sure want to ADD this details?", MsgBoxStyle.YesNo, "Message")


        Try
            ' Dim msstream As New System.IO.MemoryStream()
            ' PictureBox1.Image.Save(msstream, System.Drawing.Imaging.ImageFormat.Jpeg)
            ' arrimage = msstream.GetBuffer()
            'Dim filesize As UInt32
            'filesize = msstream.Length
            'msstream.Close()


            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
            conn.Open()


            cmd = conn.CreateCommand()
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "insert into employee(NIC,Firstname,Surname,Address,PostCode,Gender,Department,Designation,DOB,Email,Mobile) values ('" & txtNIC.Text & "','" & txtFirstname.Text & "','" & txtSurname.Text & "','" & txtAddress.Text & "','" & txtPostCode.Text & "','" & cboGender.Text & "','" & cboDepartment.Text & "','" & cboDesignation.Text & "','" & DateTimePicker1.Text & "','" & txtEmail.Text & "','" + txtEmail.Text + "')"
            cmd.ExecuteNonQuery()
            displaydate()
            MessageBox.Show("Data Inserted", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtNIC.Text = ""
            txtFirstname.Text = ""
            txtSurname.Text = ""
            txtAddress.Text = ""
            txtPostCode.Text = ""
            cboGender.Text = ""
            cboDepartment.Text = ""
            cboDesignation.Text = ""
            DateTimePicker1.Text = ""
            txtEmail.Text = ""
            txtMobile.Text = ""



            conn.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message)

        End Try

    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged
        DateTimePicker1.Text = Format(DateTimePicker1.Value, "yyyy-MM-dd")
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Dim ask As MsgBoxResult
        ask = MsgBox("Are you sure want to change the Person details?", MsgBoxStyle.YesNo, "Message")

        Try
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If

            conn.Open()

            cmd = conn.CreateCommand()
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "update employee set NIC='" + txtNIC.Text + "',Firstname='" + txtFirstname.Text + "',Surname='" + txtSurname.Text + "',Address='" + txtAddress.Text + "',PostCode='" + txtPostCode.Text + "',Gender='" + cboGender.Text + "',Department='" + cboDepartment.Text + "',Designation='" + cboDesignation.Text + "',DOB='" + DateTimePicker1.Text + "',Email='" + txtEmail.Text + "',Mobile='" + txtMobile.Text + "' where NIC=" & txtNIC.Text & ""
            cmd.ExecuteNonQuery()
            displaydate()
            MessageBox.Show("Person details changed", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information)



        Catch ex As Exception
            MessageBox.Show("Data Not Update", "Messsage", MessageBoxButtons.OK, MessageBoxIcon.Question)


        End Try

    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Dim ask As MsgBoxResult
        ask = MsgBox("Are you sure want to Delete this person details?", MsgBoxStyle.YesNo, "Message")
        If ask = MsgBoxResult.Yes Then

            If conn.State = ConnectionState.Open Then
                conn.Close()

            End If
            conn.Open()

            cmd = conn.CreateCommand()
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "Delete from employee where NIC='" + txtNIC.Text + "'"
            cmd.ExecuteNonQuery()
            displaydate()
            MessageBox.Show("Person Detail was Deleted", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information)

        End If

    End Sub

    Private Sub txtA_Click(sender As Object, e As EventArgs) Handles txtA.Click

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click

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
            cmd.CommandText = "select  NIC from employee where NIC=" & i & ""
            cmd.ExecuteNonQuery()

            Dim dt As New DataTable()
            Dim da As New MySqlDataAdapter(cmd)
            da.Fill(dt)
            Dim dr As MySqlDataReader
            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            While dr.Read

                txtNIC.Text = dr.GetValue(0).ToString()


            End While

        Catch ex As Exception

        End Try

    End Sub

    Private Sub txtID_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNIC.KeyPress
        If (Asc(e.KeyChar) >= 48 And Asc(e.KeyChar) <= 57) Or Asc(e.KeyChar) = 46 Or Asc(e.KeyChar) = 8 Then
        Else
            e.Handled = True
        End If
        If txtNIC.Text.Length >= 10 Then
            MessageBox.Show("Only Type 10 Numbers", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtNIC.Text = txtNIC.Text
        End If
    End Sub

    Private Sub txtID_TextChanged(sender As Object, e As EventArgs) Handles txtNIC.TextChanged

    End Sub

    Private Sub txtMobile_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtMobile.KeyPress
        If (Asc(e.KeyChar) >= 48 And Asc(e.KeyChar) <= 57) Or Asc(e.KeyChar) = 46 Or Asc(e.KeyChar) = 8 Then
        Else
            e.Handled = True
        End If
        If txtMobile.Text.Length >= 10 Then
            MessageBox.Show("Only Type 10 Numbers", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtMobile.Text = txtMobile.Text
        End If
    End Sub

    Private Sub t_Click(sender As Object, e As EventArgs) Handles t.Click

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs)

    End Sub

    Private Sub Timer1_Tick_1(sender As Object, e As EventArgs)

    End Sub

    Private Sub Z(sender As Object, e As EventArgs)

    End Sub

    Private Sub Timer1_Tick_2(sender As Object, e As EventArgs) Handles Timer1.Tick
        lbldate.Text = Date.Now.ToString("dd-MM-yyy")
        lbltime.Text = Date.Now.ToString("hh-mm-ss")
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        FilterData(txtSearch.Text)
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboDepartment.SelectedIndexChanged

    End Sub

    Private Sub cboDesignation_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboDesignation.SelectedIndexChanged

    End Sub

    Private Sub BtnSearch_Click(sender As Object, e As EventArgs) Handles BtnSearch.Click
        FilterData(txtSearch.Text)
    End Sub

    Private Sub txtReset_Click(sender As Object, e As EventArgs) Handles txtReset.Click
        txtNIC.Clear()
        txtFirstname.Clear()
        txtSurname.Clear()
        txtPostCode.Clear()
        cboGender.Text = ""
        txtAddress.Clear()
        txtEmail.Clear()
        cboDepartment.Text = ""
        cboDesignation.Text = ""
        DateTimePicker1.Text = ""


    End Sub

    Private Sub txtMobile_TextChanged(sender As Object, e As EventArgs) Handles txtMobile.TextChanged

    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)

    End Sub

    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click

    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs)
        'Try
        '  Dim ofd As FileDialog = New OpenFileDialog()

        'ofd.Filter = "Image File(*.jpg;*.png;*.gif;*jpeg)|*.jpg*.png*.gif*jpeg"

        'If ofd.ShowDialog() = DialogResult.OK Then
        'imgpath = ofd.FileName
        'PictureBox1.ImageLocation = imgpath
        'End If

        'ofd = Nothing
        'Catch ex As Exception
        ' MsgBox(ex.Message.ToString())

        'End Try


    End Sub
End Class
