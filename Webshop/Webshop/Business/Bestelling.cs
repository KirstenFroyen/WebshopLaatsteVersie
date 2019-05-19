using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Webshop.Business
{
    public class Bestelling
    {
        public int OrderNr { get; set; }
        public DateTime Datum { get; set; }
        public int KlantNr { get; set; }
       
    }
}