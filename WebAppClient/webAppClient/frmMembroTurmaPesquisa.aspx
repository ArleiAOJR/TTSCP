<%@ Page Title="" Language="C#" MasterPageFile="~/MyMaster.master" AutoEventWireup="true" CodeBehind="frmMembroTurmaPesquisa.aspx.cs" Inherits="WebAppClient.frmMembroTurmaPesquisa" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <form id="form1" runat="server">
    <asp:Button ID="BVerPesquisas" runat="server" OnClick="BVerTurmas_Click" Text="Atualizar Lista" Width="100px" />
    <br />
    <br />
    <asp:Label ID="LResult" runat="server" Text="Resultado: "></asp:Label>
    <br />
    <br />
    <asp:Label ID="Label3" runat="server" Font-Bold="True" Text="Lista de Pesquisas"></asp:Label>
    <asp:Table ID="TPesquisas" runat="server">
    </asp:Table>
</form>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Footer" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="AfterBody" runat="server">
</asp:Content>
