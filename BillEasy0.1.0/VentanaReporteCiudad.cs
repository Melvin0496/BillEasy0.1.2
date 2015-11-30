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
    public partial class VentanaReporteCiudad : Form
    {
        public VentanaReporteCiudad()
        {
            InitializeComponent();
        }

        private void VentanaReporteCiudad_Load(object sender, EventArgs e)
        {
            ReporteCiudad reporte = new ReporteCiudad();
            CiudadCrystalReportViewer.ReportSource = reporte;
            CiudadCrystalReportViewer.RefreshReport();
        }
    }
}
