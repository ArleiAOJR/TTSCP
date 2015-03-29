<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="frmAssociaMembroTurma.aspx.cs" Inherits="WebAppClient.frmAssociaMembroTurma" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <form id="form1" runat="server">
        <asp:Label ID="LTurma" runat="server" Font-Bold="True" Text="Turma: "></asp:Label>
        <br />
        <br />
        <asp:Label ID="Label1" runat="server" Font-Bold="True" Text="Lista de Membros Associados"></asp:Label>
        <br />
        <asp:Table ID="TMembrosAssociados" runat="server">
        </asp:Table>
        <br />
        <asp:Label ID="Label2" runat="server" Font-Bold="True" Text="Lista de Todos os Membros"></asp:Label>
        <br />
        <asp:Table ID="TTodosOsMembros" runat="server">
        </asp:Table>
        <br />
    </form>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Footer" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="AfterBody" runat="server">
</asp:Content>
