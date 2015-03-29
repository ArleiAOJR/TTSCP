using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAppClient
{
    public partial class frmAlteraSenha : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Blogin_Click(object sender, EventArgs e)
        {
            if (TBNovaSenha.Text.CompareTo(TBNovaSenha2.Text)==0)
            {
                WSAppTTSCP.WSAppTTSCPSoapClient cliente = new WSAppTTSCP.WSAppTTSCPSoapClient();
                LResult.Text = "Resultado: " + cliente.alteraSenha(GlobalVar.EmailMembroAutenticado, TBSenha.Text, TBNovaSenha.Text);
                if (LResult.Text.CompareTo("Resultado: Senha alterada com sucesso!") == 0)
                {
                    GlobalVar.MembroAutenticado = true;
                    Server.Transfer("Default.aspx", true);
                }
            }
            else
            {
                LResult.Text = "Resultado: As novas senhas não conferem!";
            }
        }
    }
}