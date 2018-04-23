using System.Drawing;
using DevExpress.XtraPrinting;
using DevExpress.XtraPrinting.Control;
using DevExpress.XtraReports.UI;
// ...

namespace ControlHighlighting {
    public partial class XtraReport1 : DevExpress.XtraReports.UI.XtraReport {
        public XtraReport1() {
            InitializeComponent();
            ReportPrintTool printTool = new ReportPrintTool(this);
            ((PrintTool)this.ReportPrintTool).PreviewForm.PrintControl.BrickMouseMove += new BrickEventHandler(PrintControl_BrickMouseMove);
        }

        Brick brick;

        void PrintControl_BrickMouseMove(object sender, BrickEventArgs e) {
            this.brick = e.Brick;
            mouseMove = e.Brick != null;

            ((PrintTool)this.ReportPrintTool).PreviewForm.PrintControl.Invalidate();
            ((PrintTool)this.ReportPrintTool).PreviewForm.PrintControl.Refresh();
        }

        bool mouseMove = false;

        private void xrLabel1_Draw(object sender, DrawEventArgs e) {
            if (mouseMove && e.Brick == brick)
                e.Brick.BackColor = Color.Aqua;
            else
                e.Brick.BackColor = Color.Transparent;
        }
    }
}
