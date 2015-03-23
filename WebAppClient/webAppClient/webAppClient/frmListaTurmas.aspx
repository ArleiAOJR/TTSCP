<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmListaTurmas.aspx.cs" Inherits="webAppClient.frmListaTurmas" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #TextArea1 {
            height: 135px;
            width: 238px;
        }
        #TAListaTurmas {
            height: 98px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Lista de Turmas..." Font-Bold="True" Font-Size="Larger" ForeColor="#009933"></asp:Label>
        </div>
    <hr />
    <p>
        <asp:TextBox ID="TBListaTurmas" runat="server" Height="102px" Width="199px" ReadOnly="True" TextMode="MultiLine"></asp:TextBox>
        </p>
        <hr />
        <p>
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/frmPrincipal.aspx">Voltar</asp:HyperLink>
        </p>
    </form>
    </body>
</html>
