using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BillEasy0._1._0
{
    public partial class VentanaReporteMarca : Form
    {
        public VentanaReporteMarca()
        {
            InitializeComponent();
        }

        private void VentanaReporteMarca_Load(object sender, EventArgs e)
        {
            ReporteMarca reporteMarca = new ReporteMarca();
            ReporteCrystalReportViewer.ReportSource = reporteMarca;
            ReporteCrystalReportViewer.RefreshReport();
        }
    }
}
