<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DemoSql.aspx.cs" Inherits="DemoSql" Theme="Punainen" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="demo.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <!-- 1. DataSourcen määrittely -->
        <asp:SqlDataSource ID="srcMuuvit"
            ConnectionString="<%$ ConnectionStrings:Muuvit %>"
            SelectCommand="SELECT title, director, year FROM movies"
            runat="server"></asp:SqlDataSource>
    <!-- 2. DataKontrolli datan esittämistä varten -->
        <h1>Kinnfino ylpeänä esittää</h1>
        <asp:GridView ID="gvMuuvit" DataSourceID="srcMuuvit" runat="server"></asp:GridView>
    
    </div>
    </form>
</body>
</html>
