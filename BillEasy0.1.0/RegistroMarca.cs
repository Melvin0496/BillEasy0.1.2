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
    public partial class RegistroMarca : Form
    {
        ErrorProvider miError;
        public RegistroMarca()
        {
            InitializeComponent();
            miError = new ErrorProvider();
        }

        private void LlenarDatos(Marcas marca)
        {
            
            Regex espacio = new Regex(@"\s+");
            marca.Nombre = espacio.Replace(NombreTextBox.Text, " "); ;
        }
        private int Validar()
        {
            int retorno = 0;

            if (!Regex.Match(NombreTextBox.Text, "^\\w{1,50}$").Success)
            {
                miError.SetError(NombreTextBox,"Sobrepasa tamaño permitido de 50");
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
            if (NombreTextBox.Text == "")
            {
                miError.SetError(NombreTextBox, "Debe llenar el nombre de la marca");
                contador += 1;
            }
            else
            {
                miError.Clear();
            }
            return contador;
        }


        public int Convertir()
        {
            int id;
            int.TryParse(MarcaIdTextBox.Text,out id);
            return id;
        }
        private void BuscarButton_Click(object sender, EventArgs e)
        {
            Marcas marca = new Marcas();
            if (marca.Buscar(Convertir()))
            {
                NombreTextBox.Text = marca.Nombre;
                MarcaIdTextBox.ReadOnly = true;
            }
            else
            {
                MessageBox.Show("Id incorrecto","Alerta",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            
        }

        private void NuevoButton_Click(object sender, EventArgs e)
        {
            MarcaIdTextBox.Clear();
            NombreTextBox.Clear();
            MarcaIdTextBox.ReadOnly = false;
        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            Marcas marca = new Marcas();
            if (MarcaIdTextBox.Text.Length == 0)
            {
                LlenarDatos(marca);

                if (Error() == 0 && Validar() == 1 && marca.Insertar())
                {
                    MessageBox.Show("Marca Guardada", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    NuevoButton.PerformClick();
                }
                else
                {
                    MessageBox.Show("Error al insertar la marca ", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (MarcaIdTextBox.Text.Length > 0 )
            {
                marca.MarcaId = Convertir();
                LlenarDatos(marca);
                if (Error() == 0 && Validar() == 1 && marca.Editar())
                {
                    MessageBox.Show("Marca Editada", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    NuevoButton.PerformClick();
                }
                else
                {
                    MessageBox.Show("Error al insertar la marca ", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            
        }

        private void EliminarButton_Click(object sender, EventArgs e)
        {
            Marcas marca = new Marcas();
            if (MarcaIdTextBox.TextLength == 0)
            {
                MessageBox.Show("Debe especificar el ID", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            if (MarcaIdTextBox.Text.Length > 0)
            {
                marca.MarcaId = Convertir();
                if (marca.Eliminar())
                {
                    MessageBox.Show("Marca Eliminada correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    NuevoButton.PerformClick();
                }
                else
                {
                    MessageBox.Show("Error al eliminar la marca", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void MarcaIdTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                miError.SetError(MarcaIdTextBox, "Solo se permiten numeros");
                e.Handled = true;
                return;
            }
            else
            {
                miError.SetError(MarcaIdTextBox, "");
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
