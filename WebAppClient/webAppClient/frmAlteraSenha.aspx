<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="frmAlteraSenha.aspx.cs" Inherits="WebAppClient.frmAlteraSenha" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <form id="form1" runat="server">
        <asp:Label ID="Label3" runat="server" Text="Senha Atual"></asp:Label>
        <br />
        <asp:TextBox ID="TBSenha" runat="server" Width="300px" TextMode="Password"></asp:TextBox>
        <br />
        <asp:Label ID="Label4" runat="server" Text="Nova Senha"></asp:Label>
        <br />
        <asp:TextBox ID="TBNovaSenha" runat="server" Width="300px" TextMode="Password"></asp:TextBox>
        <br />
        <asp:Label ID="Label5" runat="server" Text="Repita a Nova Senha"></asp:Label>
        <br />
        <asp:TextBox ID="TBNovaSenha2" runat="server" Width="300px" TextMode="Password"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="BAlterar" runat="server" Text="Alterar" OnClick="Blogin_Click" Width="100px" />
        <br />
        <br />
        <asp:Label ID="LResult" runat="server" Text="Resultado: "></asp:Label>
    </form>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Footer" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="AfterBody" runat="server">
</asp:Content>
