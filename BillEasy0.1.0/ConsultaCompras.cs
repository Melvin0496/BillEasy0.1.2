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
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            Compras compras = new Compras();
            string condicion;

            if(ComprascomboBox.SelectedIndex == 0)
            {
                if(ComprastextBox.TextLength == 0)
                {
                    condicion = "1=1";
                }
                else
                {
                    condicion = "CompraId = " + ComprastextBox.Text;
                }
                dt = compras.Listado("*",condicion,"");
                ComprasdataGridView.DataSource = dt;
            }
        }
    }
}
