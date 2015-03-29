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
            GlobalVar.TurmaAAssociar = btn.ID;
            Server.Transfer("frmAssociaMembroTurma.aspx", true);
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

                    //TableCell tCell = new TableCell();
                    //tCell.Text = "Turma: " + t[i];
                    //tRow.Cells.Add(tCell);

                    TableCell tCellIncluir = new TableCell();
                    Button b = new Button { ID = t[i], Text = "Associar membros -> " + t[i] };
                    b.Click += new EventHandler(btn_click);
                    tCellIncluir.Controls.Add(b);
                    tRow.Cells.Add(tCellIncluir);
                }
            }
        }

        protected void BVerTurmas_Click(object sender, EventArgs e)
        {
            
        }
    }
}