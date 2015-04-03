<%@ Page Title="" Language="C#" MasterPageFile="~/MyMaster.master" AutoEventWireup="true" CodeBehind="frmLogin.aspx.cs" Inherits="WebAppClient.frmLogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <form id="form1" runat="server">
        <asp:Label ID="Label4" runat="server" Text="E-Mail"></asp:Label>
        <br />
        <asp:TextBox ID="TBemail" runat="server" Width="300px"></asp:TextBox>
        <br />
        <asp:Label ID="Label3" runat="server" Text="Senha"></asp:Label>
        <br />
        <asp:TextBox ID="TBSenha" runat="server" Width="300px" TextMode="Password"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="Blogin" runat="server" Text="Entrar" OnClick="Blogin_Click" Width="100px" />
    </form>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Footer" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="AfterBody" runat="server">
</asp:Content>
