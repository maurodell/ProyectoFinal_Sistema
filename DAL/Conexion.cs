using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DAL
{
    public class Conexion
    {

        private static Conexion conn = null;
        private Conexion() { }

        public SqlConnection CrearConexion()
        {
            SqlConnection Cadena = new SqlConnection();
            try
            {
                Cadena.ConnectionString = @"Data Source=DESKTOP-P9A5E2K\SQLEXPRESS;Initial Catalog=final;Integrated Security=True";
            }
            catch (Exception ex)
            {
                Cadena = null;
                throw ex;
            }
            return Cadena;
        }
        public static Conexion getInstancia()
        {
            if(conn == null)
            {
                conn = new Conexion();
            }
            return conn;
        }
    }
}
