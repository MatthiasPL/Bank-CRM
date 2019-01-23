using bankudes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace bankudes
{
    public partial class home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BazaDanych bd = new BazaDanych();
            if (string.IsNullOrEmpty(Session["login"] as string))
            {
                Response.Redirect("default.aspx");
            }
            else
            {
                //bd.dodajWalute("cos", "COS", 12.00, 11.98);
                powitanie.InnerHtml = "Witaj, " + bd.pobierzImie(Session["login"].ToString());
            }
        }

        protected void logout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("default.aspx");
        }

        protected void bKonto_Click(object sender, EventArgs e)
        {
            Response.Redirect("nowekonto.aspx");
        }

        protected void bWymiana_Click(object sender, EventArgs e)
        {
            Response.Redirect("wymiana.aspx");
        }
    }
}