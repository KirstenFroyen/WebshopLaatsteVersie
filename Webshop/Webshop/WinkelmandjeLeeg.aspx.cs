using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Webshop.Business;

namespace Webshop
{
    public partial class WinkelmandjeLeeg : System.Web.UI.Page
    {

        Controller _cont = new Controller();
        protected void Page_Load(object sender, EventArgs e)
        {
            lblKlantNr.Text = _cont.laadKlant(Convert.ToInt32(Context.User.Identity.Name)).KlantNr.ToString();
            lblNaam.Text = _cont.laadKlant(Convert.ToInt32(Context.User.Identity.Name)).Voornaam + " " + _cont.laadKlant(Convert.ToInt32(Context.User.Identity.Name)).Naam;
            lblAdres.Text = _cont.laadKlant(Convert.ToInt32(Context.User.Identity.Name)).Adres.ToString();
            lblPC.Text = _cont.laadKlant(Convert.ToInt32(Context.User.Identity.Name)).PC.ToString();
            lblGemeente.Text = _cont.laadKlant(Convert.ToInt32(Context.User.Identity.Name)).Gemeente.ToString();
            lblDatum.Text = DateTime.Now.ToLongDateString();
        }

        protected void btnTerug_Click(object sender, EventArgs e)
        {
            Response.Redirect("default.aspx");
        }
    }
}