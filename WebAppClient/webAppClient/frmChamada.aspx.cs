using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAppClient
{
    public partial class frmChamada : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BConfirmar_Click(object sender, EventArgs e)
        {
            WSAppTTSCP.WSAppTTSCPSoapClient cliente = new WSAppTTSCP.WSAppTTSCPSoapClient();
            LResult.Text = "Resultado: " + cliente.presencaInicia(GlobalVar.TurmaAAssociar);
        }

        protected void BCancelar_Click(object sender, EventArgs e)
        {
            WSAppTTSCP.WSAppTTSCPSoapClient cliente = new WSAppTTSCP.WSAppTTSCPSoapClient();
            LResult.Text = "Resultado: " + cliente.presencaFinaliza(GlobalVar.TurmaAAssociar);
            Server.Transfer("frmTurma.aspx", true);
        }
    }
}