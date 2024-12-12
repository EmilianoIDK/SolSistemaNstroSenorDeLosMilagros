using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
