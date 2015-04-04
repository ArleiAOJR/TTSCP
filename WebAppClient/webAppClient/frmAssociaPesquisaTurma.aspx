<%@ Page Title="" Language="C#" MasterPageFile="~/MyMaster.master" AutoEventWireup="true" CodeBehind="frmAssociaPesquisaTurma.aspx.cs" Inherits="WebAppClient.frmAssociaPesquisaTurma" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <form id="form1" runat="server">
        <asp:Label ID="Label3" runat="server" Text="Título da Pesquisa"></asp:Label>
        <br />
        <asp:TextBox ID="TBTituloPesquisa" runat="server" Width="300px"></asp:TextBox>
        <br />
        <asp:Label ID="Label4" runat="server" Text="Pesquisa (Pergunta)"></asp:Label>
        <br />
        <asp:TextBox ID="TBDescricaoPesquisa" runat="server" Width="841px"></asp:TextBox>
        <br />
        <asp:Label ID="Label7" runat="server" Text="Data Final Para Votação"></asp:Label>
        <br />
        <asp:TextBox ID="TBData" runat="server" TextMode="Date" Width="300px"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="BIncluirPesquisa" runat="server" Text="Incluir Pesquisa" OnClick="BIncluirMembro_Click" Width="100px" />
        <br />
        <br />
        <asp:Label ID="LResultado" runat="server" Text="Resultado: "></asp:Label>
        <br />
        <br />
        <asp:Button ID="BVerPesquisas" runat="server" OnClick="BVerPesquisas_Click" Text="Ver Pesquisas" Width="100px" />
        <br />
        <br />
        <asp:Label ID="Label6" runat="server" Font-Bold="True" Text="Lista de Pesquisas"></asp:Label>
        <asp:Table ID="TPesquisas" runat="server">
        </asp:Table>
    </form>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Footer" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="AfterBody" runat="server">
</asp:Content>
