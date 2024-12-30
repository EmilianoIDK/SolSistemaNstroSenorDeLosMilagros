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
        public entEmpleado Verificar_Inicio_Sesion(String Usuario, String Contrasena)
        {
            try
            {
                return datEmpleado.Instancia.Verificar_Inicio_Sesion(Usuario, Contrasena);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion metodos
    }
}
