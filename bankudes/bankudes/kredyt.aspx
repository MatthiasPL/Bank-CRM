<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="kredyt.aspx.cs" Inherits="bankudes.kredyt" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:DropDownList ID="ddKredyty" runat="server">
        </asp:DropDownList>
    
    </div>
        <div>
            <asp:Button ID="bKredytOn" runat="server" Text="Weź kredyt" OnClick="bKredytOn_Click" />
            <asp:Button ID="bZatwierdz" runat="server" Text="Zatwierdź kredyt" OnClick="bZatwierdz_Click" />
            <asp:Button ID="bUsun" runat="server" Text="Usuń kredyt" OnClick="bUsun_Click" />
        </div>
    <div id="NowyKredyt" runat="server">
        <asp:DropDownList ID="ddKonta" runat="server" OnSelectedIndexChanged="ddKonta_SelectedIndexChanged">
        </asp:DropDownList>
            <asp:TextBox ID="tbKwota" runat="server"></asp:TextBox>
        <asp:Button ID="bPozycz" runat="server" Text="Pożycz" OnClick="bPozycz_Click" />
    </div>
        
    </form>
    </body>
</html>
