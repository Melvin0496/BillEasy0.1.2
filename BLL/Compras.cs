using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class Compras : ClaseMaestra
    {
        public int CompraId { get; set; }
        public int ProductoId { get; set; }
        public int ProveedorId { get; set; }
        public int UsuarioId { get; set; }
        public string Fecha { get; set; }
        public string TipoCompra { get; set; }
        public string NFC { get; set; }
        public string TipoNFC { get; set; }
        public float Flete { get; set; }
        public float Monto { get; set; }
        public float Costo { get; set; }
        public List<Productos> Producto { get; set; }


        public Compras()
        {
            this.CompraId = 0;
            this.ProductoId = 0;
            this.ProveedorId = 0;
            this.UsuarioId = 0;
            this.Fecha = "";
            this.TipoCompra = "";
            this.NFC = "";
            this.TipoNFC = "";
            this.Flete = 0f;
            this.Costo = 0f;
            this.Monto = 0f;
            Producto = new List<Productos>();
        }

        public void AgregarProducto(int productoId, string nombre, float costo, int cantidad, float itbis, float importe)
        {
            this.Producto.Add(new Productos(productoId, nombre, costo, cantidad, itbis, importe));
        }

        public override bool Insertar()
        {
            ConexionDb conexion = new ConexionDb();
            bool retorno;
            StringBuilder comando = new StringBuilder();

            retorno = conexion.Ejecutar(String.Format("Insert Into Compras(ProveedorId,Fecha  ,TipoCompra ,NFC ,TipoNFC , Flete,Monto ) Values({0},'{1}','{2}','{3}','{4}',{5},{6})", this.ProveedorId, this.Fecha, this.TipoCompra, this.NFC, this.TipoNFC, this.Flete, this.Monto));

            if (retorno)
            {
                this.CompraId = (int)conexion.ObtenerDatos("Select MAX(CompraId) as CompraId from Compras").Rows[0]["CompraId"];

                foreach (var producto in Producto)
                {
                    comando.AppendLine(String.Format("Insert into DetallesCompras(CompraId,ProductoId,Costo,Cantidad,Importe) values({0},{1},{2},{3},{4})", this.CompraId, producto.ProductoId, producto.Costo, producto.Cantidad, producto.Importe));
                }

                retorno = conexion.Ejecutar(comando.ToString());
            }
            return retorno;
        }

        public override bool Editar()
        {
            ConexionDb conexion = new ConexionDb();
            bool retorno = false;
            StringBuilder comando = new StringBuilder();

            retorno = conexion.Ejecutar(String.Format("Update Compras set ProveedorId = {0},Fecha = '{1}',TipoCompra = '{2}' ,NFC = '{3}' ,TipoNFC ='{4}' ,Flete ={5} , Monto = {6} Where CompraId = {7}", this.ProveedorId, this.Fecha, this.TipoCompra, this.NFC, this.TipoNFC, this.Flete, this.Monto, this.CompraId));
            if (retorno)
            {
                conexion.Ejecutar("Delete from DetallesCompras where CompraId = " + this.CompraId);

                foreach (var producto in Producto)
                {
                    comando.AppendLine(String.Format("Insert into DetallesCompras(CompraId,ProductoId,Costo,Cantidad,Importe) values({0},{1},{2},{3},{4})", this.CompraId, producto.ProductoId, producto.Costo, producto.Cantidad, producto.Importe));
                }
                retorno = conexion.Ejecutar(comando.ToString());
            }
            return retorno;

        }

        public override bool Eliminar()
        {
            ConexionDb conexion = new ConexionDb();
            bool retorno = false;
            retorno = conexion.Ejecutar("Delete From DetallesCompras where CompraId = " + this.CompraId + ";"
                                        + "Delete From  Compras Where CompraId = " + this.CompraId);
            return retorno;
        }

        public override bool Buscar(int idBuscado)
        {
            DataTable dt = new DataTable();
            DataTable dtProducto = new DataTable();
            ConexionDb conexion = new ConexionDb();
            StringBuilder comando = new StringBuilder();
            dt = conexion.ObtenerDatos(String.Format("Select * From Compras Where CompraId = {0} ", idBuscado));
            dtProducto = conexion.ObtenerDatos(String.Format("Select V.Nombre,V.ITBIS,D.ProductoId,D.Cantidad,D.Costo ,D.Importe from DetallesCompras D inner join Productos V on D.ProductoId = V.ProductoId   where D.CompraId = {0} ", idBuscado));
            if (dt.Rows.Count > 0)
            {

                this.ProveedorId = (int)dt.Rows[0]["ProveedorId"];
                //this.UsuarioId = (int)dt.Rows[0]["UsuarioId"];
                this.Fecha = dt.Rows[0]["Fecha"].ToString();
                this.TipoCompra = dt.Rows[0]["TipoCompra"].ToString();
                this.NFC = dt.Rows[0]["NFC"].ToString();
                this.TipoNFC = dt.Rows[0]["TipoNFC"].ToString();
                this.Flete = Convert.ToSingle(dt.Rows[0]["Flete"]);
                this.Monto = Convert.ToSingle(dt.Rows[0]["Monto"]);

                this.Producto.Clear();
                foreach (DataRow row in dtProducto.Rows)
                {
                    this.AgregarProducto((int)row["ProductoId"], row["Nombre"].ToString(), Convert.ToSingle(row["Costo"]), (int)(row["Cantidad"]), Convert.ToSingle(row["ITBIS"]), Convert.ToSingle(row["Importe"]));
                }
            }
            return dt.Rows.Count > 0;
        }

        public override DataTable Listado(string campos, string condicion, string orden)
        {
            ConexionDb conexion = new ConexionDb();
            string ordenFinal = "";
            if (!orden.Equals(""))
                ordenFinal = " Ordden by " + orden;
            return conexion.ObtenerDatos("Select " + campos +
                " From Compras Where " + condicion + "" + ordenFinal);
        }
    }
}

