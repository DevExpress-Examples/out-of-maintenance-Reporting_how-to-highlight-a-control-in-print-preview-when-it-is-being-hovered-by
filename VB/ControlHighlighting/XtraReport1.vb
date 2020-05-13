Imports System.Drawing
Imports DevExpress.XtraPrinting
Imports DevExpress.XtraPrinting.Control
Imports DevExpress.XtraPrinting.Preview
Imports DevExpress.XtraReports.UI
' ...

Namespace ControlHighlighting
	Partial Public Class XtraReport1
		Inherits DevExpress.XtraReports.UI.XtraReport

'INSTANT VB NOTE: The field printControl was renamed since Visual Basic does not allow fields to have the same name as other class members:
		Private printControl_Conflict As DocumentViewer = Nothing

		Public Property PrintControl() As DocumentViewer
			Get
				Return printControl_Conflict
			End Get
			Set(ByVal value As DocumentViewer)
				If printControl_Conflict IsNot Nothing Then
					RemoveHandler PrintControl.BrickMouseMove, AddressOf PrintControl_BrickMouseMove
				End If

				printControl_Conflict = value

				If printControl_Conflict IsNot Nothing Then
					AddHandler PrintControl.BrickMouseMove, AddressOf PrintControl_BrickMouseMove
				End If

			End Set
		End Property

		Public Sub New()
			InitializeComponent()
		End Sub

		Private brick As Brick

		Private Sub PrintControl_BrickMouseMove(ByVal sender As Object, ByVal e As BrickEventArgs)
			Me.brick = e.Brick
			mouseMove = e.Brick IsNot Nothing

			PrintControl?.Invalidate()
			PrintControl?.Refresh()
		End Sub

		Private mouseMove As Boolean = False

		Private Sub xrLabel1_Draw(ByVal sender As Object, ByVal e As DrawEventArgs) Handles xrLabel1.Draw
			If mouseMove AndAlso e.Brick = brick Then
				e.Brick.BackColor = Color.Aqua
			Else
				e.Brick.BackColor = Color.Transparent
			End If
		End Sub
	End Class
End Namespace
