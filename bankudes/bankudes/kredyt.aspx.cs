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
                
                if (!IsPostBack)
                {
                    ddKredyty.DataSource = bd.pobierzKredytUz(Session["login"].ToString());
                    ddKredyty.DataBind();
                }
            }
            if(bd.PobierzUprawnienia(Session["login"].ToString()) == true)
            {
                bKredytOn.Visible = false;

                if (!IsPostBack)
                {
                    ddKredyty.DataSource = bd.pobierzKredyty();
                    ddKredyty.DataBind();
                }
            }

        }

        protected void bKredytOn_Click(object sender, EventArgs e)
        {
            BazaDanych bd = new BazaDanych();
            NowyKredyt.Visible = true;
            //if (!IsPostBack)
            //{
                ddKonta.DataSource = bd.pobierzKonta(Session["login"].ToString());
                ddKonta.DataBind();
            //}
        }

        string selectedKonto = "1";



        protected void bPozycz_Click(object sender, EventArgs e)
        {
            BazaDanych bd = new BazaDanych();
            string i = tbKwota.Text;
            if (i == "") ;
                //ostrzezenie.InnerHtml = "<strong>Nie wprowadzono kwoty</strong>";
            double kwota;
            bool success = Double.TryParse(i, out kwota);
            if (success)
            {
                
                string klient_id = bd.pobierzIdKlienta(Session["login"].ToString());
                List<string> kontaUzID = bd.pobierzIdKont(klient_id);
                Console.WriteLine(selectedKonto);
                string konto_id = kontaUzID[Int32.Parse(selectedKonto) - 1];
                double saldo = bd.pobierzSaldo(konto_id);
                bd.Przelew(kwota, saldo, konto_id);
                bd.dodajKredyt(konto_id, kwota);
                //insert w kredytach

                Response.Redirect(Request.RawUrl);
            }
            else
            {
                //ostrzezenie.InnerHtml = "<strong>Niepoprawny format liczby</strong>";
            }
        

    }

        protected void ddKonta_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedKonto = (ddKonta.SelectedIndex + 1).ToString();
        }

        protected void bZatwierdz_Click(object sender, EventArgs e)
        {
            BazaDanych bd = new BazaDanych();
            string selval = ddKredyty.Items[0].Value;
            selval = ddKredyty.SelectedValue;
            //string klient_id = bd.pobierzIdKlienta(Session["login"].ToString());
            //List<string> kontaUzID = bd.pobierzIdKont(klient_id);
            //Console.WriteLine(selectedKonto);
            string konto_id = selval.Substring(3,2);
            Console.WriteLine(konto_id);
            bd.ZatwierdzKredyt(konto_id);

            Response.Redirect(Request.RawUrl);
        }

        protected void bUsun_Click(object sender, EventArgs e)
        {
            BazaDanych bd = new BazaDanych();
            string selval = ddKredyty.Items[0].Value;
            selval = ddKredyty.SelectedValue;
            //string klient_id = bd.pobierzIdKlienta(Session["login"].ToString());
            //List<string> kontaUzID = bd.pobierzIdKont(klient_id);
            //Console.WriteLine(selectedKonto);
            string konto_id = selval.Substring(0, 1);
            Console.WriteLine(konto_id);
            bd.UsunKredyt(konto_id);

            Response.Redirect(Request.RawUrl);
        }

        protected void logout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("default.aspx");
        }
    }
}