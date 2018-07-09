Public Class Filebrowser


    Private Sub Filebrowser_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.TextBox_Path.Enabled = False
        If Me.CheckBox_Enable.Enabled = False Then
            Me.Btn_browse.Enabled = False
            Me.TextBox_description.Enabled = False
        End If
    End Sub

    Private Sub CheckBox_Enable_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox_Enable.CheckedChanged
        If Me.CheckBox_Enable.Enabled = False Then
            Me.Btn_browse.Enabled = False
            Me.TextBox_description.Enabled = False
        Else
            Me.Btn_browse.Enabled = True
            Me.TextBox_description.Enabled = True

        End If
    End Sub
End Class
