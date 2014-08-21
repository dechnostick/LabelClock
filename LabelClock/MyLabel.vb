Public Class MyLabel : Inherits Label

    Public Sub New(ByVal x As Integer, ByVal y As Integer, ByVal text As String)
        Me.New()
        Me.Location = New Point(x, y)
        Me.Text = text
        Me.InitializeComponent()
    End Sub

    Public Sub New()
        MyBase.New()
        Me.AutoSize = True
        Me.BorderStyle = BorderStyle.FixedSingle
        Me.Cursor = Cursors.Hand
        Me.ForeColor = Color.Black
        Me.ImageAlign = ContentAlignment.MiddleCenter
        Me.DefaultColor()
    End Sub

    Public Sub DefaultColor()
        Me.BackColor = Color.FromArgb(&HB6, &HCA, &HEA)
    End Sub

    Public Sub SelectedColor()
        Me.BackColor = Color.FromArgb(&HD2, &HEE, &HC1)
    End Sub

    Private Sub InitializeComponent()
        Me.SuspendLayout()
        Me.Font = New System.Drawing.Font("ÉÅÉCÉäÉI", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.ResumeLayout(False)
    End Sub
End Class
