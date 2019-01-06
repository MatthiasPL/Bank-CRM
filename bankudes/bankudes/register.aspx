<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="bankudes.register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Rejestracja</title>

    <environment names="Development">
        <link rel="stylesheet" href="~/lib/bootstrap/dist/css/bootstrap.css" />
        <link rel="stylesheet" href="~/css/site.css" />
    </environment>
    <environment names="Staging,Production">
        <link rel="stylesheet" href="https://ajax.aspnetcdn.com/ajax/bootstrap/3.3.6/css/bootstrap.min.css"
              asp-fallback-href="~/lib/bootstrap/dist/css/bootstrap.min.css"
              asp-fallback-test-class="sr-only" asp-fallback-test-property="position" asp-fallback-test-value="absolute" />
        <link rel="stylesheet" href="~/css/site.min.css" asp-append-version="true" />
        <link rel="stylesheet" href="~/css/litera.css" />
        <link rel="stylesheet" href="Content/loginregisterform.css" />
    </environment>
</head>
<body>
    <form id="form1" runat="server">
    <div class="container">
        <!--Rejestracja-->
        <div class="col">
            <div class="row">
                <h1>Bankudes - Twój przyjazny bank</h1>
            </div>
        </div>
        <div class="form-group">
            <div class="bs-component">
              <div id="errorBox" class="alert alert-dismissible alert-danger" runat="server">
              </div>
            </div>
                <div class="row">
                    <label for="login">Login:</label>
                    <asp:TextBox ID="login" runat="server" required="required" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="row">
                    <label for="haslo">Hasło:</label>
                    <asp:TextBox ID="haslo" runat="server" required="required" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="row">
                    <label for="imie">Imię:</label>
                    <asp:TextBox ID="imie" runat="server" required="required" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="row">
                    <label for="nazwisko">Nazwisko:</label>
                    <asp:TextBox ID="nazwisko" runat="server" required="required" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="row">
                    <label for="pesel">PESEL:</label>
                    <asp:TextBox ID="pesel" runat="server" required="required" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="row">
                    <label for="miasto">Miasto:</label>
                    <asp:TextBox ID="miasto" runat="server" required="required" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="row">
                    <label for="ulica">Ulica:</label>
                    <asp:TextBox ID="ulica" runat="server" required="required" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="row">
                    <label for="numer_domu">Numer domu:</label>
                    <asp:TextBox ID="numer_domu" runat="server" required="required" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="row">
                    <label for="numer_telefonu">Numer telefonu:</label>
                    <asp:TextBox ID="numer_telefonu" runat="server" required="required" CssClass="form-control"></asp:TextBox>
                </div>
            <div class="row">
                <asp:Button ID="registerbutton" runat="server" Text="ZAREJESTRUJ" CssClass="btn btn-primary" OnClick="registerbutton_Click" />
            </div>
            <div class="row text-center">
                Masz już konto? <asp:HyperLink ID="HLlogin" runat="server" NavigateUrl="~/default.aspx">Zaloguj się</asp:HyperLink>!
            </div>
        </div>
	</div>
    </form>
</body>
</html>
