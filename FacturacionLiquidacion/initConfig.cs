using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;

namespace FacturacionLiquidacion
{
    class initConfig
    {
        public initConfig() { 
            CultureInfo ci = CultureInfo.InstalledUICulture;
            CultureInfo Cultura = new CultureInfo("es-US");
            Thread.CurrentThread.CurrentCulture = Cultura;
            Thread.CurrentThread.CurrentUICulture = Cultura;
        }
    }
}
