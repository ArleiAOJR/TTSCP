<%@ Page Title="" Language="C#" MasterPageFile="~/MyMaster.master" AutoEventWireup="true" CodeBehind="frmResultadoPesquisa.aspx.cs" Inherits="WebAppClient.frmResultadoPesquisa" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <form id="form1" runat="server">
    <p>
        <asp:Button ID="BResult" runat="server" Text="Ver Resultado" Width="100px" />
    </p>
    <p>
        <asp:Label ID="LResult" runat="server" Text="Resultado: "></asp:Label>
    </p>
</form>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Footer" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="AfterBody" runat="server">
</asp:Content>
