using bankudes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace bankudes
{
    public partial class register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Session["login"] as string))
            {
                Response.Redirect("home.aspx");
            }
            errorBox.Visible = false;
        }

        protected void registerbutton_Click(object sender, EventArgs e)
        {
            BazaDanych bd = new BazaDanych();
            if(bd.dodajKlienta(imie.Text, nazwisko.Text, pesel.Text, miasto.Text, ulica.Text, numer_domu.Text, numer_telefonu.Text, login.Text, haslo.Text) == true)
            {
                ClearTextBoxes(form1);
            }
            else
            {
                errorBox.InnerHtml = "<button type=\"button\" class=\"close\" data-dismiss=\"alert\">×</button> <strong>Błąd przy rejestracji!</strong>";
                errorBox.Visible = true;
            }

        }

        protected void ClearTextBoxes(Control p1)
        {
            foreach (Control ctrl in p1.Controls)
            {
                if (ctrl is TextBox)
                {
                    TextBox t = ctrl as TextBox;

                    if (t != null)
                    {
                        t.Text = String.Empty;
                    }
                }
                else
                {
                    if (ctrl.Controls.Count > 0)
                    {
                        ClearTextBoxes(ctrl);
                    }
                }
            }
        }
    }
}