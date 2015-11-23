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
    public partial class RegistroCompras : Form
    {
        public RegistroCompras()
        {
            InitializeComponent();
        }
        private void RegistroCompras_Load(object sender, EventArgs e)
        {
            Proveedores proveedor = new Proveedores();
            Usuarios usuario = new Usuarios();
            ProveedorComboBox.DataSource = proveedor.Listado("*", "1=1", "");
            ProveedorComboBox.DisplayMember = "NombreEmpresa";
            ProveedorComboBox.ValueMember = "ProveedorId";
        }
        private void BuscarVentaButton_Click(object sender, EventArgs e)
        {

        }

        private void BuscarProductoButton_Click(object sender, EventArgs e)
        {
            Productos producto = new Productos();
            int productoId;
            int.TryParse(ProductoIdTextBox.Text,out productoId);
            if (producto.Buscar(productoId))
            {
                NombreTextBox.Text = producto.Nombre;
                CostoTextBox.Text = producto.Costo.ToString();
                ITBISTextBox.Text = producto.ITBIS.ToString();
            }
            else
            {
                MessageBox.Show("El producto no existe", "alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AgregarButton_Click(object sender, EventArgs e)
        {
            CompraDataGridView.Rows.Add(ProductoIdTextBox.Text, NombreTextBox.Text, CantidadTextBox.Text, CostoTextBox.Text, ITBISTextBox.Text, FleteTextBox.Text);
        }

        private void NuevoButton_Click(object sender, EventArgs e)
        {
            CompraIdTextBox.Clear();
            ProductoIdTextBox.Clear();
            CantidadTextBox.Clear();
            CostoTextBox.Clear();
            NFCTextBox.Clear();
            TipoNFCTextBox.Clear();
            TipoCompraTextBox.Clear();
            FleteTextBox.Clear();
            TotallTextBox.Clear();
            CompraDataGridView.Rows.Clear();
        }
        public void LlenarDatos(Compras compras)
        {
            int id,cantidad;
            float itbis, precio, flete;
            int.TryParse(CompraIdTextBox.Text,out id);
            int.TryParse(CantidadTextBox.Text,out cantidad);
            float.TryParse(ITBISTextBox.Text,out itbis);
            float.TryParse(CostoTextBox.Text, out precio);
            float.TryParse(FleteTextBox.Text, out flete);
           
            compras.CompraId = id;
            compras.Fecha = FechaDateTimePicker.Text;
            compras.Cantidad = cantidad;
            compras.TipoCompra = TipoCompraTextBox.Text;
            compras.NFC = NFCTextBox.Text;
            compras.TipoNFC = TipoNFCTextBox.Text;
            compras.Flete = flete;
            compras.ProveedorId = (int)ProveedorComboBox.SelectedValue;

            foreach (DataGridViewRow row in CompraDataGridView.Rows)
            {
                int mierda = Convert.ToInt32(row.Cells["ProductoId"].Value);
                //compras.AgregarProducto(mierda, row.Cells["Nombre"].Value.ToString(), Convert.ToDouble(row.Cells["Precio"].Value), Convert.ToDouble(row.Cells["ITBIS"].Value));
                //int eje = Convert.ToInt32(row.Cells["Cantidad"].Value);
                //venta.AgregarVenta(mierda, eje, Convert.ToDouble(row.Cells["Descuento"].Value));
                //venta.Tamano++;

            }
        }
        private void GuardarButton_Click(object sender, EventArgs e)
        {
            Compras compra = new Compras();
            if(CompraIdTextBox.TextLength == 0)
            {
                LlenarDatos(compra);
                if (compra.Insertar())
                {
                    MessageBox.Show("Compra registrada","Mensaje",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    NuevoButton.PerformClick();
                }
                else
                {
                    MessageBox.Show("Error al registrar la compra","Alerta",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
        }

        private void EliminarButton_Click(object sender, EventArgs e)
        {
            Compras compra = new Compras();
            if (compra.Eliminar())
            {
                MessageBox.Show("Compra Eliminada", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                NuevoButton.PerformClick();
            }
            else
            {
                MessageBox.Show("Error al eliminar", "alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CantidadTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("No es una cantidad valida", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Handled = true;
                return;
            }
        }

        private void FleteTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (FleteTextBox.Text.Contains("."))
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

        private void CompraIdTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Valor no valido", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Handled = true;
                return;
            }
        }

        private void ProductoIdTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Valor no valido", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Handled = true;
                return;
            }
        }
    }
}
