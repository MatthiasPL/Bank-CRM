using bankudes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace bankudes
{
    public partial class kredyt : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BazaDanych bd = new BazaDanych();
            NowyKredyt.Visible = false;
            if(bd.PobierzUprawnienia(Session["login"].ToString())==false)
            {
                bZatwierdz.Visible = false;
                bUsun.Visible = false;
                bd.pobierzKredytUz(Session["login"].ToString());
            }
                
        }

        protected void bKredytOn_Click(object sender, EventArgs e)
        {
            NowyKredyt.Visible = true;
        }
    }
}