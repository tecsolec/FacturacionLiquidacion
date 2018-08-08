using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace FacturacionLiquidacion
{
    class CdaConsultas
    {
        string connetionString = null;
        SqlConnection cnn;
        SqlCommand cmd;
        SqlDataAdapter da;
        public CdaConsultas()
        {
            //LOCAL
            connetionString = "Data Source=.;Initial Catalog=PRODUMAR;Integrated Security=True; ";
        }
        public DataSet ConsultaEspecie()
        {
            //se declara una variable de tipo SqlConnection
            cnn = new SqlConnection();
            //se indica la cadena de conexion
            cnn.ConnectionString = connetionString;
            //codigo para llenar el comboBox
            DataSet ds = new DataSet();
            //endicamos la consulta en SQL
            SqlDataAdapter da = new SqlDataAdapter("SELECT distinct ESPECIE FROM LIQ_PRODUCTOS_DETALLE", cnn);
            //se indica el nombre de la tabla            
            da.Fill(ds, "ESPECIE");
            return ds;
            //comboBox1.DataSource = ds.Tables[0].DefaultView;
            //se especifica el campo de la tabla
            //comboBox1.ValueMember = “Nombre_Anime”;
        }
        public DataSet ConsultaTipo(Hashtable param)
        {
            String whereSql = "";
            //se declara una variable de tipo SqlConnection
            cnn = new SqlConnection();
            //se indica la cadena de conexion
            cnn.ConnectionString = connetionString;
            //codigo para llenar el comboBox
            DataSet ds = new DataSet();
            //endicamos la consulta en SQL
            if(param["ESPECIE"]!=null)
            {
                whereSql=" Where ESPECIE='"+ param["ESPECIE"] + "'";
            }
            SqlDataAdapter da = new SqlDataAdapter("SELECT distinct TIPO FROM LIQ_PRODUCTOS_DETALLE " + whereSql, cnn);
            //se indica el nombre de la tabla
            da.Fill(ds, "TIPO");
            return ds;
        }
        public DataSet ConsultaClase(Hashtable param)
        {
            String whereSql = "";
            //se declara una variable de tipo SqlConnection
            cnn = new SqlConnection();
            //se indica la cadena de conexion
            cnn.ConnectionString = connetionString;
            //codigo para llenar el comboBox
            DataSet ds = new DataSet();
            //endicamos la consulta en SQL
            if (param["ESPECIE"] != null)
            {
                whereSql = " Where ESPECIE='" + param["ESPECIE"] + "'";
            }
            if (param["TIPO"] != null)
            {
                if (param["ESPECIE"] == null)
                {
                    whereSql = " Where TIPO='" + param["TIPO"] + "'";
                }
                else
                    whereSql += " and TIPO='" + param["TIPO"] + "'";
            }
            SqlDataAdapter da = new SqlDataAdapter("SELECT distinct CLASE FROM LIQ_PRODUCTOS_DETALLE " + whereSql, cnn);
            //se indica el nombre de la tabla
            da.Fill(ds, "CLASE");
            return ds;
        }
        public DataSet ConsultaTalla(Hashtable param)
        {
            String whereSql = "";
            //se declara una variable de tipo SqlConnection
            cnn = new SqlConnection();
            //se indica la cadena de conexion
            cnn.ConnectionString = connetionString;
            //codigo para llenar el comboBox
            DataSet ds = new DataSet();
            //endicamos la consulta en SQL
            if (param["ESPECIE"] != null)
            {
                whereSql = " Where ESPECIE='" + param["ESPECIE"] + "'";
            }
            if (param["TIPO"] != null)
            {
                if (param["ESPECIE"] == null)
                {
                    whereSql = " Where TIPO='" + param["TIPO"] + "'";
                }
                else
                    whereSql += " and TIPO='" + param["TIPO"] + "'";
            }
            if (param["CLASE"] != null)
            {
                if (param["ESPECIE"] == null)
                {
                    whereSql = " Where CLASE='" + param["CLASE"] + "'";
                }
                else
                    whereSql += " and CLASE='" + param["CLASE"] + "'";
            }
            SqlDataAdapter da = new SqlDataAdapter("SELECT distinct TALLA FROM LIQ_PRODUCTOS_DETALLE " + whereSql, cnn);
            //se indica el nombre de la tabla
            da.Fill(ds, "TALLA");
            return ds;
        }

        public DataSet ConsultaCodigoProducto(Hashtable param)
        {
            String whereSql = "";
            //se declara una variable de tipo SqlConnection
            cnn = new SqlConnection();
            //se indica la cadena de conexion
            cnn.ConnectionString = connetionString;
            //codigo para llenar el comboBox
            DataSet ds = new DataSet();
            //endicamos la consulta en SQL
            if (param["ESPECIE"] != null)
            {
                whereSql = " Where ESPECIE='" + param["ESPECIE"] + "'";
            }
            if (param["TIPO"] != null)
            {
                if (param["ESPECIE"] == null)
                {
                    whereSql = " Where TIPO='" + param["TIPO"] + "'";
                }
                else
                    whereSql += " and TIPO='" + param["TIPO"] + "'";
            }
            if (param["CLASE"] != null)
            {
                if (param["ESPECIE"] == null)
                {
                    whereSql = " Where CLASE='" + param["CLASE"] + "'";
                }
                else
                    whereSql += " and CLASE='" + param["CLASE"] + "'";
            }
            if (param["TALLA"] != null)
            {
                if (param["ESPECIE"] == null)
                {
                    whereSql = " Where TALLA='" + param["TALLA"] + "'";
                }
                else
                    whereSql += " and TALLA='" + param["TALLA"] + "'";
            }
            SqlDataAdapter da = new SqlDataAdapter("select lp.CODIGO , lp.NOMBRE from LIQ_PRODUCTOS_DETALLE lpd inner join LIQ_PRODUCTOS lp on lpd.CODIGO=lp.CODIGO " + whereSql, cnn);
            //se indica el nombre de la tabla
            da.Fill(ds, "RECETA");
            return ds;
        }


        //Procedimiento para guardar las guias
        public string Guardar_Guias(IList<Guia> guias, string liquidacion)
        {

            string error = "OK";
            //se declara una variable de tipo SqlConnection
            cnn = new SqlConnection();
            //se indica la cadena de conexion
            cnn.ConnectionString = connetionString;

            //Iniciando la transaccion
            cnn.Open();
            SqlTransaction transaction;
            // Start a local transaction.
            transaction = cnn.BeginTransaction("SampleTransaction");

            try
            {

                cmd = cnn.CreateCommand();
                cmd.Transaction = transaction;

                //Consultando el detalle dela factura y almacenando en la base
                foreach (Guia _guia in guias)
                {
                    cmd.CommandText = "P_Ingresar_Guia " + _guia.Numeroguia + ",'" + _guia.Fechaguia + "','" + _guia.Piscina + "','" + _guia.Ciclo + "'," + Convert.ToString(_guia.Lbs).Replace(",",".") + "," + Convert.ToString(_guia.Kg).Replace(",", ".") + "," + Convert.ToString(_guia.Un).Replace(",", ".") + ",'" + _guia.Empacadora + "'," + liquidacion ;
                    cmd.ExecuteNonQuery();
                }

                transaction.Commit();
                cnn.Close();

                return error;
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                transaction.Rollback();
                cnn.Close();
                error = "Error al guardar las guias: " + ex.Message;
                return error;
            }
        }
    }
}
