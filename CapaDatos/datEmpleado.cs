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
                cmd = new SqlCommand("VerificarEmpleado", cn);  //Consulta a la base de datos
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmUsuario", usuario);
                cmd.Parameters.AddWithValue("@prmContrasena", contrasena);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    e = new entEmpleado();
                    e.idEmpleado = Convert.ToInt32(dr["idEmpleado"]);
                    e.nombres = Convert.ToString(dr["nombres"]);
                    e.apellidos = Convert.ToString(dr["apellidos"]);
                    e.documentoIdentidad = Convert.ToString(dr["documentoIdentidad"]);
                    e.celular = Convert.ToString(dr["celular"]);
                    e.correo = Convert.ToString(dr["correo"]);
                    e.usuario = Convert.ToString(dr["usuario"]);
                    e.contrasena = Convert.ToString(dr["contrasena"]);
                    e.cargo = Convert.ToString(dr["cargo"]);
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

        public List<entEmpleado> ListarEmpleado()
        {
            SqlCommand cmd = null;
            List<entEmpleado> lista = new List<entEmpleado>();
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("psListarEmpleado", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    entEmpleado p = new entEmpleado();
                    p.idEmpleado = Convert.ToInt32(dr["identEmpleado"]);
                    p.nombres = Convert.ToString(dr["nombre"]);
                    p.apellidos = Convert.ToString(dr["apellido"]);
                    p.documentoIdentidad = Convert.ToString(dr["documentoIdentidad"]);
                    p.celular = Convert.ToString(dr["celular"]);
                    p.correo = Convert.ToString(dr["correo"]);
                    p.usuario = Convert.ToString(dr["usuario"]);
                    p.contrasena = Convert.ToString(dr["contrasena"]);
                    p.cargo = Convert.ToString(dr["cargo"]);


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

        public entEmpleado BuscarEmpleado(int idEmpleado)
        {
            SqlCommand cmd = null;
            entEmpleado p = null;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("psBuscarEmpleado", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmidEmpleado", idEmpleado);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    p = new entEmpleado();
                    p.idEmpleado = Convert.ToInt32(dr["identEmpleado"]);
                    p.nombres = Convert.ToString(dr["nombre"]);
                    p.apellidos = Convert.ToString(dr["apellido"]);
                    p.documentoIdentidad = Convert.ToString(dr["documentoIdentidad"]);
                    p.celular = Convert.ToString(dr["celular"]);
                    p.correo = Convert.ToString(dr["correo"]);
                    p.usuario = Convert.ToString(dr["usuario"]);
                    p.contrasena = Convert.ToString(dr["contrasena"]);
                    p.cargo = Convert.ToString(dr["cargo"]);
                }
                cn.Close();
            }
            catch (SqlException ex)
            {
                throw ex;
            }

            return p;
        }

        // Método para eliminar un empleado
        public Boolean EliminarEmpleado(int idEmpleado)
        {
            SqlCommand cmd = null;

            try
            {
                using (SqlConnection cn = Conexion.Instancia.Conectar())
                {
                    cmd = new SqlCommand("psEliminarEmpleado", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@prmidEmpleado", idEmpleado);

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

        // Método para editar un empleado
        public Boolean EditarEmpleado(entEmpleado empleado)
        {
            SqlCommand cmd = null;

            try
            {
                using (SqlConnection cn = Conexion.Instancia.Conectar())
                {
                    cmd = new SqlCommand("psEditarEmpleado", cn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Agrega los parámetros necesarios para editar el empleado
                    cmd.Parameters.AddWithValue("@prmidEmpleado", empleado.idEmpleado);
                    cmd.Parameters.AddWithValue("@prmNombres", empleado.nombres);
                    cmd.Parameters.AddWithValue("@prmApellidos", empleado.apellidos);
                    cmd.Parameters.AddWithValue("@prmDocumentoIdentidad", empleado.documentoIdentidad);
                    cmd.Parameters.AddWithValue("@prmCelular", empleado.celular);
                    cmd.Parameters.AddWithValue("@prmCorreo", empleado.correo);
                    cmd.Parameters.AddWithValue("@prmUsuario", empleado.usuario);
                    cmd.Parameters.AddWithValue("@prmContrasena", empleado.contrasena);
                    cmd.Parameters.AddWithValue("@prmCargo", empleado.cargo);

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

        public Boolean InsertarEmpleado(entEmpleado e)
        {
            SqlCommand cmd = null;
            Boolean Insertar = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar(); //Conexion a la base de datos
                cmd = new SqlCommand("spInsertarEmpleado", cn);  //Consulta a la base de datos
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmnombres", e.nombres);
                cmd.Parameters.AddWithValue("@prmapellidos", e.apellidos);
                cmd.Parameters.AddWithValue("@prmcorreo", e.correo);
                cmd.Parameters.AddWithValue("@prmusuario", e.usuario);
                cmd.Parameters.AddWithValue("@prmcontrasena", e.contrasena);
                cmd.Parameters.AddWithValue("@prmcargo", e.cargo);
                cn.Open();

                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    Insertar = true;
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

            return Insertar;
        }

        #endregion Metodos CRUD
    }
    
}