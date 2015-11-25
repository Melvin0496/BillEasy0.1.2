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
        double total;
        public int Convertir()
        {
            int id;
            int.TryParse(CompraIdTextBox.Text,out id);
            return id;
        }
        private void BuscarVentaButton_Click(object sender, EventArgs e)
        {
            Compras compras = new Compras();
            if (compras.Buscar(Convertir()))
            {
                ProveedorComboBox.SelectedValue = compras.ProveedorId;
                TipoCompraTextBox.Text = compras.TipoCompra;
                NFCTextBox.Text = compras.NFC;
                TipoNFCTextBox.Text = compras.TipoNFC;
                FechaDateTimePicker.Text = compras.Fecha;
                MontoTextBox.Text = compras.Monto.ToString();
                foreach (var compra in compras.Producto)
                {
                    CompraDataGridView.Rows.Add(compra.ProductoId.ToString(), compra.Nombre,compra.Costo.ToString(),compra.Cantidad.ToString(), compra.ITBIS.ToString(),compra.Importe.ToString());
                }

            }
            else
            {
                MessageBox.Show("Id invalido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

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
            ErrorerrorProvider.Clear();
            double itbis, cantidad, costo, importe,flete;
            double.TryParse(CantidadTextBox.Text,out cantidad);
            double.TryParse(ITBISTextBox.Text,out itbis);
            double.TryParse(CostoTextBox.Text,out costo);
            double.TryParse(FleteTextBox.Text, out flete);

           
                itbis *= cantidad;
                importe = (costo * cantidad) + itbis;
                total += importe + flete;
                CompraDataGridView.Rows.Add(ProductoIdTextBox.Text, NombreTextBox.Text, cantidad.ToString(), costo.ToString(), itbis.ToString(), importe.ToString());
                MontoTextBox.Text = total.ToString();

                FleteTextBox.Enabled = false;
                LimpiarProducto(); 
            
            
            
        }
        public void LimpiarProducto()
        {
            ProductoIdTextBox.Clear();
            NombreTextBox.Clear();
            CostoTextBox.Clear();
            CantidadTextBox.Clear();
            FleteTextBox.Clear();
            ITBISTextBox.Clear();
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
            MontoTextBox.Clear();
            CompraDataGridView.Rows.Clear();
        }
        public void LlenarDatos(Compras compras)
        {
            int id,cantidad;
            float itbis, precio, flete, monto;
            int.TryParse(CompraIdTextBox.Text,out id);
            int.TryParse(CantidadTextBox.Text,out cantidad);
            float.TryParse(ITBISTextBox.Text,out itbis);
            float.TryParse(CostoTextBox.Text, out precio);
            float.TryParse(FleteTextBox.Text, out flete);
            float.TryParse(MontoTextBox.Text,out monto);
           
            compras.CompraId = id;
            compras.Fecha = FechaDateTimePicker.Text;
            compras.Cantidad = cantidad;
            compras.TipoCompra = TipoCompraTextBox.Text;
            compras.NFC = NFCTextBox.Text;
            compras.TipoNFC = TipoNFCTextBox.Text;
            compras.Flete = flete;
            compras.Monto = monto;
            compras.ProveedorId = (int)ProveedorComboBox.SelectedValue;

            foreach (DataGridViewRow row in CompraDataGridView.Rows)
            {
                int id1 = Convert.ToInt32(row.Cells["ProductoId"].Value);
                int cantidad1 = Convert.ToInt32(row.Cells["Cantidad"].Value);
                compras.AgregarProducto(id1, row.Cells["Nombre"].Value.ToString(), Convert.ToDouble(row.Cells["Costo"].Value),cantidad1, Convert.ToDouble(row.Cells["ITBIS"].Value),Convert.ToDouble(row.Cells["Importe"].Value));

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
            compra.CompraId = Convertir();
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
