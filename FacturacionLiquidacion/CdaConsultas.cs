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
        public string Guardar_Guias(IList<Guia> guias, Liquidacion Liq, IList<Receta> recetas)
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

                //Ingresando cada guia
                foreach (Guia _guia in guias)
                {
                    cmd.CommandText = "P_Ingresar_Guia " + _guia.Numeroguia + ",'" + _guia.Fechaguia + "','" + _guia.Piscina + "','" + _guia.Ciclo + "'," + Convert.ToString(_guia.Lbs).Replace(",",".") + "," + Convert.ToString(_guia.Kg).Replace(",", ".") + "," + Convert.ToString(_guia.Un).Replace(",", ".") + ",'" + _guia.Empacadora + "'," + Liq.Numeroliquidacion;
                    cmd.ExecuteNonQuery();
                }

                //Ingresando la cabecera de la liquidación
                cmd.CommandText = "insert into cab_liquidacion values (" + Liq.Numeroliquidacion + ",'" + Liq.LoteMBA + "','" + Liq.Piscina + "','" + Liq.Ciclo + "','" + Liq.Op + "'," + Convert.ToString(Liq.Lbstotales).Replace(",", ".") + "," + Convert.ToString(Liq.Kgtotales).Replace(",", ".") + ",'" + Liq.Empacadora + "',getdate()," + Convert.ToString(Liq.Entero).Replace(",",".") + "," + Convert.ToString(Liq.Sobre_Cc).Replace(",",".") + "," + Convert.ToString(Liq.Cola).Replace(",",".") + "," + Convert.ToString(Liq.Basura).Replace(",",".") + ","  + Liq.Diferencia +  ",1,'N')";
                cmd.ExecuteNonQuery();

                //Ingresando cada receta: ini
                List<Receta> lista_final = new List<Receta>();
                Receta primera;
                double total = 0;
                foreach (Receta rec1 in recetas)
                {
                    primera = new Receta();
                    primera = rec1;
                    total = 0;
                    foreach (Receta rec in recetas)
                    {
                        if (rec.Tipo == primera.Tipo && rec.Clase == primera.Clase && rec.Talla == primera.Talla)
                        {
                            total = total + rec.Cantidad;
                        }
                    }
                    rec1.Cantidad = total;
                    lista_final.Add(rec1);
                }


                foreach (Receta _receta in lista_final)
                {
                    cmd.CommandText = "insert into Det_Liquidacion values ( " + Liq.Numeroliquidacion + ",'" + _receta.CodProducto + "','" + _receta.Tipo + "','" + _receta.Clase + "','" + _receta.Talla + "'," + _receta.Cantidad  + ",'" + _receta.Detalle + "')";
                    cmd.ExecuteNonQuery();
                }
                //fin

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


        //Consultando liquidaciones Pendientes
        public DataTable ConsultarLiquidacionesPendientes()
        {
            try
            {
                //se declara una variable de tipo SqlConnection
                cnn = new SqlConnection();
                //se indica la cadena de conexion
                cnn.ConnectionString = connetionString;
                String SQLQuery = "Exec P_Cons_Liq_Pendientes";
                cmd = new SqlCommand(SQLQuery, cnn);
                cnn.Open();
                DataTable dt = new DataTable();
                SqlDataReader dr = cmd.ExecuteReader();
                dt.Load(dr);
                cnn.Close();

                return dt;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Consultando liquidaciones Pendientes
        public DataTable ConsultarDetalleLiquidacionesPendientes(decimal cod_liquidacion)
        {
            try
            {
                //se declara una variable de tipo SqlConnection
                cnn = new SqlConnection();
                //se indica la cadena de conexion
                cnn.ConnectionString = connetionString;
                String SQLQuery = "P_Cons_Det_Liq_Pendientes " + cod_liquidacion;
                cmd = new SqlCommand(SQLQuery, cnn);
                cnn.Open();
                DataTable dt = new DataTable();
                SqlDataReader dr = cmd.ExecuteReader();
                dt.Load(dr);
                cnn.Close();

                return dt;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
