using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FacturacionLiquidacion
{
    public class detalle_factura
    {
        public string numero_factura { get; set; }
        public string codigo_producto { get; set; }
        public double cantidad { get; set; }
        public double precio_unitario { get; set; }
        public int unidades_gratis { get; set; }
        public double iva { get; set; }
        public double descuento { get; set; }
        public string tamanio { get; set; }
        public double peso { get; set; }
        public double peso_neto { get; set; }
        public string color { get; set; }
        public string grosor { get; set; }
        public string identificacion { get; set; }
        public string observaciones { get; set; }
        public string adicional { get; set; }
        public string camp_adicional_1 { get; set; }
        public string camp_adicional_2 { get; set; }
        public string camp_adicional_3 { get; set; }
        public double camp_nume_1 { get; set; }
        public double camp_nume_2 { get; set; }
        public double camp_nume_3 { get; set; }
        public string camp_fecha_1 { get; set; }
        public string camp_fecha_2 { get; set; }
        public string camp_fecha_3 { get; set; }

        public string multi_detalle { get; set; }
        public int impuesto_2 { get; set; }  //1: verd 0: falso
        public int impuesto_3 { get; set; }  //1: verd 0: falso
        public int impuesto_4 { get; set; }  //1: verd 0: falso
        public int impuesto_5 { get; set; }  //1: verd 0: falso
        public string cod_impuesto_1 { get; set; }
        public int porc_impuesto_1 { get; set; }
        public string cod_impuesto_2 { get; set; }
        public int porc_impuesto_2 { get; set; }
        public string cod_impuesto_3 { get; set; }
        public int porc_impuesto_3 { get; set; }
        public string cod_impuesto_4 { get; set; }
        public int porc_impuesto_4 { get; set; }
        public string cod_impuesto_5 { get; set; }
        public int porc_impuesto_5 { get; set; }
        public string lote_ubicacion { get; set; }
        public double total_neto { get; set; }


        public detalle_factura()
        {
            numero_factura = "100";
            codigo_producto = "";
            cantidad = 0;
            precio_unitario = 0;
            unidades_gratis = 0;
            iva = 0; // si va con IVA
            descuento = 0;
            tamanio = "";
            peso = 0;
            peso_neto = 0;
            color = "";
            grosor = "";
            identificacion = "";
            observaciones = "";
            adicional = "";
            camp_adicional_1 = "";
            camp_adicional_2 = "";
            camp_adicional_3 = "";
            camp_nume_1 = 0;
            camp_nume_2 = 0;
            camp_nume_3 = 0;
            camp_fecha_1 = "";
            camp_fecha_2 = "";
            camp_fecha_3 = "";
            multi_detalle = "";
            impuesto_2 = 0;  //1: verd 0: falso
            impuesto_3 = 0;  //1: verd 0: falso
            impuesto_4 = 0; //1: verd 0: falso
            impuesto_5 = 0;  //1: verd 0: falso
            cod_impuesto_1 = "";
            porc_impuesto_1 = 0;
            cod_impuesto_2 = "";
            porc_impuesto_2 = 0;
            cod_impuesto_3 = "";
            porc_impuesto_3 = 0;
            cod_impuesto_4 = "";
            porc_impuesto_4 = 0;
            cod_impuesto_5 = "";
            porc_impuesto_5 = 0;
            lote_ubicacion = "";
            total_neto = 0;
        }

    }
}
