
Imports System.Data.SqlClient

Public Class MyConnection
    Dim MySource = My.Settings.MyConnectionString
    Public conn As New SqlConnection("Data Source=" + MySource + ";Initial Catalog=FOmrExams;Integrated Security=True")

    Sub New()




    End Sub

    Public Function openConnection() As SqlConnection
        Try
            If conn.State = ConnectionState.Closed Then

                conn.Open()

            End If

        Catch ex As SqlException
            MessageBox.Show("connection error" + ex.Message)

            Return conn
        End Try

        Return conn
    End Function

    Public Function closeConnection() As Boolean
        Try
            If conn.State = ConnectionState.Open Then

                conn.Close()

            End If

        Catch ex As SqlException
            MessageBox.Show("connection error" + ex.Message)

            Return False
        End Try

        Return True
    End Function

    Public Function checkMyStatus() As Boolean


        If openConnection().State = ConnectionState.Open Then
            Return True


        Else
            Return False
        End If

    End Function


End Class
