using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using CapaEntidades;

namespace CapaDatos
{
    public class datProducto
    {
        #region Singleton
        private static readonly datProducto UnicaInstancia = new datProducto();

        public static datProducto Instancia
        {
            get
            {
                return datProducto.UnicaInstancia;
            }
        }
        #endregion Singleton

        #region Metodos CRUD

        public List<entProducto> ListarProductos()
        {
            List<entProducto> lista = new List<entProducto>();
            using (SqlConnection cn = Conexion.Instancia.Conectar())
            {
                using (SqlCommand cmd = new SqlCommand("spListarProducto", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            entProducto p = new entProducto
                            {
                                idProducto = Convert.ToInt32(dr["idProducto"]),
                                nombre = Convert.ToString(dr["nombre"]),
                                marca = Convert.ToString(dr["marca"]),
                                precio = Convert.ToDecimal(dr["precio"]),
                                cantidad = Convert.ToInt32(dr["cantidad"]),
                                vencimiento = Convert.ToString(dr["vencimiento"]),
                                estado = Convert.ToBoolean(dr["estado"])
                            };
                            lista.Add(p);
                        }
                    }
                }
            }
            return lista;
        }


        public entProducto BuscarProducto(int idProducto)
        {
            SqlCommand cmd = null;
            entProducto p = null;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spBuscarProducto", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmidProducto", idProducto);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    p = new entProducto();
                    p.idProducto = Convert.ToInt32(dr["idProducto"]);
                    p.nombre = Convert.ToString(dr["nombre"]);
                    p.marca = Convert.ToString(dr["marca"]);
                    p.precio = Convert.ToDecimal(dr["precio"]);
                    p.cantidad = Convert.ToInt32(dr["cantidad"]);
                    p.vencimiento = Convert.ToString(dr["vencimiento"]);
                    p.estado = Convert.ToBoolean(dr["estado"]);
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
        public Boolean EliminarProducto(int idProducto)
        {
            SqlCommand cmd = null;

            try
            {
                using (SqlConnection cn = Conexion.Instancia.Conectar())
                {
                    cmd = new SqlCommand("spEliminarProducto", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@prmidProducto", idProducto);

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

        // Método para editar un producto
        public Boolean EditarProducto(entProducto producto)
        {
            SqlCommand cmd = null;

            try
            {
                using (SqlConnection cn = Conexion.Instancia.Conectar())
                {
                    cmd = new SqlCommand("psEditarProducto", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@prmidProducto", producto.idProducto);
                    cmd.Parameters.AddWithValue("@prmNombre", producto.nombre);
                    cmd.Parameters.AddWithValue("@prmMarca", producto.marca);
                    cmd.Parameters.AddWithValue("@prmPrecio", producto.precio);
                    cmd.Parameters.AddWithValue("@prmCantidad", producto.cantidad);
                    cmd.Parameters.AddWithValue("@prmvencimiento", producto.vencimiento);

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

        // Método para insertar un producto
        public Boolean InsertarProducto(entProducto p)
        {
            SqlCommand cmd = null;
            Boolean Insertar = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spInsertarProducto", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@prmNombre", p.nombre);
                cmd.Parameters.AddWithValue("@prmMarca", p.marca);
                cmd.Parameters.AddWithValue("@prmPrecio", p.precio);
                cmd.Parameters.AddWithValue("@prmCantidad", p.cantidad);
                cmd.Parameters.AddWithValue("@prmvencimiento", p.vencimiento);
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

