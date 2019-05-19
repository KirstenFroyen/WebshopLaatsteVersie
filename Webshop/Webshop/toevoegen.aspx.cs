using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Webshop.Business;
namespace Webshop
{
    public partial class toevoegen : System.Web.UI.Page
    {
        Controller _cont = new Controller();
        protected void Page_Load(object sender, EventArgs e)
        {
            imgFoto.ImageUrl = _cont.laadArtikel(Convert.ToInt32(Session["ArtNr"])).Foto;
            lblArtNr.Text = Session["ArtNr"].ToString();
            lblNaam.Text = _cont.laadArtikel(Convert.ToInt32(Session["ArtNr"])).Naam;
            lblPrijs.Text = " € "+_cont.laadArtikel(Convert.ToInt32(Session["ArtNr"])).Prijs.ToString();
            lblVoorraad.Text = _cont.laadArtikel(Convert.ToInt32(Session["ArtNr"])).Voorraad.ToString();
        }

        protected void btnToevoegenAanMand_Click(object sender, EventArgs e)
        {
            int Getal;

            if (int.TryParse(txtbAantal.Text, out Getal) && Getal > 0)
            {
               

                if (Convert.ToInt32(txtbAantal.Text) > _cont.laadArtikel(Convert.ToInt32(Session["ArtNr"])).Voorraad)
                {
                    lblWaarschuwing.Text = "Voorraad is ontoereikend! ";
           
                }
                else
                {
                    try
                    {
                        int NieuweVoorraad = _cont.laadArtikel(Convert.ToInt32(Session["ArtNr"])).Voorraad - Convert.ToInt32(txtbAantal.Text);
                        _cont.voegProductAanMandjeToe(Convert.ToInt32(Context.User.Identity.Name), _cont.laadArtikel(Convert.ToInt32(Session["ArtNr"])).ArtNr, Convert.ToInt32(txtbAantal.Text));
                        _cont.PasVoorraadAan(Convert.ToInt32(Session["ArtNr"]), NieuweVoorraad);
                   
                        Response.Redirect("winkelmandje.aspx");
                    }
                    catch
                    {
                        lblWaarschuwing.Text = "Dit product zit al in het mandje. Als u het aantal wil wijzigen, verwijder het dan uit het mandje en voeg het correcte aantal toe.";
                    }
                
                }

            }
            else
            {
                lblWaarschuwing.Text = "Vul een geldig getal in bij het gewenste aantal artikelen!";
            }

        }

        protected void btnTerug_Click(object sender, EventArgs e)
        {
            Response.Redirect("default.aspx");
        }
    }
}