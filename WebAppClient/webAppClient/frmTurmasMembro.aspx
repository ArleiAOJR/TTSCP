<%@ Page Title="" Language="C#" MasterPageFile="~/MyMaster.master" AutoEventWireup="true" CodeBehind="frmTurmasMembro.aspx.cs" Inherits="WebAppClient.frmTurmasMembro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <form id="form1" runat="server">
        <asp:Button ID="BVerTurmas" runat="server" OnClick="BVerTurmas_Click" Text="Atualizar Lista" Width="100px" />
        <br />
        <br />
        <asp:Label ID="Label3" runat="server" Font-Bold="True" Text="Lista de Turmas"></asp:Label>
        <asp:Table ID="TTurmas" runat="server">
        </asp:Table>
    </form>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Footer" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="AfterBody" runat="server">
</asp:Content>
