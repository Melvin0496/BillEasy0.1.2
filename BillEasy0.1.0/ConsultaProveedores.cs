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
    public partial class ConsultaProveedores : Form
    {
        public ConsultaProveedores()
        {
            InitializeComponent();
            BuscarComboBox.SelectedIndex = 0;
        }

        private void BuscarButton_Click(object sender, EventArgs e)
        {
            Proveedores proveedor = new Proveedores();
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
                    condicion = "ProveedorId = " + id.ToString();
                }
                DatosDataGridView.DataSource = proveedor.Listado(" ProveedorId,CiudadId,NombreEmpresa,Direccion,Telefono,Email,RNC,NombreRepresentante,Celular ", condicion, "");
            }
            if (BuscarComboBox.SelectedIndex == 1)
            {
                if (DatosTextBox.Text.Trim().Length == 1)
                {
                    condicion = "2=2";
                }
                else
                {
                    condicion = String.Format("NombreEmpresa like '{0}%' ", DatosTextBox.Text);
                }
                DatosDataGridView.DataSource = proveedor.Listado(" ProveedorId,CiudadId,NombreEmpresa,Direccion,Telefono,Email,RNC,NombreRepresentante,Celular ", condicion, "");
            }
            if (BuscarComboBox.SelectedIndex == 2)
            {
                if (DatosTextBox.Text.Trim().Length == 2)
                {
                    condicion = "3=3";
                }
                else
                {
                    condicion = String.Format("RNC like '{0}%' ", DatosTextBox.Text);
                }
                DatosDataGridView.DataSource = proveedor.Listado(" ProveedorId,CiudadId,NombreEmpresa,Direccion,Telefono,Email,RNC,NombreRepresentante,Celular ", condicion, "");
            }
            if (BuscarComboBox.SelectedIndex == 3)
            {
                if (DatosTextBox.Text.Trim().Length == 3)
                {
                    condicion = "4=4";
                }
                else
                {
                    condicion = String.Format("NombreRepresentante like '{0}%' ", DatosTextBox.Text);
                }
                DatosDataGridView.DataSource = proveedor.Listado(" ProveedorId,CiudadId,NombreEmpresa,Direccion,Telefono,Email,RNC,NombreRepresentante,Celular ", condicion, "");
            }
        }

        private void ImprimirButton_Click(object sender, EventArgs e)
        {
            VentanaReporteProveedor proveedor = new VentanaReporteProveedor();
            proveedor.Show();
        }
    }
}
