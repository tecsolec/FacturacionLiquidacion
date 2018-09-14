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
            connetionString = "Server=10.51.1.12\\PORTAL;Database=LIQUIFACT;User Id=sa;Password = 123456; ";

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


        public DataTable Consultar_Det_Factura(String _proy, String _subproy,String _liqui)
        {
            try
            {
                //se declara una variable de tipo SqlConnection
                cnn = new SqlConnection();
                //se indica la cadena de conexion
                cnn.ConnectionString = connetionString;
                string query = "P_Cons_Detalle_Factura";
                cmd = new SqlCommand(query, cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Proyecto", _proy);
                cmd.Parameters.AddWithValue("@Subproyecto", _subproy);
                cmd.Parameters.AddWithValue("@Liquidacion", _liqui);
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


        public DataTable Consultar_Liq_X_Proyecto(String _proy, String _subproy)
        {
            try
            {
                //se declara una variable de tipo SqlConnection
                cnn = new SqlConnection();
                //se indica la cadena de conexion
                cnn.ConnectionString = connetionString;
                string query = "P_Cons_Liq_X_Proyecto";
                cmd = new SqlCommand(query, cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Proyecto", _proy);
                cmd.Parameters.AddWithValue("@Subproyecto", _subproy);
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


        public DataTable Consultar_Cliente(String _nombre)
        {
            try
            {
                //se declara una variable de tipo SqlConnection
                cnn = new SqlConnection();
                //se indica la cadena de conexion
                cnn.ConnectionString = connetionString;
                string query = "P_Cons_Cliente";
                cmd = new SqlCommand(query, cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nombre", _nombre);
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
