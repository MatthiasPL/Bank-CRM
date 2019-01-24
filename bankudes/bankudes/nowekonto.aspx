<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="nowekonto.aspx.cs" Inherits="bankudes.profil" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Strona główna</title>

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
        <div class="alert alert-danger" runat="server" id="ostrzezenie">

        </div>
        <div class="col-lg-6 col-md-6">
        <fieldset class="form-group">
            <legend>Typ konta</legend>
                    <asp:DropDownList ID="ddKonta" runat="server" OnSelectedIndexChanged="ddKonta_SelectedIndexChanged">
            </asp:DropDownList>
        </fieldset>
        </div>
        <div class="col-lg-6 col-md-6">
            <div class="row">
                <fieldset class="form-group">
                    <legend>Waluta</legend>
                            <asp:DropDownList ID="ddWaluty" runat="server" OnSelectedIndexChanged="ddWaluty_SelectedIndexChanged">
                    </asp:DropDownList>
                </fieldset>
            </div>
            <div class-"row">
                <asp:Button ID="bDodaj" runat="server" Text="Załóż konto" CssClass="btn btn-primary pull-right" OnClick="bDodaj_Click" />
            </div>
        </div>
       <!--<input type="submit" value="test" />-->
	</div>
    </form>
</body>
</html>
