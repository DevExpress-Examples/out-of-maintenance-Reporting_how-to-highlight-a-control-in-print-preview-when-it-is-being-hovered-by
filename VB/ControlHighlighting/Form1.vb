Imports System
Imports System.Windows.Forms
Imports DevExpress.XtraReports.UI
' ...

Namespace ControlHighlighting
	Partial Public Class Form1
		Inherits Form

		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			If Not Me.button1.IsHandleCreated Then Return

			Dim report As New XtraReport1()
			Using tool As New ReportPrintTool(report)
				report.PrintControl = tool.PreviewRibbonForm.PrintControl
				tool.ShowRibbonPreviewDialog()
			End Using

		End Sub
	End Class
End Namespace
