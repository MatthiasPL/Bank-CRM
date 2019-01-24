<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="wymiana.aspx.cs" Inherits="bankudes.wymiana" %>

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

        <div class="col-sm-12 col-md-6 col-lg-6">
            <div class="row">
                <asp:Label ID="LabelKonta" runat="server" Text="Przelej z:"></asp:Label>
                <asp:DropDownList ID="ddKontaUz" runat="server" OnSelectedIndexChanged="ddKontaUz_SelectedIndexChanged">
                </asp:DropDownList>
            </div>
            <div class="row">
                <asp:Label ID="LabelKontaUz2" runat="server" Text="Przelej na:"></asp:Label>
                <asp:DropDownList ID="ddKontaUz2" runat="server" OnSelectedIndexChanged="ddKontaUz2_SelectedIndexChanged">
                </asp:DropDownList>
            </div>
        </div>
        
        <div class="col-sm-12 col-md-6 col-lg-6">
            <div class="row">
                <asp:Label ID="LabelPrzelew" runat="server" Text="Kwota przelewu:"></asp:Label>
                <asp:TextBox ID="TbKwota" runat="server"></asp:TextBox>
            </div>
            <div class="row">
                <asp:Button ID="Button1" runat="server" OnClick="bTransfer_Click" Text="Dokonaj przelewu" CssClass="btn btn-info" />
            </div>
        </div>
      
	</div>
    </form>
</body>
</html>
