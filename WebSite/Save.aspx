<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Save.aspx.cs" Inherits="Save" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox ID="txtTexto" runat="server"></asp:TextBox>
            <asp:Button ID="btnGuardar" runat="server" OnClick="btnGuardar_Click" Text="Guardar" />
        </div>
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Read.aspx" Target="_self">Ver Texto Ingresado</asp:HyperLink>
    </form>
</body>
</html>
