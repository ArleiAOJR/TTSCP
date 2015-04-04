using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAppClient
{
    public partial class frmResultadoPesquisa : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            resultadoPesquisa();
        }

        protected void resultadoPesquisa()
        {
            WSAppTTSCP.WSAppTTSCPSoapClient cliente = new WSAppTTSCP.WSAppTTSCPSoapClient();
            LResult.Text = cliente.resultadoPesquisa(GlobalVar.TurmaAAssociar, GlobalVar.idPesquisa);
        }
    }
}