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
            report.CreateDocument()
            Dim tool As New ReportPrintTool(report)
            AddHandler tool.PreviewForm.Shown, AddressOf PreviewForm_Shown
            tool.ShowPreview()
        End Sub

        Private Sub PreviewForm_Shown(ByVal sender As Object, ByVal e As EventArgs)
            SetParametersPanelWidth(sender)
        End Sub
        Private Sub SetParametersPanelWidth(ByVal sender As Object)
            Dim previewForm As PrintPreviewFormEx = TryCast(sender, PrintPreviewFormEx)
            Dim parametersPanel As DevExpress.XtraBars.Docking.DockPanel = GetParametersPanel(previewForm)
            SetPanelWidth(parametersPanel, 500)
        End Sub
        Private Sub SetPanelWidth(ByVal parametersPanel As DevExpress.XtraBars.Docking.DockPanel, ByVal customParamsPanelWidth As Integer)
            parametersPanel.Width = customParamsPanelWidth
        End Sub
        Private Function GetParametersPanel(ByVal previewForm As PrintPreviewFormEx) As DevExpress.XtraBars.Docking.DockPanel
            Return previewForm.PrintControl.DockManager.Panels.FirstOrDefault(Function(x) x.Text = GetParametersPanelText())
        End Function
        Private Function GetParametersPanelText() As System.String
            Return PreviewLocalizer.GetString(PreviewStringId.ParametersRequest_Caption)
        End Function
    End Class
End Namespace
