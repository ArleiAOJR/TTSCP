using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAppClient
{
    public partial class frmLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Blogin_Click(object sender, EventArgs e)
        {
            WSAppTTSCP.WSAppTTSCPSoapClient cliente = new WSAppTTSCP.WSAppTTSCPSoapClient();
            if (cliente.autenticaMembro(TBemail.Text, TBSenha.Text))
            {
                GlobalVar.MembroAutenticado = true;
                string dados = cliente.dadosMembro(TBemail.Text);
                string[] d = dados.Split(new Char[] { '|' });
                GlobalVar.TipoMembro = Convert.ToInt32(d[2]);
                GlobalVar.NomeMembroAutenticado = d[0];
                GlobalVar.EmailMembroAutenticado = d[1];

                //Indicar o nome do membro que se autenticou no form
                

                if (TBSenha.Text.CompareTo("password") == 0)
                {
                    GlobalVar.MembroAutenticado = false;
                    Server.Transfer("frmAlteraSenha.aspx", true);
                }
                
                //se for professor é direcionado para o form de turmas
                if (GlobalVar.TipoMembro==0)
                {
                    Server.Transfer("frmTurma.aspx", true);
                }

                //se for aluno deve ser direcionado para as minhas turmas
                if (GlobalVar.TipoMembro == 1)
                {
                    Server.Transfer("frmTurmasMembro.aspx", true);
                }

            }
            else
            {
                GlobalVar.MembroAutenticado = false;
                GlobalVar.TipoMembro = 3;
                GlobalVar.NomeMembroAutenticado = "";
                GlobalVar.EmailMembroAutenticado = "";
                LResult.Text = "Resultado: Usuário e senha não conferem!";
            }
        }
    }
}