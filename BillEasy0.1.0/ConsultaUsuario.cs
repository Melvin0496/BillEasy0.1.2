using System;
using System.Data;
using System.Windows.Forms;
using BLL;
namespace BillEasy0._1._0
{
    public partial class ConsultaUsuario : Form
    {
        public ConsultaUsuario()
        {
            InitializeComponent();
            BuscarComboBox.SelectedIndex = 0;
        }

        private void BuscarButton_Click(object sender, EventArgs e)
        {
            Usuarios usuario = new Usuarios();
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
                    condicion = "UsuarioId = " + id.ToString();
                }
                DatosDataGridView.DataSource = usuario.Listado(" UsuarioId, Nombres, NombreUsuario, Contrasena, Area, Fecha", condicion, "");
            }

            if (BuscarComboBox.SelectedIndex == 1)
            {
                if (DatosTextBox.Text.Trim().Length == 1)
                {
                    condicion = "2=2";
                }
                else
                {
                    condicion = string.Format("Nombres  like '{0}%' ", DatosTextBox.Text);
                }
                DatosDataGridView.DataSource = usuario.Listado(" UsuarioId, Nombres, NombreUsuario, Contrasena, Area, Fecha", condicion, "");
            }
            if (BuscarComboBox.SelectedIndex == 2)
            {
                if (DatosTextBox.Text.Trim().Length == 2)
                {
                    condicion = "3=3";
                }
                else
                {
                    condicion = string.Format("NombreUsuario like '{0}%'", DatosTextBox.Text);
                }
                DatosDataGridView.DataSource = usuario.Listado(" UsuarioId, Nombres, NombreUsuario, Contrasena, Area, Fecha", condicion, "");
            }
            if (BuscarComboBox.SelectedIndex == 3)
            {
                if (DatosTextBox.Text.Trim().Length == 3)
                {
                    condicion = "4=4";
                }
                else
                {
                    condicion = string.Format("Area like '{0}%'", DatosTextBox.Text);
                }
                DatosDataGridView.DataSource = usuario.Listado(" UsuarioId, Nombres, NombreUsuario, Contrasena, Area, Fecha", condicion, "");
            }

        }

        private void ImprimirButton_Click(object sender, EventArgs e)
        {
            VentanaReporteUsuario usuario = new VentanaReporteUsuario();
            usuario.Show();
        }
    }
}
