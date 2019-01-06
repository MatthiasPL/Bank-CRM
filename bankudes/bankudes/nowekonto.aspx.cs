using bankudes.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SQLite;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace bankudes
{
    public partial class profil : System.Web.UI.Page
    {
        string selectedwalutaid = "-1";
        string selectedkontoid = "-1";

        protected void Page_Load(object sender, EventArgs e)
        {
            ostrzezenie.Visible = false;
            BazaDanych bd = new BazaDanych();
            if (string.IsNullOrEmpty(Session["login"] as string))
            {
                Response.Redirect("default.aspx");
            }
            else
            {

            }
        }

        protected void bDodaj_Click(object sender, EventArgs e)
        {
            //bDodaj.Text = RadioButtonListWaluty.SelectedIndex.ToString();

            string selectedWaluta = "", selectedKonta = "";

            if (RadioButtonListWaluty.SelectedIndex > -1)
            {
                
            }
            else
            {
                ostrzezenie.InnerHtml += "<strong>Nie wybrano rodzaju konta</strong>";
            }
            if(RadioButtonListKonta.SelectedIndex > -1)
            {

            }
            else
            {
                ostrzezenie.InnerHtml += "<strong>Nie wybrano waluty</strong>";
            }
            //if(RadioButtonListWaluty.SelectedIndex > -1 && RadioButtonListKonta.SelectedIndex > -1)
            //{
            BazaDanych bd = new BazaDanych();
            bd.dodajKonto("1", "1", "1");
                //bd.dodajKonto(bd.pobierzIdKlienta(Session["login"].ToString()), (RadioButtonListKonta.SelectedIndex+1).ToString(), (RadioButtonListWaluty.SelectedIndex + 1).ToString());
            //}
        }
    }
}