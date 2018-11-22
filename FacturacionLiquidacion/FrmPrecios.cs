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
            llenar_Clientes();
            llenar_Productos();
            llenar_Precios();
        }
        //((Agregar Clientes))
        private void btAgregarCliente_Click(object sender, EventArgs e)
        {
            String query = "insert into liquifact.dbo.columnasXcliente (codigo_empresa,nombre_empresa,orden) select  '" + txCodigoCliente.Text + "','" + txNombreCliente.Text + "', max(orden)+1 from liquifact.dbo.columnasXcliente;";
            dat_consultas = new CdaConsultas();
            dat_consultas.Guardar_Datos(query);
            llenar_Clientes();
            llenar_Precios();
        }
        //((Agregar Productos))
        private void btAgregarProducto_Click(object sender, EventArgs e)
        {

        }
        private void llenar_Precios()
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
                if (row[2].ToString() == "0")
                    dt.Columns.Add("PRECIO BASE", typeof(double));
                else
                    dt.Columns.Add(row[1].ToString(), typeof(double));
                foreach (DataRow row2 in dt.Rows)
                {
                    foreach (DataRow row3 in precios.Select("Orden=" + row[2].ToString()))
                    {
                        if (row2[0].ToString() == row3[2].ToString())
                            row2[Convert.ToInt32(row[2].ToString()) + 2] = row3[3].ToString();
                    }
                }
            }
            dgvPrecios.DataSource = dt;
        }
        private void llenar_Clientes()
        {
            DataTable Clientes = new DataTable();
            dat_consultas = new CdaConsultas();
            Clientes = dat_consultas.Consultar_Orden_Clientes();
            ((ListBox)cblClientes).DataSource = Clientes;
            ((ListBox)cblClientes).DisplayMember = "codigo_empresa";
            ((ListBox)cblClientes).ValueMember = "codigo_empresa";
        }
        private void llenar_Productos()
        {
            DataTable Productos = new DataTable();
            dat_consultas = new CdaConsultas();
            Productos = dat_consultas.Consultar_Productos();
            ((ListBox)cblProductos).DataSource = Productos;
            ((ListBox)cblProductos).DisplayMember = "CODIGO";
            ((ListBox)cblProductos).ValueMember = "CODIGO";
        }

        private void cblClientes_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            for (int ix = 0; ix < cblClientes.Items.Count; ++ix)
                if (ix != e.Index) cblClientes.SetItemChecked(ix, false);
        }

        private void cblProductos_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            for (int ix = 0; ix < cblProductos.Items.Count; ++ix)
                if (ix != e.Index) cblProductos.SetItemChecked(ix, false);
        }

        private void btEliminarCliente_Click(object sender, EventArgs e)
        {
            if (cblClientes.CheckedItems.Count > 0)
            {
                foreach (DataRowView item in cblClientes.CheckedItems)
                {
                    dat_consultas = new CdaConsultas();
                    dat_consultas.Delete_Orden_Clientes(item["codigo_empresa"].ToString());                    
                }
                llenar_Clientes();
                llenar_Precios();
            }
        }

        private void btEliminarProducto_Click(object sender, EventArgs e)
        {
            if (cblProductos.CheckedItems.Count > 0)
            {
                foreach (DataRowView item in cblProductos.CheckedItems)
                {
                    dat_consultas = new CdaConsultas();
                    dat_consultas.Delete_Productos(item["CODIGO"].ToString());
                }
                llenar_Productos();
                llenar_Precios();
            }
        }

        private void btGuardarPrecios_Click(object sender, EventArgs e)
        {
            String query = "";
            dat_consultas = new CdaConsultas();
            DataTable clientes = new DataTable();
            clientes = dat_consultas.Consultar_Orden_Clientes();
            foreach (DataGridViewRow row in dgvPrecios.Rows)
            {
                if (query == "")
                    query = "truncate table LIQUIFACT.dbo.precios; Insert into LIQUIFACT.dbo.precios ( codigo_producto, precio, codigo_empresa, estado) values ";
                
                foreach (DataRow rowCli in clientes.Rows)
                {
                    query += "('" + row.Cells[0].Value + "',"+ row.Cells[Convert.ToInt32(rowCli[2].ToString())+2].Value.ToString().Replace(",",".") + ",'"+rowCli[0].ToString() + "','A'),";
                }               
            }
            query = query.TrimEnd(','); //codentero.Substring(codentero.Length-1,1);
            dat_consultas.Guardar_Datos(query);
            llenar_Precios();
        }
        
    }
}
