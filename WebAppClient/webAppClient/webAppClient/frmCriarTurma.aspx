<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmCriarTurma.aspx.cs" Inherits="webAppClient.frmCriarTurma" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Criação de Turma</title>
    
    <style type="text/css">
        #form1 {
            height: 372px;
        }
        #Text1 {
            height: 21px;
            width: 448px;
        }
    </style>
    
</head>
<body>
    <form id="form1" runat="server">
        <br />
        <div>
            <asp:Label ID="Label1" runat="server" Text="Criação de Turmas..." Font-Bold="True" Font-Size="Larger" ForeColor="#009933"></asp:Label>
        </div>
        <hr />
        <asp:Label ID="Label2" runat="server" Text="Descrição da Turma"></asp:Label>
        <br />
        <asp:TextBox ID="TBTurma" runat="server"></asp:TextBox>
        <hr />
        <asp:Button ID="BCriaTurma" runat="server" Text="Criar Turma" Width="127px" OnClick="BCriaTurma_Click" />
        <hr />
        <asp:Label ID="LResultado" runat="server" Text="Resultado: "></asp:Label>
        <br />
        <hr />
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/frmPrincipal.aspx">Voltar</asp:HyperLink>
        <br />
    </form>
</body>
</html>
