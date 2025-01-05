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

        public List<entProducto> ListarProducto()
        {
            try
            {
                return datProducto.Instancia.ListarProducto();
            }
            catch (Exception ex)
            {
                throw ex;
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

        public Boolean InsertarProducto(entProducto p)
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

        public Boolean EditarProducto(entProducto p)
        {
            try
            {
                return datProducto.Instancia.EditarProducto(p);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Boolean EliminarProducto(int idProducto)
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
