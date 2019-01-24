using bankudes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace bankudes
{
    public partial class wymiana : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ostrzezenie.Visible = false;
            BazaDanych bd = new BazaDanych();
            if (string.IsNullOrEmpty(Session["login"] as string))
            {
                Response.Redirect("default.aspx");
            }
            if (!IsPostBack)
            {
                ddKontaUz.DataSource = bd.pobierzKontaNiezerowe(Session["login"].ToString());
                ddKontaUz.DataBind();
                //ddKonta.Items.AddRange(bd.zaladujCheckBoxy());
                ddKontaUz2.DataSource = bd.pobierzKonta(Session["login"].ToString());
                ddKontaUz2.DataBind();
                //ddWaluty.Items.Add(bd.zaladujWaluty());
            }
        }

        string selectedKonto1 = "1", selectedKonto2 = "1";


        protected void ddKontaUz_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedKonto1 = (ddKontaUz.SelectedIndex + 1).ToString();
        }

        protected void ddKontaUz2_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedKonto2 = (ddKontaUz2.SelectedIndex + 1).ToString();
        }

        protected void logout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("default.aspx");
        }

        protected void bTransfer_Click(object sender, EventArgs e)
        {
            BazaDanych bd = new BazaDanych();
            string selval1 = ddKontaUz.Items[0].Value, selval2 = ddKontaUz2.Items[0].Value;
            selval1 = ddKontaUz.SelectedValue;
            selval2 = ddKontaUz2.SelectedValue;
            if (selval1 == selval2)
            {
                ostrzezenie.InnerHtml = "<strong>Nie wybrano dwóch różnych kont</strong>";
                ostrzezenie.Visible = true;
            }

            string i = TbKwota.Text;
            if (i == "")
                ostrzezenie.InnerHtml = "<strong>Nie wprowadzono kwoty</strong>";
            double kwota;
            bool success = Double.TryParse(i, out kwota);
            if (success)
            {
                string skrot1 = selval1.Substring(selval1.Length - 3, 3);
                string skrot2 = selval2.Substring(selval2.Length - 3, 3);
                double koszt;
                double wynik;
                if (skrot1 == skrot2)
                {
                    wynik = kwota;
                }
                if (skrot1 == "PLN")
                {
                    koszt = Double.Parse(bd.pobierzSprzedazWaluty(skrot2));
                    wynik = kwota * koszt;
                }
                if (skrot2 == "PLN")
                {
                    koszt = Double.Parse(bd.pobierzKupnoWaluty(skrot1));
                    wynik = kwota * koszt;
                }
                else
                {
                    koszt = Double.Parse(bd.pobierzKupnoWaluty(skrot1));
                    wynik = kwota * koszt;
                    koszt = Double.Parse(bd.pobierzSprzedazWaluty(skrot2));
                    wynik = wynik * koszt;
                }
                string klient_id = bd.pobierzIdKlienta(Session["login"].ToString());
                List<string> kontaUzID = bd.pobierzIDKontNiezerowych(klient_id);
                Console.WriteLine(selectedKonto1);
                string konto_id = kontaUzID[Int32.Parse(selectedKonto1) - 1];
                double saldo = bd.pobierzSaldo(konto_id);
                bd.Przelew(-wynik, saldo, konto_id);

                Console.WriteLine(selectedKonto2);
                kontaUzID = bd.pobierzIdKont(klient_id);
                konto_id = kontaUzID[Int32.Parse(selectedKonto2) - 1];
                saldo = bd.pobierzSaldo(konto_id);
                bd.Przelew(wynik, saldo, konto_id);

                Response.Redirect(Request.RawUrl);
            }
            else
            {
                ostrzezenie.InnerHtml = "<strong>Niepoprawny format liczby</strong>";
            }
        }
    }
}