<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FAddNewExam
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextBox_ExamName = New System.Windows.Forms.TextBox()
        Me.ComboBox_Lang = New System.Windows.Forms.ComboBox()
        Me.Button_save = New System.Windows.Forms.Button()
        Me.NewEx_Back = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(100, 67)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(76, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Name of Exam"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(100, 105)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(54, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Language"
        '
        'TextBox_ExamName
        '
        Me.TextBox_ExamName.Location = New System.Drawing.Point(182, 67)
        Me.TextBox_ExamName.Name = "TextBox_ExamName"
        Me.TextBox_ExamName.Size = New System.Drawing.Size(121, 20)
        Me.TextBox_ExamName.TabIndex = 3
        '
        'ComboBox_Lang
        '
        Me.ComboBox_Lang.FormattingEnabled = True
        Me.ComboBox_Lang.Items.AddRange(New Object() {"Francais", "Arabic", "English"})
        Me.ComboBox_Lang.Location = New System.Drawing.Point(182, 102)
        Me.ComboBox_Lang.Name = "ComboBox_Lang"
        Me.ComboBox_Lang.Size = New System.Drawing.Size(121, 21)
        Me.ComboBox_Lang.TabIndex = 4
        '
        'Button_save
        '
        Me.Button_save.Location = New System.Drawing.Point(363, 200)
        Me.Button_save.Name = "Button_save"
        Me.Button_save.Size = New System.Drawing.Size(75, 23)
        Me.Button_save.TabIndex = 5
        Me.Button_save.Text = "Save"
        Me.Button_save.UseVisualStyleBackColor = True
        '
        'NewEx_Back
        '
        Me.NewEx_Back.Location = New System.Drawing.Point(0, 0)
        Me.NewEx_Back.Name = "NewEx_Back"
        Me.NewEx_Back.Size = New System.Drawing.Size(75, 23)
        Me.NewEx_Back.TabIndex = 6
        Me.NewEx_Back.Text = "Back"
        Me.NewEx_Back.UseVisualStyleBackColor = True
        '
        'FAddNewExam
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(479, 261)
        Me.Controls.Add(Me.NewEx_Back)
        Me.Controls.Add(Me.Button_save)
        Me.Controls.Add(Me.ComboBox_Lang)
        Me.Controls.Add(Me.TextBox_ExamName)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "FAddNewExam"
        Me.Text = "New Exam"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents TextBox_ExamName As TextBox
    Friend WithEvents ComboBox_Lang As ComboBox
    Friend WithEvents Button_save As Button
    Friend WithEvents NewEx_Back As Button
End Class
