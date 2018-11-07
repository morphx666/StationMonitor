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
        Me.CbStation = New System.Windows.Forms.ComboBox()
        Me.TbSamplingTime = New System.Windows.Forms.TrackBar()
        Me.BtnCancel = New System.Windows.Forms.Button()
        Me.BtnSave = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.RbRight = New System.Windows.Forms.RadioButton()
        Me.RbLeft = New System.Windows.Forms.RadioButton()
        Me.CbChannelMode = New System.Windows.Forms.ComboBox()
        Me.CbSources = New System.Windows.Forms.ComboBox()
        Me.CbDevices = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TbVolume = New NMixerProNET.VolumeFader()
        Me.Label5 = New System.Windows.Forms.Label()
        CType(Me.TbSamplingTime, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TbVolume, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cbStation
        '
        Me.CbStation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbStation.FormattingEnabled = True
        Me.CbStation.Location = New System.Drawing.Point(108, 14)
        Me.CbStation.Name = "cbStation"
        Me.CbStation.Size = New System.Drawing.Size(180, 23)
        Me.CbStation.TabIndex = 0
        '
        'tbSamplingTime
        '
        Me.TbSamplingTime.BackColor = System.Drawing.SystemColors.Control
        Me.TbSamplingTime.Location = New System.Drawing.Point(108, 114)
        Me.TbSamplingTime.Minimum = 1
        Me.TbSamplingTime.Name = "tbSamplingTime"
        Me.TbSamplingTime.Size = New System.Drawing.Size(353, 45)
        Me.TbSamplingTime.TabIndex = 4
        Me.TbSamplingTime.Value = 3
        '
        'btnCancel
        '
        Me.BtnCancel.Location = New System.Drawing.Point(377, 241)
        Me.BtnCancel.Name = "btnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(85, 30)
        Me.BtnCancel.TabIndex = 62
        Me.BtnCancel.Text = "Cancel"
        Me.BtnCancel.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.BtnSave.Location = New System.Drawing.Point(285, 242)
        Me.BtnSave.Name = "btnSave"
        Me.BtnSave.Size = New System.Drawing.Size(85, 30)
        Me.BtnSave.TabIndex = 61
        Me.BtnSave.Text = "Save"
        Me.BtnSave.UseVisualStyleBackColor = True
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
        Me.RbRight.Appearance = System.Windows.Forms.Appearance.Button
        Me.RbRight.Location = New System.Drawing.Point(383, 76)
        Me.RbRight.Name = "rbRight"
        Me.RbRight.Size = New System.Drawing.Size(79, 27)
        Me.RbRight.TabIndex = 60
        Me.RbRight.Text = "Right"
        Me.RbRight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.RbRight.UseVisualStyleBackColor = True
        '
        'rbLeft
        '
        Me.RbLeft.Appearance = System.Windows.Forms.Appearance.Button
        Me.RbLeft.Checked = True
        Me.RbLeft.Location = New System.Drawing.Point(299, 76)
        Me.RbLeft.Name = "rbLeft"
        Me.RbLeft.Size = New System.Drawing.Size(79, 27)
        Me.RbLeft.TabIndex = 60
        Me.RbLeft.TabStop = True
        Me.RbLeft.Text = "Left"
        Me.RbLeft.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.RbLeft.UseVisualStyleBackColor = True
        '
        'cbChannelMode
        '
        Me.CbChannelMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbChannelMode.FormattingEnabled = True
        Me.CbChannelMode.Items.AddRange(New Object() {"Single", "Dual"})
        Me.CbChannelMode.Location = New System.Drawing.Point(299, 45)
        Me.CbChannelMode.Name = "cbChannelMode"
        Me.CbChannelMode.Size = New System.Drawing.Size(163, 23)
        Me.CbChannelMode.TabIndex = 59
        '
        'cbSources
        '
        Me.CbSources.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbSources.FormattingEnabled = True
        Me.CbSources.Location = New System.Drawing.Point(108, 76)
        Me.CbSources.Name = "cbSources"
        Me.CbSources.Size = New System.Drawing.Size(180, 23)
        Me.CbSources.TabIndex = 3
        '
        'cbDevices
        '
        Me.CbDevices.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbDevices.FormattingEnabled = True
        Me.CbDevices.Location = New System.Drawing.Point(108, 45)
        Me.CbDevices.Name = "cbDevices"
        Me.CbDevices.Size = New System.Drawing.Size(180, 23)
        Me.CbDevices.TabIndex = 2
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
        Me.TbVolume.CoreAudioControl = Nothing
        Me.TbVolume.IntegralChanges = True
        Me.TbVolume.Location = New System.Drawing.Point(94, 182)
        Me.TbVolume.Name = "tbVolume"
        Me.TbVolume.PeakLevel = 0
        Me.TbVolume.Size = New System.Drawing.Size(380, 45)
        Me.TbVolume.TabIndex = 63
        Me.TbVolume.TickStyle = System.Windows.Forms.TickStyle.TopLeft
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
        Me.Controls.Add(Me.TbVolume)
        Me.Controls.Add(Me.CbStation)
        Me.Controls.Add(Me.TbSamplingTime)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.BtnCancel)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.BtnSave)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.CbDevices)
        Me.Controls.Add(Me.RbRight)
        Me.Controls.Add(Me.CbSources)
        Me.Controls.Add(Me.RbLeft)
        Me.Controls.Add(Me.CbChannelMode)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "MonitorSetup"
        Me.Text = "Monitor Setup"
        CType(Me.TbSamplingTime, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TbVolume, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CbStation As ComboBox
    Friend WithEvents TbSamplingTime As TrackBar
    Friend WithEvents BtnCancel As Button
    Friend WithEvents BtnSave As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents RbRight As RadioButton
    Friend WithEvents RbLeft As RadioButton
    Friend WithEvents CbChannelMode As ComboBox
    Friend WithEvents CbSources As ComboBox
    Friend WithEvents CbDevices As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents TbVolume As NMixerProNET.VolumeFader
    Friend WithEvents Label5 As Label
End Class
