using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class entFactura
    {
        public int id_Factura { get; set; }
        public entEmpresa idEmpresa { get; set; }
        public entCliente idCliente { get; set; }
        public DateTime fecha { get; set; }
        public decimal total { get; set; }
        public Boolean estado { get; set; }
    }
}
