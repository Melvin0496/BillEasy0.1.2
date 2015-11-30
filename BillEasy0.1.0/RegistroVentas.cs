using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using BLL;

namespace BillEasy0._1._0
{
    public partial class RegistroVentas : Form
    {
        ErrorProvider miError;
        public RegistroVentas()
        {
            InitializeComponent();
            miError = new ErrorProvider();
            TipoVentaComboBox.SelectedIndex = 0;
        }

        private int Validar()
        {
            int retorno = 0;

            if (!Regex.Match(NFCTextBox.Text, "^\\w{1,20}$").Success)
            {
                miError.SetError(NFCTextBox, "Sobrepasa tamaño permitido de 20");
                
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

            if (NFCTextBox.TextLength == 0)
            {
                miError.SetError(NFCTextBox, "Debe llenar el NFC");
                contador = 1;
            }
            else
            {
                miError.Clear();
            }
           
            if (TipoNFCTextBox.TextLength == 0)
            {
                miError.SetError(TipoNFCTextBox, "Debe llenar el tipo de NFC");
                contador = 1;
            }
            else
            {
                miError.Clear();
            }
           
            if (VentasdataGridView.RowCount == 0)
            {
                miError.SetError(VentasdataGridView, "Debe de agregar productos a la venta");
                contador = 1;
            }
            else
            {
                miError.Clear();
            }
            if ((int)ClientecomboBox.SelectedValue == 0)
            {
                miError.SetError(ClientecomboBox, "seleccionar el cliente");
                contador = 1;
            }
            else
            {
                miError.Clear();
            }


            return contador;
        }

        private void NuevoButton_Click(object sender, EventArgs e)
        {
            VentaIdTextBox.Clear();
            CantidadTextBox.Clear();
            PrecioTextBox.Clear();
            NFCTextBox.Clear();
            TipoNFCTextBox.Clear();
            DescuentosTextBox.Clear();
            TotalTextBox.Clear();
            VentasdataGridView.Rows.Clear();
            BuscarVentaButton.Enabled = true;
        }

        private void RegistroVentas_Load(object sender, EventArgs e)
        {
            Clientes cliente = new Clientes();
            Usuarios usuario = new Usuarios();
            ClientecomboBox.DataSource = cliente.Listado("*", "1=1", "");
            ClientecomboBox.DisplayMember = "Nombres";
            ClientecomboBox.ValueMember = "ClienteId";

        }
        public int Convertir()
        {
            int id;
            int.TryParse(VentaIdTextBox.Text, out id);
            return id;
        }
        float total = 0f;
        public void LlenarDatos(Ventas venta)
        {
            float itbis;
            int id;
            int.TryParse(VentaIdTextBox.Text, out id);
            venta.VentaId = id;
            venta.ClienteId = (int)ClientecomboBox.SelectedValue;
            venta.TipoVenta = TipoVentaComboBox.Text;
            venta.NFC = NFCTextBox.Text;
            venta.TipoNFC = TipoNFCTextBox.Text;
            venta.Fecha = FechadateTimePicker.Text;
            venta.Total = total;

            foreach (DataGridViewRow row in VentasdataGridView.Rows)
            {
                id= Convert.ToInt32(row.Cells["ProductoId"].Value);
                int cantidad = Convert.ToInt32(row.Cells["Cantidad"].Value);
                itbis = Convert.ToSingle(row.Cells["ITBIS"].Value);
                float descuentos = Convert.ToSingle(row.Cells["Descuento"].Value);
                venta.AgregarProducto(id,row.Cells["Nombre"].Value.ToString(),Convert.ToSingle(row.Cells["Precio"].Value),itbis, cantidad, descuentos, Convert.ToSingle(row.Cells["Importe"].Value));
                

            }

        }
        private void EliminarButton_Click(object sender, EventArgs e)
        {
            Ventas ventas = new Ventas();
            ventas.VentaId = Convertir();

            if (ventas.Eliminar())
            {
                MessageBox.Show("Venta Eliminada","Mensaje",MessageBoxButtons.OK,MessageBoxIcon.Information);
                NuevoButton.PerformClick();
            }
            else
            {
                MessageBox.Show("Error al eliminar","alerta",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            Ventas venta = new Ventas();

            if (VentaIdTextBox.Text.Length == 0)
            {
                LlenarDatos(venta);
                if (Error() == 0 && Validar() == 1 && venta.Insertar())
                {
                    MessageBox.Show("Venta Guardada", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    NuevoButton.PerformClick();
                }
                else
                {
                    MessageBox.Show("Error al guardar", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if(VentaIdTextBox.Text.Length > 0)
            {
                venta.VentaId = Convertir();
                LlenarDatos(venta);
                if (Error() == 0 && Validar() == 1 && venta.Editar())
                {
                    MessageBox.Show("Venta Editada", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    NuevoButton.PerformClick();
                }
                else
                {
                    MessageBox.Show("Error al editar", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void BuscarProductoButton_Click(object sender, EventArgs e)
        {
            int productoId;
            int.TryParse(ProductoIdTextBox.Text, out productoId);
            Productos producto = new Productos();

            
            if (producto.Buscar(productoId))
            {
                PrecioTextBox.Text = producto.Precio.ToString();
                NombreTextBox.Text = producto.Nombre;
                ITBISTextBox.Text = producto.ITBIS.ToString();
            }
            else
            {
                MessageBox.Show("El producto no existe", "alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BuscarVentaButton_Click(object sender, EventArgs e)
        {
            Ventas ventas = new Ventas();
            if (ventas.Buscar(Convertir()))
            {
                ClientecomboBox.SelectedValue = ventas.ClienteId;
                TipoVentaComboBox.Text = ventas.TipoVenta;
                NFCTextBox.Text = ventas.NFC;
                TipoNFCTextBox.Text = ventas.TipoNFC;
                FechadateTimePicker.Text = ventas.Fecha;
                TotalTextBox.Text = ventas.Total.ToString();
                total = ventas.Total;
                foreach (var venta in ventas.Producto)
                {
                    VentasdataGridView.Rows.Add(venta.ProductoId.ToString(), venta.Nombre, venta.Cantidad.ToString(), venta.Precio.ToString(), venta.ITBIS.ToString(),venta.Descuentos.ToString(),venta.Importe.ToString());
                }
                BuscarVentaButton.Enabled = false;
             
            }
            else
            {
                MessageBox.Show("Id invalido","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
        
        private void AgregarButton_Click(object sender, EventArgs e)
        {
            Ventas venta = new Ventas();
            int cantidad;
            float precio, itbis, descuento;
            float.TryParse(PrecioTextBox.Text, out precio);
            int.TryParse(CantidadTextBox.Text, out cantidad);
            float.TryParse(ITBISTextBox.Text, out itbis);
            miError.Clear();
            if (DescuentosTextBox.TextLength == 0 || CantidadTextBox.TextLength == 0)
            {
                miError.SetError(CantidadTextBox, "Debe de completar este campo");
                miError.SetError(DescuentosTextBox, "Debe de completar este campo");
                
            }
            else
            {
                itbis *= cantidad;
                float importe = (precio * cantidad) + itbis;
                float.TryParse(DescuentosTextBox.Text, out descuento);
                total += importe - descuento;
                TotalTextBox.Text = total.ToString();
                VentasdataGridView.Rows.Add(ProductoIdTextBox.Text, NombreTextBox.Text, CantidadTextBox.Text, PrecioTextBox.Text, itbis.ToString(), descuento.ToString(), importe.ToString());
                LimpiarProducto();
            }
        }
        public void LimpiarProducto()
        {
            ProductoIdTextBox.Clear();
            PrecioTextBox.Clear();
            ITBISTextBox.Clear();
            NombreTextBox.Clear();
            CantidadTextBox.Clear();
            DescuentosTextBox.Clear();
        }
        private void CantidadtextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                miError.SetError(CantidadTextBox,"No es una cantidad valida");
                e.Handled = true;
                return;
            }
            miError.Clear();
        }

        private void DescuentostextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
            {

                e.Handled = true;
            }
        }

        private void VentaIdtextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                miError.SetError(VentaIdTextBox,"VentaId incorrecto");
                e.Handled = true;
                return;
            }
            miError.Clear();

        }

        private void ProductoIdtextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                miError.SetError(ProductoIdTextBox,"ProductoId incorrecto");
                e.Handled = true;
                return;
            }
            miError.Clear();
        }

    }
}
