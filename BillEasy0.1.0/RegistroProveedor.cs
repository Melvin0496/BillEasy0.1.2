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
    public partial class RegistroProveedor : Form
    {
        ErrorProvider miError;
        public RegistroProveedor()
        {
            InitializeComponent();
            miError = new ErrorProvider();
        }

        private void LlenarDatos(Proveedores proveedor)
        {
            Regex espacio = new Regex(@"\s+");
            proveedor.CiudadId = (int)CiudadComboBox.SelectedValue;
            proveedor.NombreEmpresa = espacio.Replace(NombreEmpresaTextBox.Text, " "); ;
            proveedor.Direccion = espacio.Replace(DireccionTextBox.Text, " ");
            proveedor.Telefono = TelefonoMaskedTextBox.Text;
            proveedor.Email = EmailTextBox.Text;
            proveedor.RNC = RNCTextBox.Text;
            proveedor.NombreRepresentante = espacio.Replace(NombreRepresentanteTextBox.Text, " ");
            proveedor.Celular = CelularMaskedTextBox.Text;
        }
        private int Validar()
        {
            int retorno = 0;

            if (!Regex.Match(NombreEmpresaTextBox.Text, "^\\w{1,70}$").Success)
            {
                miError.SetError(NombreEmpresaTextBox, "Sobrepasa tamaño permitido de 70");
                retorno = 0;
            }
            if (!Regex.Match(DireccionTextBox.Text, "^\\w{1,150}$").Success)
            {
                miError.SetError(DireccionTextBox, "Sobrepasa tamaño permitido de 150");
                retorno = 0;
            }
            if (!Regex.Match(NombreRepresentanteTextBox.Text, "^\\w{1,50}$").Success)
            {
                miError.SetError(NombreRepresentanteTextBox, "Sobrepasa tamaño permitido de 50");
                retorno = 0;
            }
            if (!Regex.Match(EmailTextBox.Text, "^\\w{1,50}$").Success)
            {
                miError.SetError(EmailTextBox, "Sobrepasa tamaño permitido de 50");
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

            if (NombreEmpresaTextBox.Text == "")
            {
                miError.SetError(NombreEmpresaTextBox, "Debe llenar el nombre de la empresa");
                contador = 1;
            }
            else
            {
                miError.SetError(NombreEmpresaTextBox, "");
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
            if (TelefonoMaskedTextBox.Text == "")
            {
                miError.SetError(TelefonoMaskedTextBox, "Debe llenar el numero de telefono");
                contador = 1;
            }
            else
            {
                miError.SetError(TelefonoMaskedTextBox, "");
            }
            if (EmailTextBox.Text == "")
            {
                miError.SetError(EmailTextBox, "Debe llenar el email");
                contador = 1;
            }
            else
            {
                miError.SetError(EmailTextBox, "");
            }
            if (RNCTextBox.Text == "")
            {
                miError.SetError(RNCTextBox, "Debe llenar el RNC");
                contador = 1;
            }
            else
            {
                miError.SetError(RNCTextBox, "");
            }
            if (NombreRepresentanteTextBox.Text == "")
            {
                miError.SetError(NombreRepresentanteTextBox, "Debe llenar el  nombre del representante");
                contador = 1;
            }
            else
            {
                miError.SetError(NombreRepresentanteTextBox, "");
            }
            if (CelularMaskedTextBox.Text == "")
            {
                miError.SetError(CelularMaskedTextBox, "Debe llenar el  numero de telefono");
                contador = 1;
            }
            else
            {
                miError.SetError(CelularMaskedTextBox, "");
            }
            if ((int)CiudadComboBox.SelectedValue == 0)
            {
                miError.SetError(CiudadComboBox, "Debe seleccionar  la ciudad");
                contador = 1;
            }
            else
            {
                miError.SetError(CiudadComboBox, "");
            }
            return contador;
        }

        public int Convertidor()
        {
            int id;
            int.TryParse(ProveedorIdTextBox.Text, out id);
            return id;
        }

        private void RegistroProveedor_Load_1(object sender, EventArgs e)
        {

            Ciudades ciudad = new Ciudades();
            CiudadComboBox.DataSource = ciudad.Listado("CiudadId,Nombre,CodigoPostal ", "1=1", "");
            CiudadComboBox.DisplayMember = "Nombre";
            CiudadComboBox.ValueMember = "CiudadId";
        }

        private void BuscarButton_Click(object sender, EventArgs e)
        {
            Proveedores proveedor = new Proveedores();
            if (proveedor.Buscar(Convertidor()))
            {
                ProveedorIdTextBox.Text = proveedor.ProveedorId.ToString();
                NombreEmpresaTextBox.Text = proveedor.NombreEmpresa;
                CiudadComboBox.SelectedValue = proveedor.CiudadId;
                DireccionTextBox.Text = proveedor.Direccion;
                TelefonoMaskedTextBox.Text = proveedor.Telefono;
                EmailTextBox.Text = proveedor.Email;
                RNCTextBox.Text = proveedor.RNC;
                NombreRepresentanteTextBox.Text = proveedor.NombreRepresentante;
                CelularMaskedTextBox.Text = proveedor.Celular;
                ProveedorIdTextBox.ReadOnly = true;
            }
            else
            {
                MessageBox.Show("Id incorrecto", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void NuevoButton_Click(object sender, EventArgs e)
        {
            ProveedorIdTextBox.Clear();
            NombreEmpresaTextBox.Clear();
            DireccionTextBox.Clear();
            TelefonoMaskedTextBox.Clear();
            EmailTextBox.Clear();
            RNCTextBox.Clear();
            NombreRepresentanteTextBox.Clear();
            CelularMaskedTextBox.Clear();
            ProveedorIdTextBox.ReadOnly = false;
        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            Proveedores proveedor = new Proveedores();

            if (ProveedorIdTextBox.TextLength == 0)
            {
                LlenarDatos(proveedor);
                if (Error() == 0 && Validar() == 1 && proveedor.Insertar())
                {
                    MessageBox.Show("Proveedor insertado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    NuevoButton.PerformClick();
                }
                else
                {
                    MessageBox.Show("Error al insertar", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                proveedor.ProveedorId = Convertidor();
                LlenarDatos(proveedor);
                if (Error() == 0 && Validar() == 1 && proveedor.Editar())
                {
                    MessageBox.Show("Proveedor editado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    NuevoButton.PerformClick();
                }
                else
                {
                    MessageBox.Show("Erro al editar", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }


        }

        private void EliminarButton_Click(object sender, EventArgs e)
        {
            Proveedores proveedor = new Proveedores();
            if (ProveedorIdTextBox.TextLength == 0)
            {
                MessageBox.Show("Puto");
            }
            else
            {
                proveedor.ProveedorId = Convertidor();
                if (proveedor.Eliminar())
                {
                    MessageBox.Show("Proveedor Eliminado correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    NuevoButton.PerformClick();
                }
                else
                {
                    MessageBox.Show("Error al eliminar", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ProveedorIdTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                miError.SetError(ProveedorIdTextBox, "Solo se permiten numeros");
                e.Handled = true;
                return;
            }
            else
            {
                miError.SetError(ProveedorIdTextBox, "");
            }
        }

        private void NombreEmpresaTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && !(char.IsSeparator(e.KeyChar)))
            {
                miError.SetError(NombreEmpresaTextBox, "Solo se permiten letras");
                e.Handled = true;
                return;
            }
            else
            {
                miError.SetError(NombreEmpresaTextBox, "");
            }
        }

        private void NombreRepresentanteTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && !(char.IsSeparator(e.KeyChar)))
            {
                miError.SetError(NombreRepresentanteTextBox, "Solo se permiten letras");
                e.Handled = true;
                return;
            }
            else
            {
                miError.SetError(NombreRepresentanteTextBox, "");
            }
        }
}
}
