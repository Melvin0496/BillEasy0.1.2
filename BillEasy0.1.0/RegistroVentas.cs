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
    public partial class RegistroVentas : Form
    {
        public RegistroVentas()
        {
            InitializeComponent();
        }

        private void Nuevobutton_Click(object sender, EventArgs e)
        {
            VentaIdtextBox.Clear();
            CantidadtextBox.Clear();
            PreciotextBox.Clear();
            NFCtextBox.Clear();
            TipoNFCtextBox.Clear();
            TipoVentastextBox.Clear();
            DescuentostextBox.Clear();
            TotaltextBox.Clear();
            VentasdataGridView.Rows.Clear();
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
        public void LlenarDatos(Ventas venta)
        {
            float itbis, total;
            float.TryParse(ITBIStextBox.Text, out itbis);
            float.TryParse(TotaltextBox.Text,out total);
            int id,mierda;
            int.TryParse(VentaIdtextBox.Text, out id);
            venta.VentaId = id;
            venta.ClienteId = (int)ClientecomboBox.SelectedValue;
            venta.TipoVenta = TipoVentastextBox.Text;
            venta.NFC = NFCtextBox.Text;
            venta.TipoNFC = TipoNFCtextBox.Text;
            venta.Fecha = FechadateTimePicker.Text;
            venta.ITBIS = itbis;
            venta.Total = total;
            
            foreach (DataGridViewRow row in VentasdataGridView.Rows)
            {
                mierda = Convert.ToInt32(row.Cells["ProductoId"].Value);
                venta.AgregarProducto(mierda,row.Cells["Nombre"].Value.ToString(),Convert.ToDouble(row.Cells["Precio"].Value),Convert.ToDouble(row.Cells["ITBIS"].Value));
                int eje = Convert.ToInt32(row.Cells["Cantidad"].Value);
                venta.AgregarVenta(mierda,eje, Convert.ToDouble(row.Cells["Descuento"].Value));
                venta.Tamano++;

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
            LlenarDatos(venta);
            if (venta.Insertar())
            {
                MessageBox.Show("Venta Guardada","Mensaje",MessageBoxButtons.OK,MessageBoxIcon.Information);
                Nuevobutton.PerformClick();
            }
            else
            {
                MessageBox.Show("Error al guardar","Alerta",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
        private void BuscarProductobutton_Click(object sender, EventArgs e)
        {
            int productoId;
            int.TryParse(ProductoIdtextBox.Text, out productoId);
            Productos producto = new Productos();

            
            if (producto.Buscar(productoId))
            {
                //MessageBox.Show("Producto encontrado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                PreciotextBox.Text = producto.Precio.ToString();
                NombretextBox.Text = producto.Nombre;
                ITBIStextBox.Text = producto.Costo.ToString();
                //VentasdataGridView.Rows.Add(producto.ProductoId.ToString(), producto.Nombre, CantidadtextBox.Text, producto.Precio.ToString(), producto.ITBIS.ToString(), DescuentostextBox.Text);

               
            }
            else
            {
                MessageBox.Show("El producto no existe", "alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
         //VentasdataGridView.Columns.Insert(0,producto.Precio.ToString());
        }

        private void BuscarVentabutton_Click(object sender, EventArgs e)
        {
            Ventas ventas = new Ventas();
            if (ventas.Buscar(Convertir()))
            {
                ClientecomboBox.SelectedValue = ventas.ClienteId;
                TipoVentastextBox.Text = ventas.TipoVenta;
                NFCtextBox.Text = ventas.NFC;
                TipoNFCtextBox.Text = ventas.TipoNFC;
                FechadateTimePicker.Text = ventas.Fecha;
                ITBIStextBox.Text = ventas.ITBIS.ToString();
                TotaltextBox.Text = ventas.Total.ToString();

                foreach (var venta in ventas.Producto)
                {
                    VentasdataGridView.Rows.Add(venta.ProductoId.ToString(),venta.Nombre,venta.Precio.ToString(),venta.ITBIS.ToString());
                }

                /*foreach (var venta in ventas.Venta)
                {
                    VentasdataGridView.Rows.Add(ventas.Cantidad.ToString(), ventas.Descuento.ToString());
                }*/
            }
            else
            {
                MessageBox.Show("Id invalido","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }

        }

        private void Agregarbutton_Click(object sender, EventArgs e)
        {
            VentasdataGridView.Rows.Add(ProductoIdtextBox.Text, NombretextBox.Text, CantidadtextBox.Text, PreciotextBox.Text, ITBIStextBox.Text, DescuentostextBox.Text);
            ProductoIdtextBox.Clear();
            PreciotextBox.Clear();
            ITBIStextBox.Clear();
            NombretextBox.Clear();
        }

        private void CantidadtextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("No es una cantidad valida", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Handled = true;
                return;
            }
        }

        private void DescuentostextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (DescuentostextBox.Text.Contains("."))
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

        private void VentaIdtextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten numeros", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Handled = true;
                return;
            }

        }

        private void ProductoIdtextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten numeros", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Handled = true;
                return;
            }
        }
    }
}
