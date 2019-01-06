<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="bankudes.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Logowanie</title>

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
                  <strong>Niepoprawne dane logowania!</strong>
              </div>
            </div>
                <div class="row">
                    <label for="login">Login:</label>
                    <asp:TextBox ID="login" runat="server" required="required" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="row">
                    <label for="password">Hasło:</label>
                    <asp:TextBox ID="haslo" type="password" runat="server" required="required" CssClass="form-control"></asp:TextBox>
                </div>
            <div class="row">
                <asp:Button ID="loginbutton" runat="server" Text="ZALOGUJ" CssClass="btn btn-primary" OnClick="buttonLogin_Click" />
            </div>
            <div class="row text-center">
                Nie masz konta? <asp:HyperLink ID="HLregister" runat="server" NavigateUrl="~/register.aspx">Zarejestruj się</asp:HyperLink>!
            </div>
        </div>
	</div>
    </form>
</body>
</html>
