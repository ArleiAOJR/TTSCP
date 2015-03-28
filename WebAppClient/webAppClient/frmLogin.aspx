<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="frmLogin.aspx.cs" Inherits="WebAppClient.frmLogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <form id="form1" runat="server">
        <asp:Label ID="Label4" runat="server" Text="E-Mail"></asp:Label>
        <br />
        <asp:TextBox ID="TBemail" runat="server" Width="300px"></asp:TextBox>
        <br />
        <asp:Label ID="Label5" runat="server" Text="Tipo Membro"></asp:Label>
        <br />
        <asp:DropDownList ID="DDLTipoMembro" runat="server" Height="18px" Width="307px">
            <asp:ListItem Selected="True" Value="1">Aluno</asp:ListItem>
            <asp:ListItem Value="0">Professor</asp:ListItem>
        </asp:DropDownList>
        <br />
        <asp:Label ID="Label3" runat="server" Text="Senha"></asp:Label>
        <br />
        <asp:TextBox ID="TBSenha" runat="server" Width="300px" TextMode="Password"></asp:TextBox>
        <br />
        <asp:Button ID="Blogin" runat="server" Text="Entrar" OnClick="Blogin_Click" />
        <br />
        <asp:Label ID="LResult" runat="server" Text="Resultado: "></asp:Label>
    </form>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Footer" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="AfterBody" runat="server">
</asp:Content>
