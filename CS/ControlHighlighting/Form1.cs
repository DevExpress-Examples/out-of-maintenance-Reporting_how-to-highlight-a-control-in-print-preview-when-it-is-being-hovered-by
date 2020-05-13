using System;
using System.Windows.Forms;
using DevExpress.XtraReports.UI;
// ...

namespace ControlHighlighting {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {
            XtraReport1 report = new XtraReport1();
            using (ReportPrintTool tool = new ReportPrintTool(report)) {
                report.PrintControl = tool.PreviewRibbonForm.PrintControl;
                tool.ShowRibbonPreviewDialog();
            }
            
        }
    }
}
