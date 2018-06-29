<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ExamType
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.RadioButton_Err = New System.Windows.Forms.RadioButton()
        Me.RadioButton_C = New System.Windows.Forms.RadioButton()
        Me.RadioButton_B = New System.Windows.Forms.RadioButton()
        Me.RadioButton_A = New System.Windows.Forms.RadioButton()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.RadioButton_Err)
        Me.GroupBox1.Controls.Add(Me.RadioButton_C)
        Me.GroupBox1.Controls.Add(Me.RadioButton_B)
        Me.GroupBox1.Controls.Add(Me.RadioButton_A)
        Me.GroupBox1.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(109, 62)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(72, 14)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(17, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Er"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(55, 14)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(14, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "C"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(35, 14)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(13, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "B"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(15, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(14, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "A"
        '
        'RadioButton_Err
        '
        Me.RadioButton_Err.AutoSize = True
        Me.RadioButton_Err.Location = New System.Drawing.Point(75, 30)
        Me.RadioButton_Err.Name = "RadioButton_Err"
        Me.RadioButton_Err.Size = New System.Drawing.Size(14, 13)
        Me.RadioButton_Err.TabIndex = 3
        Me.RadioButton_Err.TabStop = True
        Me.RadioButton_Err.UseVisualStyleBackColor = True
        '
        'RadioButton_C
        '
        Me.RadioButton_C.AutoSize = True
        Me.RadioButton_C.Location = New System.Drawing.Point(55, 30)
        Me.RadioButton_C.Name = "RadioButton_C"
        Me.RadioButton_C.Size = New System.Drawing.Size(14, 13)
        Me.RadioButton_C.TabIndex = 2
        Me.RadioButton_C.TabStop = True
        Me.RadioButton_C.UseVisualStyleBackColor = True
        '
        'RadioButton_B
        '
        Me.RadioButton_B.AutoSize = True
        Me.RadioButton_B.Location = New System.Drawing.Point(35, 30)
        Me.RadioButton_B.Name = "RadioButton_B"
        Me.RadioButton_B.Size = New System.Drawing.Size(14, 13)
        Me.RadioButton_B.TabIndex = 1
        Me.RadioButton_B.TabStop = True
        Me.RadioButton_B.UseVisualStyleBackColor = True
        '
        'RadioButton_A
        '
        Me.RadioButton_A.AutoSize = True
        Me.RadioButton_A.Location = New System.Drawing.Point(15, 30)
        Me.RadioButton_A.Name = "RadioButton_A"
        Me.RadioButton_A.Size = New System.Drawing.Size(14, 13)
        Me.RadioButton_A.TabIndex = 0
        Me.RadioButton_A.TabStop = True
        Me.RadioButton_A.UseVisualStyleBackColor = True
        '
        'ExamType
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "ExamType"
        Me.Size = New System.Drawing.Size(115, 69)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents RadioButton_Err As RadioButton
    Friend WithEvents RadioButton_C As RadioButton
    Friend WithEvents RadioButton_B As RadioButton
    Friend WithEvents RadioButton_A As RadioButton
End Class
