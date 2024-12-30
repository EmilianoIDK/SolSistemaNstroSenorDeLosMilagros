using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class Conexion
    {
        #region singleton
        private static readonly Conexion UnicaInstancia = new Conexion();

        public static Conexion Instancia
        {
            get
            {
                return Conexion.UnicaInstancia;
            }
        }
        #endregion singleton

        #region metodos
        public SqlConnection Conectar()
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = "Data Source=LAPTOP-C8GMATIL\\SQL_EXPRESS; Initial Catalog=DBNstroSenorDeLosMilagros; Integrated Security=True";
            
            try
            {
                cn.Open(); // Intenta abrir la conexión
                Console.WriteLine("Conexión exitosa");
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error al conectar a la base de datos: " + ex.Message);
            }

            return cn;
        }
        #endregion metodos
    }
}
