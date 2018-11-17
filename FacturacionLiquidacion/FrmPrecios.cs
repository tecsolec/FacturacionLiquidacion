using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FacturacionLiquidacion
{
    public partial class FrmPrecios : Form
    {
        CdaConsultas dat_consultas;
        public FrmPrecios()
        {
            InitializeComponent();
        }

        private void FrmPrecios_Load(object sender, EventArgs e)
        {
            dat_consultas = new CdaConsultas();
            DataTable precios = new DataTable();
            DataTable productos = new DataTable();
            DataTable clientes = new DataTable();
            clientes = dat_consultas.Consultar_Orden_Clientes();
            productos = dat_consultas.Consultar_Productos();
            precios = dat_consultas.Consultar_Precios();
            DataTable dt = new DataTable();
            dt.Columns.Add("Productos", typeof(string));
            dt.Columns.Add("Descripción", typeof(string));

            foreach (DataRow row in productos.Rows)
            {
                dt.Rows.Add(row[0].ToString(), row[1].ToString());
            }
            foreach (DataRow row in clientes.Rows)
            {
                if (row[1].ToString() == "0")
                    dt.Columns.Add("PRECIO BASE", typeof(double));
                else
                    dt.Columns.Add(row[0].ToString(), typeof(double));
                foreach (DataRow row2 in dt.Rows)
                {
                    foreach (DataRow row3 in precios.Select("Orden="+ row[1].ToString()))
                    {
                        if(row2[0].ToString()==row3[2].ToString())
                            row2[Convert.ToInt32(row[1].ToString()) + 2] = row3[3].ToString();
                    }
                }
            }                
            dgvPrecios.DataSource = dt;
        }
    }
}
