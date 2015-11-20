using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class Ventas : ClaseMaestra
    {
        public int VentaId { get; set; }
        public int ClienteId { get; set; }
        public int UsuarioId { get; set; }
        public int ProductoId { get; set; }
        public string Fecha { get; set; }
        public double ITBIS { get; set; }
        public double Descuento { get; set; }
        public string TipoVenta { get; set; }
        public string NFC { get; set; }
        public string TipoNFC { get; set; }
        public double Total { get; set; }
        public int Cantidad { get; set; }
        public double Precio { get; set; }
        public int Tamano { get; set; }
        public List<Productos> Producto { get; set;}
        public List <Ventas>Venta  { get; set; }

        public Ventas()
        {
            this.VentaId = 0;
            this.ClienteId = 0;
            this.UsuarioId = 0;
            this.ProductoId = 0;
            this.Fecha = "";
            this.ITBIS = 0f;
            this.Descuento = 0f;
            this.TipoVenta = "";
            this.NFC = "";
            this.TipoNFC = "";
            this.Total = 0f;
            this.Cantidad = 0;
            this.Precio = 0f;
            Producto = new List<Productos>();
            Venta = new List<Ventas>();
        }

        public Ventas(int productoId,int cantidad,double descuentos)
        {
            this.ProductoId = productoId;
            this.Cantidad = cantidad;
            this.Descuento = descuentos;
            Venta = new List<Ventas>();
        }
       
        public void AgregarVenta(int productoId,int cantidad,double descuentos)
        {
            this.Venta.Add(new Ventas(productoId,cantidad,descuentos));
        }

        public void AgregarProducto(int productoId, string nombre,double precio,double itbis)
        {
            this.Producto.Add(new Productos(productoId,nombre,precio,itbis));
        }

        public override bool Insertar()
        {
            ConexionDb conexion = new ConexionDb();
            StringBuilder comando = new StringBuilder();
            bool retorno = false;
            double[] descuentos = new Double[this.Tamano];
            int contador = 0, contador2 = 0; 
            int[] cantidad;
            cantidad = new int[this.Tamano];
            retorno = conexion.Ejecutar(String.Format("Insert into Ventas(ClienteId,Fecha,ITBIS,TipoVentas,NFC,TipoNFC,Total) values({0},'{1}',{2},'{3}','{4}','{5}',{6})", this.ClienteId, this.Fecha, this.ITBIS, this.TipoVenta, this.NFC, this.TipoNFC, this.Total));

            if (retorno)
            {
                this.VentaId = (int)conexion.ObtenerDatos("Select MAX(VentaId) as VentaId from Ventas").Rows[0]["VentaId"];
                foreach (var venta in Venta)
                {
                    cantidad[contador] = venta.Cantidad;
                    descuentos[contador] = venta.Descuento;
                    contador++;
                }
                foreach (var producto in Producto)
                {
                    comando.AppendLine(String.Format("Insert into DetallesVentas(VentaId,ProductoId,Precio,Cantidad,Descuentos) values({0},{1},{2},{3},{4})", this.VentaId,producto.ProductoId,producto.Precio, cantidad[contador2], descuentos[contador2]));

                    contador2++;
                }
                retorno = conexion.Ejecutar(comando.ToString());
            }

            return retorno;
        }

        public override bool Editar()
        {
            ConexionDb conexion = new ConexionDb();
            StringBuilder comando = new StringBuilder();
            bool retorno = false;

            retorno = conexion.Ejecutar(String.Format("Update Ventas set ClienteId = {0},Fecha = '{1}',ITBIS = {2},Descuentos = {3},TipoVenta = {4},NFC = {5},TipoNFC = {6},Total = {7} where VentaId = {8}",ClienteId,Fecha,TipoVenta,NFC,TipoNFC,Total,this.VentaId));

            if (retorno)
            {
                conexion.Ejecutar("Delete from DetallesVentas where VentasId = " + this.VentaId);

                foreach(var producto in this.Producto)
                {
                    comando.AppendLine(String.Format("Insert into DetallesVentas(VentaId,ProductoId,Cantidad,Precio) values({0},{1},{2},{3},{4},{5})", this.VentaId, producto.ProductoId,this.Cantidad, this.Precio));
                }
                retorno = conexion.Ejecutar(comando.ToString());
            }
            return retorno;
        }

        public override bool Eliminar()
        {
            ConexionDb conexion = new ConexionDb();
            bool retorno = false;
            retorno = conexion.Ejecutar("Delete from Ventas where VentaId = " +this.VentaId + ";" 
                                          + "Delete from DetallesVentas where VentaId = " +this.VentaId);

            return retorno;

        }

        public override bool Buscar(int idBuscado)
        {
            ConexionDb conexion = new ConexionDb();
            DataTable dt = new DataTable();
            DataTable dtUsuarios = new DataTable();
            //double precio, itbis;

            dt = conexion.ObtenerDatos(String.Format("Select *from Ventas where VentaId = {0} ",idBuscado));
            dtUsuarios = conexion.ObtenerDatos(String.Format("Select V.Nombre,V.ITBIS,D.ProductoId,D.Cantidad,D.Precio ,D.Descuentos from DetallesVentas D inner join Productos V on D.ProductoId = V.ProductoId   where D.VentaId = {0} ", idBuscado));

            if (dt.Rows.Count > 0)
            {
                this.ClienteId = (int)dt.Rows[0]["ClienteId"];
                this.Fecha = dt.Rows[0]["Fecha"].ToString();
                //this.ITBIS = (double)dt.Rows[0]["ITBIS"];
                //this.Descuento = (double)dt.Rows[0]["Descuento"];
                this.TipoVenta = dt.Rows[0]["TipoVentas"].ToString();
                this.NFC = dt.Rows[0]["NFC"].ToString();
                this.TipoNFC = dt.Rows[0]["TipoNFC"].ToString();
                //this.Total = (double)dt.Rows[0]["Total"];

                this.Producto.Clear();
                foreach(DataRow row in dtUsuarios.Rows)
                {


                    this.AgregarProducto((int)row["ProductoId"], row["Nombre"].ToString(), Convert.ToDouble(row["Precio"]), Convert.ToDouble(row["ITBIS"]));
                }
                foreach (DataRow row in dtUsuarios.Rows)
                {
                    this.AgregarVenta((int)row["ProductoId"],(int)(row["Cantidad"]), Convert.ToDouble(row["Descuentos"]));
                }
                
            }

            return dt.Rows.Count > 0;
        }

        public override DataTable Listado(string campos, string condicion, string orden)
        {
            ConexionDb conexion = new ConexionDb();
            string ordenFinal = "";
            if (!orden.Equals(""))
                ordenFinal = " Orden by  " + orden;

            return conexion.ObtenerDatos("Select " + campos +
                " From Ventas Where " + condicion + "" + ordenFinal);
        }
    }
}
