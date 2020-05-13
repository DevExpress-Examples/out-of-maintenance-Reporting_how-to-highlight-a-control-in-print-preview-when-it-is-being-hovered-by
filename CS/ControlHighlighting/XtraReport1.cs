using System.Drawing;
using DevExpress.XtraPrinting;
using DevExpress.XtraPrinting.Control;
using DevExpress.XtraPrinting.Preview;
using DevExpress.XtraReports.UI;
// ...

namespace ControlHighlighting {
    public partial class XtraReport1 : DevExpress.XtraReports.UI.XtraReport {
        DocumentViewer printControl = null;

        public DocumentViewer PrintControl {
            get {
                return printControl;
            }
            set {
                if (printControl != null)
                    PrintControl.BrickMouseMove -= PrintControl_BrickMouseMove;

                printControl = value;

                if (printControl != null)
                    PrintControl.BrickMouseMove += PrintControl_BrickMouseMove;

            }
        }

        public XtraReport1() {
            InitializeComponent();
        }

        Brick brick;

        void PrintControl_BrickMouseMove(object sender, BrickEventArgs e) {
            this.brick = e.Brick;
            mouseMove = e.Brick != null;

            PrintControl?.Invalidate();
            PrintControl?.Refresh();
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
