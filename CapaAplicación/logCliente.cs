using System;
using System.Collections.Generic;
using CapaDatos;
using CapaEntidades;

namespace CapaAplicación
{
    public class logCliente
    {
        #region singleton
        private static readonly logCliente UnicaInstancia = new logCliente();

        public static logCliente Instancia
        {
            get
            {
                return logCliente.UnicaInstancia;
            }
        }
        #endregion singleton

        #region metodos

        public List<entCliente> ListarClientes()
        {
            try
            {
                return datCliente.Instancia.ListarClientes();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public entCliente BuscarCliente(int idCliente)
        {
            try
            {
                return datCliente.Instancia.BuscarCliente(idCliente);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Boolean InsertarCliente(entCliente c)
        {
            try
            {
                return datCliente.Instancia.InsertarCliente(c); 
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Boolean EditarCliente(entCliente c)
        {
            try
            {
                return datCliente.Instancia.EditarCliente(c);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Boolean EliminarCliente(int idCliente)
        {
            try
            {
                return datCliente.Instancia.EliminarCliente(idCliente);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion metodos
    }
}
