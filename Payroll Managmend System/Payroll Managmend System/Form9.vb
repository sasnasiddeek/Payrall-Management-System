
Imports MySql.Data.MySqlClient
Public Class Form9
    Dim conn As New MySqlConnection("server=localhost;user id=root;password=sasna1234;database=employee")
    Dim cmd As New MySqlCommand
    Private Sub Form9_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
        cmd.CommandText = "Select * From payment"
        cmd.ExecuteNonQuery()
        Dim dt As New DataTable()
        Dim da As New MySqlDataAdapter(cmd)
        da.Fill(dt)
        DataGridView1.DataSource = dt


    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        lbldate.Text = Date.Now.ToString("dd-MM-yyy")
        lbltime.Text = Date.Now.ToString("hh-mm-ss")
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles lbltime.Click

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles txtname.TextChanged

    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim sal As Double
        Dim hou As Double
        Dim con As Double
        Dim med As Double
        Dim tran As Double
        Dim util As Double
        Dim bonus As Double
        Dim gross As Double
        Dim net As Double
        Dim tax As Double

        sal = Convert.ToDecimal(txtsalary.Text)
        If CheckBox1.Checked = True Then
            hou = (35 / 100) * sal

        End If
        If CheckBox2.Checked = True Then
            con = (8.5 / 100) * sal

        End If
        If CheckBox3.Checked = True Then
            tran = (9 / 100) * sal

        End If
        If CheckBox4.Checked = True Then
            med = (7 / 100) * sal
        End If
        If CheckBox6.Checked Then
            util = (12 / 100) * sal

        End If
        If CheckBox5.Checked Then
            If cbobenifit.Text = "New Year Bonus" Then

                bonus = 3500

            End If
            If cbobenifit.Text = "Diwali Bouns" Then

                bonus = 5000


            End If
            If cbobenifit.Text = "Weekend Bouns" Then

                bonus = (1 / 100) * sal

            End If
            If cbobenifit.Text = "Overtime Bouns" Then

                bonus = 6500

            End If
        End If
        gross = bonus + hou + med + tran + con + util + sal
        tax = (15 / 100) * sal
        net = gross - tax
        txtgross.Text = Convert.ToDouble(gross)
        txtnet.Text = Convert.ToDouble(net)
        txttax.Text = Convert.ToDouble(tax)












    End Sub

    Private Sub btnclear_Click(sender As Object, e As EventArgs) Handles btnclear.Click
        txtgross.Clear()
        txtnet.Clear()
        txttax.Clear()
        cbobenifit.Text = ""
        cbodesignation.Text = ""
        txtsalary.Clear()
        txtname.Clear()
        txtNIC.Clear()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim ask As MsgBoxResult
        ask = MsgBox("Are you sure want to Delete this person details?", MsgBoxStyle.YesNo, "Message")
        If ask = MsgBoxResult.Yes Then

            If conn.State = ConnectionState.Open Then
                conn.Close()

            End If
            conn.Open()

            cmd = conn.CreateCommand()
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "Delete from payment where NIC='" + txtNIC.Text + "'"
            cmd.ExecuteNonQuery()
            displaydate()
            MessageBox.Show("Person Detail was Deleted", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information)

        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim ask As MsgBoxResult
        ask = MsgBox("Are you sure want to ADD this details?", MsgBoxStyle.YesNo, "Message")


        Try
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
            conn.Open()


            cmd = conn.CreateCommand()
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "insert into payment(NIC,EmployeeName,EmployeeDesignation,BesicSalary,Benifit,GrossPay,NetPay,TaxPay) values ('" & txtNIC.Text & "','" & txtname.Text & "','" & cbodesignation.Text & "','" & txtsalary.Text & "','" & cbobenifit.Text & "','" & txtgross.Text & "','" & txtnet.Text & "','" + txttax.Text + "')"
            cmd.ExecuteNonQuery()
            displaydate()
            MessageBox.Show("Data Inserted", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtNIC.Text = ""
            txtname.Text = ""
            cbodesignation.Text = ""
            txtsalary.Text = ""
            cbobenifit.Text = ""
            txtgross.Text = ""
            txtnet.Text = ""
            txttax.Text = ""


            conn.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message)

        End Try

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim ask As MsgBoxResult
        ask = MsgBox("Are you sure want to change the Person details?", MsgBoxStyle.YesNo, "Message")

        Try
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If

            conn.Open()

            cmd = conn.CreateCommand()
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "update payment set NIC='" + txtNIC.Text + "',EmployeeName='" + txtname.Text + "',EmployeeDessignation='" + cbodesignation.Text + "',BesicSalary='" + txtsalary.Text + "',Benifit='" + cbobenifit.Text + "',GrossPay='" + txtgross.Text + "',NetPay='" + txtnet.Text + "',TaxPay='" + txttax.Text + "' where NIC=" & txtNIC.Text & ""
            cmd.ExecuteNonQuery()
            displaydate()
            MessageBox.Show("Person details changed", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information)



        Catch ex As Exception
            MessageBox.Show("Data Not Update", "Messsage", MessageBoxButtons.OK, MessageBoxIcon.Question)


        End Try
    End Sub

    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click

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
            cmd.CommandText = "select  NIC,EmployeeName from payment where NIC=" & i & ""
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

    Private Sub txtgross_TextChanged(sender As Object, e As EventArgs) Handles txtgross.TextChanged

    End Sub

    Private Sub cbobenifit_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbobenifit.SelectedIndexChanged

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub DataGridView1_RowsDefaultCellStyleChanged(sender As Object, e As EventArgs) Handles DataGridView1.RowsDefaultCellStyleChanged

    End Sub

    Private Sub txttax_TextChanged(sender As Object, e As EventArgs) Handles txttax.TextChanged

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
End Class