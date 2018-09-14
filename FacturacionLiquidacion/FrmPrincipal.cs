﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace FacturacionLiquidacion
{
    public partial class FrmPrincipal : Form
    {
        cabecera_factura cab;
        detalle_factura det;
        List<detalle_factura> lista_detalles;
        CdaConsultas dat_consultas;

        public FrmPrincipal()
        {
            InitializeComponent();
        }

        //Evento para consultar liquidaciones segun proyecto
        private void btnConsultar_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtProyecto.Text))
                MessageBox.Show("Ingrese el código del proyecto.");
            else
            {
                if(string.IsNullOrEmpty(txt_SubProyecto.Text))
                    MessageBox.Show("Ingrese el código del sub-proyecto.");
                else
                {
                    dat_consultas = new CdaConsultas();
                    DataTable Liq = new DataTable();
                    DataTable cliente = new DataTable();

                    //llenar el combobox con las liquidaciones
                    Liq = dat_consultas.Consultar_Liq_X_Proyecto(txtProyecto.Text.Trim(), txt_SubProyecto.Text.Trim());
                    cmbLiquidaciones.DataSource = Liq;
                    cmbLiquidaciones.DisplayMember = "liquida";
                    cmbLiquidaciones.ValueMember = "liquida";

                    //LLenando los datos de la empresa
                    cliente = dat_consultas.Consultar_Cliente("Expalsa");
                    txtNombreCliente.Text = cliente.Rows[0][3].ToString();
                    txt_identificacion.Text = cliente.Rows[0][4].ToString();
                    txt_telefono.Text = cliente.Rows[0][6].ToString();
                    txt_direccion.Text = cliente.Rows[0][35].ToString();
                }
            }
            
          
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            lblFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }


        //Evento del botón guardar
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string query = "";


            string code_s = "04";
            string corp_s = "PRODU";
            string group_category = "API";
            int integer_1 = 0, logint_1 = 0;
            string origin = "PRI";
            string texto1_10;
            string text1_24 = "10.51.1.11";
            string text2_x = ""; //información de la cabecera de la factura
            string texto3_x = ""; //información del detalle de la factura
            string texto4_x = "", texto7_x = "", numdoc_s = "", local_origen = "", local_destino = "", IDConsulta_s = "";
            int Opcion_i = 1; // indica que la factura es confirmada 
            
            
            cuota_factura cuota = new cuota_factura();
            Informacion_Adicional info_ad = new Informacion_Adicional();
            validar_datos();


            text2_x = cab.numero_factura + "|" + cab.codigo_cliente + "|" + cab.emision_factura + "|" + cab.vencimiento_factura + "|" + cab.identificacion + "|" + cab.nombre_sub_cliente + "|" +
                              cab.codigo_vendedor + "|" + "US" + "|" + cab.valor_cotizacion + "|" + cab.numero_pagos + "|" + cab.codigo_bodega + "|" + cab.descuento + "|" + cab.codigo_almacen + "|" +
                              cab.codigo_caja + "|" + cab.vendedor_comisiona + "|" + cab.telefono_cliente + "|" + cab.direccion_cliente + "|" + cab.identificacion_cliente + "|" + cab.codigo_subcliente + "|" +
                              cab.documento_subcliente + "|" + cab.referencias_subcliente + "|" + cab.origen + "|" + cab.tipo_documento + "|" + cab.multidimension + "|" + cab.pago_venta + "|" + cab.memo_factura + "|" +
                              cab.imprimir_memo + "|" + cab.numero_aprobacion + "|" + cab.fecha_caducidad;

            string detalle = "";
            int i = 0;
            foreach (detalle_factura dt in lista_detalles)
            {
                //if (i == 1)
                //    break;
                detalle = detalle + dt.numero_factura + "|" + dt.codigo_producto + "|" + dt.cantidad.ToString().Replace(',','.') + "|" + dt.precio_unitario.ToString().Replace(',','.') + "|" + dt.unidades_gratis + "|" + dt.iva + "|" +
                              dt.descuento + "|" + dt.tamanio + "|" + dt.peso + "|" + dt.peso_neto + "|" + dt.color + "|" + dt.grosor + "|" + dt.identificacion + "|" +
                              dt.observaciones + "|" + dt.adicional + "|" + dt.camp_adicional_1 + "|" + dt.camp_adicional_2 + "|" + dt.camp_adicional_3 + "|" + dt.camp_nume_1 + "|" +
                              dt.camp_nume_2 + "|" + dt.camp_nume_3 + "|" + dt.camp_fecha_1 + "|" + dt.camp_fecha_2 + "|" + dt.camp_fecha_3 + "|" + dt.multi_detalle + "|" +
                              dt.impuesto_2 + "|" + dt.impuesto_3 + "|" + dt.impuesto_4 + "|" + dt.impuesto_5 + "|" + dt.cod_impuesto_1 + "|" + dt.porc_impuesto_1 + "|" +
                              dt.cod_impuesto_2 + "|" + dt.porc_impuesto_2 + "|" + dt.cod_impuesto_3 + "|" + dt.porc_impuesto_3 + "|" + dt.cod_impuesto_4 + "|" + dt.porc_impuesto_4 + "|" +
                              dt.cod_impuesto_5 + "|" + dt.porc_impuesto_5 + "|" + dt.lote_ubicacion + "|" + dt.total_neto.ToString().Replace(',','.');

                if (!(i == lista_detalles.Count - 1) )
                    detalle = detalle + "|";

                i++;
            }
           
            texto3_x = detalle;

            texto4_x = cuota.numero_factura + "|" + cuota.fecha_factura + "|" + cuota.valor + "|" + cuota.dias + "|" + cuota.porcentaje; //detalle cuotas

            //detalle informacion adicional 
            texto7_x = info_ad.numero_factura + "|" + info_ad.pedido_manual + "|" + info_ad.fecha_ped_manual + "|" + info_ad.ord_comp_cliente + "|" + info_ad.fecha_ord_comp + "|" + info_ad.fecha_rec_entr_merca + "|" +
                        info_ad.fecha_rec_entr_merca + "|" + info_ad.addenda_1 + "|" + info_ad.addenda_2 + "|" + info_ad.addenda_3 + "|" + info_ad.addenda_4 + "|" + info_ad.addenda_5 + "|" + info_ad.addenda_6;


            integer_1 = 1;
            logint_1 = 1;
            texto1_10 = "2";
            numdoc_s = "11";
            local_origen = "PRI";
            local_destino = "PRI";
            IDConsulta_s = "11-PRODU";

            query = "insert into sist_api(CODE_s,CORP_s,GROUP_CATEGORY_s,INTEGER_1,LONGINT_1,ORIGIN,TEXTO1_10,TEXTO1_24,TEXTO2_X,TEXTO3_X,NumDoc_s,Local_origen,Local_destino,IDConsulta_s,Opcion_i)";
            query = query + " values ('" + code_s + "','" + corp_s + "','" + group_category + "'," + integer_1 + "," + logint_1 + ",'" + origin + "','" + texto1_10 + "','" + text1_24 + "','" + text2_x + "','" + texto3_x + "','";
            query = query + numdoc_s + "','" + local_origen + "','" + local_destino + "','" + IDConsulta_s + "'," + Opcion_i + ")";

            txtquery.Text = query;
            //MessageBox.Show(query);
            MessageBox.Show("Factura ingresada.");
        }

        
        public void validar_datos()
        {
            cab = new cabecera_factura();
            

            //solo datos obligatorios Cabecera
            cab.numero_factura = "";
            cab.emision_factura = lblFecha.Text;
            cab.vencimiento_factura = dtpHasta.Text;
            cab.codigo_cliente = "CL000048";
            cab.codigo_bodega = "BPT";
            cab.codigo_almacen = "";
            cab.origen = "PRI";
            cab.multidimension = "01;;" + txtProyecto.Text + ";" + txt_SubProyecto.Text + ";;;;;";  //8 campos
            cab.multidimension = "";  //8 campos

            //datos obligatorios detalle
            lista_detalles = new List<detalle_factura>();
            //recorriendo el detalle
            foreach(DataGridViewRow row in grdDetalle.Rows)
            {
                if (!string.IsNullOrEmpty(Convert.ToString(row.Cells[0].Value)))
                {
                    det = new detalle_factura();
                    det.numero_factura = cab.numero_factura;
                    //det.multi_detalle = "01;;" + txtProyecto.Text + ";" + txt_SubProyecto.Text + ";;;;;";  //8 campos
                    det.multi_detalle = "01;;;;;;;";  //8 campos
                    det.codigo_producto = row.Cells[0].Value.ToString();
                    det.cantidad = Convert.ToDouble(row.Cells[2].Value.ToString());
                    det.precio_unitario = Convert.ToDouble(row.Cells[3].Value.ToString());
                    det.total_neto = det.precio_unitario * det.cantidad;
                    lista_detalles.Add(det);
                }
            }

        }


        public void Actualizar_Totales()
        {
            double subtotal = 0,total = 0,descuento = 0;

            foreach (DataGridViewRow row in grdDetalle.Rows)
            {
                if (!string.IsNullOrEmpty(Convert.ToString(row.Cells[0].Value)))
                {
                    double totalxproducto = Convert.ToDouble(row.Cells[2].Value.ToString()) * Convert.ToDouble(row.Cells[3].Value.ToString());
                    subtotal = subtotal + totalxproducto;
                }
            }


            total = subtotal - descuento;
            txt_subtotal.Text = subtotal.ToString("N2");
            txt_descuento.Text = descuento.ToString("N2");
            txt_total.Text = total.ToString("N2");
        }


        //evento al momento de editar un precio
        private void grdDetalle_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3) // al cambiar algún precio
                Actualizar_Totales();
        }



        public void LLenar_Detalle(String _proy, String _subproy, String _liqui)
        {
            CdaConsultas dat_consultas = new CdaConsultas();
            DataTable detalle = new DataTable();

            //llenando el detalle de la factura
            DataTable dt = new DataTable();
            dt.Columns.Add("cod_Pdto", typeof(string));
            dt.Columns.Add("nomb_Pdto", typeof(string));
            dt.Columns.Add("cantidad", typeof(double));
            dt.Columns.Add("precio", typeof(double));
            detalle = dat_consultas.Consultar_Det_Factura(_proy,_subproy,_liqui);
            grdDetalle.AutoGenerateColumns = true;

            foreach (DataRow row in detalle.Rows)
            {
                String codprod = "";
                String nomprod = "";
                double cant = 0;
                double precio = 0;
                codprod = row[0].ToString();
                nomprod = row[1].ToString();
                if (row[2].ToString() != "")
                    cant = Convert.ToDouble(row[2].ToString());
                if (row[3].ToString() != "")
                    precio = Convert.ToDouble(row[3].ToString());
                dt.Rows.Add(codprod, nomprod, cant , precio);
            }

            grdDetalle.DataSource = dt;
            grdDetalle.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            grdDetalle.Columns[0].ReadOnly = true;
            grdDetalle.Columns[0].HeaderText = "Código";
            grdDetalle.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grdDetalle.Columns[0].Width = 150;
            grdDetalle.Columns[1].ReadOnly = true;
            grdDetalle.Columns[1].HeaderText = "Descripción";
            grdDetalle.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grdDetalle.Columns[2].ReadOnly = true;
            grdDetalle.Columns[2].HeaderText = "Cant.";
            grdDetalle.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grdDetalle.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grdDetalle.Columns[2].Width = 80;
            //columna precio
            grdDetalle.Columns[3].HeaderText = "PVP Unit";
            grdDetalle.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grdDetalle.Columns[3].DefaultCellStyle.Format = "N2";
            grdDetalle.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            grdDetalle.Columns[3].Width = 120;
            grdDetalle.Columns[3].ReadOnly = false;

            Actualizar_Totales();
        }


        //Evento al escoger una liquidación
        private void cmbLiquidaciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            LLenar_Detalle(txtProyecto.Text.Trim(),txt_SubProyecto.Text.Trim(),cmbLiquidaciones.ValueMember);
        }
    }
}
