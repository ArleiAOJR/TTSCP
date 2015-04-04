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
            if (TBNovaSenha.Text.Length<5)
            {
                LResult.Text = "A nova senha precisa ter pelo menos 5 caracteres!";
                return;
            }
                        
            if (TBNovaSenha.Text.CompareTo(TBNovaSenha2.Text)==0)
            {
                WSAppTTSCP.WSAppTTSCPSoapClient cliente = new WSAppTTSCP.WSAppTTSCPSoapClient();
                LResult.Text = "Resultado: " + cliente.alteraSenha(GlobalVar.EmailMembroAutenticado, TBSenha.Text, TBNovaSenha.Text);
                if (LResult.Text.CompareTo("Resultado: Senha alterada com sucesso!") == 0)
                {
                    GlobalVar.MembroAutenticado = true;
                    TBSenha.Text = "";
                    TBNovaSenha.Text = "";
                    TBNovaSenha2.Text = "";
                }
            }
            else
            {
                LResult.Text = "Resultado: As novas senhas não conferem!";
            }
        }
    }
}