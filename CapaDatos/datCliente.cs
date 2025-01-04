using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using CapaEntidades;

namespace CapaDatos
{
    public class datCliente
    {
        #region Singleton
        private static readonly datCliente UnicaInstancia = new datCliente();

        public static datCliente Instancia
        {
            get
            {
                return datCliente.UnicaInstancia;
            }
        }
        #endregion Singleton

        #region Metodos CRUD

        // Método para listar clientes
        public List<entCliente> ListarClientes()
        {
            SqlCommand cmd = null;
            List<entCliente> lista = new List<entCliente>();
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar(); // Conexión a la base de datos
                cmd = new SqlCommand("spListarCliente", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    entCliente c = new entCliente();
                    c.idCliente = Convert.ToInt32(dr["idCliente"]);
                    c.nombres = Convert.ToString(dr["nombres"]);
                    c.apellidos = Convert.ToString(dr["apellidos"]);
                    c.dni = Convert.ToInt32(dr["dni"]);
                    c.telefono = Convert.ToString(dr["telefono"]);
                    c.email = Convert.ToString(dr["email"]);
                    c.estado = Convert.ToBoolean(dr["estado"]);
                    lista.Add(c);
                }
                cn.Close();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return lista;
        }

        // Método para buscar un cliente por ID
        public entCliente BuscarCliente(int idCliente)
        {
            SqlCommand cmd = null;
            entCliente c = null;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("BuscarCliente", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmidCliente", idCliente);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    c = new entCliente();
                    c.idCliente = Convert.ToInt32(dr["idCliente"]);
                    c.nombres = Convert.ToString(dr["nombres"]);
                    c.apellidos = Convert.ToString(dr["apellidos"]);
                    c.dni = Convert.ToInt32(dr["dni"]);
                    c.telefono = Convert.ToString(dr["telefono"]);
                    c.email = Convert.ToString(dr["email"]);
                    c.estado = Convert.ToBoolean(dr["estado"]);
                }
                cn.Close();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return c;
        }

        // Método para insertar un cliente
        public Boolean InsertarCliente(entCliente cliente)
        {
            SqlCommand cmd = null;
            bool insertar = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spInsertarCliente", cn); 
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmNombres", cliente.nombres);
                cmd.Parameters.AddWithValue("@prmApellidos", cliente.apellidos);
                cmd.Parameters.AddWithValue("@prmDNI", cliente.dni);
                cmd.Parameters.AddWithValue("@prmTelefono", cliente.telefono);
                cmd.Parameters.AddWithValue("@prmEmail", cliente.email);
                cn.Open();
                int filasAfectadas = cmd.ExecuteNonQuery();
                insertar = filasAfectadas > 0; // Retorna true si se insertó correctamente
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                if (cmd != null && cmd.Connection.State == ConnectionState.Open)
                    cmd.Connection.Close();
            }
            return insertar;
        }

        // Método para editar un cliente
        public Boolean EditarCliente(entCliente cliente)
        {
            SqlCommand cmd = null;
            try
            {
                using (SqlConnection cn = Conexion.Instancia.Conectar())
                {
                    cmd = new SqlCommand("spEditarCliente", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@prmidCliente", cliente.idCliente);
                    cmd.Parameters.AddWithValue("@prmNombres", cliente.nombres);
                    cmd.Parameters.AddWithValue("@prmApellidos", cliente.apellidos);
                    cmd.Parameters.AddWithValue("@prmDNI", cliente.dni);
                    cmd.Parameters.AddWithValue("@prmTelefono", cliente.telefono);
                    cmd.Parameters.AddWithValue("@prmEmail", cliente.email);
                    cn.Open();
                    int filasAfectadas = cmd.ExecuteNonQuery();
                    return filasAfectadas > 0; // Retorna true si se actualizó correctamente
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        // Método para eliminar un cliente
        public Boolean EliminarCliente(int idCliente)
        {
            SqlCommand cmd = null;
            try
            {
                using (SqlConnection cn = Conexion.Instancia.Conectar())
                {
                    cmd = new SqlCommand("EliminarCliente", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@prmidCliente", idCliente);
                    cn.Open();
                    int filasAfectadas = cmd.ExecuteNonQuery();
                    return filasAfectadas > 0; // Retorna true si se eliminó correctamente
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        #endregion Metodos CRUD
    }
}
