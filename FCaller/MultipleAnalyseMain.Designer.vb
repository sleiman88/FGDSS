<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MultipleAnalyseMain
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
        Me.Button_Start = New System.Windows.Forms.Button()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.ComboBox_Lang = New System.Windows.Forms.ComboBox()
        Me.ComboBox_ExamN = New System.Windows.Forms.ComboBox()
        Me.ExamstblBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.MyDataSet = New FCaller.MyDataSet()
        Me.Btn_Back = New System.Windows.Forms.Button()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Exams_tblTableAdapter = New FCaller.MyDataSetTableAdapters.Exams_tblTableAdapter()
        Me.Filebrowser1 = New FCaller.Filebrowser()
        CType(Me.ExamstblBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MyDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button_Start
        '
        Me.Button_Start.Location = New System.Drawing.Point(1126, 519)
        Me.Button_Start.Name = "Button_Start"
        Me.Button_Start.Size = New System.Drawing.Size(169, 23)
        Me.Button_Start.TabIndex = 13
        Me.Button_Start.Text = "Start Multiple"
        Me.Button_Start.UseVisualStyleBackColor = True
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(116, 84)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(55, 13)
        Me.Label25.TabIndex = 70
        Me.Label25.Text = "Language"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(116, 45)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(33, 13)
        Me.Label26.TabIndex = 69
        Me.Label26.Text = "Exam"
        '
        'ComboBox_Lang
        '
        Me.ComboBox_Lang.FormattingEnabled = True
        Me.ComboBox_Lang.Location = New System.Drawing.Point(212, 84)
        Me.ComboBox_Lang.Name = "ComboBox_Lang"
        Me.ComboBox_Lang.Size = New System.Drawing.Size(121, 21)
        Me.ComboBox_Lang.TabIndex = 68
        '
        'ComboBox_ExamN
        '
        Me.ComboBox_ExamN.DataSource = Me.ExamstblBindingSource
        Me.ComboBox_ExamN.DisplayMember = "Name_Exam"
        Me.ComboBox_ExamN.FormattingEnabled = True
        Me.ComboBox_ExamN.Location = New System.Drawing.Point(212, 45)
        Me.ComboBox_ExamN.Name = "ComboBox_ExamN"
        Me.ComboBox_ExamN.Size = New System.Drawing.Size(121, 21)
        Me.ComboBox_ExamN.TabIndex = 67
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
        'Btn_Back
        '
        Me.Btn_Back.Location = New System.Drawing.Point(1, 0)
        Me.Btn_Back.Name = "Btn_Back"
        Me.Btn_Back.Size = New System.Drawing.Size(75, 23)
        Me.Btn_Back.TabIndex = 71
        Me.Btn_Back.Text = "Back"
        Me.Btn_Back.UseVisualStyleBackColor = True
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(396, 5)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(458, 20)
        Me.Label27.TabIndex = 72
        Me.Label27.Text = "Please Note all Folders should Have same Exam and same type"
        '
        'Exams_tblTableAdapter
        '
        Me.Exams_tblTableAdapter.ClearBeforeFill = True
        '
        'Filebrowser1
        '
        Me.Filebrowser1.Location = New System.Drawing.Point(12, 134)
        Me.Filebrowser1.Name = "Filebrowser1"
        Me.Filebrowser1.Size = New System.Drawing.Size(1027, 30)
        Me.Filebrowser1.TabIndex = 73
        '
        'MultipleAnalyseMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1352, 584)
        Me.Controls.Add(Me.Filebrowser1)
        Me.Controls.Add(Me.Label27)
        Me.Controls.Add(Me.Btn_Back)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.Label26)
        Me.Controls.Add(Me.ComboBox_Lang)
        Me.Controls.Add(Me.ComboBox_ExamN)
        Me.Controls.Add(Me.Button_Start)
        Me.Name = "MultipleAnalyseMain"
        Me.Text = "MultipleAnalyseMain"
        CType(Me.ExamstblBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MyDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button_Start As Button
    Friend WithEvents Label25 As Label
    Friend WithEvents Label26 As Label
    Friend WithEvents ComboBox_Lang As ComboBox
    Friend WithEvents ComboBox_ExamN As ComboBox
    Friend WithEvents Btn_Back As Button
    Friend WithEvents Label27 As Label
    Friend WithEvents MyDataSet As MyDataSet
    Friend WithEvents ExamstblBindingSource As BindingSource
    Friend WithEvents Exams_tblTableAdapter As MyDataSetTableAdapters.Exams_tblTableAdapter
    Friend WithEvents Filebrowser1 As Filebrowser
End Class
