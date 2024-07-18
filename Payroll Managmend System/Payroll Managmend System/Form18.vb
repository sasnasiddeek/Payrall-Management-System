Imports MySql.Data.MySqlClient
Public Class Form18
    Dim conn As New MySqlConnection("server=localhost;user id=root;password=sasna1234;database=employee")
    Dim cmd As New MySqlCommand
    Private Sub Form18_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        displaydate()

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

    Private Sub txtsearch_TextChanged(sender As Object, e As EventArgs) Handles txtsearch.TextChanged
        FilterData(txtsearch.Text)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        FilterData(txtsearch.Text)
    End Sub
End Class

