using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class Clientes : ClaseMaestra
    {
        public int ClienteId { get; set; }
        public int CiudadId { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Telefono { get; set; }
        public string Celular { get; set; }
        public string Direccion { get; set; }
        public string Email { get; set; }
        public string Cedula { get; set; }

        
        public Clientes()
        {
            this.ClienteId = 0;
            this.CiudadId = 0;
            this.Nombres = "";
            this.Apellidos = "";
            this.Telefono = "";
            this.Celular = "";
            this.Direccion = "";
            this.Email = "";
            this.Cedula = "";

        }

        public Clientes(int clienteId,int ciudadId,string nombres,string apellido,string telefono, string celular, string direccion, string email, string cedula)
        {
            this.ClienteId = ClienteId;
            this.CiudadId = ciudadId;
            this.Nombres = nombres;
            this.Apellidos =  apellido;
            this.Telefono =  telefono;
            this.Celular = celular;
            this.Direccion = direccion;
            this.Email =  email;
            this.Cedula = cedula;
        }

        public override bool Insertar()
        {
            bool retorno = false;
            ConexionDb conexion = new ConexionDb();
            retorno = conexion.Ejecutar(String.Format("Insert Into Clientes (CiudadId,Nombres,Apellidos,Telefono,Celular,Direccion,Email,Cedula) Values ({0},'{1}','{2}','{3}','{4}','{5}','{6}','{7}')",this.CiudadId,this.Nombres,this.Apellidos,this.Telefono,this.Celular,this.Direccion,this.Email,this.Cedula));
            return retorno;
        }

        public override bool Editar()
        {

            bool retorno = false;
            ConexionDb conexion = new ConexionDb();
            retorno = conexion.Ejecutar(String.Format("Update Clientes set CiudadId = {0} ,Nombres = '{1}', Apellidos = '{2}',Telefono = '{3}',Celular = '{4}',Direccion = '{5}' ,Email = '{6}',Cedula = '{7}' where ClienteId = {8} ",this.CiudadId, this.Nombres, this.Apellidos, this.Telefono, this.Celular, this.Direccion, this.Email, this.Cedula,this.ClienteId));
            return retorno;
        }

        public override bool Eliminar()
        {

            bool retorno = false;
            ConexionDb conexion = new ConexionDb();
            retorno = conexion.Ejecutar("Alter table Ventas NOCHECK constraint ALL " + ";" + "Delete Clientes where ClienteId =  " + this.ClienteId + "Alter table Ventas CHECK constraint ALL ");
            return retorno;
        }

        public override bool Buscar(int idBuscado)
        {
            ConexionDb conexion = new ConexionDb();
            DataTable dt = new DataTable();
            DataTable dtCiudades = new DataTable();
           
            dt = conexion.ObtenerDatos(String.Format("Select *from Clientes where ClienteId = {0}",idBuscado));
            if(dt.Rows.Count > 0)
            {
                
                this.Nombres = dt.Rows[0]["Nombres"].ToString();
                this.Apellidos = dt.Rows[0]["Apellidos"].ToString();
                this.Telefono = dt.Rows[0]["Telefono"].ToString();
                this.Celular = dt.Rows[0]["Celular"].ToString();
                this.Direccion = dt.Rows[0]["Direccion"].ToString();
                this.CiudadId = (int)dt.Rows[0]["CiudadId"];
                this.Email = dt.Rows[0]["Email"].ToString();
                this.Cedula = dt.Rows[0]["Cedula"].ToString();

                
            }
            return dt.Rows.Count > 0;
        }

        public override DataTable Listado(string campos, string condicion, string orden)
        {
            ConexionDb conexion = new ConexionDb();
            string ordenFinal = "";
            if (!orden.Equals(""))
                ordenFinal = " Orden by  " + orden;
            return conexion.ObtenerDatos("Select " + campos + " from Clientes where " + condicion + "" + ordenFinal);

        }
    }
}
