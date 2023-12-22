using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppTipoCambio.Entidades
{
    public class clsTiposCambio
    {
        public clsConfig config { get; set; }
        public List<clsPeriod> periods { get; set; }
    }
}