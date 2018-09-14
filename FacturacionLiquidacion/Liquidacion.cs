using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace FacturacionLiquidacion
{
    class Liquidacion
    {
        DateTime fecha;
        String loteMBA;
        String piscina;
        String ciclo;
        String op;
        Double lbstotales;
        Double kgtotales;
        Int32 untotales;
        String empacadora;
        String especie;
        String tsiembra;
        String numeroliquidacion;
        IList<Guia> guias;

        public DateTime Fecha { get; set; }
        public string LoteMBA { get; set; }
        public string Op { get; set; }
        public double Lbstotales { get; set; }
        public double Kgtotales { get; set; }
        public int Untotales { get; set; }
        public string Empacadora { get; set; }
        public string Especie { get; set; }
        public string Tsiembra { get; set; }
        public string Numeroliquidacion { get; set; }
        public string Piscina { get; set; }
        public string Ciclo { get; set; }

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
                        lrow.numeroliquidacion = dr["Liquidacion"].ToString();
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
                        lrow.Kgtotales = grow.Kg;
                        lrow.Lbstotales = grow.Lbs;
                        lrow.Untotales = grow.Un;
                        lrow.guias = new List<Guia>();
                        lrow.guias.Add(grow);
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
                            lrow.numeroliquidacion = dr["Liquidacion"].ToString();
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
                            lrow.Kgtotales += grow.Kg;
                            lrow.Lbstotales += grow.Lbs;
                            lrow.Untotales += grow.Un;
                            lrow.guias = new List<Guia>();
                            lrow.guias.Add(grow);
                            tmp.Add(lrow);
                        }else
                        {
                            Guia grow = new Guia();
                            grow.Kg = Convert.ToDouble(dr["KG"]);
                            grow.Lbs = Convert.ToDouble(dr["LBS"]);
                            grow.Un = Convert.ToInt32(dr["UNIDAD"]);
                            grow.Numeroguia = dr["# Guia"].ToString();
                            grow.Responsable = dr["RESPON#"].ToString();
                            lrow.Kgtotales += grow.Kg;
                            lrow.Lbstotales += grow.Lbs;
                            lrow.Untotales += grow.Un;
                            //lrow.guias = new List<Guia>();
                            lrow.guias.Add(grow);                            
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
        Double lbs;
        Double kg;
        Int32 un;
        String responsable;

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
        double cantidad;
        double precio;
        
        public string CodProducto { get; set; }
        public string Detalle { get; set; }
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

