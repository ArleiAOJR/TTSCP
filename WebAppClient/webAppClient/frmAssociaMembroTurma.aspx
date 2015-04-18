<%@ Page Title="" Language="C#" MasterPageFile="~/MyMaster.master" AutoEventWireup="true" CodeBehind="frmAssociaMembroTurma.aspx.cs" Inherits="WebAppClient.frmAssociaMembroTurma" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <form id="form1" runat="server">
        <asp:Label ID="LTurma" runat="server" Font-Bold="True" Text="Turma: "></asp:Label>
        &nbsp;<asp:Button ID="BAtualiza" runat="server" OnClick="BAtualiza_Click" Text="Atualizar Lista" Width="100px" />
        &nbsp;<asp:Button ID="BVoltar" runat="server" OnClick="BVoltar_Click" Text="Voltar" Width="100px" />
        <br />
        <br />
        <asp:Label ID="LUltimaAcao" runat="server" Text="Útima ação:"></asp:Label>
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
