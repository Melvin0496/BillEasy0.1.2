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
        }

        private int Validar()
        {
            int retorno = 0;

            if (!Regex.Match(NFCtextBox.Text, "^\\w{1,20}$").Success)
            {
                miError.SetError(NFCtextBox, "Sobrepasa tamaño permitido de 20");
                
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

            if (NFCtextBox.TextLength == 0)
            {
                miError.SetError(NFCtextBox, "Debe llenar el NFC");
                contador = 1;
            }
            else
            {
                miError.Clear();
            }
           
            if (TipoNFCtextBox.TextLength == 0)
            {
                miError.SetError(TipoNFCtextBox, "Debe llenar el tipo de NFC");
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
           
            
            return contador;
        }

        private void Nuevobutton_Click(object sender, EventArgs e)
        {
            VentaIdtextBox.Clear();
            CantidadtextBox.Clear();
            PreciotextBox.Clear();
            NFCtextBox.Clear();
            TipoNFCtextBox.Clear();
            DescuentostextBox.Clear();
            TotaltextBox.Clear();
            VentasdataGridView.Rows.Clear();
            BuscarVentabutton.Enabled = true;
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
            int.TryParse(VentaIdtextBox.Text, out id);
            return id;
        }
        float total = 0f;
        public void LlenarDatos(Ventas venta)
        {
            float itbis;
            int id;
            int.TryParse(VentaIdtextBox.Text, out id);
            venta.VentaId = id;
            venta.ClienteId = (int)ClientecomboBox.SelectedValue;
            venta.TipoVenta = TipoVentacomboBox.Text;
            venta.NFC = NFCtextBox.Text;
            venta.TipoNFC = TipoNFCtextBox.Text;
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
                Nuevobutton.PerformClick();
            }
            else
            {
                MessageBox.Show("Error al eliminar","alerta",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            Ventas venta = new Ventas();

            if (VentaIdtextBox.Text.Length == 0)
            {
                LlenarDatos(venta);
                if (Error() == 0 && Validar() == 1 && venta.Insertar())
                {
                    MessageBox.Show("Venta Guardada", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Nuevobutton.PerformClick();
                }
                else
                {
                    MessageBox.Show("Error al guardar", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if(VentaIdtextBox.Text.Length > 0)
            {
                venta.VentaId = Convertir();
                LlenarDatos(venta);
                if (Error() == 0 && Validar() == 1 && venta.Editar())
                {
                    MessageBox.Show("Venta Editada", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Nuevobutton.PerformClick();
                }
                else
                {
                    MessageBox.Show("Error al editar", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void BuscarProductobutton_Click(object sender, EventArgs e)
        {
            int productoId;
            int.TryParse(ProductoIdtextBox.Text, out productoId);
            Productos producto = new Productos();

            
            if (producto.Buscar(productoId))
            {
                PreciotextBox.Text = producto.Precio.ToString();
                NombretextBox.Text = producto.Nombre;
                ITBIStextBox.Text = producto.ITBIS.ToString();
            }
            else
            {
                MessageBox.Show("El producto no existe", "alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BuscarVentabutton_Click(object sender, EventArgs e)
        {
            Ventas ventas = new Ventas();
            if (ventas.Buscar(Convertir()))
            {
                ClientecomboBox.SelectedValue = ventas.ClienteId;
                TipoVentacomboBox.Text = ventas.TipoVenta;
                NFCtextBox.Text = ventas.NFC;
                TipoNFCtextBox.Text = ventas.TipoNFC;
                FechadateTimePicker.Text = ventas.Fecha;
                TotaltextBox.Text = ventas.Total.ToString();
                foreach (var venta in ventas.Producto)
                {
                    VentasdataGridView.Rows.Add(venta.ProductoId.ToString(), venta.Nombre, venta.Cantidad.ToString(), venta.Precio.ToString(), venta.ITBIS.ToString(),venta.Descuentos.ToString(),venta.Importe.ToString());
                }
                BuscarVentabutton.Enabled = false;
             
            }
            else
            {
                MessageBox.Show("Id invalido","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
        
        private void Agregarbutton_Click(object sender, EventArgs e)
        {
            Ventas venta = new Ventas();
            int cantidad;
            float precio, itbis, descuento;
            float.TryParse(PreciotextBox.Text, out precio);
            int.TryParse(CantidadtextBox.Text, out cantidad);
            float.TryParse(ITBIStextBox.Text, out itbis);
            miError.Clear();
            if (DescuentostextBox.TextLength == 0 || CantidadtextBox.TextLength == 0)
            {
                miError.SetError(CantidadtextBox, "Debe de completar este campo");
                miError.SetError(DescuentostextBox, "Debe de completar este campo");
                
            }
            else
            {
                itbis *= cantidad;
                float importe = (precio * cantidad) + itbis;
                float.TryParse(DescuentostextBox.Text, out descuento);
                total += importe - descuento;
                TotaltextBox.Text = total.ToString();
                VentasdataGridView.Rows.Add(ProductoIdtextBox.Text, NombretextBox.Text, CantidadtextBox.Text, PreciotextBox.Text, itbis.ToString(), descuento.ToString(), importe.ToString());
                LimpiarProducto();
            }
        }
        public void LimpiarProducto()
        {
            ProductoIdtextBox.Clear();
            PreciotextBox.Clear();
            ITBIStextBox.Clear();
            NombretextBox.Clear();
            CantidadtextBox.Clear();
            DescuentostextBox.Clear();
        }
        private void CantidadtextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                miError.SetError(CantidadtextBox,"No es una cantidad valida");
                e.Handled = true;
                return;
            }
            miError.Clear();
        }

        private void DescuentostextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            /*if (DescuentostextBox.Text.Contains("."))
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

        private void VentaIdtextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                miError.SetError(VentaIdtextBox,"VentaId incorrecto");
                e.Handled = true;
                return;
            }
            miError.Clear();

        }

        private void ProductoIdtextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                miError.SetError(ProductoIdtextBox,"ProductoId incorrecto");
                e.Handled = true;
                return;
            }
            miError.Clear();
        }

        private void Imprimirbutton_Click(object sender, EventArgs e)
        {
            VentanaReporteVenta reporteVenta = new VentanaReporteVenta();
            reporteVenta.Show();
        }
    }
}
