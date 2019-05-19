using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Webshop.Business
{
    public class Klant
    {
        public int KlantNr { get; set; }
        public string  Naam { get; set; }
        public string Voornaam { get; set; }
        public string Adres { get; set; }
        public string PC { get; set; }
        public string Gemeente { get; set; }
        public string Mail { get; set; }
        public string GebrNaam { get; set; }
        public string Wachtwoord { get; set; }
    }
}