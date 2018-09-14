using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FacturacionLiquidacion
{
    public class cabecera_factura
    {
        public string numero_factura { get; set; }
        public string codigo_cliente { get; set; }
        public string emision_factura { get; set; }
        public string vencimiento_factura { get; set; }
        public string identificacion { get; set; }
        public string nombre_sub_cliente { get; set; }
        public string codigo_vendedor { get; set; }
        public string codigo_moneda { get; set; }
        public double valor_cotizacion { get; set; }
        public int numero_pagos { get; set; }
        public string codigo_bodega { get; set; }
        public double descuento { get; set; }
        public string codigo_almacen { get; set; }
        public string codigo_caja { get; set; }
        public int vendedor_comisiona { get; set; }
        public string telefono_cliente { get; set; }
        public string direccion_cliente { get; set; }
        public string identificacion_cliente { get; set; }
        public int codigo_subcliente { get; set; }
        public string documento_subcliente { get; set; }
        public string referencias_subcliente { get; set; }
        public string origen { get; set; }
        public string tipo_documento { get; set; }
        public string multidimension { get; set; }
        public int pago_venta { get; set; }
        public string memo_factura { get; set; }
        public int imprimir_memo { get; set; }
        public string numero_aprobacion { get; set; }
        public string fecha_caducidad { get; set; }

        public cabecera_factura()
        {
            numero_factura = "100";
            codigo_cliente = "";
            emision_factura = "00/00/00";
            vencimiento_factura = "00/00/00";
            identificacion = "";
            nombre_sub_cliente = "";
            codigo_vendedor = "";
            codigo_moneda = "US";
            valor_cotizacion = 0;
            numero_pagos = 1; // 1 por defecto
            codigo_bodega = "";
            descuento = 0;
            codigo_almacen = "";
            codigo_caja = "999";
            vendedor_comisiona = 0;
            telefono_cliente = "";
            direccion_cliente = "";
            identificacion_cliente = "";
            codigo_subcliente = 0;
            documento_subcliente = "";
            referencias_subcliente = "";
            origen = "";
            tipo_documento = "FE";
            multidimension = "";
            pago_venta = 0;
            memo_factura = "";
            imprimir_memo = 0;
            numero_aprobacion = "";
            fecha_caducidad = "";
        }


    }

}
