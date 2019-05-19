using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Net.Mail;
using Webshop.Business;
using System.Net;

namespace Webshop
{
    public partial class winkelmandje : System.Web.UI.Page
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

            gvMandje.DataSource = _cont.haalMandjeOp(Convert.ToInt32(Context.User.Identity.Name));
            gvMandje.DataBind();

            lblTotExBtw.Text = "€ " + Math.Round(_cont.Haaltotalenop(Convert.ToInt32(Context.User.Identity.Name)).TotExBtw,2);
            lblBtw.Text = "€ " + Math.Round(_cont.Haaltotalenop(Convert.ToInt32(Context.User.Identity.Name)).Btw, 2);
            lblTotIncBtw.Text = "€ " + Math.Round(_cont.Haaltotalenop(Convert.ToInt32(Context.User.Identity.Name)).TotIncBtw, 2);
            Session["totaal"] = Math.Round(_cont.Haaltotalenop(Convert.ToInt32(Context.User.Identity.Name)).TotIncBtw, 2);


        }
        protected void gvMandje_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            int NieuweVoorraad = _cont.Haalvoorraadop(Convert.ToInt32(gvMandje.SelectedRow.Cells[2].Text))+ Convert.ToInt32(gvMandje.SelectedRow.Cells[4].Text);
            _cont.PasVoorraadAan(Convert.ToInt32(gvMandje.SelectedRow.Cells[2].Text), NieuweVoorraad);
            _cont.verwijderProduct(Convert.ToInt32(gvMandje.SelectedRow.Cells[2].Text), Convert.ToInt32(Context.User.Identity.Name));

            if (_cont.mandjeChecken(Convert.ToInt32(Context.User.Identity.Name)))
            {
                Response.Redirect("WinkelmandjeLeeg.aspx");
            }
            else
            {
                gvMandje.DataSource = _cont.haalMandjeOp(Convert.ToInt32(Context.User.Identity.Name));
                gvMandje.DataBind();

                lblTotExBtw.Text = "€ " + Math.Round(_cont.Haaltotalenop(Convert.ToInt32(Context.User.Identity.Name)).TotExBtw, 2);
                lblBtw.Text = "€ " + Math.Round(_cont.Haaltotalenop(Convert.ToInt32(Context.User.Identity.Name)).Btw, 2);
                lblTotIncBtw.Text = "€ " + Math.Round(_cont.Haaltotalenop(Convert.ToInt32(Context.User.Identity.Name)).TotIncBtw, 2);
                Session["totaal"] = Math.Round(_cont.Haaltotalenop(Convert.ToInt32(Context.User.Identity.Name)).TotIncBtw, 2);
            }
        }

        protected void btnBestellen_Click(object sender, EventArgs e)
        {
            // Email versturen met bevestiging 


            // Bestelling opslaan in de databank 

            _cont.slaBestellingOp(DateTime.Now, Convert.ToInt32(Context.User.Identity.Name));
            for ( int i = 0; i< gvMandje.Rows.Count; i++)
            {
               
                _cont.slaBestellijnOp(_cont.haalOrderNrOp(DateTime.Now), Convert.ToInt32(gvMandje.Rows[i].Cells[2].Text), Convert.ToInt32(gvMandje.Rows[i].Cells[4].Text), _cont.haalPrijsOp(Convert.ToInt32(gvMandje.Rows[i].Cells[2].Text)));

                _cont.verwijderProduct(Convert.ToInt32(gvMandje.Rows[i].Cells[2].Text), Convert.ToInt32(Context.User.Identity.Name));
            }
            Session["ordernr"] = _cont.haalOrderNrOp(DateTime.Now);

            

            MailMessage mm = new MailMessage();
            mm.From = new MailAddress("aestheticbeast345@gmail.com");
            mm.To.Add(_cont.haalMailOp(Convert.ToInt32(Context.User.Identity.Name)));
            mm.Subject = "Bevestiging order Online GPU-Shop";
            AlternateView imgView = AlternateView.CreateAlternateViewFromString("Uw bestelling met ordernummer " + _cont.haalOrderNrOp(DateTime.Now) + " werd door ons goed ontvangen. "+
                "<br/>" +"Na betaling van € "+ Session["totaal"]+ " op rekeningnummer BE91 5612 1236 7895 zullen wij overgaan tot de verzending van de grafische kaart(en)." +
              "<br/>" + "Gelieve het ordernummer als betalingsreferentie mee te geven. " +
              "<br/>"+ "Bedankt voor uw vertrouwen! " + "<br/><img src=cid:imgpath height=250 width=250>", null, "text/html");
            LinkedResource lr = new LinkedResource("C:/Users/Kirsten Froyen/Desktop/WebshopLaatsteVersie/Webshop/Images/MailBevestiging.png");
            lr.ContentId = "imgpath";
            imgView.LinkedResources.Add(lr);
            mm.AlternateViews.Add(imgView);
            mm.Body = lr.ContentId;
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.EnableSsl = true;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential("aestheticbeast345@gmail.com", "27017878389653Gg");
            smtp.Send(mm);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Email succesvol verstuurd !');", true);


            Response.Redirect("bestelbevestiging.aspx");
  

        }

        protected void btnTerug_Click(object sender, EventArgs e)
        {
            Response.Redirect("default.aspx");
        }
    }
}