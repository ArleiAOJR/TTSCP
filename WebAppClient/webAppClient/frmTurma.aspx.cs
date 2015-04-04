using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAppClient
{
    public partial class frmTurma : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            carregaTurmas();
        }

        protected void BCriaTurma_Click(object sender, EventArgs e)
        {
            WSAppTTSCP.WSAppTTSCPSoapClient cliente = new WSAppTTSCP.WSAppTTSCPSoapClient();
            LResultado.Text = "Resultado: " + cliente.criarTurma(TBTurma.Text);
        }

        protected void btn_click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            GlobalVar.TurmaAAssociar = btn.CommandArgument;
            Server.Transfer("frmAssociaMembroTurma.aspx", true);
        }

        protected void btnPesq_click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            GlobalVar.TurmaAAssociar = btn.CommandArgument;
            Server.Transfer("frmAssociaPesquisaTurma.aspx", true);
        }

        protected void carregaTurmas()
        {
            WSAppTTSCP.WSAppTTSCPSoapClient cliente = new WSAppTTSCP.WSAppTTSCPSoapClient();
            string turmas = cliente.listaTurmas();
            string[] t = turmas.Split(new Char[] { '|' });

            for (int i = 0; i < t.Length; i++)
            {
                //a estrutra da linha é sempre Nome|senha|email|tipo
                if ((!String.IsNullOrEmpty(t[i])) & (t[i].CompareTo("\0") != 0))
                {
                    TableRow tRow = new TableRow();
                    TTurmas.Rows.Add(tRow);
                    TableCell tCellIncluir = new TableCell();

                    //label da turma
                    Label l = new Label { ID = "L" + t[i], Text = t[i]+" -> "};
                    tCellIncluir.Controls.Add(l);
                    tRow.Cells.Add(tCellIncluir);

                    //Botões de associar membro com a turma
                    Button b = new Button { ID = "AM"+t[i], Text = "Add Membro", CommandArgument = t[i]};
                    b.Click += new EventHandler(btn_click);
                    tCellIncluir.Controls.Add(b);
                    tRow.Cells.Add(tCellIncluir);

                    //Botôes de associar pesquisa com a turma
                    Button bpesq = new Button { ID = "AP" + t[i], Text = "Add Pesquisa", CommandArgument = t[i] };
                    bpesq.Click += new EventHandler(btnPesq_click);
                    tCellIncluir.Controls.Add(bpesq);
                    tRow.Cells.Add(tCellIncluir);
                }
            }
        }

        protected void BVerTurmas_Click(object sender, EventArgs e)
        {
            
        }
    }
}