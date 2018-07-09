<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MainForm
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
        Me.components = New System.ComponentModel.Container()
        Me.ComboBox_ExamN = New System.Windows.Forms.ComboBox()
        Me.ExamstblBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.MyDataSet = New FCaller.MyDataSet()
        Me.ComboBox_Lang = New System.Windows.Forms.ComboBox()
        Me.Exams_tblTableAdapter = New FCaller.MyDataSetTableAdapters.Exams_tblTableAdapter()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Btn_NewExam = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TextBox_Path = New System.Windows.Forms.TextBox()
        Me.Button_browse = New System.Windows.Forms.Button()
        Me.Button_Start = New System.Windows.Forms.Button()
        Me.ProgressBar_Action = New System.Windows.Forms.ProgressBar()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TextBox_desc = New System.Windows.Forms.TextBox()
        Me.Button_GradeAndAnswers = New System.Windows.Forms.Button()
        Me.Button_AddNames = New System.Windows.Forms.Button()
        Me.Btn_Multi = New System.Windows.Forms.Button()
        CType(Me.ExamstblBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MyDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ComboBox_ExamN
        '
        Me.ComboBox_ExamN.DataSource = Me.ExamstblBindingSource
        Me.ComboBox_ExamN.DisplayMember = "Name_Exam"
        Me.ComboBox_ExamN.FormattingEnabled = True
        Me.ComboBox_ExamN.Location = New System.Drawing.Point(98, 15)
        Me.ComboBox_ExamN.Name = "ComboBox_ExamN"
        Me.ComboBox_ExamN.Size = New System.Drawing.Size(121, 21)
        Me.ComboBox_ExamN.TabIndex = 0
        Me.ComboBox_ExamN.ValueMember = "Name_Exam"
        '
        'ExamstblBindingSource
        '
        Me.ExamstblBindingSource.DataMember = "Exams_tbl"
        Me.ExamstblBindingSource.DataSource = Me.MyDataSet
        '
        'MyDataSet
        '
        Me.MyDataSet.DataSetName = "MyDataSet"
        Me.MyDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ComboBox_Lang
        '
        Me.ComboBox_Lang.FormattingEnabled = True
        Me.ComboBox_Lang.Location = New System.Drawing.Point(98, 54)
        Me.ComboBox_Lang.Name = "ComboBox_Lang"
        Me.ComboBox_Lang.Size = New System.Drawing.Size(121, 21)
        Me.ComboBox_Lang.TabIndex = 1
        '
        'Exams_tblTableAdapter
        '
        Me.Exams_tblTableAdapter.ClearBeforeFill = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(2, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(33, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Exam"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(2, 54)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Language"
        '
        'Btn_NewExam
        '
        Me.Btn_NewExam.Location = New System.Drawing.Point(273, 15)
        Me.Btn_NewExam.Name = "Btn_NewExam"
        Me.Btn_NewExam.Size = New System.Drawing.Size(75, 23)
        Me.Btn_NewExam.TabIndex = 4
        Me.Btn_NewExam.Text = "NewExam"
        Me.Btn_NewExam.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(2, 152)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(80, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Path to JPG file"
        '
        'TextBox_Path
        '
        Me.TextBox_Path.Enabled = False
        Me.TextBox_Path.Location = New System.Drawing.Point(98, 149)
        Me.TextBox_Path.Name = "TextBox_Path"
        Me.TextBox_Path.Size = New System.Drawing.Size(229, 20)
        Me.TextBox_Path.TabIndex = 6
        '
        'Button_browse
        '
        Me.Button_browse.Location = New System.Drawing.Point(357, 149)
        Me.Button_browse.Name = "Button_browse"
        Me.Button_browse.Size = New System.Drawing.Size(75, 23)
        Me.Button_browse.TabIndex = 7
        Me.Button_browse.Text = "Browse"
        Me.Button_browse.UseVisualStyleBackColor = True
        '
        'Button_Start
        '
        Me.Button_Start.Location = New System.Drawing.Point(357, 212)
        Me.Button_Start.Name = "Button_Start"
        Me.Button_Start.Size = New System.Drawing.Size(75, 23)
        Me.Button_Start.TabIndex = 8
        Me.Button_Start.Text = "Start"
        Me.Button_Start.UseVisualStyleBackColor = True
        '
        'ProgressBar_Action
        '
        Me.ProgressBar_Action.Location = New System.Drawing.Point(98, 212)
        Me.ProgressBar_Action.Name = "ProgressBar_Action"
        Me.ProgressBar_Action.Size = New System.Drawing.Size(229, 23)
        Me.ProgressBar_Action.TabIndex = 9
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(2, 108)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(60, 13)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Description"
        '
        'TextBox_desc
        '
        Me.TextBox_desc.Location = New System.Drawing.Point(98, 101)
        Me.TextBox_desc.Name = "TextBox_desc"
        Me.TextBox_desc.Size = New System.Drawing.Size(229, 20)
        Me.TextBox_desc.TabIndex = 11
        '
        'Button_GradeAndAnswers
        '
        Me.Button_GradeAndAnswers.Location = New System.Drawing.Point(384, 15)
        Me.Button_GradeAndAnswers.Name = "Button_GradeAndAnswers"
        Me.Button_GradeAndAnswers.Size = New System.Drawing.Size(138, 23)
        Me.Button_GradeAndAnswers.TabIndex = 12
        Me.Button_GradeAndAnswers.Text = "Grades And Answers"
        Me.Button_GradeAndAnswers.UseVisualStyleBackColor = True
        '
        'Button_AddNames
        '
        Me.Button_AddNames.Location = New System.Drawing.Point(384, 65)
        Me.Button_AddNames.Name = "Button_AddNames"
        Me.Button_AddNames.Size = New System.Drawing.Size(138, 23)
        Me.Button_AddNames.TabIndex = 13
        Me.Button_AddNames.Text = "Add Names From Excel"
        Me.Button_AddNames.UseVisualStyleBackColor = True
        '
        'Btn_Multi
        '
        Me.Btn_Multi.Location = New System.Drawing.Point(384, 103)
        Me.Btn_Multi.Name = "Btn_Multi"
        Me.Btn_Multi.Size = New System.Drawing.Size(138, 23)
        Me.Btn_Multi.TabIndex = 14
        Me.Btn_Multi.Text = "Start Analyse Multiple"
        Me.Btn_Multi.UseVisualStyleBackColor = True
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1460, 489)
        Me.Controls.Add(Me.Btn_Multi)
        Me.Controls.Add(Me.Button_AddNames)
        Me.Controls.Add(Me.Button_GradeAndAnswers)
        Me.Controls.Add(Me.TextBox_desc)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.ProgressBar_Action)
        Me.Controls.Add(Me.Button_Start)
        Me.Controls.Add(Me.Button_browse)
        Me.Controls.Add(Me.TextBox_Path)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Btn_NewExam)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ComboBox_Lang)
        Me.Controls.Add(Me.ComboBox_ExamN)
        Me.Name = "MainForm"
        Me.Text = "MainForm"
        CType(Me.ExamstblBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MyDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ComboBox_ExamN As ComboBox
    Friend WithEvents ComboBox_Lang As ComboBox
    Friend WithEvents MyDataSet As MyDataSet
    Friend WithEvents ExamstblBindingSource As BindingSource
    Friend WithEvents Exams_tblTableAdapter As MyDataSetTableAdapters.Exams_tblTableAdapter
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Btn_NewExam As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents TextBox_Path As TextBox
    Friend WithEvents Button_browse As Button
    Friend WithEvents Button_Start As Button
    Friend WithEvents ProgressBar_Action As ProgressBar
    Friend WithEvents Label4 As Label
    Friend WithEvents TextBox_desc As TextBox
    Friend WithEvents Button_GradeAndAnswers As Button
    Friend WithEvents Button_AddNames As Button
    Friend WithEvents Btn_Multi As Button
End Class
