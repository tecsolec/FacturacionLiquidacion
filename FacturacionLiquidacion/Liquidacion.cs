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

        public DateTime Fecha { get => fecha; set => fecha = value; }
        public string LoteMBA { get => loteMBA; set => loteMBA = value; }
        public string Op { get => op; set => op = value; }
        public double Lbstotales { get => lbstotales; set => lbstotales = value; }
        public double Kgtotales { get => kgtotales; set => kgtotales = value; }
        public int Untotales { get => untotales; set => untotales = value; }
        public string Empacadora { get => empacadora; set => empacadora = value; }
        public string Especie { get => especie; set => especie = value; }
        public string Tsiembra { get => tsiembra; set => tsiembra = value; }
        public string Numeroliquidacion { get => numeroliquidacion; set => numeroliquidacion = value; }
        public string Piscina { get => piscina; set => piscina = value; }
        public string Ciclo { get => ciclo; set => ciclo = value; }

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

        public DateTime Fechaguia { get => fechaguia; set => fechaguia = value; }
        public string Numeroguia { get => numeroguia; set => numeroguia = value; }
        public double Lbs { get => lbs; set => lbs = value; }
        public double Kg { get => kg; set => kg = value; }
        public int Un { get => un; set => un = value; }
        public string Responsable { get => responsable; set => responsable = value; }
    }
    class Receta
    {
        String codProducto;
        String detalle;
        double cantidad;
        double precio;
        
        public string CodProducto { get => codProducto; set => codProducto = value; }
        public string Detalle { get => detalle; set => detalle = value; }
        public double Cantidad { get => cantidad; set => cantidad = value; }
        public double Precio { get => precio; set => precio = value; }

        public void GetReceta(DataSet ds)
        {
            //Receta tmp = new Receta();
            DataRow dr = ds.Tables[0].Rows[0];
            CodProducto = dr["codigo"].ToString();
            Detalle = dr["nombre"].ToString();
        }
    }
}

