using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Webshop
{
    public partial class bestelbevestiging : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblOrderNr.Text = Convert.ToInt32(Session["ordernr"]).ToString();
            lblTotaal.Text = "€ " + Convert.ToDouble(Session["totaal"]);

        }

        protected void btnTerugNaarCath_Click(object sender, EventArgs e)
        {
            Response.Redirect("default.aspx");
        }
    }
}