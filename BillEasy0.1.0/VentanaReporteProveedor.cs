﻿using System;
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
    public partial class VentanaReporteProveedor : Form
    {
        public VentanaReporteProveedor()
        {
            InitializeComponent();
        }

        private void VentanaReporteProveedor_Load(object sender, EventArgs e)
        {
            ReporteProveedor reporte = new ReporteProveedor();
            ProveedorCrystalReportViewer.ReportSource = reporte;
        }
    }
}
