using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FacturacionLiquidacion
{
    public partial class FrmLiquidacion : Form
    {
        Liquidacion liq;

        public Liquidacion Liq
        {
            get
            {
                return liq;
            }

            set
            {
                liq = value;
            }
        }

        public FrmLiquidacion()
        {
            InitializeComponent();
        }




        private void FrmLiquidacion_Load(object sender, EventArgs e)
        {
            DataSet dsEspecie;
            tbLiquidacion.Text = Liq.Numeroliquidacion;
            dtpFechaLiquidacion.Value = Liq.Fecha.Date;
            CdaConsultas cons = new CdaConsultas();
            dsEspecie = cons.ConsultaEspecie();
            cbEspecie.ValueMember = "ESPECIE";
            cbEspecie.DataSource = dsEspecie.Tables[0].DefaultView;
            cbEspecie.SelectedItem = "ENTERO";

            //agregando datos de la liquidacion
            tbEntero.Text = Liq.Entero.ToString("N2");
            tbSobrCC.Text = Liq.Sobre_Cc.ToString("N2");
            tbCola.Text = Liq.Cola.ToString("N2");
            tbBasura.Text = Liq.Basura.ToString("N2");
            if (Liq.Diferencia == 0)
                tbDiferencia.Text = Liq.Lbstotales.ToString("N2");
            else
                tbDiferencia.Text = Liq.Diferencia.ToString("N2");
            txt_hidden_detalle.Text = "0";
            //solo si existe un detalle
            if (Liq.Recetas.Count > 0)
            {
                foreach (Receta rec in Liq.Recetas)
                {
                    Int32 idx = dgvReceta.Rows.Add();
                    DataGridViewRow row = dgvReceta.Rows[idx];
                    row.Cells["codProducto"].Value = rec.CodProducto;
                    row.Cells["detalle"].Value = rec.Detalle;
                    row.Cells["cantidad"].Value = rec.Cantidad;
                }
            }
                //dgvReceta.DataSource = Liq.Recetas;


        }

        private void cbEspecie_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet dsTipo;
            Hashtable param=new Hashtable();
            CdaConsultas cons = new CdaConsultas();
            param.Add("ESPECIE", cbEspecie.SelectedValue);
            dsTipo = cons.ConsultaTipo(param);
            cbTipo.ValueMember = "TIPO";
            cbTipo.DataSource = dsTipo.Tables[0].DefaultView;
            
        }

        private void cbTipo_SelectedValueChanged(object sender, EventArgs e)
        {
            DataSet dsClase;
            Hashtable param = new Hashtable();
            CdaConsultas cons = new CdaConsultas();
            param.Add("ESPECIE", cbEspecie.SelectedValue);
            param.Add("TIPO", cbTipo.SelectedValue);
            dsClase = cons.ConsultaClase(param);
            cbClase.ValueMember = "CLASE";
            cbClase.DataSource = dsClase.Tables[0].DefaultView;
        }

        private void cbClase_SelectedValueChanged(object sender, EventArgs e)
        {
            DataSet dsTalla;
            Hashtable param = new Hashtable();
            CdaConsultas cons = new CdaConsultas();
            param.Add("ESPECIE", cbEspecie.SelectedValue);
            param.Add("TIPO", cbTipo.SelectedValue);
            param.Add("CLASE", cbClase.SelectedValue);
            dsTalla = cons.ConsultaTalla(param);
            cbTalla.ValueMember = "TALLA";
            cbTalla.DataSource = dsTalla.Tables[0].DefaultView;
        }

        private void btnAgregarItem_Click(object sender, EventArgs e)
        {
            if (txt_hidden_detalle.Text == "0") //agregar nueva fila
            {
                Receta tmp = new Receta();

                Hashtable param = new Hashtable();
                CdaConsultas cons = new CdaConsultas();
                param.Add("ESPECIE", cbEspecie.SelectedValue);
                param.Add("TIPO", cbTipo.SelectedValue);
                param.Add("CLASE", cbClase.SelectedValue);
                param.Add("TALLA", cbTalla.SelectedValue);
                tmp.GetReceta(cons.ConsultaCodigoProducto(param));
                tmp.Cantidad = Convert.ToDouble(tbCantidad.Text);
                tmp.Precio = 0.0;
                tmp.Tipo = cbTipo.SelectedValue.ToString();
                tmp.Talla = cbTalla.SelectedValue.ToString();
                tmp.Clase = cbClase.SelectedValue.ToString();
                Int32 idx = dgvReceta.Rows.Add();
                DataGridViewRow row = dgvReceta.Rows[idx];
                row.Cells["codProducto"].Value = tmp.CodProducto;
                row.Cells["detalle"].Value = tmp.Detalle;
                row.Cells["cantidad"].Value = tmp.Cantidad;
                Liq.Recetas.Add(tmp);
            }
            else
            {
                int linea = Convert.ToInt32(txt_hidden_detalle.Text) - 1;
                Receta tmp = new Receta();
                Hashtable param = new Hashtable();
                CdaConsultas cons = new CdaConsultas();
                param.Add("ESPECIE", cbEspecie.SelectedValue);
                param.Add("TIPO", cbTipo.SelectedValue);
                param.Add("CLASE", cbClase.SelectedValue);
                param.Add("TALLA", cbTalla.SelectedValue);
                tmp.GetReceta(cons.ConsultaCodigoProducto(param));
                DataGridViewRow row = dgvReceta.Rows[linea];
                row.Cells["codProducto"].Value = tmp.CodProducto;
                row.Cells["detalle"].Value = tmp.Detalle;
                row.Cells["cantidad"].Value = Convert.ToDouble(tbCantidad.Text);

                txt_hidden_detalle.Text = "0";
                btnAgregarItem.Text = "Agregar";
                btnLimpiarDetalle.Text = "Limpiar";
            }

        }

        private void btnLimpiarDetalle_Click(object sender, EventArgs e)
        {
            if (txt_hidden_detalle.Text == "0") //limpiar toda información del grid
            {
                dgvReceta.Rows.Clear();
            }
            else //limpiar controles de ingreso
            {
                txt_hidden_detalle.Text = "0";
                btnAgregarItem.Text = "Agregar";
                btnLimpiarDetalle.Text = "Limpiar";
            }
        }

        private void dgvReceta_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.ColumnIndex;
            //evento del boton eliminar
            if (e.ColumnIndex == 3)
            {
                txt_hidden_detalle.Text = Convert.ToString(e.RowIndex + 1);
                btnAgregarItem.Text = "Actualizar";
                btnLimpiarDetalle.Text = "Cancelar";
                tbCantidad.Text = dgvReceta.Rows[e.RowIndex].Cells["cantidad"].Value.ToString();
            }

            if (e.ColumnIndex == 4)
            {
                dgvReceta.Rows.RemoveAt(e.RowIndex);
            }
        }


        //evento grabar detalle de liquidacion en BD
        private void btnGrabar_Click(object sender, EventArgs e)
        {
            string resultado = "";

            //obteniendo la informacion de las guias
            IList<Guia> guias = Liq.Guias;
            IList<Receta> recetas = Liq.Recetas;
            CdaConsultas cons = new CdaConsultas();
            Liq.Entero = Convert.ToDouble(tbEntero.Text);
            Liq.Sobre_Cc = Convert.ToDouble(tbSobrCC.Text);
            Liq.Cola = Convert.ToDouble(tbCola.Text);
            Liq.Basura = Convert.ToDouble(tbBasura.Text);
            Liq.Diferencia = Convert.ToDouble(tbDiferencia.Text);
            resultado = cons.Guardar_Guias(guias, Liq, recetas);
            if (resultado.Equals("OK"))
                MessageBox.Show("Liquidación ingresada.");
            else
                MessageBox.Show("Error al ingresar: " + resultado);

            //foreach (DataGridViewRow row in dgvReceta.Rows)

            //Obteniendo información de los grid en una lista

        }

        private void tbEntero_TextChanged(object sender, EventArgs e)
        {
            double entero = 0,sobre_cc = 0;

            if (!string.IsNullOrEmpty(tbSobrCC.Text))
                sobre_cc = Convert.ToDouble(tbSobrCC.Text);

            if (!string.IsNullOrEmpty(tbEntero.Text))
                entero = Convert.ToDouble(tbEntero.Text);

            tbDiferencia.Text = ((entero + sobre_cc) - Liq.Lbstotales).ToString("N2");
        }

        private void tbSobrCC_TextChanged(object sender, EventArgs e)
        {
            double entero = 0, sobre_cc = 0;

            if (!string.IsNullOrEmpty(tbSobrCC.Text))
                sobre_cc = Convert.ToDouble(tbSobrCC.Text);

            if (!string.IsNullOrEmpty(tbEntero.Text))
                entero = Convert.ToDouble(tbEntero.Text);

            tbDiferencia.Text = ((entero + sobre_cc) - Liq.Lbstotales).ToString("N2");
        }

        private void Limpiar_Controles()
        {

        }

    }
}

