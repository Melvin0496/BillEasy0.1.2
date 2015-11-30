using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
namespace BLL
{
    public class Productos : ClaseMaestra
    {
        public int ProductoId { get; set; }
        public int MarcaId { get; set; }
        public string Nombre { get; set; }
        public int Cantidad { get; set; }
        public float Precio { get; set; }
        public float Costo { get; set; }
        public float ITBIS { get; set; }
        public float Flete { get; set; }
        public float Descuentos { get; set; }
        public float Importe { get; set; }

        public Productos()
        {
            this.ProductoId = 0;
            this.MarcaId = 0;
            this.Nombre = "";
            this.Cantidad = 0;
            this.Precio = 0f;
            this.Costo = 0f;
            this.ITBIS = 0f;
        }

        public Productos(int productoId, int marcaId, string nombre, int cantidad, float precio, float costo, float iTBIS)
        {
            this.ProductoId = productoId;
            this.MarcaId = marcaId;
            this.Nombre = nombre;
            this.Cantidad = cantidad;
            this.Precio = precio;
            this.Costo = costo;
            this.ITBIS = iTBIS;
        }
        public Productos(int productoId, string nombre, float precio, float itbis, int cantidad, float Descuentos, float importe)
        {
            this.ProductoId = productoId;
            this.Nombre = nombre;
            this.Precio = precio;
            this.ITBIS = itbis;
            this.Cantidad = cantidad;
            this.Descuentos = Descuentos;
            this.Importe = importe;
        }
        public Productos(int productoId, string nombre, float costo,int cantidad, float itbis,float importe)
        {
            this.ProductoId = productoId;
            this.Nombre = nombre;
            this.Costo = costo;
            this.ITBIS = itbis;
            this.Cantidad = cantidad;
            this.Importe = importe;
        }



        public override bool Insertar()
        {
            bool retorno;
            ConexionDb conexion = new ConexionDb();
            retorno = conexion.Ejecutar(String.Format("Insert Into Productos(MarcaId,Nombre,Cantidad,Precio,Costo,ITBIS) Values({0},'{1}',{2},{3},{4},{5}) ", this.MarcaId, this.Nombre,this.Cantidad, this.Precio, this.Costo, this.ITBIS, this.ProductoId));
            return retorno;
        }

        public override bool Editar()
        {
            bool retorno;
            ConexionDb conexion = new ConexionDb();
            retorno = conexion.Ejecutar(String.Format("Update Productos set MarcaId = {0},Nombre  = '{1}',Cantidad = {2},Precio = {3},Costo = {4}, ITBIS = {5} Where ProductoId = {6}" , this.MarcaId, this.Nombre,this.Cantidad, this.Precio, this.Costo, this.ITBIS, this.ProductoId));
            return retorno;
        }

        public override bool Eliminar()
        {
            bool retorno;
            ConexionDb conexion = new ConexionDb();
            retorno = conexion.Ejecutar("Alter table DetallesVentas NOCHECK constraint ALL " + ";"
                                      + "Alter table DetallesCompras NOCHECK constraint ALL" + ";"
                                      + "Delete Productos where ProductoId =  " + this.ProductoId
                                      + "Alter table DetallesVentas CHECK constraint ALL " + ";"
                                      + "Alter table DetallesCompras CHECK constraint ALL");
            return retorno;
        }

        public override bool Buscar(int idBuscado)
        {
            ConexionDb conexion = new ConexionDb();
            DataTable dt = new DataTable();
            dt = conexion.ObtenerDatos(String.Format("Select ProductoId,MarcaId,Nombre,Cantidad,Precio,Costo,ITBIS From Productos Where ProductoId = {0} ", idBuscado));
            if (dt.Rows.Count > 0)
            {
                this.ProductoId = (int)dt.Rows[0]["ProductoId"];
                this.MarcaId = (int)dt.Rows[0]["MarcaId"];
                this.Nombre = dt.Rows[0]["Nombre"].ToString();
                this.Cantidad = (int)dt.Rows[0]["Cantidad"];
                this.Precio = Convert.ToSingle(dt.Rows[0]["Precio"]);
                this.Costo = Convert.ToSingle(dt.Rows[0]["Costo"]);
                this.ITBIS = Convert.ToSingle(dt.Rows[0]["ITBIS"]);
            }
            return dt.Rows.Count > 0;
        }

        public override DataTable Listado(string campos, string condicion, string orden)
        {
            ConexionDb conexion = new ConexionDb();
            string ordenFinal = "";
            if (!orden.Equals(""))
                ordenFinal = " Orden by " + orden;
            return conexion.ObtenerDatos("Select " + campos +
                " From Productos  Where " + condicion + "" + ordenFinal);
        }
    }
}

