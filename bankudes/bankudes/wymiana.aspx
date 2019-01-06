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

	</div>
    </form>
</body>
</html>
