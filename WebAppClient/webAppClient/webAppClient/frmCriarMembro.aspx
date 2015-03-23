<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmCriarMembro.aspx.cs" Inherits="webAppClient.frmCriarMembro" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <p>
            <asp:Label ID="Label1" runat="server" Text="Incluir Membros..." Font-Bold="True" Font-Size="Larger" ForeColor="#009933"></asp:Label>
        </p>
        <hr />
        <asp:Label ID="Label2" runat="server" Text="Turma"></asp:Label>
        <br />
        <asp:DropDownList ID="DDLListTurmas" runat="server" Height="19px" Width="300px">
        </asp:DropDownList>
        <br />
        <br />
        <asp:Label ID="Label3" runat="server" Text="Nome do Membro"></asp:Label>
        <br />
        <asp:TextBox ID="TBNomeMembro" runat="server" Width="300px"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label4" runat="server" Text="E-mail do Membro"></asp:Label>
        <br />
        <asp:TextBox ID="TBEmailMembro" runat="server" Width="300px"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label5" runat="server" Text="Tipo do Membro"></asp:Label>
        <br />
        <asp:DropDownList ID="DDLTipoMembro" runat="server" Height="19px" Width="300px">
            <asp:ListItem Value="0">Professor</asp:ListItem>
            <asp:ListItem Selected="True" Value="1">Aluno</asp:ListItem>
        </asp:DropDownList>
        <hr />
        <asp:Button ID="BIncluirMembro" runat="server" Text="Incluir Membro" OnClick="BIncluirMembro_Click" />
        <hr />
        <p>
            <asp:Label ID="LResultado" runat="server" Text="Resultado: "></asp:Label>
        </p>
        <hr />
        <p>
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/frmPrincipal.aspx">Voltar</asp:HyperLink>
        </p>
    </form>
</body>
</html>
