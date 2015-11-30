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
    public partial class ConsultaCiudad : Form
    {

        public ConsultaCiudad()
        {
            InitializeComponent();
            BuscarComboBox.SelectedIndex = 0;
        }

        private void BuscarButton_Click(object sender, EventArgs e)
        {
            Ciudades ciudad = new Ciudades();
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
                    condicion = "CiudadId = " + id.ToString();
                }
                DatosDataGridView.DataSource = ciudad.Listado(" CiudadId, Nombre, CodigoPostal ", condicion, "");
            }
            else if (BuscarComboBox.SelectedIndex == 1)
            {
                if (DatosTextBox.Text.Trim().Length == 1)
                {
                    condicion = "2=2";
                }
                else
                {
                    condicion = String.Format("Nombre like '{0}%'  ", DatosTextBox.Text);
                }
                DatosDataGridView.DataSource = ciudad.Listado(" CiudadId, Nombre, CodigoPostal ", condicion, "");
            }
            else if (BuscarComboBox.SelectedIndex == 2)
            {
                if (DatosTextBox.Text.Trim().Length == 0)
                {
                    condicion = "3=3";
                }
                else
                {
                    int codigo;
                    int.TryParse(DatosTextBox.Text, out codigo);
                    condicion = "CodigoPostal = " + codigo.ToString();
                }
                DatosDataGridView.DataSource = ciudad.Listado(" CiudadId, Nombre, CodigoPostal ", condicion, "");
                MessageBox.Show(condicion);
            }
        }

        private void ImprimirButton_Click(object sender, EventArgs e)
        {
            VentanaReporteCiudad ciudad = new VentanaReporteCiudad();
            ciudad.Show();
        }
    }
}
