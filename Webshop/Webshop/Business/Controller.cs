using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Webshop.Persistence;
namespace Webshop.Business
{
    public class Controller
    {
        //

        PersistenceCode persistence = new PersistenceCode();
        Winkelmandje winkelmandje = new Winkelmandje();
        Bestelling bestelling = new Bestelling();
        Bestellijn bestellijn = new Bestellijn();

        //

       public List<Product> haalProductenOp()
        {
            return persistence.loadProducts();
        }

        //

        public void voegProductAanMandjeToe(int klantnr, int artnr, int aantal )
        {
            winkelmandje.KlantNr = klantnr;
            winkelmandje.ArtNr = artnr;
            winkelmandje.Aantal = aantal;

            persistence.insertCart(winkelmandje);
           
            
        }

        public List<Winkelmandje> haalMandjeOp(int KN)
        {
            return persistence.loadCart(KN);
        }

        //

        public Product laadArtikel(int id )
        {
            return persistence.getProduct(id);
        }

        //

        public void verwijderProduct(int id , int klantnr)
        {
            persistence.deleteProduct(id, klantnr);
        }

        //
       
        public void PasVoorraadAan(int id, int voorraad)
        {
            persistence.UpdateVoorraad(id, voorraad);
        }

        //

        public bool mandjeChecken(int klantnr)
        {
            return persistence.CheckMandje(klantnr);
        }

        //

        public Klant laadKlant(int id)
        {
            return persistence.loadClient(id);
        }

        //

        public void slaBestellingOp( DateTime datum, int klantnr )
        {
          
            bestelling.Datum = datum;
            bestelling.KlantNr = klantnr;
           

            persistence.insertOrder(bestelling);
        }

        //

        public void slaBestellijnOp(int ordernr, int artnr, int aantal, double histprijs)
        {
            bestellijn.OrderNr = ordernr;
            bestellijn.ArtikelNr = artnr;
            bestellijn.Aantal = aantal;
            bestellijn.HistPrijs = histprijs;

            persistence.insertOrderline(bestellijn);
        }

        //

        public double haalPrijsOp(int artnr)
        {
            return persistence.getHistprice(artnr);
        }

        //

        public Totalen Haaltotalenop(int klnr)
            {
            return persistence.getTotals(klnr);
        }

        //

        public int haalOrderNrOp(DateTime datum)
        {
            return persistence.getOrderNumber(datum);

        }

        //

        public int Haalvoorraadop(int id)
        {
            return persistence.getVoorraad(id);
        }

        //

        public string haalMailOp(int klantnr)
        {
            return persistence.getEmail(klantnr);
        }

        //

        public bool controleerAanmeldgegevens(string gebrnaam, string ww)
        {
            return persistence.checkCredentials(gebrnaam, ww);
        }

        //

        public int haalKlantNrOp(string gebrnaam)
        {
            return persistence.getClientId(gebrnaam);
        }

    }
}