using System;
using System.Collections.Generic;
using CapaDatos;
using CapaEntidades;

namespace CapaAplicación
{
    public class logProducto
    {
        #region singleton
        private static readonly logProducto UnicaInstancia = new logProducto();

        public static logProducto Instancia
        {
            get
            {
                return logProducto.UnicaInstancia;
            }
        }
        #endregion singleton

        #region metodos

        public List<entProducto> ListarProductos()
        {
            try
            {
                return datProducto.Instancia.ListarProductos();
            }
            catch (Exception ex)
            {
                throw ex; // Considera manejar la excepción de manera más específica si es necesario.
            }
        }

        public entProducto BuscarProducto(int idProducto)
        {
            try
            {
                return datProducto.Instancia.BuscarProducto(idProducto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool InsertarProducto(entProducto p)
        {
            try
            {
                return datProducto.Instancia.InsertarProducto(p);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool EditarProducto(entProducto p)
        {
            try
            {
                return datProducto.Instancia.EditarProducto(p);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al editar el producto", ex);
            }

        }

        public bool EliminarProducto(int idProducto)
        {
            try
            {
                return datProducto.Instancia.EliminarProducto(idProducto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion metodos
    }
}
