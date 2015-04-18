using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAppClient
{
    public partial class frmMembroDelete : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BConfirmar_Click(object sender, EventArgs e)
        {
            WSAppTTSCP.WSAppTTSCPSoapClient cliente = new WSAppTTSCP.WSAppTTSCPSoapClient();
            LResult.Text = "Resultado: " + cliente.exlcuirMembro(GlobalVar.emailMembroAExlcuir);
            LResult.Text = LResult.Text.Replace("|", "<br><br>");
        }

        protected void BCancelar_Click(object sender, EventArgs e)
        {
            Server.Transfer("frmMembro.aspx", true);
        }
    }
}