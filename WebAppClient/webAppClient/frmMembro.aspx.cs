using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAppClient
{
    public partial class frmMembro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BIncluirMembro_Click(object sender, EventArgs e)
        {
            WSAppTTSCP.WSAppTTSCPSoapClient cliente = new WSAppTTSCP.WSAppTTSCPSoapClient();
            LResultado.Text = "Resultado: " + cliente.criarMembro(TBNomeMembro.Text, TBEmailMembro.Text, Convert.ToInt32(DDLTipoMembro.SelectedValue));
        }
    }
}