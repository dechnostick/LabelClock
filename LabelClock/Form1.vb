Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.SetStyle(ControlStyles.ResizeRedraw, True)
        Me.SetStyle(ControlStyles.DoubleBuffer, True)
        Me.SetStyle(ControlStyles.UserPaint, True)
        Me.SetStyle(ControlStyles.AllPaintingInWmPaint, True)
        Me.Timer1.Start()
    End Sub

    Private hasPainted = False
    Private Sub Form1_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        If Me.hasPainted Then
            Return
        End If
        Me.hasPainted = True
        Dim nl As MyLabel = New MyLabel(0, 0, "Hello, world.")
        nl.Update()
        AddHandler nl.MouseDown, AddressOf NodeLabels_MouseDown
        AddHandler nl.MouseMove, AddressOf MyLabel_MouseMove
        AddHandler nl.MouseUp, AddressOf MyLabel_MouseUp
        Me.Controls.Add(nl)
    End Sub

    Private dragging As Boolean = False
    Private selectedOffset As Point = Nothing

    Private Sub NodeLabels_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        Me.selectedOffset = New Point(e.X, e.Y)
        Me.dragging = True
    End Sub

    Private Sub MyLabel_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If Not Me.dragging Then
            Return
        End If
        Dim ml As MyLabel = DirectCast(sender, MyLabel)
        ml.Location = Me.PointToClient(Cursor.Position) - Me.selectedOffset
        ml.SelectedColor()
        ml.Update()
        Me.Refresh()
    End Sub

    Private Sub MyLabel_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        Dim ml As MyLabel = DirectCast(sender, MyLabel)
        ml.DefaultColor()
        Me.dragging = False
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        For Each c As Control In Me.Controls
            If TypeOf c Is MyLabel Then
                c.Text = DateTime.Now.ToString("HH:mm:ss")
                Exit For
            End If
        Next
    End Sub
End Class
