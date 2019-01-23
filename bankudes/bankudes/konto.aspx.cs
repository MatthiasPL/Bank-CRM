using bankudes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace bankudes
{
    public partial class konto : System.Web.UI.Page
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
                daneOsobowe.InnerHtml = bd.pobierzDaneOsobowe(Session["login"].ToString());
            }
        }
    }
}