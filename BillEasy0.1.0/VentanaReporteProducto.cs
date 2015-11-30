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
    public partial class VentanaReporteProducto : Form
    {
        public VentanaReporteProducto()
        {
            InitializeComponent();
        }

        private void VentanaReporteProducto_Load(object sender, EventArgs e)
        {
            ReporteProducto reporte = new ReporteProducto();
            ProductoCrystalReportViewer.ReportSource = reporte;
            ProductoCrystalReportViewer.RefreshReport();
        }
    }
}
