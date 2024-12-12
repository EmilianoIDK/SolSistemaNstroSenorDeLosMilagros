using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class entCliente
    {
        public int idCliente { get; set; }
        public int dni { get; set; }
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public string telefono { get; set; }
        public string email { get; set; }
        public Boolean estado { get; set; }
    }
}
