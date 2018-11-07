<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MonitorSetup
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
        Me.cbStation = New System.Windows.Forms.ComboBox()
        Me.tbSamplingTime = New System.Windows.Forms.TrackBar()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.rbRight = New System.Windows.Forms.RadioButton()
        Me.rbLeft = New System.Windows.Forms.RadioButton()
        Me.cbChannelMode = New System.Windows.Forms.ComboBox()
        Me.cbSources = New System.Windows.Forms.ComboBox()
        Me.cbDevices = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tbVolume = New NMixerProNET.VolumeFader()
        Me.Label5 = New System.Windows.Forms.Label()
        CType(Me.tbSamplingTime, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbVolume, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cbStation
        '
        Me.cbStation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbStation.FormattingEnabled = True
        Me.cbStation.Location = New System.Drawing.Point(108, 14)
        Me.cbStation.Name = "cbStation"
        Me.cbStation.Size = New System.Drawing.Size(180, 23)
        Me.cbStation.TabIndex = 0
        '
        'tbSamplingTime
        '
        Me.tbSamplingTime.BackColor = System.Drawing.SystemColors.Control
        Me.tbSamplingTime.Location = New System.Drawing.Point(108, 114)
        Me.tbSamplingTime.Minimum = 1
        Me.tbSamplingTime.Name = "tbSamplingTime"
        Me.tbSamplingTime.Size = New System.Drawing.Size(353, 45)
        Me.tbSamplingTime.TabIndex = 4
        Me.tbSamplingTime.Value = 3
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(377, 241)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(85, 30)
        Me.btnCancel.TabIndex = 62
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(285, 242)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(85, 30)
        Me.btnSave.TabIndex = 61
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(13, 125)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(87, 15)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Sampling Time"
        '
        'rbRight
        '
        Me.rbRight.Appearance = System.Windows.Forms.Appearance.Button
        Me.rbRight.Location = New System.Drawing.Point(383, 76)
        Me.rbRight.Name = "rbRight"
        Me.rbRight.Size = New System.Drawing.Size(79, 27)
        Me.rbRight.TabIndex = 60
        Me.rbRight.Text = "Right"
        Me.rbRight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rbRight.UseVisualStyleBackColor = True
        '
        'rbLeft
        '
        Me.rbLeft.Appearance = System.Windows.Forms.Appearance.Button
        Me.rbLeft.Checked = True
        Me.rbLeft.Location = New System.Drawing.Point(299, 76)
        Me.rbLeft.Name = "rbLeft"
        Me.rbLeft.Size = New System.Drawing.Size(79, 27)
        Me.rbLeft.TabIndex = 60
        Me.rbLeft.TabStop = True
        Me.rbLeft.Text = "Left"
        Me.rbLeft.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rbLeft.UseVisualStyleBackColor = True
        '
        'cbChannelMode
        '
        Me.cbChannelMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbChannelMode.FormattingEnabled = True
        Me.cbChannelMode.Items.AddRange(New Object() {"Single", "Dual"})
        Me.cbChannelMode.Location = New System.Drawing.Point(299, 45)
        Me.cbChannelMode.Name = "cbChannelMode"
        Me.cbChannelMode.Size = New System.Drawing.Size(163, 23)
        Me.cbChannelMode.TabIndex = 59
        '
        'cbSources
        '
        Me.cbSources.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbSources.FormattingEnabled = True
        Me.cbSources.Location = New System.Drawing.Point(108, 76)
        Me.cbSources.Name = "cbSources"
        Me.cbSources.Size = New System.Drawing.Size(180, 23)
        Me.cbSources.TabIndex = 3
        '
        'cbDevices
        '
        Me.cbDevices.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbDevices.FormattingEnabled = True
        Me.cbDevices.Location = New System.Drawing.Point(108, 45)
        Me.cbDevices.Name = "cbDevices"
        Me.cbDevices.Size = New System.Drawing.Size(180, 23)
        Me.cbDevices.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 81)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(43, 15)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Source"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(13, 17)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 15)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Station"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 50)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(42, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Device"
        '
        'tbVolume
        '
        Me.tbVolume.CoreAudioControl = Nothing
        Me.tbVolume.IntegralChanges = True
        Me.tbVolume.Location = New System.Drawing.Point(94, 182)
        Me.tbVolume.Name = "tbVolume"
        Me.tbVolume.PeakLevel = 0
        Me.tbVolume.Size = New System.Drawing.Size(380, 45)
        Me.tbVolume.TabIndex = 63
        Me.tbVolume.TickStyle = System.Windows.Forms.TickStyle.TopLeft
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(14, 192)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(48, 15)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Volume"
        '
        'MonitorSetup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(477, 286)
        Me.ControlBox = False
        Me.Controls.Add(Me.tbVolume)
        Me.Controls.Add(Me.cbStation)
        Me.Controls.Add(Me.tbSamplingTime)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cbDevices)
        Me.Controls.Add(Me.rbRight)
        Me.Controls.Add(Me.cbSources)
        Me.Controls.Add(Me.rbLeft)
        Me.Controls.Add(Me.cbChannelMode)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "MonitorSetup"
        Me.Text = "Monitor Setup"
        CType(Me.tbSamplingTime, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbVolume, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cbStation As System.Windows.Forms.ComboBox
    Friend WithEvents tbSamplingTime As System.Windows.Forms.TrackBar
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents rbRight As System.Windows.Forms.RadioButton
    Friend WithEvents rbLeft As System.Windows.Forms.RadioButton
    Friend WithEvents cbChannelMode As System.Windows.Forms.ComboBox
    Friend WithEvents cbSources As System.Windows.Forms.ComboBox
    Friend WithEvents cbDevices As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tbVolume As NMixerProNET.VolumeFader
    Friend WithEvents Label5 As System.Windows.Forms.Label
End Class
