using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace webAppClient
{
    public partial class frmListaTurmas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            carregaTurmas();
        }

        protected void carregaTurmas()
        {
            WSAppTTSCP.WSAppTTSCPSoapClient cliente = new WSAppTTSCP.WSAppTTSCPSoapClient();
            string turmas = cliente.listaTurmas();
            string[] t = turmas.Split(new Char[] { '|' });

            foreach (string tone in t)
            {
                //a estrutra da linha é sempre Nome|senha|email|tipo
                if ((!String.IsNullOrEmpty(tone)) & (tone.CompareTo("\0") != 0))
                {
                    TBListaTurmas.Text = TBListaTurmas.Text + tone + System.Environment.NewLine;
                }
            }

        }


    }
}