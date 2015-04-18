using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAppClient
{
    public partial class frmMembroTurmaPresenca : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BPresenca_Click(object sender, EventArgs e)
        {
            WSAppTTSCP.WSAppTTSCPSoapClient cliente = new WSAppTTSCP.WSAppTTSCPSoapClient();
            LResult.Text = "Resultado: " + cliente.presencaAtualiza(GlobalVar.TurmaAAssociar, GlobalVar.EmailMembroAutenticado, TBCodigo.Text);
        }

        protected void BVoltar_Click(object sender, EventArgs e)
        {
            Server.Transfer("frmTurmasMembro.aspx", true);
        }
    }
}