Imports System.Data.SqlClient
Imports Excel = Microsoft.Office.Interop.Excel
Public Class AddExcelNames
    Public Property xlWorkBook As Object
    Public Property xlWorkSheet As Object
    Dim myConn As MyConnection


    Private Sub AddExcelNames_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        OpenFileDialog1.Title = "Please select a Excel file"
        OpenFileDialog1.InitialDirectory = "C:\"
        OpenFileDialog1.Filter = "Excel Files|*.xls"
        myConn = New MyConnection()
    End Sub

    Private Sub Button_Browse_Click(sender As Object, e As EventArgs) Handles Button_Browse.Click
        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            TextBox_FilePath.Text = OpenFileDialog1.FileName

        End If
    End Sub

    Private Sub Button_InsertToDB_Click(sender As Object, e As EventArgs) Handles Button_InsertToDB.Click
        If TextBox_FilePath.Text.Length = 0 Then
            MessageBox.Show("Please choose a file first !!")
        Else

            Dim APP As New Excel.Application
            Dim worksheet As Excel.Worksheet
            Dim workbook As Excel.Workbook
            workbook = APP.Workbooks.Open(TextBox_FilePath.Text)
            worksheet = workbook.Worksheets("SQL Results")
            Dim Nbr(8817) As Integer
            Dim Name(8817) As String
            Dim NbrFixed(8817) As String
            ProgressBar1.Visible = True
            ProgressBar1.Minimum = 1
            ProgressBar1.Maximum = 17632
            ProgressBar1.Step = 1
            Dim k As Integer
            k = 1
            Dim temp As Integer
            For i = 2 To 8816
                temp = worksheet.Cells(i, 4).Value.ToString
                Name(k) = worksheet.Cells(i, 2).Value
                NbrFixed(k) = temp.ToString("D5")
                k = k + 1
                ProgressBar1.PerformStep()
                'My.Application.Log.WriteEntry(worksheet.Cells(i, 4).Value)
            Next
            workbook.Close()
            insertRowstoDB(NbrFixed, Name)
        End If


    End Sub
    Private Sub insertRowstoDB(Nbr() As String, Name() As String)
        Try
            Dim query As String
            Dim cmd As SqlCommand

            For k = 1 To 8815
                query = "INSERT INTO CandidatNames_tbl (CandidatNumber_Candidat,CandidatName_Candidat)
              VALUES('" + Nbr(k) + "','" + Name(k) + "');"
                My.Application.Log.WriteEntry(query)
                cmd = New SqlCommand(query, myConn.openConnection())
                cmd.ExecuteNonQuery()
                ProgressBar1.PerformStep()
            Next

            ProgressBar1.Visible = False
            MessageBox.Show("Done!")
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            myConn.closeConnection()
        End Try
        myConn.closeConnection()
    End Sub

End Class