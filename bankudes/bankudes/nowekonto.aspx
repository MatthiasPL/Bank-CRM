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
        <div class="alert alert-danger" runat="server" id="ostrzezenie">

        </div>
        <div class="col-lg-6 col-md-6">
        <fieldset class="form-group">
            <legend>Typ konta</legend>
                    <asp:RadioButtonList ID="RadioButtonListKonta" runat="server"></asp:RadioButtonList>
        </fieldset>
        </div>
        <div class="col-lg-6 col-md-6">
            <div class="row">
                <fieldset class="form-group">
                    <legend>Waluta</legend>
                            <asp:RadioButtonList ID="RadioButtonListWaluty" runat="server"></asp:RadioButtonList>
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
