using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace FacturacionLiquidacion
{
    public class Liquidacion
    {
        DateTime fecha;
        String loteMBA;
        String piscina;
        String ciclo;
        String op;
        Double lbstotales;
        Double kgtotales;
        double entero;
        double sobre_cc;
        double cola;
        double basura;
        double diferencia;
        Int32 untotales;
        String empacadora;
        String especie;
        String tsiembra;
        String numeroliquidacion;
        IList<Guia> guias;
        IList<Receta> recetas;

        public DateTime Fecha { get; set; }

        public string LoteMBA { get; set; }


        public string Piscina { get; set; }

        public string Ciclo { get; set; }

        public string Op { get; set; }

        public double Lbstotales { get; set; }

        public double Entero { get; set; }

        public double Sobre_Cc { get; set; }

        public double Cola { get; set; }

        public double Basura { get; set; }

        public double Diferencia { get; set; }

        public double Kgtotales { get; set; }

        public int Untotales { get; set; }

        public string Empacadora { get; set; }

        public string Especie { get; set; }

        public string Tsiembra { get; set; }

        public string Numeroliquidacion { get; set; }

        internal IList<Guia> Guias { get; set; }


        internal IList<Receta> Recetas { get; set; }


        public IList<Liquidacion> FillList(DataSet guias)
        {
            IList<Liquidacion> tmp=new List<Liquidacion>();

            foreach (DataRow dr in guias.Tables[0].Rows)
            {
                if(dr["Liquidacion"]!=DBNull.Value)
                {
                    if (tmp.Count == 0)
                    {
                        Liquidacion lrow = new Liquidacion();
                        lrow.Fecha = Convert.ToDateTime(dr["FECHA"].ToString());
                        lrow.LoteMBA = dr["Lote MBA"].ToString();
                        lrow.Op = dr["OP"].ToString();
                        lrow.Numeroliquidacion = dr["Liquidacion"].ToString();
                        lrow.Empacadora = dr["EMPACADORA"].ToString();
                        lrow.Especie = dr["Especie"].ToString();
                        lrow.Tsiembra = dr["T# Siem"].ToString();
                        lrow.Piscina = dr["PISC"].ToString();
                        lrow.Ciclo = dr["CICLO"].ToString();
                        Guia grow = new Guia();
                        grow.Kg = Convert.ToDouble(dr["KG"]);
                        grow.Lbs = Convert.ToDouble(dr["LBS"]);
                        grow.Un = Convert.ToInt32(dr["UNIDAD"]);
                        grow.Numeroguia = dr["# Guia"].ToString();
                        grow.Responsable = dr["RESPON#"].ToString();
                        grow.Piscina = dr["PISC"].ToString();
                        grow.Ciclo = dr["CICLO"].ToString();
                        grow.Empacadora = dr["EMPACADORA"].ToString();
                        grow.Fechaguia = Convert.ToDateTime(dr["FECHA"].ToString());
                        lrow.Kgtotales = grow.Kg;
                        lrow.Lbstotales = grow.Lbs;
                        lrow.Untotales = grow.Un;
                        lrow.Guias = new List<Guia>();
                        lrow.Recetas = new List<Receta>();
                        lrow.Guias.Add(grow);
                        tmp.Add(lrow);
                    } else
                    {
                        Liquidacion lrow = tmp.Where(l => l.Numeroliquidacion == dr["Liquidacion"].ToString()).FirstOrDefault();
                        if (lrow == null)
                        {
                            lrow = new Liquidacion();
                            lrow.Fecha = Convert.ToDateTime(dr["FECHA"].ToString());
                            lrow.LoteMBA = dr["Lote MBA"].ToString();
                            lrow.Op = dr["OP"].ToString();
                            lrow.Numeroliquidacion = dr["Liquidacion"].ToString();
                            lrow.Empacadora = dr["EMPACADORA"].ToString();
                            lrow.Especie = dr["Especie"].ToString();
                            lrow.Tsiembra = dr["T# Siem"].ToString();
                            lrow.Piscina = dr["PISC"].ToString();
                            lrow.Ciclo = dr["CICLO"].ToString();
                            Guia grow = new Guia();
                            grow.Kg = Convert.ToDouble(dr["KG"]);
                            grow.Lbs = Convert.ToDouble(dr["LBS"]);
                            grow.Un = Convert.ToInt32(dr["UNIDAD"]);
                            grow.Numeroguia = dr["# Guia"].ToString();
                            grow.Responsable = dr["RESPON#"].ToString();
                            grow.Piscina = dr["PISC"].ToString();
                            grow.Ciclo = dr["CICLO"].ToString();
                            grow.Empacadora = dr["EMPACADORA"].ToString();
                            grow.Fechaguia = Convert.ToDateTime(dr["FECHA"].ToString());
                            lrow.Kgtotales += grow.Kg;
                            lrow.Lbstotales += grow.Lbs;
                            lrow.Untotales += grow.Un;
                            lrow.Guias = new List<Guia>();
                            lrow.Recetas = new List<Receta>();
                            lrow.Guias.Add(grow);
                            tmp.Add(lrow);
                        }else
                        {
                            Guia grow = new Guia();
                            grow.Kg = Convert.ToDouble(dr["KG"]);
                            grow.Lbs = Convert.ToDouble(dr["LBS"]);
                            grow.Un = Convert.ToInt32(dr["UNIDAD"]);
                            grow.Numeroguia = dr["# Guia"].ToString();
                            grow.Responsable = dr["RESPON#"].ToString();
                            grow.Piscina = dr["PISC"].ToString();
                            grow.Ciclo = dr["CICLO"].ToString();
                            grow.Empacadora = dr["EMPACADORA"].ToString();
                            grow.Fechaguia = Convert.ToDateTime(dr["FECHA"].ToString());
                            lrow.Kgtotales += grow.Kg;
                            lrow.Lbstotales += grow.Lbs;
                            lrow.Untotales += grow.Un;
                            //lrow.guias = new List<Guia>();
                            lrow.Guias.Add(grow);                            
                            //tmp.Add(lrow);
                        }
                    }
                }
            }
                return tmp;
        }
    }

    class Guia
    {
        DateTime fechaguia;
        String numeroguia;
        string piscina;
        string ciclo;
        string empacadora;
        Double lbs;
        Double kg;
        Int32 un;
        String responsable;
        int liquidacion;
        int estado_guia;

        public string Piscina { get; set; }

        public string Ciclo { get; set; }
        public string Empacadora { get; set; }

        public int Liquidacion { get; set; }

        public int Estado_Guia { get; set; }

        public DateTime Fechaguia { get; set; }

        public string Numeroguia { get; set; }

        public double Lbs { get; set; }


        public double Kg { get; set; }

        public int Un { get; set; }

        public string Responsable { get; set; }
    }



    class Receta
    {
        String codProducto;
        String detalle;
        string tipo;
        string talla;
        string clase;
        double cantidad;
        double precio;


        public int numer_factura { get; set; }

        public string CodProducto { get; set; }

        public string Detalle { get; set; }

        public string Clase { get; set; }

        public string Tipo { get; set; }

        public string Talla { get; set; }

        public double Cantidad { get; set; }

        public double Precio { get; set; }

        public void GetReceta(DataSet ds)
        {
            //Receta tmp = new Receta();
            DataRow dr = ds.Tables[0].Rows[0];
            CodProducto = dr["codigo"].ToString();
            Detalle = dr["nombre"].ToString();
        }
    }
}

