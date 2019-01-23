<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="bankudes.home" %>

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
          </div>
        </div>
        <div class="col-lg-6 col-md-6">
            <div class="row">
                <div class="bs-component karta">
                    <div class="alert alert-dismissible alert-info">
                        <asp:Button ID="bKonto" runat="server" Text="Załóż konto!" CssClass="btn btn-info" OnClick="bKonto_Click" /> <br /> Zwiększ swoją noworoczną podwyżkę z nowym kontem oszczędnościowym.
                    </div>
                </div>
            </div>
        </div>
        <div class="col-lg-6 col-md-6">
            <div class="row">
                <div class="bs-component karta">
                    <div class="alert alert-dismissible alert-success">
                        <asp:Button ID="bWymiana" runat="server" Text="Noworoczna wycieczka?" CssClass="btn btn-success" OnClick="bWymiana_Click" /> <br /> Skorzystaj z naszej wygodnej wymiany walut i zyskaj czas na przygotowania do wyjazdu.
                    </div>
                </div>
            </div>
        </div>
        <!--
            TODO:
                Dodawanie nowych kont i rachunków do nich
                Wymiana walut
                Przelewy (czyli trzeba dodać jakieś dane do przelewów?)
            -->
	</div>
    </form>
</body>
</html>
