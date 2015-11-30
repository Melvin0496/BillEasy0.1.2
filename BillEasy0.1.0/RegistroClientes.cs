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
    public partial class RegistroClientes : Form
    {
        ErrorProvider miError;
        public RegistroClientes()
        {
            InitializeComponent();
            miError = new ErrorProvider();
        }

        public void Datos(Clientes clientes)
        {
            int id;
            int.TryParse(ClienteIdtextBox.Text, out id);
            Regex espacio = new Regex(@"\s+");
            clientes.ClienteId = id;
            clientes.CiudadId = (int)CiudadComboBox.SelectedValue;
            clientes.Nombres = espacio.Replace(NombresTextBox.Text, " ");
            clientes.Apellidos = espacio.Replace(ApellidosTextBox.Text, " ");
            clientes.Telefono = TelefonomaskedTextBox.Text;
            clientes.Celular = CelularmaskedTextBox.Text;
            clientes.Direccion = espacio.Replace(DireccionTextBox.Text, " ");
            clientes.Email = EmailTextBox.Text;
            clientes.Cedula = CedulamaskedTextBox.Text;
        }

        private int Validar()
        {
            int retorno = 0;

            if (!Regex.Match(NombresTextBox.Text, "^\\w{1,50}$").Success)
            {
                miError.SetError(NombresTextBox, "Sobrepasa tamaño permitido de 50");
                retorno = 0;
            }
            if (!Regex.Match(ApellidosTextBox.Text, "^\\w{1,50}$").Success)
            {
                miError.SetError(ApellidosTextBox, "Sobrepasa tamaño permitido de 50");
                retorno = 0;
            }
            if (!Regex.Match(DireccionTextBox.Text, "^\\w{1,150}$").Success)
            {
                miError.SetError(DireccionTextBox, "Sobrepasa tamaño permitido de 150");
                retorno = 0;
            }
            if (!Regex.Match(EmailTextBox.Text, "^\\w{1,100}$").Success)
            {
                miError.SetError(EmailTextBox, "Sobrepasa tamaño permitido de 100");
                retorno = 0;
            }
            if (!Regex.Match(EmailTextBox.Text, @"\A(\w+\.?\w*\@\w+.)(com)\Z").Success)
            {
                miError.SetError(EmailTextBox, "Correo Invalido");
                retorno = 0;
            }
            else
            {
                retorno += 1;
                miError.Clear();
            }

            return retorno;
        }

        private int Error()
        {
            int contador = 0;

            if (NombresTextBox.Text == "")
            {
                miError.SetError(NombresTextBox, "Debe llenar el nombre del cliente");
                contador = 1;
            }
            else
            {
                miError.SetError(NombresTextBox, "");
            }
            if (ApellidosTextBox.Text == "")
            {
                miError.SetError(ApellidosTextBox, "Debe llenar el apellido");
                contador = 1;
            }
            else
            {
                miError.SetError(ApellidosTextBox, "");
            }
            if (TelefonomaskedTextBox.Text == "")
            {
                miError.SetError(TelefonomaskedTextBox, "Debe llenar el numero de telefono");
                contador = 1;
            }
            else
            {
                miError.SetError(TelefonomaskedTextBox, "");
            }
            if (CelularmaskedTextBox.Text == "")
            {
                miError.SetError(CelularmaskedTextBox, "Debe llenar el email");
                contador = 1;
            }
            else
            {
                miError.SetError(CelularmaskedTextBox, "");
            }
            if (DireccionTextBox.Text == "")
            {
                miError.SetError(DireccionTextBox, "Debe llenar la direccion");
                contador = 1;
            }
            else
            {
                miError.SetError(DireccionTextBox, "");
            }
            if (EmailTextBox.Text == "")
            {
                miError.SetError(EmailTextBox, "Debe llenar el  email");
                contador = 1;
            }
            else
            {
                miError.SetError(EmailTextBox, "");
            }
            if (CedulamaskedTextBox.Text == "")
            {
                miError.SetError(CedulamaskedTextBox, "Debe llenar el  numero de telefono");
                contador = 1;
            }
            else
            {
                miError.SetError(CedulamaskedTextBox, "");
            }
            return contador;
        }

        public int ConversionId()
        {
            int id;
            int.TryParse(ClienteIdtextBox.Text, out id);

            return id;
        }

        private void RegistroClientes_Load(object sender, EventArgs e)
        {
            Ciudades ciudades = new Ciudades();
            CiudadComboBox.DataSource = ciudades.Listado("CiudadId,Nombre,CodigoPostal ", "1=1", "");
            CiudadComboBox.DisplayMember = string.Format("Nombre");
            CiudadComboBox.ValueMember = "CiudadId";
        }

        private void BuscarButton_Click(object sender, EventArgs e)
        {
            Clientes clientes = new Clientes();

            if (clientes.Buscar(ConversionId()))
            {
                NombresTextBox.Text = clientes.Nombres;
                ApellidosTextBox.Text = clientes.Apellidos;
                TelefonomaskedTextBox.Text = clientes.Telefono;
                CiudadComboBox.SelectedValue = clientes.CiudadId;
                CelularmaskedTextBox.Text = clientes.Celular;
                DireccionTextBox.Text = clientes.Direccion;
                EmailTextBox.Text = clientes.Email;
                CedulamaskedTextBox.Text = clientes.Cedula;
                CiudadComboBox.SelectedValue = clientes.CiudadId;
                ClienteIdtextBox.ReadOnly = true;

            }
            else
            {
                MessageBox.Show("El id especificado no existe", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void NuevoButton_Click(object sender, EventArgs e)
        {
            ClienteIdtextBox.Clear();
            NombresTextBox.Clear();
            ApellidosTextBox.Clear();
            TelefonomaskedTextBox.Clear();
            CelularmaskedTextBox.Clear();
            DireccionTextBox.Clear();
            EmailTextBox.Clear();
            CedulamaskedTextBox.Clear();
            ClienteIdtextBox.ReadOnly = false;
        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            DataTable table = new DataTable();
            Clientes clientes = new Clientes();

           if (ClienteIdtextBox.TextLength == 0)
            {
                Datos(clientes);
                if (Error() == 0 && Validar() == 1 && clientes.Insertar())
                {
                    MessageBox.Show("Cliente insertado","Mensaje",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    NuevoButton.PerformClick();
                }
                else
                {
                    MessageBox.Show("Error tratando de insertar el cliente","Alerta",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
            else
            {
                clientes.ClienteId = ConversionId();
                Datos(clientes);
                if (Error() == 0 && Validar() == 1 && clientes.Editar())
                {
                    MessageBox.Show("Se edito Correctamente","Mensaje",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    NuevoButton.PerformClick();
                }
                else
                {
                    MessageBox.Show("Error al editar", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void EliminarButton_Click(object sender, EventArgs e)
        {
            Clientes clientes = new Clientes();
            clientes.ClienteId = ConversionId();
            if (clientes.Eliminar() == true)
            {
                MessageBox.Show("Cliente eliminado","Mensaje",MessageBoxButtons.OK,MessageBoxIcon.Information);
                NuevoButton.PerformClick();
            }
            else
            {
                MessageBox.Show("Ese cliente no existe","Alerta",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void ClienteIdtextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                miError.SetError(ClienteIdtextBox, "Solo se permiten numeros");
                e.Handled = true;
                return;
            }
            else
            {
                miError.SetError(ClienteIdtextBox, "");
            }
        }

        private void NombresTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && !(char.IsSeparator(e.KeyChar)))
            {
                miError.SetError(NombresTextBox, "Solo se permiten letras");
                e.Handled = true;
                return;
            }
            else
            {
                miError.SetError(NombresTextBox, "");
            }
        }

        private void ApellidostextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && !(char.IsSeparator(e.KeyChar)))
            {
                miError.SetError(ApellidosTextBox, "Solo se permiten letras");
                e.Handled = true;
                return;
            }
            else
            {
                miError.SetError(ApellidosTextBox, "");
            }
        }
    }
}
