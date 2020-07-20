<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GradeAndAnswers
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
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Btn_result = New System.Windows.Forms.Button()
        Me.DataGridView_Exam = New System.Windows.Forms.DataGridView()
        Me.Btn_AddAnswers = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.MyDataSet = New FCaller.MyDataSet()
        Me.ExamsLanguageBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Exams_LanguageTableAdapter = New FCaller.MyDataSetTableAdapters.Exams_LanguageTableAdapter()
        Me.btn_EditAnswers = New System.Windows.Forms.Button()
        CType(Me.DataGridView_Exam, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MyDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ExamsLanguageBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(0, 2)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Back"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Btn_result
        '
        Me.Btn_result.Location = New System.Drawing.Point(512, 303)
        Me.Btn_result.Name = "Btn_result"
        Me.Btn_result.Size = New System.Drawing.Size(114, 23)
        Me.Btn_result.TabIndex = 1
        Me.Btn_result.Text = "Result"
        Me.Btn_result.UseVisualStyleBackColor = True
        '
        'DataGridView_Exam
        '
        Me.DataGridView_Exam.AllowUserToAddRows = False
        Me.DataGridView_Exam.AllowUserToDeleteRows = False
        Me.DataGridView_Exam.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView_Exam.Location = New System.Drawing.Point(12, 67)
        Me.DataGridView_Exam.Name = "DataGridView_Exam"
        Me.DataGridView_Exam.ReadOnly = True
        Me.DataGridView_Exam.Size = New System.Drawing.Size(494, 259)
        Me.DataGridView_Exam.TabIndex = 2
        '
        'Btn_AddAnswers
        '
        Me.Btn_AddAnswers.Enabled = False
        Me.Btn_AddAnswers.Location = New System.Drawing.Point(512, 30)
        Me.Btn_AddAnswers.Name = "Btn_AddAnswers"
        Me.Btn_AddAnswers.Size = New System.Drawing.Size(114, 23)
        Me.Btn_AddAnswers.TabIndex = 3
        Me.Btn_AddAnswers.Text = "Add Answers"
        Me.Btn_AddAnswers.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(21, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(119, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Exams Missing Answers"
        '
        'MyDataSet
        '
        Me.MyDataSet.DataSetName = "MyDataSet"
        Me.MyDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ExamsLanguageBindingSource
        '
        Me.ExamsLanguageBindingSource.DataMember = "Exams_Language"
        Me.ExamsLanguageBindingSource.DataSource = Me.MyDataSet
        '
        'Exams_LanguageTableAdapter
        '
        Me.Exams_LanguageTableAdapter.ClearBeforeFill = True
        '
        'btn_EditAnswers
        '
        Me.btn_EditAnswers.Location = New System.Drawing.Point(512, 81)
        Me.btn_EditAnswers.Name = "btn_EditAnswers"
        Me.btn_EditAnswers.Size = New System.Drawing.Size(114, 23)
        Me.btn_EditAnswers.TabIndex = 6
        Me.btn_EditAnswers.Text = "Edit Answers"
        Me.btn_EditAnswers.UseVisualStyleBackColor = True
        '
        'GradeAndAnswers
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(638, 338)
        Me.Controls.Add(Me.btn_EditAnswers)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Btn_AddAnswers)
        Me.Controls.Add(Me.DataGridView_Exam)
        Me.Controls.Add(Me.Btn_result)
        Me.Controls.Add(Me.Button1)
        Me.Name = "GradeAndAnswers"
        Me.Text = "GradeAndAnswers"
        CType(Me.DataGridView_Exam, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MyDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ExamsLanguageBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Button1 As Button
    Friend WithEvents Btn_result As Button
    Friend WithEvents DataGridView_Exam As DataGridView
    Friend WithEvents Btn_AddAnswers As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents MyDataSet As MyDataSet
    Friend WithEvents ExamsLanguageBindingSource As BindingSource
    Friend WithEvents Exams_LanguageTableAdapter As MyDataSetTableAdapters.Exams_LanguageTableAdapter
    Friend WithEvents btn_EditAnswers As Button
End Class
