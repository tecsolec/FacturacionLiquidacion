using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FacturacionLiquidacion
{
    class Camaron
    {
        Tipo tipo;
        public Camaron()
        {
            tipo = new Tipo();
        }
    }
    class Especies
    {

    }
    class Tipo
    {
        public string codigo { get; set; }
        public string descripcion { get; set; }
        public Tipo()
        {
            codigo = "";
            descripcion = "";
        }
    }
}
