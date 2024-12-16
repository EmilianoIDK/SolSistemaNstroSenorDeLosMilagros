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
    public class datRegistroFactura
    {
        public List<entFactura> ListarComprobante()
        {
            SqlCommand cmd = null;
            List<entFactura> lista = new List<entFactura>();
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar(); //Conexion a la base de datos
                cmd = new SqlCommand("spListarComprobante", cn);  //Consulta a la base de datos
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    entFactura p = new entFactura();
                    p.id_Factura = Convert.ToInt32(dr["idFactura"]);
                    p.idEmpresa = Convert.ToInt32(dr["idEmpresa"]);
                    p.idCliente = Convert.ToInt32(dr["idCliente"]);
                    p.fecha = Convert.ToDateTime(dr["Fecha"]);
                    p.total = Convert.ToDecimal(dr["total"]);
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



        public entFactura BuscarComprobante(int idComprobante)
        {
            SqlCommand cmd = null;
            entFactura p = null;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar(); //Conexion a la base de datos
                cmd = new SqlCommand("spBuscarComprobante", cn);  //Consulta a la base de datos
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmidComprobante", idComprobante);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    p = new entFactura();
                    p.id_Factura = Convert.ToInt32(dr["idFactura"]);
                    p.idEmpresa = Convert.ToInt32(dr["idEmpresa"]);
                    p.idCliente = Convert.ToInt32(dr["idCliente"]);
                    p.fecha = Convert.ToDateTime(dr["Fecha"]);
                    p.total = Convert.ToDecimal(dr["total"]);
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

        public Boolean InsertarComprobante(entFactura p)
        {
            SqlCommand cmd = null;
            Boolean Insertar = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar(); //Conexion a la base de datos
                cmd = new SqlCommand("spInsertarComprobante", cn);  //Consulta a la base de datos
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmFecha", p.fecha);
                cmd.Parameters.AddWithValue("@prmTotal", p.total);
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

        public Boolean EditarComprobante(entFactura p)
        {
            SqlCommand cmd = null;
            Boolean Editar = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar(); //Conexion a la base de datos
                cmd = new SqlCommand("spEditarComprobante", cn);  //Consulta a la base de datos
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmID_Comprobante", p.id_Factura);
                cmd.Parameters.AddWithValue("@prmID_Empresa", p.idEmpresa);
                cmd.Parameters.AddWithValue("@prmID_Cliente", p.idCliente);
                cmd.Parameters.AddWithValue("@prmFecha", p.fecha);
                cmd.Parameters.AddWithValue("@prmTotal", p.total);
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


        public Boolean EliminarComprobante(int idComprobante)
        {
            SqlCommand cmd = null;
            Boolean Eliminar = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar(); //Conexion a la base de datos
                cmd = new SqlCommand("spEliminarComprobante", cn);  //Consulta a la base de datos
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmID_Comprobante", idComprobante);
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
