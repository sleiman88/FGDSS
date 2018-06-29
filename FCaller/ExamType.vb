Public Class ExamType

    Public Function getSelected() As String
        If Me.RadioButton_A.Checked Then
            Return "A"
        End If
        If Me.RadioButton_B.Checked Then
            Return "B"
        End If
        If Me.RadioButton_C.Checked Then
            Return "C"
        End If

        If Me.RadioButton_Err.Checked Then
            Return "error"
        End If
        Return ""
    End Function

    Public Sub setRadio(letter As String)
        Select Case letter
            Case "A"
                Me.RadioButton_A.Checked = True

            Case "B"
                Me.RadioButton_B.Checked = True
            Case "C"
                Me.RadioButton_C.Checked = True
            Case "error"
                Me.RadioButton_Err.Checked = True

        End Select
    End Sub


End Class
