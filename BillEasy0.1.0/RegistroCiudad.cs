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
using System.Text.RegularExpressions;
namespace BillEasy0._1._0
{
    public partial class RegistroCiudad : Form
    {
        ErrorProvider miError;
        public RegistroCiudad()
        {
            InitializeComponent();
            miError = new ErrorProvider();
        }

        private void LlenarDatos(Ciudades ciudad)
        {
            Regex espacio = new Regex(@"\s+");
            ciudad.Nombre = espacio.Replace(NombreTextBox.Text, " ");
            int codigoPostal;
            int.TryParse(CodigoPostalTextBox.Text, out codigoPostal);
            ciudad.CodigoPostal = codigoPostal;
        }

        private int Error()
        {
            int contador = 0;

            if (NombreTextBox.Text == "")
            {
                miError.SetError(NombreTextBox, "Debe llenar el nombre de la ciudad");
                contador = 1;
            }
            else
            {
                miError.SetError(NombreTextBox, "");
            }
            if (CodigoPostalTextBox.Text == "")
            {
                miError.SetError(CodigoPostalTextBox, "Debe llenar el codigo postal");
                contador = 1;
            }
            else
            {
                miError.SetError(CodigoPostalTextBox, "");
            } 
            return contador;
        }

        

        private int Validar()
        {
            int retorno = 0;

            if (!Regex.Match(CodigoPostalTextBox.Text, @"^\d{5}$").Success)
            {
                miError.SetError(CodigoPostalTextBox, "Codigo postal invalido");
                retorno = 0;
            }
            if(!Regex.Match(NombreTextBox.Text, "^\\w{1,50}$").Success)
            {
                miError.SetError(NombreTextBox,"Sobrepasa el tamaño de 50");
                retorno = 0;
            }
            else
            {
                retorno = 1;
                miError.Clear();
            }
            

            return retorno;
        }

        public int Convertir()
        {
            int id;
            int.TryParse(CiudadIdTextBox.Text,out id);
            return id;
        }
        private void BuscarButton_Click(object sender, EventArgs e)
        {
            Ciudades ciudad = new Ciudades();
            if (ciudad.Buscar(Convertir()))
            {
                CiudadIdTextBox.Text = ciudad.CiudadId.ToString();
                NombreTextBox.Text = ciudad.Nombre;
                CodigoPostalTextBox.Text = ciudad.CodigoPostal.ToString();
                CiudadIdTextBox.ReadOnly = true;
            }
            else
            {
                MessageBox.Show("Id incorrecto","Alerta",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void NuevoButton_Click(object sender, EventArgs e)
        {
            CiudadIdTextBox.Clear();
            NombreTextBox.Clear();
            CodigoPostalTextBox.Clear();
            CiudadIdTextBox.ReadOnly = false;
        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            Ciudades ciudad = new Ciudades();
            if (CiudadIdTextBox.Text.Length == 0 && Error() == 0 && Validar() == 1)
            {
                LlenarDatos(ciudad);
                if (ciudad.Insertar())
                {
                    MessageBox.Show("Ciudad Guardada", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    NuevoButton.PerformClick();
                }
                else
                {
                    MessageBox.Show("Error al insertar la ciudad", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (CiudadIdTextBox.Text.Length > 0 && Error() == 0 && Validar() == 1)
            {
                ciudad.CiudadId = Convertir();
                LlenarDatos(ciudad);
                if (ciudad.Editar() && Validar() == 1 && Error() == 0)
                {
                    MessageBox.Show("Ciudad Editada", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    NuevoButton.PerformClick();
                }
                else
                {
                    MessageBox.Show("Debe de completar todos los campos", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            
        }

        private void EliminarButton_Click(object sender, EventArgs e)
        {
            Ciudades ciudad = new Ciudades();
            if (CiudadIdTextBox.TextLength == 0)
            {
                MessageBox.Show("Debe especificar el ID", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            if (CiudadIdTextBox.Text.Length > 0)
            {
                
                ciudad.CiudadId = Convertir();
                if (ciudad.Eliminar())
                {
                    MessageBox.Show("Ciudad Eliminada correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    NuevoButton.PerformClick();
                }
                else
                {
                    MessageBox.Show("Error al eliminar la ciudad", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void CiudadIdTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                miError.SetError(CiudadIdTextBox, "Solo se perminten numeros");
                e.Handled = true;
                return;
            }
            else
            {
                miError.SetError(CiudadIdTextBox, "");
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

        private void CodigoPostalTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                miError.SetError(CodigoPostalTextBox, "Solo se permiten numeros");
                e.Handled = true;
                return;
            }
            else
            {
                miError.SetError(CodigoPostalTextBox, "");
            }
        }
    }
}
