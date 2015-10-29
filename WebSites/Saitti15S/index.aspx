<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>To 22.10.2015</h1>
        <asp:hyperlink ID="hyperlink1" runat="server" NavigateUrl="~/Default.aspx">Eka sivu</asp:hyperlink>
        <asp:hyperlink ID="hyperlink2" runat="server" NavigateUrl="~/Wines.aspx">Maailman viinit</asp:hyperlink>
        <asp:hyperlink ID="hyperlink3" runat="server" NavigateUrl="~/DemoxOy.aspx">Maailman viiniloppahuulet</asp:hyperlink>
        <h1>To 29.10.2015</h1>
        <asp:hyperlink ID="hyperlink4" runat="server" NavigateUrl="~/DemoSql.aspx">Demo SqlDataSource</asp:hyperlink>
        <asp:hyperlink ID="hyperlink5" runat="server" NavigateUrl="~/DemoXml.aspx">Demo XmlDataSource</asp:hyperlink>
    </div>
    </form>
</body>
</html>
