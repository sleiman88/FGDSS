<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class AddExcelNames
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.Button_Browse = New System.Windows.Forms.Button()
        Me.TextBox_FilePath = New System.Windows.Forms.TextBox()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.Button_InsertToDB = New System.Windows.Forms.Button()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.SuspendLayout()
        '
        'Button_Browse
        '
        Me.Button_Browse.Location = New System.Drawing.Point(403, 38)
        Me.Button_Browse.Name = "Button_Browse"
        Me.Button_Browse.Size = New System.Drawing.Size(75, 23)
        Me.Button_Browse.TabIndex = 0
        Me.Button_Browse.Text = "Browse"
        Me.Button_Browse.UseVisualStyleBackColor = True
        '
        'TextBox_FilePath
        '
        Me.TextBox_FilePath.Enabled = False
        Me.TextBox_FilePath.Location = New System.Drawing.Point(13, 38)
        Me.TextBox_FilePath.Name = "TextBox_FilePath"
        Me.TextBox_FilePath.Size = New System.Drawing.Size(368, 20)
        Me.TextBox_FilePath.TabIndex = 1
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'Button_InsertToDB
        '
        Me.Button_InsertToDB.Location = New System.Drawing.Point(403, 91)
        Me.Button_InsertToDB.Name = "Button_InsertToDB"
        Me.Button_InsertToDB.Size = New System.Drawing.Size(81, 23)
        Me.Button_InsertToDB.TabIndex = 2
        Me.Button_InsertToDB.Text = "Insert"
        Me.Button_InsertToDB.UseVisualStyleBackColor = True
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(13, 91)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(368, 23)
        Me.ProgressBar1.TabIndex = 3
        Me.ProgressBar1.Visible = False
        '
        'AddExcelNames
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(540, 277)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.Button_InsertToDB)
        Me.Controls.Add(Me.TextBox_FilePath)
        Me.Controls.Add(Me.Button_Browse)
        Me.Name = "AddExcelNames"
        Me.Text = "AddExcelNames"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Button_Browse As Button
    Friend WithEvents TextBox_FilePath As TextBox
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents Button_InsertToDB As Button
    Friend WithEvents ProgressBar1 As ProgressBar
End Class
