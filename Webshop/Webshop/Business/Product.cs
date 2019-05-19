using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Webshop.Business
{
    public class Product
    {
        public int ArtNr { get; set; }
        public string  Naam { get; set; }
        public string Foto { get; set; }
        public double Prijs { get; set; }
        public int Voorraad { get; set; }
    }
}