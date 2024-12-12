using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class entProducto
    {
        public int idProducto { get; set; }
        public string nombre { get; set; }
        public string marca { get; set; }
        public decimal precio { get; set; }
        public int cantidad { get; set; }
        public string vencimiento { get; set; }
        public Boolean estado { get; set; }
    }
}
