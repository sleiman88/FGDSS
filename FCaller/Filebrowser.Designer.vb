<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Filebrowser
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBox_description = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextBox_Path = New System.Windows.Forms.TextBox()
        Me.Btn_browse = New System.Windows.Forms.Button()
        Me.CheckBox_Enable = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Description"
        '
        'TextBox_description
        '
        Me.TextBox_description.Location = New System.Drawing.Point(90, 4)
        Me.TextBox_description.Name = "TextBox_description"
        Me.TextBox_description.Size = New System.Drawing.Size(245, 20)
        Me.TextBox_description.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(372, 7)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Path To JPG Folder"
        '
        'TextBox_Path
        '
        Me.TextBox_Path.Location = New System.Drawing.Point(501, 3)
        Me.TextBox_Path.Name = "TextBox_Path"
        Me.TextBox_Path.Size = New System.Drawing.Size(331, 20)
        Me.TextBox_Path.TabIndex = 3
        '
        'Btn_browse
        '
        Me.Btn_browse.Location = New System.Drawing.Point(851, 3)
        Me.Btn_browse.Name = "Btn_browse"
        Me.Btn_browse.Size = New System.Drawing.Size(75, 23)
        Me.Btn_browse.TabIndex = 4
        Me.Btn_browse.Text = "Browse"
        Me.Btn_browse.UseVisualStyleBackColor = True
        '
        'CheckBox_Enable
        '
        Me.CheckBox_Enable.AutoSize = True
        Me.CheckBox_Enable.Location = New System.Drawing.Point(946, 9)
        Me.CheckBox_Enable.Name = "CheckBox_Enable"
        Me.CheckBox_Enable.Size = New System.Drawing.Size(59, 17)
        Me.CheckBox_Enable.TabIndex = 5
        Me.CheckBox_Enable.Text = "Enable"
        Me.CheckBox_Enable.UseVisualStyleBackColor = True
        '
        'Filebrowser
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.CheckBox_Enable)
        Me.Controls.Add(Me.Btn_browse)
        Me.Controls.Add(Me.TextBox_Path)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TextBox_description)
        Me.Controls.Add(Me.Label1)
        Me.Name = "Filebrowser"
        Me.Size = New System.Drawing.Size(1027, 30)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents TextBox_description As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents TextBox_Path As TextBox
    Friend WithEvents Btn_browse As Button
    Friend WithEvents CheckBox_Enable As CheckBox
End Class
