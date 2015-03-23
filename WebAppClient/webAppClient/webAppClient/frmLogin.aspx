<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmLogin.aspx.cs" Inherits="webAppClient.frmLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
            <asp:Label ID="Label1" runat="server" Text="Login - TTSCP" Font-Bold="True" Font-Size="Larger" ForeColor="#009933"></asp:Label>
            <hr />
            <asp:Label ID="Label4" runat="server" Text="E-Mail"></asp:Label>
            <br />
            <asp:TextBox ID="TBemail" runat="server" Width="300px"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label5" runat="server" Text="Tipo Membro"></asp:Label>
            <br />
            <asp:DropDownList ID="DDLTipoMembro" runat="server" Height="19px" Width="300px">
                <asp:ListItem Selected="True" Value="1">Aluno</asp:ListItem>
                <asp:ListItem Value="0">Professor</asp:ListItem>
            </asp:DropDownList>
            <br />
            <br />
            <asp:Label ID="Label3" runat="server" Text="Senha"></asp:Label>
            <br />
            <asp:TextBox ID="TBSenha" runat="server" Width="300px"></asp:TextBox>
            <br />
            <hr />
            <asp:Button ID="Blogin" runat="server" Text="Entrar" OnClick="Blogin_Click" />
            <br />
            <hr />
            <asp:Label ID="LResult" runat="server" Text="Resultado: "></asp:Label>
            <br />
    </form>
</body>
</html>
