using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Webshop.Business
{
    public class Winkelmandje
    {
        public int KlantNr { get; set; }
        public int ArtNr { get; set; }
        public int Aantal { get; set; }
        public string Foto { get; set; }
        public string Naam { get; set; }
        public double  Prijs { get; set; }
        public double Totaal { get; set; }
    }
}