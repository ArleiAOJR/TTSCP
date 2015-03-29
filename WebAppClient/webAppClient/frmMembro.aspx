<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="frmMembro.aspx.cs" Inherits="WebAppClient.frmMembro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <form id="form1" runat="server">
        <asp:Label ID="Label3" runat="server" Text="Nome do Membro"></asp:Label>
        <br />
        <asp:TextBox ID="TBNomeMembro" runat="server" Width="300px"></asp:TextBox>
        <br />
        <asp:Label ID="Label4" runat="server" Text="E-mail do Membro"></asp:Label>
        <br />
        <asp:TextBox ID="TBEmailMembro" runat="server" Width="300px"></asp:TextBox>
        <br />
        <asp:Label ID="Label5" runat="server" Text="Tipo do Membro"></asp:Label>
        <br />
        <asp:DropDownList ID="DDLTipoMembro" runat="server" Height="19px" Width="300px">
            <asp:ListItem Value="0">Professor</asp:ListItem>
            <asp:ListItem Selected="True" Value="1">Aluno</asp:ListItem>
        </asp:DropDownList>
        <br />
        <br />
        <asp:Button ID="BIncluirMembro" runat="server" Text="Incluir Membro" OnClick="BIncluirMembro_Click" Width="100px" />
        <br />
        <br />
        <asp:Label ID="LResultado" runat="server" Text="Resultado: "></asp:Label>
        <br />
        <br />
        <asp:Button ID="BVerMembros" runat="server" OnClick="BVerMembros_Click" Text="Ver Membros" Width="100px" />
        <br />
        <br />
        <asp:Label ID="Label6" runat="server" Font-Bold="True" Text="Lista de Membros"></asp:Label>
        <br />
        <asp:Table ID="TMembros" runat="server">
        </asp:Table>
        <br />
    </form>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Footer" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="AfterBody" runat="server">
</asp:Content>
