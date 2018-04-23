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
            report.CreateDocument();
            ReportPrintTool tool = new ReportPrintTool(report);
            tool.PreviewForm.Shown += PreviewForm_Shown;
            tool.ShowPreview();
        }

        private void PreviewForm_Shown(object sender, EventArgs e) {
            SetParametersPanelWidth(sender);
        }
        private  void SetParametersPanelWidth(object sender) {
            PrintPreviewFormEx previewForm = sender as PrintPreviewFormEx;
            DevExpress.XtraBars.Docking.DockPanel parametersPanel = GetParametersPanel(previewForm);
            SetPanelWidth(parametersPanel, 500);
        }
        private  void SetPanelWidth(DevExpress.XtraBars.Docking.DockPanel parametersPanel, int customParamsPanelWidth) {
            parametersPanel.Width = customParamsPanelWidth;
        }
        private  DevExpress.XtraBars.Docking.DockPanel GetParametersPanel(PrintPreviewFormEx previewForm) {
            return previewForm.PrintControl.DockManager.Panels.FirstOrDefault(x => x.Text == GetParametersPanelText());
        }
        private System.String GetParametersPanelText() {
            return PreviewLocalizer.GetString(PreviewStringId.ParametersRequest_Caption);
        }
    }
}
