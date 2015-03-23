<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmPrincipal.aspx.cs" Inherits="webAppClient.frmPrincipal" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Teacher To Students Communication Platform - WebClient</title>
</head>
<body>
    <form id="form1" runat="server">
        <br />
            <asp:Label ID="Label1" runat="server" Text="Teacher To Students Communication Platform - TTSCP" Font-Bold="True" Font-Size="Larger" ForeColor="#009933"></asp:Label>
        <br />
        <hr />
        <br />
        <asp:HyperLink ID="HLCriarTurma" runat="server" NavigateUrl="~/frmCriarTurma.aspx">Criar Turma</asp:HyperLink>
        <br />
        <hr />
        <br />
        <asp:HyperLink ID="HLListaTurmas" runat="server" NavigateUrl="~/frmListaTurmas.aspx">Lista Turmas</asp:HyperLink>
        <br />
        <hr />
        <br />
        <asp:HyperLink ID="HLCriarMembros" runat="server" NavigateUrl="~/frmCriarMembro.aspx">Criar Membros</asp:HyperLink>
        <br />
        <hr />
        <p>
        <asp:HyperLink ID="HLLogin" runat="server" NavigateUrl="~/frmLogin.aspx">Login</asp:HyperLink>
        </p>
        <hr />
        <p>
            &nbsp;</p>
    </form>
</body>
</html>
