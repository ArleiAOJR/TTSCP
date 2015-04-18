using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAppClient
{
    public partial class frmPesquisaDelete : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BConfirmar_Click(object sender, EventArgs e)
        {
            WSAppTTSCP.WSAppTTSCPSoapClient cliente = new WSAppTTSCP.WSAppTTSCPSoapClient();
            LResult.Text = "Resultado: " + cliente.excluirPesquisa(GlobalVar.TurmaAAssociar, GlobalVar.idPesquisa);
            Server.Transfer("frmAssociaPesquisaTurma.aspx", true);
        }

        protected void BCancelar_Click(object sender, EventArgs e)
        {
            Server.Transfer("frmAssociaPesquisaTurma.aspx", true);
        }
    }
}