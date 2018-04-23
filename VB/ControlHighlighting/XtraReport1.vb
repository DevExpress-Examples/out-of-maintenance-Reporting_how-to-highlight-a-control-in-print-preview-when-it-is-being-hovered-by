Imports Microsoft.VisualBasic
Imports System.Drawing
Imports DevExpress.XtraPrinting
Imports DevExpress.XtraPrinting.Control
Imports DevExpress.XtraReports.UI
' ...

Namespace ControlHighlighting
	Partial Public Class XtraReport1
		Inherits DevExpress.XtraReports.UI.XtraReport
		Public Sub New()
			InitializeComponent()
			Dim printTool As New ReportPrintTool(Me)
			AddHandler (CType(ReportPrintTool, PrintTool)).PreviewForm.PrintControl.BrickMouseMove, AddressOf PrintControl_BrickMouseMove
		End Sub

		Private brick As Brick

		Private Sub PrintControl_BrickMouseMove(ByVal sender As Object, ByVal e As BrickEventArgs)
			Me.brick = e.Brick
			mouseMove = e.Brick IsNot Nothing

			CType(Me.ReportPrintTool, PrintTool).PreviewForm.PrintControl.Invalidate()
			CType(Me.ReportPrintTool, PrintTool).PreviewForm.PrintControl.Refresh()
		End Sub

		Private mouseMove As Boolean = False

		Private Sub xrLabel1_Draw(ByVal sender As Object, ByVal e As DrawEventArgs) Handles xrLabel1.Draw
			If mouseMove AndAlso e.Brick Is brick Then
				e.Brick.BackColor = Color.Aqua
			Else
				e.Brick.BackColor = Color.Transparent
			End If
		End Sub
	End Class
End Namespace
