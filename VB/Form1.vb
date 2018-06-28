Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports DevExpress.XtraPrinting.Localization
Imports DevExpress.XtraPrinting.Preview
Imports DevExpress.XtraReports.UI

Namespace WindowsFormsApplication3
    Partial Public Class Form1
        Inherits DevExpress.XtraEditors.XtraForm

        Public Sub New()
            InitializeComponent()
        End Sub
        Private Sub simpleButton1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles simpleButton1.Click
            Dim report As New XtraReport1()
            Dim tool As New ReportPrintTool(report)
            AddHandler tool.PreviewRibbonForm.Shown, AddressOf PreviewForm_Shown
            tool.ShowRibbonPreview()
        End Sub
        Private Sub PreviewForm_Shown(ByVal sender As Object, ByVal e As EventArgs)
            SetParametersPanelWidth(sender)
        End Sub
        Private Sub SetParametersPanelWidth(ByVal sender As Object)
            Dim previewForm As PrintPreviewRibbonFormEx = TryCast(sender, PrintPreviewRibbonFormEx)
            CType(previewForm.PrintControl.DocumentSource, XtraReport).CreateDocument()
            Dim parametersPanel As DevExpress.XtraBars.Docking.DockPanel = GetParametersPanel(previewForm)
            parametersPanel.Width = 700
        End Sub
        Private Function GetParametersPanel(ByVal previewForm As IPrintPreviewForm) As DevExpress.XtraBars.Docking.DockPanel
            Return previewForm.PrintControl.GetDockPanel(PreviewDockPanelKind.Parameters)
        End Function
    End Class
End Namespace
