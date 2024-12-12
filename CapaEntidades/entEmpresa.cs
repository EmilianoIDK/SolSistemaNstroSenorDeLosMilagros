using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class entEmpresa
    {
        public int idEmpresa { get; set; }
        public string RUC { get; set; }
        public string razon_social { get; set; }
        public string direccion { get; set; }

        public string celular { get; set; }
        public string telefono { get; set; }
        public Boolean estado { get; set; }
    }
}
