using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class entEmpleado
    {
        public int idEmpleado { get; set; }
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public string cargo { get; set; }
        public string celular { get; set; }
        public string telefono { get; set; }
        public Boolean estado { get; set; }
    }
}
