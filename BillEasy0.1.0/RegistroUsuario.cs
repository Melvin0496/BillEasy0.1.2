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
    public partial class RegistroUsuario : Form
    {
        ErrorProvider miError;
        public RegistroUsuario()
        {
            InitializeComponent();
            miError = new ErrorProvider();
        }

        private void LlenarDatos(Usuarios usuarios)
        {
            Regex espacio = new Regex(@"\s+");
            usuarios.Nombre = espacio.Replace(NombreTextBox.Text, " "); ;
            usuarios.NombreUsuario = NombreUsuarioTextBox.Text;
            usuarios.Contrasena = ContrasenaTextBox.Text;
            usuarios.Area = AreaTextBox.Text;
            usuarios.Fecha = FechadateTimePicker.Text;
        }

        private int Error()
        {
            int contador = 0;

            if (NombreTextBox.Text == "")
            {
                miError.SetError(NombreTextBox, "Debe llenar el nombre del empleado");
                contador = 1;
            }
            else
            {
                miError.SetError(NombreTextBox, "");
            }
            if (NombreUsuarioTextBox.Text == "")
            {
                miError.SetError(NombreUsuarioTextBox, "Debe llenar el nombre de usuario");
                contador = 1;
            }
            else
            {
                miError.SetError(NombreUsuarioTextBox, "");
            }
            if (ContrasenaTextBox.Text == "")
            {
                miError.SetError(ContrasenaTextBox, "Debe llenar la contraseña");
                contador = 1;
            }
            else
            {
                miError.SetError(ContrasenaTextBox, "");
            }
            if (AreaTextBox.Text == "")
            {
                miError.SetError(AreaTextBox, "Debe llenar el nombre de usuario");
                contador = 1;
            }
            else
            {
                miError.SetError(AreaTextBox, "");
            }
           
            return contador;
        }

        public int Convertir()
        {
            int id;
            int.TryParse(UsuarioIdTextBox.Text, out id);
            return id;
        }
        private void BuscarButton_Click(object sender, EventArgs e)
        {
            Usuarios usuario = new Usuarios();
            if (usuario.Buscar(Convertir()))
            {
                NombreTextBox.Text = usuario.Nombre;
                NombreUsuarioTextBox.Text = usuario.NombreUsuario;
                ContrasenaTextBox.Text = usuario.Contrasena;
                AreaTextBox.Text = usuario.Area;
                FechadateTimePicker.Text = usuario.Fecha;
            }
            else
            {
                MessageBox.Show("Id incorrecto","Alerta",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
        private void NuevoButton_Click(object sender, EventArgs e)
        {
            UsuarioIdTextBox.Clear();
            NombreTextBox.Clear();
            NombreUsuarioTextBox.Clear();
            ContrasenaTextBox.Clear();
            AreaTextBox.Clear();

        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            Usuarios usuarios = new Usuarios();

            if (UsuarioIdTextBox.Text.Length > 0 && Error() == 0)
            {

                usuarios.UsuarioId = Convertir();
                LlenarDatos(usuarios);
                if (usuarios.Editar())
                {
                    MessageBox.Show("Usuario editado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    NuevoButton.PerformClick();
                }
                else
                {
                    MessageBox.Show("Debe de completar todos los campos", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (UsuarioIdTextBox.Text.Length == 0 && Error() == 0 )
            {

                LlenarDatos(usuarios);
                if (usuarios.Insertar())
                {
                    MessageBox.Show("Usuario guardado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    NuevoButton.PerformClick();
                }
                else
                {
                    MessageBox.Show("Error al insertar el usuario", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void EliminarButton_Click(object sender, EventArgs e)
        {
            Usuarios usuario = new Usuarios();

            if (UsuarioIdTextBox.TextLength == 0)
            {
                MessageBox.Show("Debe especificar el ID", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {

                if (UsuarioIdTextBox.Text.Length > 0)
                {

                    usuario.UsuarioId = Convertir();
                    if (usuario.Eliminar())
                    {
                        MessageBox.Show("Usuario Eliminado correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        NuevoButton.PerformClick();
                    }
                    else
                    {
                        MessageBox.Show("Error al eliminar el usuario", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void UsuarioIdTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                miError.SetError(UsuarioIdTextBox, "Solo se permiten numeros");
                e.Handled = true;
                return;
            }
            else
            {
                miError.SetError(UsuarioIdTextBox, "");
            }
        }

        private void NombreTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && !(char.IsSeparator(e.KeyChar)))
            {
                miError.SetError(NombreTextBox, "Solo se permiten letras");
                e.Handled = true;
                return;
            }
            else
            {
                miError.SetError(NombreTextBox, "");
            }
        }
    }
}
