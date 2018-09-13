<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class AnalyseAndReport
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
        Me.Btn_Back = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextBox_TotalPaper = New System.Windows.Forms.TextBox()
        Me.TextBox_PaperWithErreurs = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TextBox_IdErreurs = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TextBox_TypeErreur = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TextBox_Good = New System.Windows.Forms.TextBox()
        Me.DataGridView_good = New System.Windows.Forms.DataGridView()
        Me.DataGridView_NotScanned = New System.Windows.Forms.DataGridView()
        Me.DataGridView_IdErrors = New System.Windows.Forms.DataGridView()
        Me.DataGridView_TypeErreur = New System.Windows.Forms.DataGridView()
        Me.DataGridView_Duplicated = New System.Windows.Forms.DataGridView()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TextBox_Duplicated = New System.Windows.Forms.TextBox()
        Me.Button_Grade = New System.Windows.Forms.Button()
        Me.Btn_BrowseNotScanned = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TextBox_duplicatedOtherScan = New System.Windows.Forms.TextBox()
        Me.DataGridView_DuplicatedWithOtherScan = New System.Windows.Forms.DataGridView()
        Me.ProgressBar_Grade = New System.Windows.Forms.ProgressBar()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        CType(Me.DataGridView_good, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView_NotScanned, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView_IdErrors, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView_TypeErreur, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView_Duplicated, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView_DuplicatedWithOtherScan, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Btn_Back
        '
        Me.Btn_Back.Location = New System.Drawing.Point(3, 2)
        Me.Btn_Back.Name = "Btn_Back"
        Me.Btn_Back.Size = New System.Drawing.Size(75, 23)
        Me.Btn_Back.TabIndex = 0
        Me.Btn_Back.Text = "Back"
        Me.Btn_Back.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(95, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(67, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Total Papers"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(283, 61)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(104, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Papers Not Scanned"
        '
        'TextBox_TotalPaper
        '
        Me.TextBox_TotalPaper.Enabled = False
        Me.TextBox_TotalPaper.Location = New System.Drawing.Point(168, 12)
        Me.TextBox_TotalPaper.Name = "TextBox_TotalPaper"
        Me.TextBox_TotalPaper.Size = New System.Drawing.Size(47, 20)
        Me.TextBox_TotalPaper.TabIndex = 3
        '
        'TextBox_PaperWithErreurs
        '
        Me.TextBox_PaperWithErreurs.Enabled = False
        Me.TextBox_PaperWithErreurs.Location = New System.Drawing.Point(392, 58)
        Me.TextBox_PaperWithErreurs.Name = "TextBox_PaperWithErreurs"
        Me.TextBox_PaperWithErreurs.Size = New System.Drawing.Size(55, 20)
        Me.TextBox_PaperWithErreurs.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(547, 61)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(110, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Papers With Id Errors"
        '
        'TextBox_IdErreurs
        '
        Me.TextBox_IdErreurs.Enabled = False
        Me.TextBox_IdErreurs.Location = New System.Drawing.Point(666, 58)
        Me.TextBox_IdErreurs.Name = "TextBox_IdErreurs"
        Me.TextBox_IdErreurs.Size = New System.Drawing.Size(52, 20)
        Me.TextBox_IdErreurs.TabIndex = 6
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(812, 55)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(89, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "ExamType Errors"
        '
        'TextBox_TypeErreur
        '
        Me.TextBox_TypeErreur.Enabled = False
        Me.TextBox_TypeErreur.Location = New System.Drawing.Point(913, 55)
        Me.TextBox_TypeErreur.Name = "TextBox_TypeErreur"
        Me.TextBox_TypeErreur.Size = New System.Drawing.Size(51, 20)
        Me.TextBox_TypeErreur.TabIndex = 8
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(42, 58)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(68, 13)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Good Papers"
        '
        'TextBox_Good
        '
        Me.TextBox_Good.Enabled = False
        Me.TextBox_Good.Location = New System.Drawing.Point(112, 55)
        Me.TextBox_Good.Name = "TextBox_Good"
        Me.TextBox_Good.Size = New System.Drawing.Size(50, 20)
        Me.TextBox_Good.TabIndex = 10
        '
        'DataGridView_good
        '
        Me.DataGridView_good.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataGridView_good.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView_good.Location = New System.Drawing.Point(3, 81)
        Me.DataGridView_good.Name = "DataGridView_good"
        Me.DataGridView_good.Size = New System.Drawing.Size(249, 228)
        Me.DataGridView_good.TabIndex = 11
        '
        'DataGridView_NotScanned
        '
        Me.DataGridView_NotScanned.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataGridView_NotScanned.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView_NotScanned.Location = New System.Drawing.Point(258, 81)
        Me.DataGridView_NotScanned.Name = "DataGridView_NotScanned"
        Me.DataGridView_NotScanned.Size = New System.Drawing.Size(249, 228)
        Me.DataGridView_NotScanned.TabIndex = 12
        '
        'DataGridView_IdErrors
        '
        Me.DataGridView_IdErrors.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataGridView_IdErrors.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView_IdErrors.Location = New System.Drawing.Point(513, 81)
        Me.DataGridView_IdErrors.Name = "DataGridView_IdErrors"
        Me.DataGridView_IdErrors.Size = New System.Drawing.Size(249, 228)
        Me.DataGridView_IdErrors.TabIndex = 13
        '
        'DataGridView_TypeErreur
        '
        Me.DataGridView_TypeErreur.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataGridView_TypeErreur.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView_TypeErreur.Location = New System.Drawing.Point(768, 81)
        Me.DataGridView_TypeErreur.Name = "DataGridView_TypeErreur"
        Me.DataGridView_TypeErreur.Size = New System.Drawing.Size(249, 228)
        Me.DataGridView_TypeErreur.TabIndex = 14
        '
        'DataGridView_Duplicated
        '
        Me.DataGridView_Duplicated.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataGridView_Duplicated.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView_Duplicated.Location = New System.Drawing.Point(1034, 81)
        Me.DataGridView_Duplicated.Name = "DataGridView_Duplicated"
        Me.DataGridView_Duplicated.Size = New System.Drawing.Size(249, 228)
        Me.DataGridView_Duplicated.TabIndex = 15
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(1045, 61)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(71, 13)
        Me.Label6.TabIndex = 16
        Me.Label6.Text = "Duplicated ID"
        '
        'TextBox_Duplicated
        '
        Me.TextBox_Duplicated.Enabled = False
        Me.TextBox_Duplicated.Location = New System.Drawing.Point(1122, 55)
        Me.TextBox_Duplicated.Name = "TextBox_Duplicated"
        Me.TextBox_Duplicated.Size = New System.Drawing.Size(59, 20)
        Me.TextBox_Duplicated.TabIndex = 17
        '
        'Button_Grade
        '
        Me.Button_Grade.Location = New System.Drawing.Point(3, 344)
        Me.Button_Grade.Name = "Button_Grade"
        Me.Button_Grade.Size = New System.Drawing.Size(249, 23)
        Me.Button_Grade.TabIndex = 18
        Me.Button_Grade.Text = "Grade And Save to  DB"
        Me.Button_Grade.UseVisualStyleBackColor = True
        '
        'Btn_BrowseNotScanned
        '
        Me.Btn_BrowseNotScanned.Location = New System.Drawing.Point(258, 344)
        Me.Btn_BrowseNotScanned.Name = "Btn_BrowseNotScanned"
        Me.Btn_BrowseNotScanned.Size = New System.Drawing.Size(249, 23)
        Me.Btn_BrowseNotScanned.TabIndex = 19
        Me.Btn_BrowseNotScanned.Text = "Export Not Scanned"
        Me.Btn_BrowseNotScanned.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(1031, 328)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(150, 13)
        Me.Label7.TabIndex = 21
        Me.Label7.Text = "Duplicated with Previous Scan"
        '
        'TextBox_duplicatedOtherScan
        '
        Me.TextBox_duplicatedOtherScan.Enabled = False
        Me.TextBox_duplicatedOtherScan.Location = New System.Drawing.Point(1187, 321)
        Me.TextBox_duplicatedOtherScan.Name = "TextBox_duplicatedOtherScan"
        Me.TextBox_duplicatedOtherScan.Size = New System.Drawing.Size(54, 20)
        Me.TextBox_duplicatedOtherScan.TabIndex = 22
        '
        'DataGridView_DuplicatedWithOtherScan
        '
        Me.DataGridView_DuplicatedWithOtherScan.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataGridView_DuplicatedWithOtherScan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView_DuplicatedWithOtherScan.Location = New System.Drawing.Point(1034, 347)
        Me.DataGridView_DuplicatedWithOtherScan.Name = "DataGridView_DuplicatedWithOtherScan"
        Me.DataGridView_DuplicatedWithOtherScan.Size = New System.Drawing.Size(249, 228)
        Me.DataGridView_DuplicatedWithOtherScan.TabIndex = 23
        '
        'ProgressBar_Grade
        '
        Me.ProgressBar_Grade.Location = New System.Drawing.Point(3, 315)
        Me.ProgressBar_Grade.Name = "ProgressBar_Grade"
        Me.ProgressBar_Grade.Size = New System.Drawing.Size(249, 23)
        Me.ProgressBar_Grade.TabIndex = 24
        Me.ProgressBar_Grade.Visible = False
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(768, 347)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(240, 192)
        Me.DataGridView1.TabIndex = 25
        '
        'AnalyseAndReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1345, 720)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.ProgressBar_Grade)
        Me.Controls.Add(Me.DataGridView_DuplicatedWithOtherScan)
        Me.Controls.Add(Me.TextBox_duplicatedOtherScan)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Btn_BrowseNotScanned)
        Me.Controls.Add(Me.Button_Grade)
        Me.Controls.Add(Me.TextBox_Duplicated)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.DataGridView_Duplicated)
        Me.Controls.Add(Me.DataGridView_TypeErreur)
        Me.Controls.Add(Me.DataGridView_IdErrors)
        Me.Controls.Add(Me.DataGridView_NotScanned)
        Me.Controls.Add(Me.DataGridView_good)
        Me.Controls.Add(Me.TextBox_Good)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.TextBox_TypeErreur)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TextBox_IdErreurs)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TextBox_PaperWithErreurs)
        Me.Controls.Add(Me.TextBox_TotalPaper)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Btn_Back)
        Me.Name = "AnalyseAndReport"
        Me.Text = "AnalyseAndReport"
        CType(Me.DataGridView_good, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView_NotScanned, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView_IdErrors, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView_TypeErreur, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView_Duplicated, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView_DuplicatedWithOtherScan, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Btn_Back As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents TextBox_TotalPaper As TextBox
    Friend WithEvents TextBox_PaperWithErreurs As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents TextBox_IdErreurs As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents TextBox_TypeErreur As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents TextBox_Good As TextBox
    Friend WithEvents DataGridView_good As DataGridView
    Friend WithEvents DataGridView_NotScanned As DataGridView
    Friend WithEvents DataGridView_IdErrors As DataGridView
    Friend WithEvents DataGridView_TypeErreur As DataGridView
    Friend WithEvents DataGridView_Duplicated As DataGridView
    Friend WithEvents Label6 As Label
    Friend WithEvents TextBox_Duplicated As TextBox
    Friend WithEvents Button_Grade As Button
    Friend WithEvents Btn_BrowseNotScanned As Button
    Friend WithEvents Label7 As Label
    Friend WithEvents TextBox_duplicatedOtherScan As TextBox
    Friend WithEvents DataGridView_DuplicatedWithOtherScan As DataGridView
    Public WithEvents ProgressBar_Grade As ProgressBar
    Friend WithEvents DataGridView1 As DataGridView
End Class
