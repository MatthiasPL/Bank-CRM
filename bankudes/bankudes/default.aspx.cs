using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SQLite;
using bankudes.Models;

namespace bankudes
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            errorBox.Visible = false;
        }

        protected void buttonLogin_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Session["login"] as string))
            {
                Response.Redirect("home.aspx");
            }
            BazaDanych bd = new BazaDanych();
            if(bd.sprawdzCzyLoginHasloPoprawne(login.Text, haslo.Text))
            {
                Session["login"] = login.Text;
                Response.Redirect("home.aspx");
            }
            else
            {
                errorBox.Visible = true;
            }
        }
    }
}