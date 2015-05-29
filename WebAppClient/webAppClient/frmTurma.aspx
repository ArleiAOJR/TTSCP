<%@ Page Title="" Language="C#" MasterPageFile="~/MyMaster.master" AutoEventWireup="true" CodeBehind="frmTurma.aspx.cs" Inherits="WebAppClient.frmTurma" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <form id="form1" runat="server">
        <asp:Label ID="Label2" runat="server" Text="Descrição da Turma"></asp:Label>
        <br />
        <asp:TextBox ID="TBTurma" runat="server" Width="300px"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="BCriaTurma" runat="server" Text="Criar Turma" Width="100px" OnClick="BCriaTurma_Click" />
        <br />
        <br />
        <asp:Label ID="LResultado" runat="server" Text="Resultado: "></asp:Label>
        <br />
        <br />
        <asp:Button ID="BVerTurmas" runat="server" OnClick="BVerTurmas_Click" Text="Atualizar Lista" Width="100px" />
        <br />
        <br />
        <asp:Label ID="Label3" runat="server" Font-Bold="True" Text="Lista de Turmas"></asp:Label>
        <br />
        <asp:Label ID="Label4" runat="server" Font-Italic="True" Text="Filtro (turma)"></asp:Label>
        <br />
        <asp:TextBox ID="tb_filtro" runat="server" Width="300px"></asp:TextBox>
        <br />
        <asp:Table ID="TTurmas" runat="server">
        </asp:Table>
    </form>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Footer" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="AfterBody" runat="server">
</asp:Content>
