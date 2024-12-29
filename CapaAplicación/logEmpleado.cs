using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidades;

namespace CapaAplicación
{
    public class logEmpleado
    {
        #region singleton
        private static readonly logEmpleado UnicaInstancia = new logEmpleado();

        public static logEmpleado Instancia
        {
            get
            {
                return logEmpleado.UnicaInstancia;
            }
        }
        #endregion singleton

        #region metodos
        public entEmpleado VerificarEmpleado (String Usuario, String Contrasena)
        {
            try
            {
                return datEmpleado.Instancia.VerificarEmpleado (Usuario, Contrasena);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public List<entEspleado> ListarEmpleado()
        {
            try
            {
                return datEmpleado.Instancia.ListarEmpleado();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public entEmpleado BuscarEmpleado(int idEmpleado)
        {
            try
            {
                return datEmpleado.Instancia.BuscarEmpleado(idEmpleado);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Boolean InsertarEmpleado(entEmpleado p)
        {
            try
            {
                return datEmpleado.Instancia.InsertarEmpleado(p);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Boolean EditarEmpleado(entEmpleado e)
        {
            try
            {
                return datEmpleado.Instancia.EditarEmpleado(e);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion metodos
