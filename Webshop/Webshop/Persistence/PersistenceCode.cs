using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using Webshop.Business;
namespace Webshop.Persistence
{
    public class PersistenceCode
    {
        private string ConnStr = "server=localhost;user id=root; password=Test123; database=webshop";

        //1 product ophalen om te tonen bij toevoegen.aspx

        public Product getProduct(int id)
        {
            MySqlConnection conn = new MySqlConnection(ConnStr);
            conn.Open();
            string qry = "SELECT * FROM tblproduct WHERE ArtNr =" + id;
            MySqlCommand cmd = new MySqlCommand(qry, conn);
            MySqlDataReader dtr = cmd.ExecuteReader();
            Product product = new Product();
            while (dtr.Read())
            {
               
                product.ArtNr = Convert.ToInt32(dtr["ArtNr"]);
                product.Naam = dtr["Naam"].ToString();
                product.Foto = dtr["Foto"].ToString();
                product.Prijs = Convert.ToDouble(dtr["Prijs"]);
                product.Voorraad = Convert.ToInt32(dtr["Voorraad"]);

            }
            conn.Close();
            return product;
            
        }

        //Product uit het winkelmandje verwijderen

        public void deleteProduct(int id, int klantnummer)
        {
            MySqlConnection conn = new MySqlConnection(ConnStr);
            conn.Open();
            string qry = "DELETE FROM tblwinkelmandje WHERE ArtNr =" + id +" and KlantNr =" + klantnummer;
            MySqlCommand cmd = new MySqlCommand(qry, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        //Catologus ophalen om te tonen in een GridView

        public List<Product> loadProducts()
        {
            MySqlConnection conn = new MySqlConnection(ConnStr);
            conn.Open();
            string qry = "SELECT * FROM tblproduct";
            MySqlCommand cmd = new MySqlCommand(qry, conn);
            MySqlDataReader dtr = cmd.ExecuteReader();
            List<Product> _lijst = new List<Product>();
            while(dtr.Read())
            {
                Product prod = new Product();
                prod.ArtNr = Convert.ToInt32(dtr["ArtNr"]);
                prod.Naam = dtr["Naam"].ToString();
                prod.Foto = dtr["Foto"].ToString();
                prod.Prijs = Convert.ToDouble(dtr["Prijs"]);
                prod.Voorraad = Convert.ToInt32(dtr["Voorraad"]);
                _lijst.Add(prod);

            }conn.Close();
            return _lijst;
        }

        //Product toevoegen aan het winkelmandje

        public void insertCart(Winkelmandje winkelmandje)
        {
            MySqlConnection conn = new MySqlConnection(ConnStr);
            conn.Open();
            string qry = "INSERT INTO tblwinkelmandje(KlantNr,ArtNr, Aantal) VALUES ('" + winkelmandje.KlantNr + "','" + winkelmandje.ArtNr + "','" + winkelmandje.Aantal + "')";
            MySqlCommand cmd = new MySqlCommand(qry, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        //Winkelmandje ophalen aan de hand van een klantnummer

        public List<Winkelmandje> loadCart(int klantnr)
        {
            MySqlConnection conn = new MySqlConnection(ConnStr);
            conn.Open();
            string qry = "SELECT Foto, tblwinkelmandje.ArtNr, Naam, Aantal, Prijs, (Aantal * Prijs) as Totaal FROM tblwinkelmandje INNER JOIN " +
                "tblproduct ON tblwinkelmandje.ArtNr = tblproduct.ArtNr  WHERE KlantNr =" + klantnr + "  ORDER BY tblwinkelmandje.ArtNr";


            MySqlCommand cmd = new MySqlCommand(qry, conn);
            MySqlDataReader dtr = cmd.ExecuteReader();
            List<Winkelmandje> _lijst = new List<Winkelmandje>();
            while (dtr.Read())
            {
                Winkelmandje winkelmandje = new Winkelmandje();
                winkelmandje.Foto = dtr["Foto"].ToString();
                winkelmandje.ArtNr = Convert.ToInt32(dtr["ArtNr"]);
                winkelmandje.Naam = dtr["Naam"].ToString();
                winkelmandje.Aantal = Convert.ToInt32(dtr["Aantal"]);
                winkelmandje.Prijs = Convert.ToDouble(dtr["Prijs"]);
                winkelmandje.Totaal = Convert.ToDouble(dtr["Totaal"]);
                _lijst.Add(winkelmandje);
            }
            conn.Close();
            return _lijst;
        }

        //Voorraad updaten wanneer een product aan het winkelmandje wordt toegevoegd of verwijderd

        public void UpdateVoorraad(int id, int voorraad)
        {
            MySqlConnection conn = new MySqlConnection(ConnStr);
            conn.Open();
            string qry = "update tblproduct set voorraad = " + voorraad + " where artnr=" + id;
            MySqlCommand cmd = new MySqlCommand(qry, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        //Checken of het winkelmandje leeg is aan de hand van het klantnummer

        public bool CheckMandje(int klantnr)
        {
            MySqlConnection conn = new MySqlConnection(ConnStr);
            conn.Open();
            string qry = "select * from tblwinkelmandje where KlantNr = " + klantnr;
            MySqlCommand cmd = new MySqlCommand(qry, conn);
            MySqlDataReader dtr = cmd.ExecuteReader();
            bool isleeg;
            if (dtr.HasRows)
            {
                isleeg = false;
            }
            else
            {
                isleeg = true;
            }
            conn.Close();
            return isleeg;
        }

        //Gegevens van de klant die op dat moment aangemeld is, ophalen om te tonen bij het winkelmandje

        public Klant loadClient(int klantnr )
        {
            MySqlConnection conn = new MySqlConnection(ConnStr);
            conn.Open();
            string qry = "SELECT * FROM tblklant WHERE KlantNr =" + klantnr;
            MySqlCommand cmd = new MySqlCommand(qry, conn);
            MySqlDataReader dtr = cmd.ExecuteReader();
            Klant klant = new Klant();
            while(dtr.Read())
            {
                klant.KlantNr = Convert.ToInt32(dtr["KlantNr"]);
                klant.Voornaam = dtr["Voornaam"].ToString();
                klant.Naam = dtr["Naam"].ToString();
                klant.Adres = dtr["Adres"].ToString();
                klant.PC = dtr["PC"].ToString();
                klant.Gemeente = dtr["Gemeente"].ToString();


            }
            conn.Close();
            return klant;
        }

        //Een bestelling toevoegen aan de databank

        public void insertOrder(Bestelling order)
        {
            MySqlConnection conn = new MySqlConnection(ConnStr);
            conn.Open();
            string juistedatum = order.Datum.ToString("yyyy-MM-dd hh:mm:ss");
            string qry = "insert into tblbestelling(datum, klantnr) values ('" + juistedatum + "','" + order.KlantNr + "')";
            MySqlCommand cmd = new MySqlCommand(qry, conn);
            cmd.ExecuteNonQuery();
            conn.Close();

        }

        //De prijs van een beplaald product ophalen om mee op te slaan bij de bestellijn

        public double getHistprice(int artnr)
        {
            MySqlConnection conn = new MySqlConnection(ConnStr);
            conn.Open();
            string qry = "SELECT Prijs from tblproduct WHERE ArtNr = " + artnr;
            MySqlCommand cmd = new MySqlCommand(qry, conn);
            MySqlDataReader dtr = cmd.ExecuteReader();
            double prijs = 0;
            while (dtr.Read())
            {
              prijs = Convert.ToDouble(dtr["Prijs"]);
            }
            conn.Close();

            return prijs;

        }

        //Een bestellijn (meer informatie over de bestelling) opslaan in de databank

        public void insertOrderline(Bestellijn orderl)
        {
            MySqlConnection conn = new MySqlConnection(ConnStr);
            conn.Open();
            string JuistePrijs = orderl.HistPrijs.ToString().Replace(",", ".");
           
            string qry = "insert into tblbestellijn(OrderNr, ArtNr, Aantal, HistPrijs) values ('" + orderl.OrderNr + "','" + orderl.ArtikelNr + "','" + orderl.Aantal + "','"+JuistePrijs+"')";
            MySqlCommand cmd = new MySqlCommand(qry, conn);
            cmd.ExecuteNonQuery();
            conn.Close();

        }

        //Totaalprijs exclusief BTW, de BTW en de totaalprijs inclusief BTW berekenen in SQL

        public Totalen getTotals(int klnr)
        {
            MySqlConnection conn = new MySqlConnection(ConnStr);
            conn.Open();
            string qry = "SELECT SUM(Aantal * Prijs ) as TotExBtw, SUM((Aantal * Prijs) * 0.21) as Btw, SUM((Aantal * Prijs) * 1.21) as TotIncBtw FROM tblwinkelmandje INNER JOIN tblproduct on tblproduct.ArtNr = " +
                "tblwinkelmandje.ArtNr " +
                "WHERE KlantNr=" + klnr;
            MySqlCommand cmd = new MySqlCommand(qry, conn);
            MySqlDataReader dtr = cmd.ExecuteReader();
            Totalen tot = new Totalen();
            while (dtr.Read())
            {
                tot.TotExBtw = Convert.ToDouble(dtr["TotExBtw"]);
                tot.Btw = Convert.ToDouble(dtr["Btw"]);
                tot.TotIncBtw = Convert.ToDouble(dtr["TotIncBtw"]);
            }
            conn.Close();
            return tot;

        }

        //Ordernummer ophalen om door te geven wanneer er op de knop 'plaats bestelling' geklikt wordt

        public int getOrderNumber(DateTime Datum)
        {
            MySqlConnection conn = new MySqlConnection(ConnStr);
            conn.Open();
            string juistedatum = Datum.ToString("yyyy-MM-dd hh:mm:ss");
            string qry = "select ordernr from  tblbestelling where datum = '" + juistedatum+"'";
            MySqlCommand cmd = new MySqlCommand(qry, conn);
            int OrderNr = 0;
            MySqlDataReader dtr = cmd.ExecuteReader();
            while(dtr.Read())
            {
                 OrderNr = Convert.ToInt32(dtr["OrderNr"]);
            }
            conn.Close();
            return OrderNr;

        }

        //De voorraad ophalen om aan te passen

        public int getVoorraad(int Id)
        {
            MySqlConnection conn = new MySqlConnection(ConnStr);
            conn.Open();
            string qry = "select voorraad from tblproduct where ArtNr=" + Id;
            MySqlCommand cmd = new MySqlCommand(qry, conn);
            MySqlDataReader dtr = cmd.ExecuteReader();
            int voorraad = 0;
            while(dtr.Read())
            {
                voorraad = Convert.ToInt32(dtr["Voorraad"]);
            }
            conn.Close();
            return voorraad;
        }

        //E-mail adres ophalen van de klant die op dat moment aangemeld is om een bevestigingsmail te verzenden

        public string getEmail(int klantnr)
        {
            MySqlConnection conn = new MySqlConnection(ConnStr);
            conn.Open();
            string qry = "SELECT Mail FROM tblklant WHERE KlantNr =" + klantnr;
            MySqlCommand cmd = new MySqlCommand(qry, conn);
            MySqlDataReader dtr = cmd.ExecuteReader();
            string Mail = "";
            while(dtr.Read())
            {
                Mail = dtr["Mail"].ToString();

            }
            conn.Close();
            return Mail;
        }

        //Checken of de aanmeldgegevens kloppen

        public bool checkCredentials(string GebrNaam, string Wachtwoord)
        {
            MySqlConnection conn = new MySqlConnection(ConnStr);
            conn.Open();
            string qry = "SELECT * FROM tblklant WHERE GebruikersNaam= '" + GebrNaam + "' and binary Wachtwoord='" + Wachtwoord + "'";
            MySqlCommand cmd = new MySqlCommand(qry, conn);
            MySqlDataReader dtr = cmd.ExecuteReader();
            bool flag;
            if (dtr.HasRows)
            {
                flag = true;
            }
            else
            {
                flag = false;
            }
            conn.Close();
            return flag;
        }

        //Klantnummer ophalen om in een sessie variabele overal te gebruiken

        public int getClientId(string gebrnaam)
        {
            MySqlConnection conn = new MySqlConnection(ConnStr);
            conn.Open();
            string qry = "SELECT KlantNr FROM tblklant WHERE GebruikersNaam= '" + gebrnaam +"'";
            MySqlCommand cmd = new MySqlCommand(qry, conn);
            MySqlDataReader dtr = cmd.ExecuteReader();
            int klantnr = 0;
            while (dtr.Read())
            {
                klantnr = Convert.ToInt32(dtr["KlantNr"]);
            }
            conn.Close();
            return klantnr;
        }


    }
}