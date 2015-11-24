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
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            Ventas ventas = new Ventas();
            string condicion;

            if(VentascomboBox.SelectedIndex == 0)
            {
                if(VentastextBox.TextLength == 0)
                {
                    condicion = "1=1";
                }
                else
                {
                    condicion = string.Format("VentaId = {0}", VentastextBox.Text);
                }
                dt = ventas.Listado("*",condicion,"");
                VentasdataGridView.DataSource = dt;
            }
        }
    }
}
