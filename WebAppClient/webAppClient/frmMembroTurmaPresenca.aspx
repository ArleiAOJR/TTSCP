<%@ Page Title="" Language="C#" MasterPageFile="~/MyMaster.master" AutoEventWireup="true" CodeBehind="frmMembroTurmaPresenca.aspx.cs" Inherits="WebAppClient.frmMembroTurmaPresenca" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <form id="form1" runat="server">
        <asp:Label ID="Label1" runat="server" Text="Código de Presença"></asp:Label>
        <br />
        <asp:TextBox ID="TBCodigo" runat="server" Width="300px"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="BPresenca" runat="server" OnClick="BPresenca_Click" Text="Presente" Width="100px" />
&nbsp;<asp:Button ID="BVoltar" runat="server" OnClick="BVoltar_Click" Text="Voltar" Width="100px" />
        <br />
        <br />
        <asp:Label ID="LResult" runat="server" Text="Resultado: "></asp:Label>
        <br />
    </form>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Footer" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="AfterBody" runat="server">
</asp:Content>
