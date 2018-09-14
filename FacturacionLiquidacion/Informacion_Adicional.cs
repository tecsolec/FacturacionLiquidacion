using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FacturacionLiquidacion
{
    public class Informacion_Adicional
    {
        public string numero_factura { get; set; }
        public string pedido_manual { get; set; }
        public string fecha_ped_manual { get; set; }
        public string ord_comp_cliente { get; set; }
        public string fecha_ord_comp { get; set; }
        public string rec_entr_merca { get; set; }
        public string fecha_rec_entr_merca { get; set; }
        public string addenda_1{ get; set; }
        public string addenda_2 { get; set; }
        public string addenda_3 { get; set; }
        public string addenda_4 { get; set; }
        public string addenda_5 { get; set; }
        public string addenda_6 { get; set; }

        public Informacion_Adicional()
        {
            numero_factura = "100";
            pedido_manual = "";
            fecha_ped_manual = "";
            ord_comp_cliente = "";
            fecha_ord_comp = "";
            rec_entr_merca = "";
            fecha_rec_entr_merca = "";
            addenda_1 = "";
            addenda_2 = "";
            addenda_3 = "";
            addenda_4 = "";
            addenda_5 = "";
            addenda_6 = "";

        }
    }
}
