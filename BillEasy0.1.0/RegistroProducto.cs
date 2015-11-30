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
using System.Globalization;
using System.Threading;
using BLL;
namespace BillEasy0._1._0
{
    public partial class RegistroProducto : Form
    {
        ErrorProvider miError;
        public RegistroProducto()
        {
            InitializeComponent();
            miError = new ErrorProvider();
        }
        private void LLenarDatos(Productos producto)
        {
            float precio, costo, itbis;
            int cantidad;
            Regex espacio = new Regex(@"\s+");
            float.TryParse(PrecioTextBox.Text, out precio);
            float.TryParse(CostoTextBox.Text, out costo);
            float.TryParse(ITBISTextBox.Text, out itbis);
            int.TryParse(CantidadTextBox.Text, out cantidad);
            producto.MarcaId = (int)MarcaComboBox.SelectedValue;
            producto.Nombre = espacio.Replace(NombreTextBox.Text, " ");
            producto.Precio = precio;
            producto.Costo = costo;
            producto.Cantidad = cantidad;
            producto.ITBIS = itbis * precio / 100;
        }

        private int Validar()
        {
            int retorno = 0;

            if (!Regex.Match(NombreTextBox.Text, "^\\w{1,50}$").Success)
            {
                miError.SetError(NombreTextBox, "Sobrepasa tamaño permitido de 50");
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

            if (NombreTextBox.Text == "")
            {
                miError.SetError(NombreTextBox, "Debe llenar el nombre del producto");
                contador = 1;
            }
            else
            {
                miError.SetError(NombreTextBox, "");
            }
            if (PrecioTextBox.Text == "")
            {
                miError.SetError(PrecioTextBox, "Debe llenar el precio");
                contador = 1;
            }
            else
            {
                miError.SetError(PrecioTextBox, "");
            }
            if (CostoTextBox.Text == "")
            {
                miError.SetError(CostoTextBox, "Debe llenar el Costo");
                contador = 1;
            }
            else
            {
                miError.SetError(CostoTextBox, "");
            }
            if (ITBISTextBox.Text == "")
            {
                miError.SetError(ITBISTextBox, "Debe llenar el ITBIS");
                contador = 1;
            }
            else
            {
                miError.SetError(ITBISTextBox, "");
            }
            if ((int)MarcaComboBox.SelectedValue == 0)
            {
                miError.SetError(MarcaComboBox, "Debe insertar una marca");
                contador = 1;

            }
            else
            {
                miError.SetError(MarcaComboBox, "");
            }
            return contador;
        }


        public int Convertidor()
        {
            int id;
            int.TryParse(ProductoIdTextBox.Text, out id);
            return id;
        }

        private void RegistroProducto_Load(object sender, EventArgs e)
        {
            Marcas marca = new Marcas();

            MarcaComboBox.DataSource = marca.Listado("MarcaId,Nombre", "1=1", "");
            MarcaComboBox.DisplayMember = "Nombre";
            MarcaComboBox.ValueMember = "MarcaId";

        }

        private void BuscarButton_Click(object sender, EventArgs e)
        {
            Productos producto = new Productos();
            if (producto.Buscar(Convertidor()))
            {
                ProductoIdTextBox.Text = producto.ProductoId.ToString();
                NombreTextBox.Text = producto.Nombre.ToString();
                MarcaComboBox.SelectedValue = producto.MarcaId;
                PrecioTextBox.Text = producto.Precio.ToString();
                CostoTextBox.Text = producto.Costo.ToString();
                CantidadTextBox.Text = producto.Cantidad.ToString();
                ITBISTextBox.Text = producto.ITBIS.ToString();
                ProductoIdTextBox.ReadOnly = true;
            }
            else
            {
                MessageBox.Show("Id incorrecto", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void NuevoButton_Click(object sender, EventArgs e)
        {
            ProductoIdTextBox.Clear();
            NombreTextBox.Clear();
            PrecioTextBox.Clear();
            CostoTextBox.Clear();
            ITBISTextBox.Clear();
            CantidadTextBox.Clear();
            ProductoIdTextBox.ReadOnly = false;
        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            Productos productos = new Productos();
            if (ProductoIdTextBox.TextLength == 0)
            {
                LLenarDatos(productos);
                if (Error() == 0 && Validar() == 1 && productos.Insertar())
                {
                    MessageBox.Show("Producto insertado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    NuevoButton.PerformClick();
                }
                else
                {
                    MessageBox.Show("Error la insertar", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                LLenarDatos(productos);
                productos.ProductoId = Convertidor();
                if (Error() == 0 && Validar() == 1 && productos.Editar())
                {
                    MessageBox.Show("Producto editado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            Productos producto = new Productos();
            if (ProductoIdTextBox.TextLength > 0)
            {
                producto.ProductoId = Convertidor();
                if (producto.Eliminar())
                {
                    MessageBox.Show("Producto Eliminado correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    NuevoButton.PerformClick();
                }
                else
                {
                    MessageBox.Show("Error al eliminar", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void ProductoIdTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                miError.SetError(ProductoIdTextBox, "Solo se permiten numeros");
                e.Handled = true;
                return;
            }
            else
            {
                miError.SetError(ProductoIdTextBox, "");
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


        private void PrecioTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            /*if (CostoTextBox.Text.Contains("."))
            {
                if (e.KeyChar == '.' && (e.KeyChar != (char)Keys.Back))
                {
                    e.Handled = true;
                }
            }
            else
            {
                if (!char.IsDigit(e.KeyChar) && (e.KeyChar != (char)Keys.Back))
                {
                    e.Handled = true;
                }

                if (char.IsPunctuation(e.KeyChar) && (e.KeyChar != (char)Keys.Back))
                {
                    e.Handled = false;
                }
            }*/
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
            if(e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
            {

                e.Handled = true;
            }

        }

        private void CostoTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            /*if (CostoTextBox.Text.Contains("."))
            {
                if (!char.IsDigit(e.KeyChar) && (e.KeyChar != (char)Keys.Back))
                {
                    e.Handled = true;
                }
            }
            else
            {
                if (!char.IsDigit(e.KeyChar) && (e.KeyChar != (char)Keys.Back))
                {
                    e.Handled = true;
                }

                if (char.IsPunctuation(e.KeyChar) && (e.KeyChar != (char)Keys.Back))
                {
                    e.Handled = false;
                }
            }*/
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
            {

                e.Handled = true;
            }
        }

        private void ITBISTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                miError.SetError(ITBISTextBox, "Solo se permiten numeros");
                e.Handled = true;
                return;
            }
            else
            {
                miError.SetError(ITBISTextBox, "");
            }
        }
    }
}
