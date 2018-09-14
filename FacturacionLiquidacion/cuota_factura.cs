using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FacturacionLiquidacion
{
    public class cuota_factura
    {
        public string numero_factura { get; set; }
        public string fecha_factura { get; set; }
        public double valor { get; set; }
        public int dias { get; set; }
        public int porcentaje { get; set; }

        public cuota_factura()
        {
            numero_factura = "100";
            fecha_factura = DateTime.Today.ToShortDateString();
            valor = 84.50;
            dias = 0;
            porcentaje = 0;

        }
    }
}
