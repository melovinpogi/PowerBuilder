Imports System.Configuration
Imports System.Data.SqlClient
Imports System
Imports System.IO.Ports
Imports System.Threading
Imports System.ComponentModel


Public Class TextCommander

    Dim commander As Commander
    Public WithEvents objSMS As New mCore.SMS
    Dim appSettings
    Dim dataSent As DataTable
    Dim dataReceive As DataTable
    Dim sqlConn As String

    Private WithEvents SMSPort As SerialPort
    Private SMSThread As Thread
    Private ReadThread As Thread
    Shared _Continue As Boolean = False
    Shared _ContSMS As Boolean = False
    Private _Wait As Boolean = False
    Shared _ReadPort As Boolean = False
    Public Event Sending(ByVal Done As Boolean)
    Public Event DataReceived(ByVal Message As String)
    'RESULT
    Dim result As String


    Private myConn As SqlConnection
    Private myCmd As SqlCommand
    Private myReader As SqlDataReader

    Private conn As SqlConnection
    Private dreader As SqlDataReader
    Private conn_server As String
    Private conn_user As String
    Private conn_pass As String
    Private conn_db As String

    Public Sub dbcon()
        conn_server = "(local)"
        conn_user = "sa"
        conn_pass = "AsAtyu2teb"
        conn_db = "textcomm"

        conn = New SqlConnection("server=" & conn_server & ";user=" & conn_user & ";password=" & conn_pass & ";database=" & conn_db)
        'Try
        '    With conn
        '        If .State = Data.ConnectionState.Open Then .Close()


        '        .Open()

        '    End With
        'Catch ex As Exception
        '    'msgbox(ex.Message.ToString)
        'End Try
    End Sub

    Public Function cmdcon(ByRef cmd As SqlCommand) As Integer
        Dim conn_status As Int16

check:
        conn_status = 0


        If conn.State = Data.ConnectionState.Open Then
            conn_status = 1
        End If

        If conn_status <> 1 Then

            If conn.State = Data.ConnectionState.Closed Or Data.ConnectionState.Broken Then
                conn.Close()
                conn.Open()
            End If

            GoTo check
        End If

        With cmd
            .Connection = conn
            dreader = .ExecuteReader

        End With

        Return 0
    End Function

    Public Function CountCharacter(ByVal value As String, ByVal ch As Char) As Integer
        Dim cnt As Integer = 0
        For Each c As Char In value
            If c = ch Then cnt += 1
        Next
        Return cnt
    End Function


 

    Private Sub txtMessage_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtMessage.KeyPress
        If e.KeyChar = Convert.ToChar(1) Then
            DirectCast(sender, TextBox).SelectAll()
            e.Handled = True
        End If
    End Sub

    Private Sub txtMessage_TextChanged(sender As Object, e As EventArgs) Handles txtMessage.TextChanged
        lblMsgLength.Text = txtMessage.Text.Length & "/160"
    End Sub

    Private Sub TextCommander_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        If objSMS.IsConnected Then
            objSMS.Disconnect()
        End If
    End Sub

    Private Sub TextCommander_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dim result As Integer = MessageBox.Show("Are you sure you want to exit?", "Exit Text Commander", MessageBoxButtons.YesNo)
        If result = DialogResult.Yes Then
            objSMS.Disconnect()
            LoadingScreen.lblProgress.Text = ""
            LoadingScreen.Show()
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub TextCommander_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CheckForIllegalCrossThreadCalls = False
        appSettings = ConfigurationManager.AppSettings

        txtSchedule.Format = DateTimePickerFormat.Custom
        txtSchedule.CustomFormat = "MMMM dd, yyyy - H:mm:ss"
        txtSchedule.Value = DateTime.Now

        sqlConn = "Initial Catalog=" & appSettings("database") & ";" & _
                "Data Source=" & appSettings("server") & ";Integrated Security=" & appSettings("security") & ";User ID=" & appSettings("username") & ";Password=" & appSettings("password") & "; MultipleActiveResultSets=True"
        commander = New Commander(sqlConn)

        commander.GetSent(Me.tblSend)
        commander.GetReceive(Me.tblReceive)

        lblTitle.Text = appSettings("appTitle")
        updateSignal()
        messageSender.RunWorkerAsync()
    End Sub

    'Private Function send(ByRef phoneNumber As String, ByRef message As String) As Boolean
    '    Dim sms As SMSPDULib.SMS = New SMSPDULib.SMS

    '    Try
    '        sms.Direction = SMSPDULib.SMSDirection.Submited
    '        sms.PhoneNumber = phoneNumber
    '        sms.ValidityPeriod = New TimeSpan(4, 0, 0, 0)
    '        sms.Message = message

    '        If message.Length < 160 Then
    '            sendProgress.Value = 40
    '            Dim msg As String = sms.Compose()
    '            sms.MessageEncoding = SMSPDULib.SMS.SMSEncoding._7bit
    '            objSMS.Command("AT")
    '            objSMS.Command("AT+CMGF=0")
    '            objSMS.Command("AT+CMGS=" & (msg.Length / 2 - 1))
    '            objSMS.Command(msg + Chr(26))
    '            sendProgress.Value = 90
    '        Else
    '            Dim longSMS() As String = sms.ComposeLongSMS()
    '            sendProgress.Value = 10

    '            For Each value As String In longSMS
    '                sms.MessageEncoding = SMSPDULib.SMS.SMSEncoding._7bit
    '                objSMS.Command("AT")
    '                objSMS.Command("AT+CMGF=0")
    '                objSMS.Command("AT+CMGS=" & (value.Length / 2 - 1))
    '                objSMS.Command(value + Chr(26))
    '            Next

    '            sendProgress.Value = 90
    '        End If

    '        Return True
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '        Return False
    '    Finally
    '        sendProgress.Value = 0
    '    End Try

    '    Return False
    'End Function

    Public Function send(ByRef phoneNumber As String, ByRef message As String) As Boolean
        Dim sms As SMSPDULib.SMS = New SMSPDULib.SMS

      

        Try
            sms.Direction = SMSPDULib.SMSDirection.Submited
            sms.PhoneNumber = phoneNumber
            sms.ValidityPeriod = New TimeSpan(4, 0, 0, 0)
            sms.Message = message

            If message.Length < 160 Then
                sendProgress.Value = 40
                Dim msg As String = sms.Compose()
                sms.MessageEncoding = SMSPDULib.SMS.SMSEncoding._7bit
                objSMS.Command("AT")
                objSMS.Command("AT+CMGF=0")
                objSMS.Command("AT+CMGS=" & (msg.Length / 2 - 1))
                result = objSMS.Command(msg + Chr(26))
                sendProgress.Value = 90
            Else
                Dim longSMS() As String = sms.ComposeLongSMS()
                sendProgress.Value = 10

                For Each value As String In longSMS
                    sms.MessageEncoding = SMSPDULib.SMS.SMSEncoding._7bit
                    objSMS.Command("AT")
                    objSMS.Command("AT+CMGF=0")
                    objSMS.Command("AT+CMGS=" & (value.Length / 2 - 1))

                    result = objSMS.Command(value + Chr(26))
                Next

                sendProgress.Value = 90
            End If

            ' RESULT
            ' MessageBox.Show(result)

            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        Finally
            sendProgress.Value = 0
        End Try

        Return False
    End Function

    Private Sub btnSend_Click(sender As Object, e As EventArgs) Handles btnSend.Click
        Dim phoneNumber As String = txtPhoneNumber.Text
        Dim message As String = txtMessage.Text
        Dim status As Boolean = True

        If phoneNumber.Trim.Length = 0 Then
            MsgBox("Please Enter Phone Number")
            txtPhoneNumber.Focus()
        Else
            btnSend.Enabled = False
            Try
                If (DateTime.Compare(DateTime.Now, txtSchedule.Value)) = 1 Then
                    status = send(phoneNumber, message)
                Else
                    status = False
                End If

                commander.InsertSend(phoneNumber, message, txtSchedule.Value.ToString(Constants.DATE_FORMAT), status)
                commander.GetSent(Me.tblSend)
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical)
            Finally
                sendProgress.Value = 0
                btnSend.Enabled = True
                txtPhoneNumber.Clear()
                txtMessage.Clear()
            End Try
        End If
    End Sub

    Private Sub sendMessages()
        Dim textid As Long
        Try
            dbcon()
            Dim cmd As New SqlCommand
            Dim cmd2 As New SqlCommand
            cmd = New SqlCommand("Select cellphonenumber,message,id from text_send where status = 0", conn)
            cmdcon(cmd)
            dreader.Read()
            ' MsgBox(dreader(2))
            txtPhoneNumber.Text = dreader(0)
            txtMessage.Text = dreader(1)
            textid = dreader(2)
            btnSend.PerformClick()

            If textid <> 0 Then
                Try
                    dbcon()
                    cmd2 = New SqlCommand("update text_send set status = 1 where id =" & textid, conn)
                    cmdcon(cmd2)
                Catch ex As Exception
                    MsgBox(ex.Message.ToString)
                End Try
            End If
            

        Catch ex As Exception
            dreader.Close()
            conn.Close()
        End Try



    End Sub

    '    Dim rs As SqlDataReader = cmd.ExecuteReader()

    '    While rs.Read
    '        If (DateTime.Compare(DateTime.Now, rs.GetValue(3).ToString)) = 1 Then
    '            If rs.GetValue(1).ToString.Length > 0 Then
    '                Dim status As Boolean = send(rs.GetValue(1).ToString, rs.GetValue(2).ToString)
    '                'Dim status As Boolean = True
    '                Dim cmd2 As New SqlCommand()
    '                cmd2.Connection = conn

    '                cmd2.CommandText = "pr_update_pending_text"
    '                cmd2.CommandType = CommandType.StoredProcedure

    '                cmd2.Parameters.AddWithValue("id", rs.GetValue(0).ToString)
    '                cmd2.Parameters.AddWithValue("status", status)

    '                cmd2.ExecuteNonQuery()

    '                If status Then
    '                    commander.GetSent(Me.tblSend)
    '                End If
    '            End If
    '        End If
    '    End While

    '    rs.Close()








    Private Sub messageSender_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles messageSender.DoWork
        While True
            System.Threading.Thread.Sleep(Constants.SENDER_INTERVAL)
            updateSignal()
            sendMessages()




        End While
    End Sub

    Private Sub processReceive()
        Dim conn As New SqlConnection(sqlConn)
        Try
            Using (conn)

                Dim cmd As New SqlCommand()

                cmd.Connection = conn

                cmd.CommandText = "pr_process_sms"
                cmd.CommandType = CommandType.StoredProcedure

                conn.Open()

                cmd.ExecuteNonQuery()
            End Using

        Catch ex As SqlException
            MsgBox(ex.Message)
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub


    Private Sub objSMS_NewMessageReceived(ByVal sender As Object, ByVal e As mCore.NewMessageReceivedEventArgs) Handles objSMS.NewMessageReceived
        commander.InsertReceive(e.Phone, e.TextMessage, e.TimeStamp)


        'CHECK IF PHILIPPINE NUMBER
        If e.Phone.Substring(0, 3) = Constants.PHONE_PREFIX Then
            processReceive()
        End If


        commander.GetSent(Me.tblSend)
        commander.GetReceive(Me.tblReceive)
    End Sub

    Private Sub updateSignal()
        signalStrength.Value = objSMS.SignalStrength
    End Sub

    Private Sub txtPhoneNumber_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles txtPhoneNumber.KeyPress
        If e.KeyChar <> ControlChars.Back Then
            e.Handled = Not (Char.IsDigit(e.KeyChar))
        End If
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Dim phoneNumber As String = txtPhoneNumber.Text
        Dim message As String = txtMessage.Text
        Dim status As Boolean = True

        If phoneNumber.Trim.Length = 0 Then
            Return
        Else
            btnSend.Enabled = False
            Try
                If (DateTime.Compare(DateTime.Now, txtSchedule.Value)) = 1 Then
                    status = send(phoneNumber, message)
                Else
                    status = False
                End If

                commander.InsertSend(phoneNumber, message, txtSchedule.Value.ToString(Constants.DATE_FORMAT), status)
                commander.GetSent(Me.tblSend)
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical)
            Finally
                sendProgress.Value = 0
                btnSend.Enabled = True
                txtPhoneNumber.Clear()
                txtMessage.Clear()
            End Try
        End If
    End Sub
End Class
