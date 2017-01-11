Public Class LoadingScreen

    Private Sub LoadingScreen_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        getPorts()
    End Sub

    Private Sub getPorts()
        For Each sp As String In My.Computer.Ports.SerialPortNames
            listPort.Items.Add(sp)
        Next
    End Sub

    Private Sub btnConnect_Click(sender As Object, e As EventArgs) Handles btnConnect.Click
        Try
            lblProgress.Text = "Connecting to port " & listPort.SelectedItem
            TextCommander.objSMS.Port = listPort.SelectedItem
            TextCommander.objSMS.BaudRate = 9600
            TextCommander.objSMS.DataBits = 8
            TextCommander.objSMS.StopBits = 1
            TextCommander.objSMS.Parity = 0
            TextCommander.objSMS.FlowControl = 1

            TextCommander.objSMS.Connect()

            TextCommander.objSMS.NewMessageIndication = True
            TextCommander.objSMS.NewMessageConcatenate = True
            TextCommander.objSMS.AutoDeleteNewMessage = True

            lblProgress.Text = "Connected Successfully"
            Me.Hide()
            TextCommander.Show()

        Catch ex As mCore.GeneralException
            lblProgress.Text = ""
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            'LoadingScreen.Hide()
        End Try
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        TextCommander.objSMS.Disconnect()
        Me.Close()
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        getPorts()
    End Sub
End Class