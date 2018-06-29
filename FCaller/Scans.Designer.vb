<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Scans
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
        Me.Btn_Back = New System.Windows.Forms.Button()
        Me.DataGridView_Scan = New System.Windows.Forms.DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Btn_finalAnalyse = New System.Windows.Forms.Button()
        CType(Me.DataGridView_Scan, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Btn_Back
        '
        Me.Btn_Back.Location = New System.Drawing.Point(0, 0)
        Me.Btn_Back.Name = "Btn_Back"
        Me.Btn_Back.Size = New System.Drawing.Size(75, 23)
        Me.Btn_Back.TabIndex = 0
        Me.Btn_Back.Text = "Back"
        Me.Btn_Back.UseVisualStyleBackColor = True
        '
        'DataGridView_Scan
        '
        Me.DataGridView_Scan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView_Scan.Location = New System.Drawing.Point(12, 53)
        Me.DataGridView_Scan.Name = "DataGridView_Scan"
        Me.DataGridView_Scan.Size = New System.Drawing.Size(566, 274)
        Me.DataGridView_Scan.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(35, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Scans"
        '
        'Btn_finalAnalyse
        '
        Me.Btn_finalAnalyse.Location = New System.Drawing.Point(407, 342)
        Me.Btn_finalAnalyse.Name = "Btn_finalAnalyse"
        Me.Btn_finalAnalyse.Size = New System.Drawing.Size(171, 23)
        Me.Btn_finalAnalyse.TabIndex = 3
        Me.Btn_finalAnalyse.Text = "Analyse and Final Result"
        Me.Btn_finalAnalyse.UseVisualStyleBackColor = True
        '
        'Scans
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(599, 377)
        Me.Controls.Add(Me.Btn_finalAnalyse)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DataGridView_Scan)
        Me.Controls.Add(Me.Btn_Back)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "Scans"
        Me.Text = "ResultAndGrades"
        CType(Me.DataGridView_Scan, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Btn_Back As Button
    Friend WithEvents DataGridView_Scan As DataGridView
    Friend WithEvents Label1 As Label
    Friend WithEvents Btn_finalAnalyse As Button
End Class
