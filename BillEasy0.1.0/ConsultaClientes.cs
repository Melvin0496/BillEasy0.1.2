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
    public partial class ConsultaClientes : Form
    {

        public ConsultaClientes()
        {
            InitializeComponent();
            BuscarClientesComboBox.SelectedIndex = 0;
        }


        private void BuscarButton_Click(object sender, EventArgs e)
        {
            Clientes clientes = new Clientes();
            DataTable dt = new DataTable();
            string condicion;

            if (BuscarClientesComboBox.SelectedIndex == 0)
            {
                if (ClientesTextBox.Text.Trim().Length == 0)
                {
                    condicion = "1=1";
                }
                else
                {
                    int id;
                    int.TryParse(ClientesTextBox.Text, out id);
                    condicion = "ClienteId = " + id.ToString();
                }
                dt = clientes.Listado("ClienteId,Nombres,Apellidos,CiudadId,Telefono,Celular,Email,Cedula", condicion, "");
                ClientesDataGridView.DataSource = dt;
            }
            if (BuscarClientesComboBox.SelectedIndex == 1)
            {
                if (ClientesTextBox.Text.Trim().Length == 1)
                {
                    condicion = "1=1";
                }
                else
                {
                    condicion = String.Format("Nombres like '{0}%' ", ClientesTextBox.Text);
                }
                dt = clientes.Listado("ClienteId,Nombres,Apellidos,CiudadId,Telefono,Celular,Email,Cedula", condicion, "");
                ClientesDataGridView.DataSource = dt;
            }
            if (BuscarClientesComboBox.SelectedIndex == 2)
            {
                if (ClientesTextBox.Text.Trim().Length == 2)
                {
                    condicion = "1=1";
                }
                else
                {
                    condicion = String.Format("Apellidos like '{0}%' ", ClientesTextBox.Text);
                }
                dt = clientes.Listado("ClienteId,Nombres,Apellidos,CiudadId,Telefono,Celular,Email,Cedula", condicion, "");
                ClientesDataGridView.DataSource = dt;
            }
            if (BuscarClientesComboBox.SelectedIndex == 3)
            {
                if (ClientesTextBox.Text.Trim().Length == 3)
                {
                    condicion = "1=1";
                }
                else
                {
                    condicion = String.Format("Telefono like '{0}%' ", ClientesTextBox.Text);
                }
                dt = clientes.Listado("ClienteId,Nombres,Apellidos,CiudadId,Telefono,Celular,Email,Cedula", condicion, "");
                ClientesDataGridView.DataSource = dt;
            }
            if (BuscarClientesComboBox.SelectedIndex == 4)
            {
                if (ClientesTextBox.Text.Trim().Length == 4)
                {
                    condicion = "1=1";
                }
                else
                {
                    condicion = String.Format("Celular like '{0}%' ", ClientesTextBox.Text);
                }
                dt = clientes.Listado("ClienteId,Nombres,Apellidos,CiudadId,Telefono,Celular,Email,Cedula", condicion, "");
                ClientesDataGridView.DataSource = dt;
            }
            if (BuscarClientesComboBox.SelectedIndex == 5)
            {
                if (ClientesTextBox.Text.Trim().Length == 5)
                {
                    condicion = "1=1";
                }
                else
                {
                    condicion = String.Format("Email like '{0}%' ", ClientesTextBox.Text);
                }
                dt = clientes.Listado("ClienteId,Nombres,Apellidos,CiudadId,Telefono,Celular,Email,Cedula", condicion, "");
                ClientesDataGridView.DataSource = dt;
            }
            if (BuscarClientesComboBox.SelectedIndex == 6)
            {
                if (ClientesTextBox.Text.Trim().Length == 6)
                {
                    condicion = "1=1";
                }
                else
                {
                    condicion = String.Format("Cedula like '{0}%' ", ClientesTextBox.Text);
                }
                dt = clientes.Listado("ClienteId,Nombres,Apellidos,CiudadId,Telefono,Celular,Email,Cedula", condicion, "");
                ClientesDataGridView.DataSource = dt;
            }

        }

        private void ImprimirButton_Click(object sender, EventArgs e)
        {
            VentanaReporteCliente cliente = new VentanaReporteCliente();
            cliente.Show();
        }
    }
}