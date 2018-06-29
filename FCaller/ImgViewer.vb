Public Class ImgViewer
    Sub New(path As String)
        InitializeComponent()

        Dim img As Bitmap
            img = New Bitmap(path, True)
            PictureBox1.Image = img
            TextBox_Path.Text = path


        ' This call is required by the designer.


        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub ImgViewer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
    End Sub




End Class