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
        public string TipoVenta { get; set; }
        public string NFC { get; set; }
        public string TipoNFC { get; set; }
        public float Total { get; set; }
        public float Precio { get; set; }
        public float Importe { get; set; }
        public List<Productos> Producto { get; set;}
        public List <Ventas>Venta  { get; set; }


        public Ventas()
        {
            this.VentaId = 0;
            this.ClienteId = 0;
            this.UsuarioId = 0;
            this.ProductoId = 0;
            this.Fecha = "";
            this.TipoVenta = "";
            this.NFC = "";
            this.TipoNFC = "";
            this.Total = 0f;
            this.Precio = 0f;
            this.Importe = 0f;
            Producto = new List<Productos>();
        }
        

        public void AgregarProducto(int productoId, string nombre,float precio,float itbis,int cantidad,float descuentos,float importe)
        {
            this.Producto.Add(new Productos(productoId,nombre,precio,itbis,cantidad,descuentos,importe));
        }

        public override bool Insertar()
        {
            ConexionDb conexion = new ConexionDb();
            StringBuilder comando = new StringBuilder();
            bool retorno = false;
            retorno = conexion.Ejecutar(String.Format("Insert into Ventas(ClienteId,Fecha,TipoVentas,NFC,TipoNFC,Total) values({0},'{1}','{2}','{3}','{4}',{5})", this.ClienteId, this.Fecha, this.TipoVenta, this.NFC, this.TipoNFC, this.Total));

            if (retorno)
            {
                this.VentaId = (int)conexion.ObtenerDatos("Select MAX(VentaId) as VentaId from Ventas").Rows[0]["VentaId"];
              
                foreach (var producto in Producto)
                {
                    comando.AppendLine(String.Format("Insert into DetallesVentas(VentaId,ProductoId,Precio,Cantidad,Descuentos,Importe) values({0},{1},{2},{3},{4},{5})", this.VentaId,producto.ProductoId,producto.Precio, producto.Cantidad, producto.Descuentos,producto.Importe));
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

            retorno = conexion.Ejecutar(String.Format("Update Ventas set ClienteId = {0},Fecha = '{1}',TipoVentas = '{2}',NFC = '{3}',TipoNFC = '{4}',Total = {5} where VentaId = {6}",this.ClienteId,this.Fecha,this.TipoVenta,this.NFC,this.TipoNFC,this.Total,this.VentaId));

            if (retorno)
            {
                conexion.Ejecutar("Delete from DetallesVentas where VentaId = " + this.VentaId);

                foreach(var producto in this.Producto)
                {
                    comando.AppendLine(String.Format("Insert into DetallesVentas(VentaId,ProductoId,Precio,Cantidad,Descuentos,Importe) values({0},{1},{2},{3},{4},{5})", this.VentaId, producto.ProductoId, producto.Precio, producto.Cantidad, producto.Descuentos,producto.Importe));
                }
                retorno = conexion.Ejecutar(comando.ToString());
            }
            return retorno;
        }

        public override bool Eliminar()
        {
            ConexionDb conexion = new ConexionDb();
            bool retorno = false;
            retorno = conexion.Ejecutar("Delete from DetallesVentas where VentaId = " +this.VentaId + ";" 
                                          + "Delete from Ventas where VentaId = " +this.VentaId);

            return retorno;

        }

        public override bool Buscar(int idBuscado)
        {
            ConexionDb conexion = new ConexionDb();
            DataTable dt = new DataTable();
            DataTable dtVentas = new DataTable();

            dt = conexion.ObtenerDatos(String.Format("Select *from Ventas where VentaId = {0} ",idBuscado));
            dtVentas = conexion.ObtenerDatos(String.Format("Select V.Nombre,V.ITBIS,D.ProductoId,D.Cantidad,D.Precio ,D.Descuentos,D.Importe from DetallesVentas D inner join Productos V on D.ProductoId = V.ProductoId   where D.VentaId = {0} ", idBuscado));
            if (dt.Rows.Count > 0)
            {
                this.ClienteId = (int)dt.Rows[0]["ClienteId"];
                this.Fecha = dt.Rows[0]["Fecha"].ToString();
                this.TipoVenta = dt.Rows[0]["TipoVentas"].ToString();
                this.NFC = dt.Rows[0]["NFC"].ToString();
                this.TipoNFC = dt.Rows[0]["TipoNFC"].ToString();
                this.Total = Convert.ToSingle(dt.Rows[0]["Total"]);
                this.Producto.Clear();
                foreach(DataRow row in dtVentas.Rows)
                {
                  this.AgregarProducto((int)row["ProductoId"], row["Nombre"].ToString(), Convert.ToSingle(row["Precio"]), Convert.ToSingle(row["ITBIS"]), (int)(row["Cantidad"]), Convert.ToSingle(row["Descuentos"]), Convert.ToSingle(row["Importe"]));
                }

                    
                
                
            }

            return dt.Rows.Count > 0;
        }
        public DataTable GetTotal()
        {
            ConexionDb conexion = new ConexionDb();

            return conexion.ObtenerDatos("Select Total from Ventas where VentaId = " + this.VentaId);
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
