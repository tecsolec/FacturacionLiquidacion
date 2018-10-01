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
            //connetionString = "Data Source=.;Initial Catalog=PRODUMAR;Integrated Security=True; ";
            connetionString = "DSN=mba;DRIVER={4D v15 ODBC Driver 32-bit};;Server=10.51.1.11;Port=19812;UID=API;PWD=API;SSL=false;PhysicalConnectionTimeout=30;LoginTimeout=30;QueryTimeout=240;DefaultPageSize=100;NetworkCacheSize=128;CharsEncoding=UTF-8;OpenQuery=false;MSAccess=false;Windev=false ";
            connetionString = "DSN=MBA3;DRIVER={4D v16 Rx ODBC Driver 64-bit};Uid=API;Pwd=API;";
        }
        //Almacenar en sist_api
        public int Guardar_SIS_API(string query)
        {
            int ultimo_movimiento = 0;
            cnn = new OdbcConnection();
            cnn.ConnectionString = connetionString;
            //Iniciando la transaccion
            cnn.Open();
            OdbcTransaction transaction;
            // Start a local transaction.
            transaction = cnn.BeginTransaction();

            try
            {

                //Grabando la cabecera de la factura
                OdbcCommand _cmd = cnn.CreateCommand();
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
    }
}
