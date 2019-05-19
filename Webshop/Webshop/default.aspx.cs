using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Webshop.Business;
namespace Webshop
{
    public partial class _default : System.Web.UI.Page
    {
        Controller _cont = new Controller();
        protected void Page_Load(object sender, EventArgs e)
        {
            gvProducten.DataSource = _cont.haalProductenOp();
            gvProducten.DataBind();

            for(int i = 0; i<gvProducten.Rows.Count; i++)
            {
                
                    if (Convert.ToInt32(gvProducten.Rows[i].Cells[4].Text) == 0)
                    {
                        gvProducten.Rows[i].Cells[5].Text = "Niet op voorraad";
                        gvProducten.Rows[i].Cells[5].Enabled = false;
                    }
            }
        }

        protected void gvProducten_SelectedIndexChanged(object sender, EventArgs e)
        {

            Session["ArtNr"] = gvProducten.SelectedRow.Cells[0].Text;

            Response.Redirect("toevoegen.aspx");
        }

        protected void btnWinkelmandje_Click(object sender, EventArgs e)
        {
            if (_cont.mandjeChecken(Convert.ToInt32(Context.User.Identity.Name)) == false)
            {
                Response.Redirect("winkelmandje.aspx");
            }
            else
            {
                Response.Redirect("WinkelmandjeLeeg.aspx");
            }
        }
    }
}