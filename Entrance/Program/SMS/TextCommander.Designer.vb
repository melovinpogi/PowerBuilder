<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TextCommander
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.txtMessage = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblMsgLength = New System.Windows.Forms.Label()
        Me.txtSchedule = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnSend = New System.Windows.Forms.Button()
        Me.tblSend = New System.Windows.Forms.DataGridView()
        Me.cellphoneNumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.message = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.schedule = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.timestamp = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.status = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.messageSender = New System.ComponentModel.BackgroundWorker()
        Me.tblReceive = New System.Windows.Forms.DataGridView()
        Me.phoneNumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.message2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.timestamp2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.status2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lblMessage = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.sendProgress = New System.Windows.Forms.ProgressBar()
        Me.signalStrength = New System.Windows.Forms.ProgressBar()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtPhoneNumber = New System.Windows.Forms.TextBox()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        CType(Me.tblSend, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tblReceive, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.Location = New System.Drawing.Point(13, 9)
        Me.lblTitle.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(176, 25)
        Me.lblTitle.TabIndex = 0
        Me.lblTitle.Text = "Text Commander"
        '
        'txtMessage
        '
        Me.txtMessage.AcceptsReturn = True
        Me.txtMessage.AcceptsTab = True
        Me.txtMessage.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMessage.Location = New System.Drawing.Point(102, 79)
        Me.txtMessage.Multiline = True
        Me.txtMessage.Name = "txtMessage"
        Me.txtMessage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtMessage.Size = New System.Drawing.Size(343, 107)
        Me.txtMessage.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(16, 50)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(73, 20)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Send To:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(16, 78)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(78, 20)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Message:"
        '
        'lblMsgLength
        '
        Me.lblMsgLength.AutoSize = True
        Me.lblMsgLength.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMsgLength.Location = New System.Drawing.Point(33, 98)
        Me.lblMsgLength.Name = "lblMsgLength"
        Me.lblMsgLength.Size = New System.Drawing.Size(36, 13)
        Me.lblMsgLength.TabIndex = 5
        Me.lblMsgLength.Text = "0/160"
        '
        'txtSchedule
        '
        Me.txtSchedule.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSchedule.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.txtSchedule.Location = New System.Drawing.Point(102, 192)
        Me.txtSchedule.Name = "txtSchedule"
        Me.txtSchedule.Size = New System.Drawing.Size(343, 22)
        Me.txtSchedule.TabIndex = 6
        Me.txtSchedule.Value = New Date(2014, 8, 28, 10, 44, 37, 0)
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(16, 194)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(80, 20)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Schedule:"
        '
        'btnSend
        '
        Me.btnSend.Location = New System.Drawing.Point(20, 220)
        Me.btnSend.Name = "btnSend"
        Me.btnSend.Size = New System.Drawing.Size(425, 31)
        Me.btnSend.TabIndex = 8
        Me.btnSend.Text = "Send"
        Me.btnSend.UseVisualStyleBackColor = True
        '
        'tblSend
        '
        Me.tblSend.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tblSend.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.tblSend.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cellphoneNumber, Me.message, Me.schedule, Me.timestamp, Me.status})
        Me.tblSend.Location = New System.Drawing.Point(9, 286)
        Me.tblSend.Name = "tblSend"
        Me.tblSend.Size = New System.Drawing.Size(760, 213)
        Me.tblSend.TabIndex = 9
        '
        'cellphoneNumber
        '
        Me.cellphoneNumber.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.cellphoneNumber.HeaderText = "Cellphone Number"
        Me.cellphoneNumber.Name = "cellphoneNumber"
        '
        'message
        '
        Me.message.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.message.HeaderText = "Message"
        Me.message.Name = "message"
        '
        'schedule
        '
        Me.schedule.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.schedule.HeaderText = "Schedule"
        Me.schedule.Name = "schedule"
        '
        'timestamp
        '
        Me.timestamp.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.timestamp.HeaderText = "Date Added"
        Me.timestamp.Name = "timestamp"
        '
        'status
        '
        Me.status.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.status.HeaderText = "Status"
        Me.status.Name = "status"
        '
        'messageSender
        '
        Me.messageSender.WorkerSupportsCancellation = True
        '
        'tblReceive
        '
        Me.tblReceive.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tblReceive.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.tblReceive.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.phoneNumber, Me.message2, Me.timestamp2, Me.status2})
        Me.tblReceive.Location = New System.Drawing.Point(451, 79)
        Me.tblReceive.Name = "tblReceive"
        Me.tblReceive.Size = New System.Drawing.Size(318, 172)
        Me.tblReceive.TabIndex = 10
        Me.tblReceive.Visible = False
        '
        'phoneNumber
        '
        Me.phoneNumber.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.phoneNumber.HeaderText = "Cellphone Number"
        Me.phoneNumber.Name = "phoneNumber"
        '
        'message2
        '
        Me.message2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.message2.HeaderText = "Message"
        Me.message2.Name = "message2"
        '
        'timestamp2
        '
        Me.timestamp2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.timestamp2.HeaderText = "Date Received"
        Me.timestamp2.Name = "timestamp2"
        '
        'status2
        '
        Me.status2.HeaderText = "Processed"
        Me.status2.Name = "status2"
        Me.status2.ReadOnly = True
        '
        'lblMessage
        '
        Me.lblMessage.AutoSize = True
        Me.lblMessage.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMessage.Location = New System.Drawing.Point(196, 13)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(0, 16)
        Me.lblMessage.TabIndex = 11
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(5, 258)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(120, 20)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "Sent Messages"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(447, 50)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(152, 20)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "Received Messages"
        Me.Label6.Visible = False
        '
        'sendProgress
        '
        Me.sendProgress.Location = New System.Drawing.Point(454, 13)
        Me.sendProgress.Name = "sendProgress"
        Me.sendProgress.Size = New System.Drawing.Size(149, 23)
        Me.sendProgress.TabIndex = 14
        '
        'signalStrength
        '
        Me.signalStrength.Location = New System.Drawing.Point(672, 13)
        Me.signalStrength.MarqueeAnimationSpeed = 0
        Me.signalStrength.Name = "signalStrength"
        Me.signalStrength.Size = New System.Drawing.Size(100, 23)
        Me.signalStrength.TabIndex = 15
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(609, 14)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(53, 20)
        Me.Label7.TabIndex = 16
        Me.Label7.Text = "Signal"
        '
        'txtPhoneNumber
        '
        Me.txtPhoneNumber.Location = New System.Drawing.Point(102, 47)
        Me.txtPhoneNumber.Name = "txtPhoneNumber"
        Me.txtPhoneNumber.Size = New System.Drawing.Size(343, 26)
        Me.txtPhoneNumber.TabIndex = 0
        '
        'Timer1
        '
        '
        'TextCommander
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 511)
        Me.Controls.Add(Me.txtPhoneNumber)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.signalStrength)
        Me.Controls.Add(Me.sendProgress)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.lblMessage)
        Me.Controls.Add(Me.tblReceive)
        Me.Controls.Add(Me.tblSend)
        Me.Controls.Add(Me.btnSend)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtSchedule)
        Me.Controls.Add(Me.lblMsgLength)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtMessage)
        Me.Controls.Add(Me.lblTitle)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "TextCommander"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Text Commander"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.tblSend, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tblReceive, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents txtMessage As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblMsgLength As System.Windows.Forms.Label
    Friend WithEvents txtSchedule As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnSend As System.Windows.Forms.Button
    Friend WithEvents messageSender As System.ComponentModel.BackgroundWorker
    Friend WithEvents lblMessage As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents sendProgress As System.Windows.Forms.ProgressBar
    Friend WithEvents signalStrength As System.Windows.Forms.ProgressBar
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Public WithEvents tblReceive As System.Windows.Forms.DataGridView
    Public WithEvents tblSend As System.Windows.Forms.DataGridView
    Friend WithEvents cellphoneNumber As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents message As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents schedule As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents timestamp As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents status As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txtPhoneNumber As System.Windows.Forms.TextBox
    Friend WithEvents phoneNumber As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents message2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents timestamp2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents status2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Timer1 As System.Windows.Forms.Timer

End Class
