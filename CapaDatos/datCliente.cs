﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                    entCliente p = new entCliente();
                    p.idCliente = Convert.ToInt32(dr["idCliente"]);
                    p.dni = Convert.ToInt32(dr["dni"]);
                    p.nombres = Convert.ToString(dr["nombres"]);
                    p.apellidos = Convert.ToString(dr["apellidos"]);
                    p.telefono = Convert.ToString(dr["telefono"]);
                    p.email = Convert.ToString(dr["correo"]);
                    p.estado = Convert.ToBoolean(dr["estado"]);

                    lista.Add(p);
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
            entCliente c = null;

            using (SqlConnection cn = Conexion.Instancia.Conectar())
            {
                using (SqlCommand cmd = new SqlCommand("spBuscarCliente", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@prmidCliente", SqlDbType.Int).Value = idCliente;

                    try
                    {
                        cn.Open();
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                c = new entCliente
                                {
                                    idCliente = Convert.ToInt32(dr["idCliente"]),
                                    dni = Convert.ToInt32(dr["dni"]),
                                    nombres = Convert.ToString(dr["nombres"]),
                                    apellidos = Convert.ToString(dr["apellidos"]),
                                    telefono = Convert.ToString(dr["telefono"]),
                                    email = Convert.ToString(dr["correo"]),
                                    estado = Convert.ToBoolean(dr["estado"])
                                };
                            }
                        }
                    }
                    catch (SqlException ex)
                    {

                        throw new Exception("Error al buscar el cliente", ex);
                    }
                }
            }

            return c;
        }


        // Método para insertar un cliente
        public Boolean InsertarCliente(entCliente idCliente)
        {
            SqlCommand cmd = null;
            bool insertar = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spInsertarCliente", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmNombres", idCliente.nombres);
                cmd.Parameters.AddWithValue("@prmApellidos", idCliente.apellidos);
                cmd.Parameters.AddWithValue("@prmCelular", idCliente.celular);
                cmd.Parameters.AddWithValue("@prmDNI", idCliente.dni);
                cmd.Parameters.AddWithValue("@prmTelefono", idCliente.telefono);
                cmd.Parameters.AddWithValue("@prmCorreo", idCliente.email);
                cn.Open();
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    insertar = true;
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Connection.Close();
            }
            return insertar;
        }

        // Método para editar un cliente
        public Boolean EditarCliente(entCliente idCliente)
        {
            SqlCommand cmd = null;
            try
            {
                using (SqlConnection cn = Conexion.Instancia.Conectar())
                {
                    cmd = new SqlCommand("spEditarCliente", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@prmidCliente", idCliente.idCliente);
                    cmd.Parameters.AddWithValue("@prmNombres", idCliente.nombres);
                    cmd.Parameters.AddWithValue("@prmApellidos", idCliente.apellidos);
                    cmd.Parameters.AddWithValue("@prmTelefono", idCliente.telefono);
                    cmd.Parameters.AddWithValue("@prmCorreo", idCliente.email);
                    cn.Open();
                    int filasAfectadas = cmd.ExecuteNonQuery();
                    return filasAfectadas > 0; 
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
                    cmd = new SqlCommand("spEliminarCliente", cn);
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
