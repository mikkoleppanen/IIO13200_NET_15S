<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DemoSql.aspx.cs" Inherits="DemoSql" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
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
        <h2>Kinnfino ylpeänä esittää</h2>
        <asp:GridView ID="gvMuuvit" DataSourceID="srcMuuvit" runat="server"></asp:GridView>
    
    </div>
    </form>
</body>
</html>
