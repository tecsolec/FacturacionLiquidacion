using System;
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
        IList<Liquidacion> liquidaciones;
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void btnSubirLiquidacion_Click(object sender, EventArgs e)
        {
            String hoja;
            //creamos un objeto OpenDialog que es un cuadro de dialogo para buscar archivos
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Archivos de Excel (*.xls;*.xlsx)|*.xls;*.xlsx"; //le indicamos el tipo de filtro en este caso que busque
                                                                             //solo los archivos excel

            dialog.Title = "Seleccione el archivo de Excel";//le damos un titulo a la ventana

            dialog.FileName = string.Empty;//inicializamos con vacio el nombre del archivo

            //si al seleccionar el archivo damos Ok
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                //el nombre del archivo sera asignado al textbox
                txtArchivo.Text = dialog.FileName;
                hoja = txtHoja.Text; //la variable hoja tendra el valor del textbox donde colocamos el nombre de la hoja
                LLenarGrid(txtArchivo.Text, hoja); //se manda a llamar al metodo

                dGVLiquidaciones.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; //se ajustan las
                                                                                          //columnas al ancho del DataGridview para que no quede espacio en blanco (opcional)
            }
        }
        private void LLenarGrid(string archivo, string hoja)
        {
            //declaramos las variables         
            OleDbConnection conexion = null;
            DataSet dataSet = null;
            OleDbDataAdapter dataAdapter = null;
            string consultaHojaExcel = "Select * from [" + hoja + "$]";
           
            //esta cadena es para archivos excel 2007 y 2010
            string cadenaConexionArchivoExcel = "provider=Microsoft.ACE.OLEDB.12.0;Data Source='" + archivo + "';Extended Properties=Excel 12.0;";

            //para archivos de 97-2003 usar la siguiente cadena
            //string cadenaConexionArchivoExcel = "provider=Microsoft.Jet.OLEDB.4.0;Data Source='" + archivo + "';Extended Properties=Excel 8.0;";

            //Validamos que el usuario ingrese el nombre de la hoja del archivo de excel a leer
            if (string.IsNullOrEmpty(hoja))
            {
                MessageBox.Show("No hay una hoja para leer");
            }
            else
            {
                try
                {
                    //Si el usuario escribio el nombre de la hoja se procedera con la busqueda
                    conexion = new OleDbConnection(cadenaConexionArchivoExcel);//creamos la conexion con la hoja de excel
                    conexion.Open(); //abrimos la conexion
                    dataAdapter = new OleDbDataAdapter(consultaHojaExcel, conexion); //traemos los datos de la hoja y las guardamos en un dataSdapter
                    dataSet = new DataSet(); // creamos la instancia del objeto DataSet
                    dataAdapter.Fill(dataSet, hoja);//llenamos el dataset
                    //IList<Liquidacion> liq;
                    dataSet.Tables[0].DefaultView.Sort = " Liquidacion,[# GUIA]";
                    //dGVLiquidaciones.DataSource = dataSet.Tables[0]; //le asignamos al DataGridView el contenido del dataSet
                    liquidaciones = new Liquidacion().FillList(dataSet);
                    dGVLiquidaciones.AutoGenerateColumns = false;
                    dGVLiquidaciones.DataSource = liquidaciones;
                    DataGridViewButtonColumn btngrid = new DataGridViewButtonColumn();
                    btngrid.UseColumnTextForButtonValue = true;
                    btngrid.Name = "Editar";
                    btngrid.DataPropertyName = "Editar Liquidación";
                    btngrid.HeaderText = "Editar Liquidación";
                    btngrid.Text = "Editar";
                    dGVLiquidaciones.Columns.Add(btngrid);
                    DataGridViewButtonColumn btngridFact = new DataGridViewButtonColumn();
                    btngridFact.UseColumnTextForButtonValue = true;
                    btngridFact.Name = "Facturar";
                    btngridFact.DataPropertyName = "Facturar Liquidación";
                    btngridFact.HeaderText = "Facturar Liquidación";
                    btngridFact.Text = "Facturar";
                    dGVLiquidaciones.Columns.Add(btngridFact);
                    conexion.Close();//cerramos la conexion
                   // dGVLiquidaciones.AllowUserToAddRows = false;       //eliminamos la ultima fila del datagridview que se autoagrega
                }
                catch (Exception ex)
                {
                    //en caso de haber una excepcion que nos mande un mensaje de error
                    MessageBox.Show("Error, Verificar el archivo o el nombre de la hoja", ex.Message);
                }
            } 
        }

        private void dGVLiquidaciones_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 8) {
                FrmLiquidacion FrmNewLiq = new FrmLiquidacion();
                FrmNewLiq.Liq = liquidaciones.Where( liquidacion => liquidacion.Numeroliquidacion == dGVLiquidaciones.Rows[e.RowIndex].Cells["numeroliquidacion"].Value.ToString()).FirstOrDefault();
                //dGVLiquidaciones.Rows[e.RowIndex].Cells["Liquidacion"].Value;
                FrmNewLiq.Show();

            }
            if (e.ColumnIndex == 9)
            {
                FrmLiquidacion FrmNewLiq = new FrmLiquidacion();
                FrmNewLiq.Liq = liquidaciones.Where(liquidacion => liquidacion.Numeroliquidacion == dGVLiquidaciones.Rows[e.RowIndex].Cells["numeroliquidacion"].Value.ToString()).FirstOrDefault();
                //dGVLiquidaciones.Rows[e.RowIndex].Cells["Liquidacion"].Value;
                FrmNewLiq.Show();

            }
        }
    }
}
