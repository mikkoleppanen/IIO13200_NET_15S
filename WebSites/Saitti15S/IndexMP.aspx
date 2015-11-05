<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="IndexMP.aspx.cs" Inherits="IndexMP" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Label ID="lblHello" runat="server" Text="..."></asp:Label>
    <h1>To 22.10.2015</h1>
    <asp:hyperlink ID="hyperlink1" runat="server" NavigateUrl="~/Default.aspx">Eka sivu</asp:hyperlink>
    <asp:hyperlink ID="hyperlink2" runat="server" NavigateUrl="~/Wines.aspx">Maailman viinit</asp:hyperlink>
    <asp:hyperlink ID="hyperlink3" runat="server" NavigateUrl="~/DemoxOy.aspx">Maailman viiniloppahuulet</asp:hyperlink>
    <h1>To 29.10.2015</h1>
    <asp:hyperlink ID="hyperlink4" runat="server" NavigateUrl="~/DemoSql.aspx">Demo SqlDataSource</asp:hyperlink>
    <asp:hyperlink ID="hyperlink5" runat="server" NavigateUrl="~/DemoXml.aspx">Demo XmlDataSource</asp:hyperlink>
    <h1>To 05.11.2015</h1>
    <asp:hyperlink ID="hyperlink6" runat="server" NavigateUrl="~/IndexMP.aspx">Demo XmlDataSource</asp:hyperlink>

    <br />
    <asp:hyperlink ID="hyperlink7" runat="server" NavigateUrl="~/IndexMP.aspx">Esimerkki tyyleistä</asp:hyperlink>
</asp:Content>

