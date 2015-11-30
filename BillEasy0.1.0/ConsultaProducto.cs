using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using BLL;

namespace BillEasy0._1._0
{
    public partial class ConsultaProducto : Form
    {
        public ConsultaProducto()
        {
            InitializeComponent();
            BuscarComboBox.SelectedIndex = 0;
        }

        private void BuscarButton_Click_1(object sender, EventArgs e)
        {
            Productos producto = new Productos();
            string condicion;

            if (BuscarComboBox.SelectedIndex == 0)
            {
                if (DatosTextBox.Text.Trim().Length == 0)
                {
                    condicion = "1=1";
                }
                else
                {
                    int id;
                    int.TryParse(DatosTextBox.Text, out id);
                    condicion = " ProductoId = " + id.ToString();
                }
                DatosDataGridView.DataSource = producto.Listado(" ProductoId,MarcaId,Nombre,Cantidad,Precio,Costo,ITBIS ", condicion, "");
            }
            if (BuscarComboBox.SelectedIndex == 1)
            {
                if (DatosTextBox.Text.Trim().Length == 1)
                {
                    condicion = "2=2";
                }
                else
                {
                    condicion = String.Format("Nombre  like '{0}%' ", DatosTextBox.Text);
                }
                DatosDataGridView.DataSource = producto.Listado(" ProductoId,MarcaId,Nombre,Cantidad,Precio,Costo,ITBIS ", condicion, "");

            }
            if (BuscarComboBox.SelectedIndex == 2)
            {
                if (DatosTextBox.Text.Trim().Length == 0)
                {
                    condicion = "3=3";
                }
                else
                {
                    double precio;
                    double.TryParse(DatosTextBox.Text, out precio);
                    condicion = "Precio = " + precio.ToString();
                }
                DatosDataGridView.DataSource = producto.Listado(" ProductoId,MarcaId,Nombre,Cantidad,Precio,Costo,ITBIS ", condicion, "");
            }
            if (BuscarComboBox.SelectedIndex == 3)
            {
                if (DatosTextBox.Text.Trim().Length == 0)
                {
                    condicion = "4=4";
                }
                else
                {
                    double costo;
                    double.TryParse(DatosTextBox.Text, out costo);
                    condicion = "Costo = " + costo.ToString();
                }
                DatosDataGridView.DataSource = producto.Listado(" ProductoId,MarcaId,Nombre,Cantidad,Precio,Costo,ITBIS ", condicion, "");
            }

        }

        private void ImprimirButton_Click(object sender, EventArgs e)
        {
            VentanaReporteProducto producto = new VentanaReporteProducto();
            producto.Show();
        }
    }
}



