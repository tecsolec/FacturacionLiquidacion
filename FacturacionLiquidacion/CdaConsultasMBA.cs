using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Linq;
using System.Text;

namespace FacturacionLiquidacion
{
    class CdaConsultasmba
    {
        string connetionString = null;
        OdbcConnection cnn;
        OdbcCommand cmd;
        OdbcDataAdapter da;
        public CdaConsultasmba()
        {
            //LOCAL            
            connetionString = "DSN=mba;DRIVER={4D v15 ODBC Driver 32-bit};;Server=10.51.1.11;Port=19812;UID=API;PWD=API;SSL=false;PhysicalConnectionTimeout=30;LoginTimeout=30;QueryTimeout=240;DefaultPageSize=100;NetworkCacheSize=128;CharsEncoding=UTF-8;OpenQuery=false;MSAccess=false;Windev=false ";
        }
        public DataSet ConsultaEspecie()
        {
            //se declara una variable de tipo SqlConnection
            cnn = new OdbcConnection();
            //se indica la cadena de conexion
            cnn.ConnectionString = connetionString;
            //codigo para llenar el comboBox
            DataSet ds = new DataSet();
            //endicamos la consulta en SQL
            OdbcDataAdapter da = new OdbcDataAdapter("SELECT distinct ESPECIE FROM LIQ_PRODUCTOS_DETALLE", cnn);
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
            cnn = new OdbcConnection();
            //se indica la cadena de conexion
            cnn.ConnectionString = connetionString;
            //codigo para llenar el comboBox
            DataSet ds = new DataSet();
            //endicamos la consulta en SQL
            if(param["ESPECIE"]!=null)
            {
                whereSql=" Where ESPECIE='"+ param["ESPECIE"] + "'";
            }
            OdbcDataAdapter da = new OdbcDataAdapter("SELECT distinct TIPO FROM LIQ_PRODUCTOS_DETALLE " + whereSql, cnn);
            //se indica el nombre de la tabla
            da.Fill(ds, "TIPO");
            return ds;
        }
        public DataSet ConsultaClase(Hashtable param)
        {
            String whereSql = "";
            //se declara una variable de tipo SqlConnection
            cnn = new OdbcConnection();
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
            OdbcDataAdapter da = new OdbcDataAdapter("SELECT distinct CLASE FROM LIQ_PRODUCTOS_DETALLE " + whereSql, cnn);
            //se indica el nombre de la tabla
            da.Fill(ds, "CLASE");
            return ds;
        }
        public DataSet ConsultaTalla(Hashtable param)
        {
            String whereSql = "";
            //se declara una variable de tipo SqlConnection
            cnn = new OdbcConnection();
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
            OdbcDataAdapter da = new OdbcDataAdapter("SELECT distinct TALLA FROM LIQ_PRODUCTOS_DETALLE " + whereSql, cnn);
            //se indica el nombre de la tabla
            da.Fill(ds, "TALLA");
            return ds;
        }

        public DataSet ConsultaCodigoProducto(Hashtable param)
        {
            String whereSql = "";
            //se declara una variable de tipo SqlConnection
            cnn = new OdbcConnection();
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
            OdbcDataAdapter da = new OdbcDataAdapter("select lp.CODIGO , lp.NOMBRE from LIQ_PRODUCTOS_DETALLE lpd inner join LIQ_PRODUCTOS lp on lpd.CODIGO=lp.CODIGO " + whereSql, cnn);
            //se indica el nombre de la tabla
            da.Fill(ds, "RECETA");
            return ds;
        }


        public DataTable Consultar_Det_Factura(String _proy, String _subproy,String _liqui)
        {
            try
            {
                //se declara una variable de tipo SqlConnection
                cnn = new OdbcConnection();
                //se indica la cadena de conexion
                cnn.ConnectionString = connetionString;
                string query = "P_Cons_Detalle_Factura";
                cmd = new OdbcCommand(query, cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Proyecto", _proy);
                cmd.Parameters.AddWithValue("@Subproyecto", _subproy);
                cmd.Parameters.AddWithValue("@Liquidacion", _liqui);
                cnn.Open();
                DataTable dt = new DataTable();
                OdbcDataReader dr = cmd.ExecuteReader();
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
                cnn = new OdbcConnection();
                //se indica la cadena de conexion
                cnn.ConnectionString = connetionString;
                string query = "P_Cons_Liq_X_Proyecto";
                cmd = new OdbcCommand(query, cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Proyecto", _proy);
                cmd.Parameters.AddWithValue("@Subproyecto", _subproy);
                cnn.Open();
                DataTable dt = new DataTable();
                OdbcDataReader dr = cmd.ExecuteReader();
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
                cnn = new OdbcConnection();
                //se indica la cadena de conexion
                cnn.ConnectionString = connetionString;
                string query = "P_Cons_Cliente_Liqui";
                cmd = new OdbcCommand(query, cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Proyecto", _nombre);
                cmd.Parameters.AddWithValue("@Subproyecto", _nombre);
                cnn.Open();
                DataTable dt = new DataTable();
                OdbcDataReader dr = cmd.ExecuteReader();
                dt.Load(dr);
                cnn.Close();

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable Consultar_Cliente(String _proyecto, String _subproyecto)
        {
            try
            {
                //se declara una variable de tipo SqlConnection
                cnn = new OdbcConnection();
                //se indica la cadena de conexion
                cnn.ConnectionString = connetionString;
                string query = "P_Cons_Cliente_Liqui";
                cmd = new OdbcCommand(query, cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Proyecto", _proyecto);
                cmd.Parameters.AddWithValue("@Subproyecto", _subproyecto);
                cnn.Open();
                DataTable dt = new DataTable();
                OdbcDataReader dr = cmd.ExecuteReader();
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
