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
            Regex espacio = new Regex(@"\s+");
            float.TryParse(PrecioTextBox.Text, out precio);
            float.TryParse(CostoTextBox.Text, out costo);
            float.TryParse(ITBISTextBox.Text, out itbis);
            producto.MarcaId = (int)MarcaComboBox.SelectedValue;
            producto.Nombre = espacio.Replace(NombreTextBox.Text, " ");
            producto.Precio = precio;
            producto.Costo = costo;
            producto.ITBIS = itbis*precio/100;
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
                ITBISTextBox.Text = producto.ITBIS.ToString();
            }
            else
            {
                MessageBox.Show("Id incorrecto","Alerta",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void NuevoButton_Click(object sender, EventArgs e)
        {
            ProductoIdTextBox.Clear();
            NombreTextBox.Clear();
            PrecioTextBox.Clear();
            CostoTextBox.Clear();
            ITBISTextBox.Clear();
        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            Productos productos = new Productos();
            if(ProductoIdTextBox.TextLength == 0)
            {
                LLenarDatos(productos);
                if (productos.Insertar() && Error() == 0)
                {
                    MessageBox.Show("Producto insertado","Mensaje",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    NuevoButton.PerformClick();
                }
                else
                {
                    MessageBox.Show("Error la insertar","Alerta",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
            else
            {
                LLenarDatos(productos);
                productos.ProductoId = Convertidor();
                if(productos.Editar() && Error() == 0)
                {
                    MessageBox.Show("Producto editado","Mensaje",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    NuevoButton.PerformClick();
                }
                else
                {
                    MessageBox.Show("Error al editar","Alerta",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
        }

        private void EliminarButton_Click(object sender, EventArgs e)
        {
            Productos producto = new Productos();
            if (ProductoIdTextBox.TextLength > 0)
            {
                producto.ProveedorId = Convertidor();
                if (producto.Eliminar())
                {
                    MessageBox.Show("Producto Eliminado correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    NuevoButton.PerformClick();
                }
                else
                {
                    MessageBox.Show("Error al eliminar","Alerta",MessageBoxButtons.OK,MessageBoxIcon.Error);
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
            if (PrecioTextBox.Text.Contains("."))
            {
                if (!char.IsDigit(e.KeyChar) && (e.KeyChar != (char)Keys.Back))
                {
                    e.Handled = true;
                }
                else
                {
                    miError.SetError(PrecioTextBox, "");
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
            }
        }

        private void CostoTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (CostoTextBox.Text.Contains("."))
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

        private void MarcaComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void NombreTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
