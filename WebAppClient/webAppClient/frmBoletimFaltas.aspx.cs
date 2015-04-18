using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAppClient
{
    public partial class frmBoletimFaltas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BBoletim_Click(object sender, EventArgs e)
        {
            WSAppTTSCP.WSAppTTSCPSoapClient cliente = new WSAppTTSCP.WSAppTTSCPSoapClient();
            string boletim = cliente.presencaBoletim(GlobalVar.TurmaAAssociar, Convert.ToInt32(DDLFiltro.SelectedValue));
            if (!String.IsNullOrEmpty(boletim))
            {
                boletim = boletim.Replace("&", "<br>");
                boletim = boletim.Replace("-----", "<br>");
                boletim = boletim.Replace("|F", " - Falta");
                boletim = boletim.Replace("|P", " - Presença");
                LBoletim.Text = boletim;
            }
        }

        protected void BVoltar_Click(object sender, EventArgs e)
        {
            Server.Transfer("frmTurma.aspx", true);
        }
    }
}