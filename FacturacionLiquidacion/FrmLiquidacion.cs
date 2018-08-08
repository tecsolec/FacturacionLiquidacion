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

            //agregando la diferencia 
            tbDiferencia.Text = Liq.Lbstotales.ToString("N2");

            txt_hidden_detalle.Text = "0";
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
                Int32 idx = dgvReceta.Rows.Add();
                DataGridViewRow row = dgvReceta.Rows[idx];
                row.Cells["codProducto"].Value = tmp.CodProducto;
                row.Cells["detalle"].Value = tmp.Detalle;
                row.Cells["cantidad"].Value = tmp.Cantidad;
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

            //DataGridViewButtonColumn btngrid = new DataGridViewButtonColumn();
            //btngrid.UseColumnTextForButtonValue = true;
            //btngrid.Name = "Editar";
            //btngrid.DataPropertyName = "Editar Liquidación";
            //btngrid.HeaderText = "Editar Liquidación";
            //btngrid.Text = "Editar";
            //dgvReceta.Columns.Add(btngrid);


            //DataGridViewButtonColumn btngridEdit = (DataGridViewButtonColumn)row.Cells["itemModificar"].Value;
            //DataGridViewButtonColumn btngridDelet = (DataGridViewButtonColumn)row.Cells["itemEliminar"].Value;
            //btngridEdit=new DataGridViewButtonColumn();
            //btngridEdit.UseColumnTextForButtonValue = true;
            //btngridEdit.Name = "Editar";
            //btngridEdit.DataPropertyName = "Editar";
            //btngridEdit.HeaderText = "Editar";
            //btngridEdit.Text = "Editar";

            //dgvReceta.AutoGenerateColumns = false;
            //dgvReceta.Rows.Add(tmp);
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
            //obteniendo la informacion de las guias
            IList<Guia> guias = Liq.Guias;
            CdaConsultas cons = new CdaConsultas();
            cons.Guardar_Guias(guias, Liq.Numeroliquidacion);
            //foreach (DataGridViewRow row in dgvReceta.Rows)

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

