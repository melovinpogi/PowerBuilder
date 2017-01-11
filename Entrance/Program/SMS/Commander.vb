Imports System.Data.SqlClient

Public Class Commander

    Private myConn As SqlConnection
    Private myCmd As SqlCommand
    Private myReader As SqlDataReader

    Public Sub New(ByVal connectionString)
        myConn = New SqlConnection(connectionString)
    End Sub


    Public Sub InsertSend(ByVal phoneNumber, ByVal message, ByVal schedule, Optional ByVal status = 0)
        Dim myCmd As New SqlCommand

        With myCmd
            .Connection = myConn
            .CommandType = CommandType.Text
            .CommandText = "INSERT INTO dbo.text_send(cellphoneNumber, message, schedule, timestamp, status) VALUES(@cellphoneNumber, @message, @schedule, @timestamp, @status)"
            .Parameters.AddWithValue("@cellphoneNumber", phoneNumber)
            .Parameters.AddWithValue("@message", message)
            .Parameters.AddWithValue("@schedule", schedule)
            .Parameters.AddWithValue("@timestamp", DateTime.Now.ToString(Constants.DATE_FORMAT))
            .Parameters.AddWithValue("@status", status)
        End With

        Try
            myConn.Open()
            myCmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        Finally
            myConn.Close()
        End Try

    End Sub

    Public Sub GetSent(ByRef tblSend As DataGridView)
        Try
            myConn.Open()
            Dim sql As String = "SELECT cellphoneNumber AS 'Phone Number', message AS Message, schedule AS Schedule, timestamp AS Time, " & _
            "'Status' = CASE status WHEN 0 THEN 'Pending' WHEN 1 THEN 'Sent' End FROM dbo.text_send ORDER BY timestamp DESC"

            Dim cmd As New SqlCommand(sql, myConn)
            cmd.CommandType = CommandType.Text

            Dim rs As SqlDataReader = cmd.ExecuteReader()
            tblSend.Rows.Clear()
            While rs.Read
                With tblSend.Rows.Add(rs.GetValue(0).ToString, rs.GetValue(1).ToString, rs.GetValue(2).ToString, rs.GetValue(3).ToString, rs.GetValue(4).ToString)
                End With
            End While

            tblSend.AutoResizeColumns()

            rs.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            myConn.Close()
        End Try
    End Sub

    Public Sub GetReceive(ByRef tblReceive As DataGridView)
        Try
            myConn.Open()
            Dim sql As String = "SELECT sender AS 'Phone Number', message AS Message, timestamp AS Time, 'Status' = CASE processed WHEN 0 THEN 'Pending' WHEN 1 THEN 'Processed' End , id FROM dbo.text_receive ORDER BY timestamp DESC"

            Dim cmd As New SqlCommand(sql, myConn)
            cmd.CommandType = CommandType.Text

            Dim rs As SqlDataReader = cmd.ExecuteReader()

            tblReceive.Rows.Clear()
            While rs.Read
                With tblReceive.Rows.Add(rs.GetValue(0).ToString, rs.GetValue(1).ToString, rs.GetValue(2).ToString, rs.GetValue(3).ToString, rs.GetValue(4))
                End With
            End While

            tblReceive.AutoResizeColumns()

            rs.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            myConn.Close()
        End Try
    End Sub

    Public Sub InsertReceive(ByVal phoneNumber, ByVal message, ByVal timestamp)
        Dim myCmd As New SqlCommand

        With myCmd
            .Connection = myConn
            .CommandType = CommandType.Text
            .CommandText = "INSERT INTO dbo.text_receive(sender, message, timestamp, processed) VALUES(@cellphoneNumber, @message, @timestamp, @processed)"
            .Parameters.AddWithValue("@cellphoneNumber", phoneNumber)
            .Parameters.AddWithValue("@message", message)
            .Parameters.AddWithValue("@timestamp", DateTime.Now.ToString(Constants.DATE_FORMAT))
            .Parameters.AddWithValue("@processed", 0)
        End With

        Try
            myConn.Open()
            myCmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        Finally
            myConn.Close()
        End Try
    End Sub


End Class
