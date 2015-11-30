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
    public partial class ConsultaCompras : Form
    {
        public ConsultaCompras()
        {
            InitializeComponent();
            ComprasComboBox.SelectedIndex = 0;
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            Compras compras = new Compras();
            string condicion;

            if(ComprasComboBox.SelectedIndex == 0)
            {
                if(ComprasTextBox.TextLength == 0)
                {
                    condicion = "1=1";
                }
                else
                {
                    condicion = "CompraId = " + ComprasTextBox.Text;
                }
                dt = compras.Listado("*",condicion,"");
                ComprasDataGridView.DataSource = dt;
            }
        }

        private void ImprimirButton_Click(object sender, EventArgs e)
        {
            VentanaReporteCompra compra = new VentanaReporteCompra();
            compra.Show();
        }
    }
}
