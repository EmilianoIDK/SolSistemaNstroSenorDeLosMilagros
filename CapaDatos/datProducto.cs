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
    public class datProducto
    {
        public List<entProducto> ListarProductos()
        {
            SqlCommand cmd = null;
            List<entProducto> lista = new List<entProducto>();
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar(); //Conexion a la base de datos
                cmd = new SqlCommand("spListarProductos", cn);  //Consulta a la base de datos
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    entProducto p = new entProducto();
                    p.idProducto = Convert.ToInt32(dr["idProducto"]);
                    p.nombre = Convert.ToString(dr["nombreProducto"]);
                    p.marca = Convert.ToString(dr["marca"]);
                    p.cantidad = Convert.ToInt32(dr["cantidad"]);
                    p.precio = Convert.ToDecimal(dr["precio"]);
                    p.vencimiento = Convert.ToString(dr["descripcion"]);
                    p.estado = Convert.ToBoolean(dr["estado"]);

                    lista.Add(p);
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

            return lista;

        }



        public entProducto BuscarProducto(int idProducto)
        {
            SqlCommand cmd = null;
            entProducto p = null;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar(); //Conexion a la base de datos
                cmd = new SqlCommand("spBuscarProducto", cn);  //Consulta a la base de datos
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmidProducto", idProducto);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    p = new entProducto();
                    p.idProducto = Convert.ToInt32(dr["idProducto"]);
                    p.nombre = Convert.ToString(dr["nombreProducto"]);
                    p.marca = Convert.ToString(dr["marca"]);
                    p.cantidad = Convert.ToInt32(dr["cantidad"]);
                    p.precio = Convert.ToDecimal(dr["precio"]);
                    p.vencimiento = Convert.ToString(dr["descripcion"]);
                    p.estado = Convert.ToBoolean(dr["estado"]);

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

            return p;

        }

        public Boolean InsertarProducto(entProducto p)
        {
            SqlCommand cmd = null;
            Boolean Insertar = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar(); //Conexion a la base de datos
                cmd = new SqlCommand("spInsertarProducto", cn);  //Consulta a la base de datos
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmNombre_producto", p.nombre);
                cmd.Parameters.AddWithValue("@prmMarca", p.marca);
                cmd.Parameters.AddWithValue("@prmCantidad", p.cantidad);
                cmd.Parameters.AddWithValue("@prmPrecio", p.precio);
                cmd.Parameters.AddWithValue("@prmDescripcion", p.vencimiento);
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

        public Boolean EditarProducto(entProducto p)
        {
            SqlCommand cmd = null;
            Boolean Editar = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar(); //Conexion a la base de datos
                cmd = new SqlCommand("spEditarProducto", cn);  //Consulta a la base de datos
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmID_producto", p.idProducto);
                cmd.Parameters.AddWithValue("@prmNombre_producto", p.nombre);
                cmd.Parameters.AddWithValue("@prmMarca", p.marca);
                cmd.Parameters.AddWithValue("@prmCantidad", p.cantidad);
                cmd.Parameters.AddWithValue("@prmPrecio", p.precio);
                cmd.Parameters.AddWithValue("@prmDescripcion", p.vencimiento);
                cn.Open();

                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    Editar = true;
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

            return Editar;

        }


        public Boolean EliminarProducto(int idProducto)
        {
            SqlCommand cmd = null;
            Boolean Eliminar = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar(); //Conexion a la base de datos
                cmd = new SqlCommand("spEliminarProducto", cn);  //Consulta a la base de datos
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmID_producto", idProducto);
                cn.Open();

                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    Eliminar = true;
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

            return Eliminar;

        }
    }
}
