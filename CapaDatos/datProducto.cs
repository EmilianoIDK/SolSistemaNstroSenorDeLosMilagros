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
        private static readonly datProducto _instancia = new datProducto();

        public static datProducto Instancia => _instancia;
        #endregion Singleton

     
        public List<entProducto> ListarProductos()
        {
            List<entProducto> lista = new List<entProducto>();
            using (SqlConnection cn = Conexion.Instancia.Conectar())
            {
                using (SqlCommand cmd = new SqlCommand("spListarProductos", cn))
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
                                cantidad = Convert.ToInt32(dr["cantidad"]),
                                precio = Convert.ToDecimal(dr["precio"]),
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
            entProducto p = null;
            using (SqlConnection cn = Conexion.Instancia.Conectar())
            {
                using (SqlCommand cmd = new SqlCommand("spBuscarProducto", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@prmidProducto", idProducto);
                    cn.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            p = new entProducto
                            {
                                idProducto = Convert.ToInt32(dr["idProducto"]),
                                nombre = Convert.ToString(dr["nombre"]),
                                marca = Convert.ToString(dr["marca"]),
                                cantidad = Convert.ToInt32(dr["cantidad"]),
                                precio = Convert.ToDecimal(dr["precio"]),
                                vencimiento = Convert.ToString(dr["vencimiento"]),
                                estado = Convert.ToBoolean(dr["estado"])
                            };
                        }
                    }
                }
            }
            return p;
        }


        public bool InsertarProducto(entProducto p)
        {
            bool insertar = false;
            using (SqlConnection cn = Conexion.Instancia.Conectar())
            {
                using (SqlCommand cmd = new SqlCommand("spInsertarProducto", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@prmNombre", p.nombre);
                    cmd.Parameters.AddWithValue("@prmMarca", p.marca);
                    cmd.Parameters.AddWithValue("@prmCantidad", p.cantidad);
                    cmd.Parameters.AddWithValue("@prmPrecio", p.precio);
                    cmd.Parameters.AddWithValue("@prmVencimiento", p.vencimiento);
                    cmd.Parameters.AddWithValue("@prmEstado", p.estado);
                    cn.Open();

                    int i = cmd.ExecuteNonQuery();
                    insertar = i > 0; 
                }
            }
            return insertar;
        }

        /// <summary>
        /// Edita un producto existente en la base de datos.
        /// </summary>
        /// <param name="p">Objeto entProducto con los nuevos datos.</param>
        /// <returns>true si se edita correctamente, false en caso contrario.</returns>
        public bool EditarProducto(entProducto p)
        {
            bool editar = false;
            using (SqlConnection cn = Conexion.Instancia.Conectar())
            {
                using (SqlCommand cmd = new SqlCommand("spEditarProducto", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@prmidProducto", p.idProducto);
                    cmd.Parameters.AddWithValue("@prmNombre", p.nombre);
                    cmd.Parameters.AddWithValue("@prmMarca", p.marca);
                    cmd.Parameters.AddWithValue("@prmCantidad", p.cantidad);
                    cmd.Parameters.AddWithValue("@prmPrecio", p.precio);
                    cmd.Parameters.AddWithValue("@prmVencimiento", p.vencimiento);
                    cmd.Parameters.AddWithValue("@prmEstado", p.estado);
                    cn.Open();

                    int i = cmd.ExecuteNonQuery();
                    editar = i > 0; 
                }
            }
            return editar;
        }

        /// <summary>
        /// Elimina un producto por su ID.
        /// </summary>
        /// <param name="idProducto">ID del producto a eliminar.</param>
        /// <returns>true si se elimina correctamente, false en caso contrario.</returns>
        public bool EliminarProducto(int idProducto)
        {
            bool eliminar = false;
            using (SqlConnection cn = Conexion.Instancia.Conectar())
            {
                using (SqlCommand cmd = new SqlCommand("spEliminarProducto", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@prmidProducto", idProducto);
                    cn.Open();

                    int i = cmd.ExecuteNonQuery();
                    eliminar = i > 0; 
                }
            }
            return eliminar;
        }
    }
}
