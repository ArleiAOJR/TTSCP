<%@ Page Title="" Language="C#" MasterPageFile="~/MyMaster.master" AutoEventWireup="true" CodeBehind="frmBoletimFaltas.aspx.cs" Inherits="WebAppClient.frmBoletimFaltas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <form id="form1" runat="server">
        <asp:Label ID="Label1" runat="server" Text="Filtro"></asp:Label>
        <br />
        <asp:DropDownList ID="DDLFiltro" runat="server" Height="24px" Width="300px">
            <asp:ListItem Value="0">Todos</asp:ListItem>
            <asp:ListItem Value="2">Presentes</asp:ListItem>
            <asp:ListItem Value="1">Faltantes</asp:ListItem>
        </asp:DropDownList>
        <br />
        <br />
        <asp:Button ID="BBoletim" runat="server" OnClick="BBoletim_Click" Text="Boletim" Width="100px" />
&nbsp;<asp:Button ID="BVoltar" runat="server" OnClick="BVoltar_Click" Text="Voltar" Width="100px" />
        <br />
        <br />
        <asp:Label ID="Label2" runat="server" Font-Bold="True" Text="Boletim"></asp:Label>
        <br />
        <br />
        <asp:Label ID="LBoletim" runat="server" Text="------"></asp:Label>
    </form>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Footer" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="AfterBody" runat="server">
</asp:Content>
