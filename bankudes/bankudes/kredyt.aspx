<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="kredyt.aspx.cs" Inherits="bankudes.kredyt" %>

<!DOCTYPE html>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Weź kredyt</title>

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
        <link rel="stylesheet" href="Content/home.css" />
    </environment>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">

            <div class="jumbotron jumbotron-fluid">
          <div class="container">
            <asp:Button ID="logout" runat="server" Text="Wyloguj" CssClass="btn btn-primary pull-right" OnClick="logout_Click" />
            <h1 class="display-4" id="powitanie" runat="server"></h1>
            <p class="lead">
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/konto.aspx">Twój profil</asp:HyperLink></p>
                          <p class="lead">
                <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/home.aspx">Strona główna</asp:HyperLink></p>
          </div>
        </div>

            <div>
    
        <asp:DropDownList ID="ddKredyty" runat="server">
        </asp:DropDownList>
    
    </div>
        <div>
            <asp:Button ID="bKredytOn" runat="server" Text="Weź kredyt" OnClick="bKredytOn_Click" CssClass="btn btn-primary" />
            <asp:Button ID="bZatwierdz" runat="server" Text="Zatwierdź kredyt" OnClick="bZatwierdz_Click" CssClass="btn btn-primary" />
            <asp:Button ID="bUsun" runat="server" Text="Usuń kredyt" OnClick="bUsun_Click" CssClass="btn btn-primary" />
        </div>
    <div id="NowyKredyt" runat="server">
        <asp:DropDownList ID="ddKonta" runat="server" OnSelectedIndexChanged="ddKonta_SelectedIndexChanged">
        </asp:DropDownList>
            <asp:TextBox ID="tbKwota" runat="server"></asp:TextBox>
        <asp:Button ID="bPozycz" runat="server" Text="Pożycz" OnClick="bPozycz_Click" CssClass="btn btn-primary" />
    </div>
        </div>
        
    </form>
    </body>
</html>
