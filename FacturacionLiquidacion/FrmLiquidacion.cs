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
        public FrmLiquidacion()
        {
            InitializeComponent();
        }


        internal Liquidacion Liq { get => liq; set => liq = value; }

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
            Receta tmp = new Receta();
            Hashtable param = new Hashtable();
            CdaConsultas cons = new CdaConsultas();
            param.Add("ESPECIE", cbEspecie.SelectedValue);
            param.Add("TIPO", cbTipo.SelectedValue);
            param.Add("CLASE", cbClase.SelectedValue);
            param.Add("TALLA", cbTalla.SelectedValue);
            tmp.GetReceta(cons.ConsultaCodigoProducto(param));
            tmp.Precio = 0.0;
            tmp.Cantidad = Convert.ToDouble(tbCantidad.Text);
            Int32 idx = dgvReceta.Rows.Add();
            DataGridViewRow row = dgvReceta.Rows[idx];
            row.Cells["codProducto"].Value = tmp.CodProducto;
            row.Cells["detalle"].Value = tmp.Detalle;
            row.Cells["cantidad"].Value = tmp.Cantidad;
            row.Cells["precio"].Value = tmp.Precio;
            DataGridViewButtonColumn btngridEdit = (DataGridViewButtonColumn)row.Cells["itemModificar"].Value;
            DataGridViewButtonColumn btngridDelet = (DataGridViewButtonColumn)row.Cells["itemEliminar"].Value;
            btngridEdit=new DataGridViewButtonColumn();
            btngridEdit.UseColumnTextForButtonValue = true;
            btngridEdit.Name = "Editar";
            btngridEdit.DataPropertyName = "Editar";
            btngridEdit.HeaderText = "Editar";
            btngridEdit.Text = "Editar";

            //dgvReceta.AutoGenerateColumns = false;
            //dgvReceta.Rows.Add(tmp);
        }

        private void btnLimpiarDetalle_Click(object sender, EventArgs e)
        {

        }

        private void dgvReceta_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
               

            }
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {

        }
    }
}

