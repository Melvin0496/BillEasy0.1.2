using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;

namespace BillEasy0._1._0
{
    public partial class ConsultaVentas : Form
    {
        public ConsultaVentas()
        {
            InitializeComponent();
            VentasComboBox.SelectedIndex = 0;
        }

        private void BuscarButton_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            Ventas ventas = new Ventas();
            string condicion;

            if(VentasComboBox.SelectedIndex == 0)
            {
                if(VentasTextBox.TextLength == 0)
                {
                    condicion = "1=1";
                }
                else
                {
                    condicion = string.Format("VentaId = {0}", VentasTextBox.Text);
                }
                dt = ventas.Listado("*",condicion,"");
                VentasDataGridView.DataSource = dt;
            }
        }

        private void ImprimirButton_Click(object sender, EventArgs e)
        {
            VentanaReporteVenta venta = new VentanaReporteVenta();
            venta.Show();
        }
    }
}
