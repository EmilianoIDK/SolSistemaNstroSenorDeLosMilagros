using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidades;

namespace CapaDatos
{
    public class datEmpleado
    {
        #region Singleton
        private static readonly datEmpleado UnicaInstancia = new datEmpleado();

        public static datEmpleado Instancia
        {
            get
            {
                return datEmpleado.UnicaInstancia;
            }
        }
        #endregion Singleton

        #region Metodos CRUD
        public entEmpleado Verificar_Inicio_Sesion(String usuario, String contrasena)
        {
            entEmpleado e = null;
            SqlCommand cmd = null;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar(); //Conexion a la base dde datos
                cmd = new SqlCommand("Verificar_Inicio_Sesion", cn);  //Consulta a la base de datos
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmUsuario", usuario);
                cmd.Parameters.AddWithValue("@prmContrasena", contrasena);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    e = new entEmpleado();
                    e.idEmpleado = Convert.ToInt32(dr["id_Empleado"]);
                    e.nombres = Convert.ToString(dr["nombres"]);
                    e.apellidos = Convert.ToString(dr["apellidos"]);
                    e.cargo = Convert.ToString(dr["cargo"]);
                    e.telefono = Convert.ToString(dr["telefono"]);
                    e.estado = Convert.ToBoolean(dr["estado"]);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Connection.Close();
            }


            return e;
        }
        #endregion Metodos CRUD
    }
}
