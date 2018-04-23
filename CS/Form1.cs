using System;
using System.Collections.Generic;
using System.Linq;
using DevExpress.XtraPrinting.Localization;
using DevExpress.XtraPrinting.Preview;
using DevExpress.XtraReports.UI;

namespace WindowsFormsApplication3 {
    public partial class Form1 : DevExpress.XtraEditors.XtraForm {
        public Form1() {
            InitializeComponent();
        }
        private void simpleButton1_Click(object sender, EventArgs e) {
            XtraReport1 report = new XtraReport1();
            ReportPrintTool tool = new ReportPrintTool(report);            
            tool.PreviewRibbonForm.Shown += PreviewForm_Shown;
            tool.ShowRibbonPreview();
        }
        private void PreviewForm_Shown(object sender, EventArgs e) {
            SetParametersPanelWidth(sender);
        }
        private  void SetParametersPanelWidth(object sender) {
            PrintPreviewRibbonFormEx previewForm = sender as PrintPreviewRibbonFormEx;
            ((XtraReport)previewForm.PrintControl.DocumentSource).CreateDocument(); 
            DevExpress.XtraBars.Docking.DockPanel parametersPanel = GetParametersPanel(previewForm);
            parametersPanel.Width = 700;
        }
        private  DevExpress.XtraBars.Docking.DockPanel GetParametersPanel(IPrintPreviewForm previewForm) {
            return previewForm.PrintControl.DockManager.Panels.FirstOrDefault(x => x.Text == PreviewLocalizer.GetString(PreviewStringId.ParametersRequest_Caption));
        }
    }
}
