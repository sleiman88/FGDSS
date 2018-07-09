Imports System.Data.SqlClient
Imports System.IO

Public Class AnalyseAndReport
    Dim IdScan As String
    Dim myConn As MyConnection
    Dim CallerScan As Scans
    Public myQuerry As MyQuerry
    Sub New(IdScan As String, CallerScan As Scans)
        Me.IdScan = IdScan
        Me.CallerScan = CallerScan
        myConn = New MyConnection()
        CallerScan.Hide()
        ' This call is required by the designer.
        InitializeComponent()
        myQuerry = New MyQuerry()

        ' Add any initialization after the InitializeComponent() call.

    End Sub


    Private Sub AnalyseAndReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        FillTextbox()

        fillAllDataGrid()
    End Sub
    Public Sub FillTextbox()
        Dim NewGetErr As New getScanErreurs(IdScan)
        TextBox_TotalPaper.Text = NewGetErr.getTotalpapers().ToString
        'TextBox_PaperWithErreurs.Text = NewGetErr.getTotalPapersWithErreurs().ToString
        'TextBox_IdErreurs.Text = NewGetErr.getTotalPapersWithIdErreurs().ToString
        'TextBox_TypeErreur.Text = NewGetErr.getTotalPapersWithTypeExamErreurs().ToString
        '' TextBox_Good.Text = NewGetErr.getTotalGood().ToString
        ' TextBox_Good.Text = DataGridView_good.Item(1, 0).Value.ToString()
        'TextBox_Duplicated.Text = NewGetErr.getDuplicatedId().ToString
        'TextBox_duplicatedOtherScan.Text = NewGetErr.getDuplicatedWithOtherScan().ToString
    End Sub
    Public Sub fillAllDataGrid()
        fillMyDataGrid(DataGridView_good, myQuerry.getQuerryDataGridGood(IdScan), TextBox_Good)
        fillMyDataGrid(DataGridView_NotScanned, myQuerry.getQuerryDataGridNotScanned(IdScan), TextBox_PaperWithErreurs)
        fillMyDatagridWtihStoreProcedure(DataGridView_IdErrors, "getWithIdError", IdScan, TextBox_IdErreurs)
        'fillMyDataGrid(DataGridView_IdErrors, myQuerry.getQuerryDataGridIdErrors(IdScan), TextBox_IdErreurs)

        fillMyDataGrid(DataGridView_TypeErreur, myQuerry.getQuerryDataGridTypeExamError(IdScan), TextBox_TypeErreur)
        fillMyDataGrid(DataGridView_Duplicated, myQuerry.getQuerryDataGridDuplicated(IdScan), TextBox_Duplicated)
        fillMyDataGrid(DataGridView_DuplicatedWithOtherScan, myQuerry.getQuerryDataGridDuplicatedWithOtherScan(IdScan), TextBox_duplicatedOtherScan)
    End Sub
    Public Sub fillMyDataGrid(DataGridView As DataGridView, querry As String, MyTextBox As TextBox)

        Dim dsGrid As New DataSet()
        Dim sqlAdapter As SqlDataAdapter


        Dim cmd As New SqlCommand(querry)

        sqlAdapter = New SqlDataAdapter(cmd.CommandText, myConn.openConnection)

        sqlAdapter.Fill(dsGrid)
        DataGridView.ClearSelection()
        Dim Dtable As DataTable
        Dim result As Int32

        Dtable = dsGrid.Tables(0)

        If Dtable IsNot Nothing AndAlso Dtable.Rows.Count > 0 Then
            result = Dtable.Rows(0)("count")
        Else
            result = 0
        End If
        MyTextBox.Text = result.ToString


        DataGridView.DataSource = dsGrid.Tables(0)
        DataGridView.Columns("count").Visible = False


        myConn.closeConnection()


    End Sub

    Private Sub fillMyDatagridWtihStoreProcedure(DataGridView As DataGridView, NameStoreProcedure As String, IdScan As String, MyTextBox As TextBox)
        Try
            Dim dsGrid As New DataSet()
            Dim sqlAdapter As SqlDataAdapter
            Dim cmd As New SqlCommand(NameStoreProcedure)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = myConn.openConnection()
            cmd.Parameters.AddWithValue("@IdScan", IdScan)
            sqlAdapter = New SqlDataAdapter(cmd)

            sqlAdapter.Fill(dsGrid)
            DataGridView.ClearSelection()
            Dim Dtable As DataTable
            Dim result As Int32

            Dtable = dsGrid.Tables(0)

            If Dtable IsNot Nothing AndAlso Dtable.Rows.Count > 0 Then
                result = Dtable.Rows(0)("count")
            Else
                result = 0
            End If
            MyTextBox.Text = result.ToString


            DataGridView.DataSource = dsGrid.Tables(0)
            DataGridView.Columns("count").Visible = False


            myConn.closeConnection()

        Catch ex As Exception
            myConn.closeConnection()
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub Btn_Back_Click(sender As Object, e As EventArgs) Handles Btn_Back.Click
        Me.Hide()
        CallerScan.fillMyDataGrid()
        CallerScan.Show()
        Me.Close()
    End Sub

    Private Sub AnalyseAndReport_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        CallerScan.fillMyDataGrid()
        CallerScan.Show()
    End Sub

    Private Sub callImgVieweWithEdit(path As String, IdScan As String)
        If path = Nothing Then
        Else
            Dim NewViewEdit As ImgViewWithEdit
            NewViewEdit = New ImgViewWithEdit(path, IdScan, Me)
            NewViewEdit.Show()

        End If

    End Sub



    Private Sub callImgViewer(path As String)
        If path = Nothing Then
        Else
            Dim NewView As ImgViewer
            NewView = New ImgViewer(path)
            NewView.Show()

        End If

    End Sub

    Private Sub DataGridView_good_RowHeaderMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView_good.RowHeaderMouseDoubleClick
        If DataGridView_good.Item(0, e.RowIndex).Value IsNot Nothing Then
            callImgVieweWithEdit(DataGridView_good.Item(0, e.RowIndex).Value.ToString(), IdScan)
        End If


    End Sub

    Private Sub DataGridView_NotScanned_RowHeaderMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView_NotScanned.RowHeaderMouseDoubleClick
        If DataGridView_NotScanned.Item(0, e.RowIndex).Value IsNot Nothing Then
            callImgViewer(DataGridView_NotScanned.Item(0, e.RowIndex).Value.ToString())
        End If


    End Sub



    Private Sub DataGridView_IdErrors_RowHeaderMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView_IdErrors.RowHeaderMouseDoubleClick
        If DataGridView_IdErrors.Item(0, e.RowIndex).Value IsNot Nothing Then
            'callImgViewer(DataGridView_IdErrors.Item(0, e.RowIndex).Value.ToString())
            callImgVieweWithEdit(DataGridView_IdErrors.Item(0, e.RowIndex).Value.ToString(), IdScan)
        End If
    End Sub



    Private Sub DataGridView_TypeErreur_RowHeaderMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView_TypeErreur.RowHeaderMouseDoubleClick
        If DataGridView_TypeErreur.Item(0, e.RowIndex).Value IsNot Nothing Then
            callImgVieweWithEdit(DataGridView_TypeErreur.Item(0, e.RowIndex).Value.ToString(), IdScan)
        End If
    End Sub


    '------------------------
    Private Sub DataGridView_good_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView_good.CellContentDoubleClick
        If DataGridView_good.Item(0, e.RowIndex).Value IsNot Nothing Then
            callImgVieweWithEdit(DataGridView_good.Item(0, e.RowIndex).Value.ToString(), IdScan)
        End If
    End Sub

    Private Sub DataGridView_NotScanned_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView_NotScanned.CellContentDoubleClick
        If DataGridView_NotScanned.Item(0, e.RowIndex).Value IsNot Nothing Then
            callImgViewer(DataGridView_NotScanned.Item(0, e.RowIndex).Value.ToString())
        End If
    End Sub

    Private Sub DataGridView_IdErrors_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView_IdErrors.CellContentDoubleClick
        If DataGridView_IdErrors.Item(0, e.RowIndex).Value IsNot Nothing Then
            'callImgViewer(DataGridView_IdErrors.Item(0, e.RowIndex).Value.ToString())
            callImgVieweWithEdit(DataGridView_IdErrors.Item(0, e.RowIndex).Value.ToString(), IdScan)
        End If
    End Sub

    Private Sub DataGridView_TypeErreur_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView_TypeErreur.CellContentDoubleClick
        If DataGridView_TypeErreur.Item(0, e.RowIndex).Value IsNot Nothing Then
            callImgVieweWithEdit(DataGridView_TypeErreur.Item(0, e.RowIndex).Value.ToString(), IdScan)
        End If
    End Sub

    Private Sub DataGridView_Duplicated_RowHeaderMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView_Duplicated.RowHeaderMouseDoubleClick
        If DataGridView_Duplicated.Item(0, e.RowIndex).Value IsNot Nothing Then
            callImgVieweWithEdit(DataGridView_Duplicated.Item(0, e.RowIndex).Value.ToString(), IdScan)
        End If
    End Sub



    Private Sub DataGridView_Duplicated_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView_Duplicated.CellContentDoubleClick
        If DataGridView_Duplicated.Item(0, e.RowIndex).Value IsNot Nothing Then
            callImgVieweWithEdit(DataGridView_Duplicated.Item(0, e.RowIndex).Value.ToString(), IdScan)
        End If
    End Sub

    Private Sub Button_Grade_Click(sender As Object, e As EventArgs) Handles Button_Grade.Click
        'If checkIfGradedAlready(IdScan) = True Then
        'MessageBox.Show("this Scan is already Graded and Saved to DB ")
        ' Else
        'Call from grade and save to DB 

        calculateGradesAndInsert()
        changeScanGradedStatus(IdScan)

        '  End If
    End Sub

    Private Sub changeScanGradedStatus(IdScan As String)
        Try
            Dim querry As String
            querry = "Update Scan_tbl set GradedAlready_Scan ='True'  where 
 Id_Scan =" + IdScan + ";"

            Dim cmd As SqlCommand
            cmd = New SqlCommand(querry, myConn.openConnection())
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub calculateGradesAndInsert()
        deleteAllGrade()
        If String.Equals(TextBox_Good.Text, "0") Or TextBox_Good.Text Is Nothing Then
            MessageBox.Show("non papers to grade ")
        Else
            ProgressBar_Grade.Visible = True
            ProgressBar_Grade.Step = 1
            ProgressBar_Grade.Minimum = 0
            ProgressBar_Grade.Maximum = Convert.ToInt32(TextBox_Good.Text)
            Dim NewMyGrade As MyGrade
            NewMyGrade = New MyGrade(IdScan, Me)
        End If
        ProgressBar_Grade.Value = 0
        ProgressBar_Grade.Visible = False

        MessageBox.Show("Done !!")
    End Sub

    Private Sub deleteAllGrade()
        Try
            Dim querry As String
            querry = "delete from FinalAnswer_tbl
where Id_PaperOmr In
(
select t2.Id_PaperOmr  from PaperOmr_tbl  as t1 join FinalAnswer_tbl as t2 on 
t1.Id_PaperOmr =t2.Id_PaperOmr
where Id_Scan =" + IdScan + ")
"
            Dim cmd As SqlCommand
            cmd = New SqlCommand(querry, myConn.openConnection)
            cmd.ExecuteNonQuery()

        Catch ex As Exception
            MessageBox.Show("could not change check status ")

        End Try
    End Sub
    'Private Function changeGradeCheckStatus() As Boolean
    '    Try
    '        Dim querry As String
    '        querry = "UPDATE GradeCheck_tbl SET StatusGraded_GradeCheck = 'True' WHERE Id_Scan =" + IdScan + ";"
    '        Dim cmd As SqlCommand
    '        cmd = New SqlCommand(querry, myConn.openConnection)
    '        cmd.ExecuteNonQuery()
    '        Return True
    '    Catch ex As Exception
    '        MessageBox.Show("could not change check status ")
    '        Return False
    '    End Try
    'End Function


    Private Function checkIfGradedAlready(IdScan As String) As Boolean
        Try

            Dim cmd As SqlCommand
            cmd = New SqlCommand("select * from GradeCheck_tbl where  Id_Scan=" + IdScan + " and StatusGraded_GradeCheck='False';", myConn.openConnection())
            Dim reader As SqlDataReader

            reader = cmd.ExecuteReader()

            If reader.HasRows = True Then
                myConn.closeConnection()
                Return False
            End If
            reader.Close()
            myConn.closeConnection()
            Return True
        Catch ex As Exception

            myConn.closeConnection()

            MessageBox.Show(ex.Message)
            Return True
        End Try
    End Function

    Private Sub Btn_BrowseNotScanned_Click(sender As Object, e As EventArgs) Handles Btn_BrowseNotScanned.Click
        If checkIfNotScannedExist() = True Then
            Dim pathNotScanned As String
            pathNotScanned = getNotScannedOriginalPath(IdScan)
            DeleteDirectory(pathNotScanned)
            creatNotScannedFolder(pathNotScanned)
            copyNotScannedToFolder(pathNotScanned)
        Else
            MessageBox.Show("all Papers was scanned")
        End If


    End Sub

    Private Function checkIfNotScannedExist() As Boolean
        Dim result As Boolean
        result = False
        Try
            Dim querry = "Select Path_PaperOmr  From PaperOmr_tbl Where Id_Scan =" + IdScan + " And error_exit ='True' ;"
            Dim cmd As SqlCommand
            cmd = New SqlCommand(querry, myConn.openConnection())
            Dim reader As SqlDataReader

            reader = cmd.ExecuteReader()

            If reader.HasRows = True Then
                myConn.closeConnection()
                result = True
            End If
            reader.Close()
            myConn.closeConnection()

        Catch ex As Exception

            myConn.closeConnection()

            MessageBox.Show(ex.Message)
            Return result
        End Try
        Return result
    End Function


    Private Sub creatNotScannedFolder(Path As String)

        If (Not System.IO.Directory.Exists(Path)) Then
            System.IO.Directory.CreateDirectory(Path)
        End If
    End Sub

    Private Sub copyNotScannedToFolder(pathNotScanned As String)


        Try
            Dim Dtable As DataTable


            Dim cmd As SqlCommand
            Dim dsID As New DataSet()
            Dim sqlAdapter As SqlDataAdapter
            Dim querry As String
            Dim Path As String
            Dim index As Int32
            index = 0
            querry = "Select Path_PaperOmr  From PaperOmr_tbl Where Id_Scan =" + IdScan + " And error_exit ='True' ;"

            cmd = New SqlCommand(querry)
            dsID.Clear()

            sqlAdapter = New SqlDataAdapter(cmd.CommandText, myConn.openConnection)

            sqlAdapter.Fill(dsID)
            Dim fileName As String

            Dtable = dsID.Tables(0)
            For index = 0 To Dtable.Rows.Count - 1
                Path = Dtable.Rows(index)(0)

                Dim imgTemp = New Bitmap(Path)
                fileName = Path.Substring(Path.LastIndexOf("\") + 1, Path.Length - (Path.LastIndexOf("\") + 1))

                SyncLock (imgTemp) 'Puts a "lock" on the object to make sure it will not be used anywhere else.
                    imgTemp.Save(pathNotScanned + "\" + fileName)
                End SyncLock 'Release the lock so that other threads can access th

            Next

            myConn.closeConnection()
            Process.Start("explorer.exe", pathNotScanned)

            myConn.closeConnection()


        Catch ex As Exception
            myConn.closeConnection()
            MessageBox.Show(ex.Message)
        End Try






    End Sub
    Private Function getNotScannedOriginalPath(IdScan As String) As String
        Dim NotScannedPath As String
        NotScannedPath = ""
        Try
            Dim Dtable As DataTable

            Dim queryId As String
            Dim cmd As SqlCommand
            Dim dsID As New DataSet()
            Dim sqlAdapter As SqlDataAdapter
            queryId = "select top 1 Path_PaperOmr from PaperOmr_tbl  where Id_Scan=" + IdScan + ";"

            cmd = New SqlCommand(queryId)
            dsID.Clear()

            sqlAdapter = New SqlDataAdapter(cmd.CommandText, myConn.openConnection)

            sqlAdapter.Fill(dsID)


            Dtable = dsID.Tables(0)


            NotScannedPath = Dtable.Rows(0)(0)

            myConn.closeConnection()
            Dim index As Int32
            index = NotScannedPath.LastIndexOf("\")

            NotScannedPath = NotScannedPath.Substring(0, index)
            NotScannedPath = NotScannedPath + "\NotScanned"

        Catch ex As Exception
            myConn.closeConnection()
            MessageBox.Show(ex.Message)
        End Try
        Return NotScannedPath
    End Function
    Private Sub DeleteDirectory(path As String)
        If Directory.Exists(path) Then
            'Delete all files from the Directory
            For Each filepath As String In Directory.GetFiles(path)
                File.Delete(filepath)
            Next
            'Delete all child Directories
            For Each dir As String In Directory.GetDirectories(path)
                DeleteDirectory(dir)
            Next
            'Delete a Directory
            Directory.Delete(path)
        End If
    End Sub






    Public Function getIdScanFromImagPath(path As String) As String
        Dim result As String
        result = "0"
        Try
            Dim Dtable As DataTable


            Dim cmd As SqlCommand
            Dim dsID As New DataSet()
            Dim sqlAdapter As SqlDataAdapter
            Dim querry As String
            querry = "select Id_Scan from PaperOmr_tbl where ResolvedPath_PaperOmr ='" & path & "';"


            cmd = New SqlCommand(querry)
            dsID.Clear()

            sqlAdapter = New SqlDataAdapter(cmd.CommandText, myConn.openConnection)

            sqlAdapter.Fill(dsID)


            Dtable = dsID.Tables(0)

            If Dtable IsNot Nothing AndAlso Dtable.Rows.Count > 0 Then
                result = Dtable.Rows(0)(0)

            Else
                result = "0"
            End If
            myConn.closeConnection()

            Return result
        Catch ex As Exception
            myConn.closeConnection()
            MessageBox.Show(ex.Message)
            Return result
        End Try


        Return result
    End Function

    Private Sub DataGridView_DuplicatedWithOtherScan_RowHeaderMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView_DuplicatedWithOtherScan.RowHeaderMouseDoubleClick

        If DataGridView_DuplicatedWithOtherScan.Item(0, e.RowIndex).Value IsNot Nothing Then


            Dim Scan, Path As String
            Scan = ""
            Path = ""
            Scan = DataGridView_DuplicatedWithOtherScan.Rows(e.RowIndex).Cells(0).Value
            Path = DataGridView_DuplicatedWithOtherScan.Rows(e.RowIndex).Cells(1).Value
            If Scan = IdScan Then
                callImgVieweWithEdit(Path, IdScan)
            Else
                callImgViewer(Path)
            End If

        End If
    End Sub



End Class