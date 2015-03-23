using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace webAppClient
{
    public partial class frmCriarMembro : System.Web.UI.Page
    {
        protected int firstLoad = 0;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (firstLoad == 0)
            {
                firstLoad++;
                carregaTurmas();
            }
        }

        protected void carregaTurmas()
        {
            WSAppTTSCP.WSAppTTSCPSoapClient cliente = new WSAppTTSCP.WSAppTTSCPSoapClient();
            string turmas = cliente.listaTurmas();
            string[] t = turmas.Split(new Char[] { '|' });

            //DDLListTurmas.Items.Clear();

            foreach (string tone in t)
            {
                //a estrutra da linha é sempre Nome|senha|email|tipo
                if ((!String.IsNullOrEmpty(tone)) & (tone.CompareTo("\0") != 0))
                {
                    ListItem NovoItem = new ListItem();
                    NovoItem.Text = tone;
                    NovoItem.Value = tone;
                    DDLListTurmas.Items.Add(NovoItem);
                }
            }

        }

        protected void BIncluirMembro_Click(object sender, EventArgs e)
        {
            WSAppTTSCP.WSAppTTSCPSoapClient cliente = new WSAppTTSCP.WSAppTTSCPSoapClient();
            LResultado.Text = "Resultado: " + cliente.criarMembro(DDLListTurmas.SelectedValue, TBNomeMembro.Text, TBEmailMembro.Text, Convert.ToInt32(DDLTipoMembro.SelectedValue));
        }

    }
}