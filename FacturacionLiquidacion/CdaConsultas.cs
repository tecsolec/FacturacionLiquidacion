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
            
            //connetionString = "Data Source=.;Initial Catalog=PRODUMAR;Integrated Security=True; ";
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

        public DataTable Consultar_Det_Factura(String _proy, String _subproy, String _cliente, String _docentero,String _doccola)
        {
            try
            {
                //se declara una variable de tipo SqlConnection
                cnn = new SqlConnection();
                //se indica la cadena de conexion
                cnn.ConnectionString = connetionString;
                string query = "P_Cons_Detalle_Factura2";
                cmd = new SqlCommand(query, cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Proyecto", _proy);
                cmd.Parameters.AddWithValue("@Subproyecto", _subproy);
                cmd.Parameters.AddWithValue("@cliente", _cliente);
                cmd.Parameters.AddWithValue("@docentero", _docentero);
                cmd.Parameters.AddWithValue("@doccola", _doccola);
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

        public DataTable Consultar_Clientes()
        {
            try
            {
                //se declara una variable de tipo SqlConnection
                cnn = new SqlConnection();
                //se indica la cadena de conexion
                cnn.ConnectionString = connetionString;
                string query = "P_Cons_Clientes";
                cmd = new SqlCommand(query, cnn);
                cmd.CommandType = CommandType.StoredProcedure;
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
        public DataTable Consultar_Cliente_X_Codigo(String _codCliente)
        {
            try
            {
                //se declara una variable de tipo SqlConnection
                cnn = new SqlConnection();
                //se indica la cadena de conexion
                cnn.ConnectionString = connetionString;
                string query = "P_Cons_Cliente_Codigo";
                cmd = new SqlCommand(query, cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@codigo_cliente", _codCliente);
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
        public DataTable Consultar_Ord_Entero(String _proy, String _subproy)
        {
            try
            {
                //se declara una variable de tipo SqlConnection
                cnn = new SqlConnection();
                //se indica la cadena de conexion
                cnn.ConnectionString = connetionString;
                string query = "P_Cons_Ordenes_Entero";
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

        public DataTable Consultar_Ord_Cola(String _proy, String _subproy)
        {
            try
            {
                //se declara una variable de tipo SqlConnection
                cnn = new SqlConnection();
                //se indica la cadena de conexion
                cnn.ConnectionString = connetionString;
                string query = "P_Cons_Ordenes_Cola";
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
                string query = "P_Cons_Cliente_Liqui";
                cmd = new SqlCommand(query, cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Proyecto", _nombre);
                cmd.Parameters.AddWithValue("@Subproyecto", _nombre);
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
        public DataTable Consultar_Cliente(String _proyecto, String _subproyecto)
        {
            try
            {
                //se declara una variable de tipo SqlConnection
                cnn = new SqlConnection();
                //se indica la cadena de conexion
                cnn.ConnectionString = connetionString;
                string query = "P_Cons_Cliente_Liqui";
                cmd = new SqlCommand(query, cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Proyecto", _proyecto);
                cmd.Parameters.AddWithValue("@Subproyecto", _subproyecto);
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


        //Almacenar en sist_api
        public int Guardar_Datos(string query)
        {
            int ultimo_movimiento = 0;
            cnn = new SqlConnection();
            cnn.ConnectionString = connetionString;
            //Iniciando la transaccion
            cnn.Open();
            SqlTransaction transaction;
            // Start a local transaction.
            transaction = cnn.BeginTransaction("SampleTransaction");

            try
            {

                //Grabando la cabecera de la factura
                SqlCommand _cmd = cnn.CreateCommand();
                _cmd.Transaction = transaction;

                //Actualizando ultimo numero de factura
                _cmd.CommandText = query;
                _cmd.ExecuteNonQuery();

                transaction.Commit();
                cnn.Close();

                return ultimo_movimiento;
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                transaction.Rollback();
                cnn.Close();
                Console.WriteLine("Error al guardar datos en SIst API: " + ex);
                return 0;
            }
        }
        //COnsultar precios
        public DataTable Consultar_Precios()
        {
            try
            {
                //se declara una variable de tipo SqlConnection
                cnn = new SqlConnection();
                //se indica la cadena de conexion
                cnn.ConnectionString = connetionString;
                string query = "P_Cons_Precios";
                cmd = new SqlCommand(query, cnn);
                cmd.CommandType = CommandType.StoredProcedure;
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
        //COnsultar precios
        public DataTable Consultar_Orden_Clientes()
        {
            try
            {
                //se declara una variable de tipo SqlConnection
                cnn = new SqlConnection();
                //se indica la cadena de conexion
                cnn.ConnectionString = connetionString;
                string query = "P_Cons_OrdClientes";
                cmd = new SqlCommand(query, cnn);
                cmd.CommandType = CommandType.StoredProcedure;
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
        //COnsultar productos
        public DataTable Consultar_Productos()
        {
            try
            {
                //se declara una variable de tipo SqlConnection
                cnn = new SqlConnection();
                //se indica la cadena de conexion
                cnn.ConnectionString = connetionString;
                string query = "P_Cons_Productos";
                cmd = new SqlCommand(query, cnn);
                cmd.CommandType = CommandType.StoredProcedure;
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
        //Delete Cliente
        public Int32 Delete_Orden_Clientes(String _Cliente)
        {
            int res = 0;
            try
            {
                //se declara una variable de tipo SqlConnection
                cnn = new SqlConnection();
                //se indica la cadena de conexion
                cnn.ConnectionString = connetionString;
                string query = "P_Del_OrdCliente";
                cmd = new SqlCommand(query, cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@codcliente", _Cliente);
                cnn.Open();
                res=cmd.ExecuteNonQuery();
                cnn.Close();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return res;
        }
    }
}
