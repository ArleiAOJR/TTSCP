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

        }

        protected void BCriaTurma_Click(object sender, EventArgs e)
        {
            WSAppTTSCP.WSAppTTSCPSoapClient cliente = new WSAppTTSCP.WSAppTTSCPSoapClient();
            LResultado.Text = "Resultado: " + cliente.criarTurma(TBTurma.Text);
        }

        protected void BVerTurmas_Click(object sender, EventArgs e)
        {
            WSAppTTSCP.WSAppTTSCPSoapClient cliente = new WSAppTTSCP.WSAppTTSCPSoapClient();
            string turmas = cliente.listaTurmas();
            string[] t = turmas.Split(new Char[] { '|' });
            
            for (int i = 0; i<t.Length; i++)
            {
                //a estrutra da linha é sempre Nome|senha|email|tipo
                if ((!String.IsNullOrEmpty(t[i])) & (t[i].CompareTo("\0") != 0))
                {
                    TableRow tRow = new TableRow();
                    TTurmas.Rows.Add(tRow);
                    
                    TableCell tCell = new TableCell();
                    tCell.Text = "Turma: " + t[i];
                    tRow.Cells.Add(tCell);

                    TableCell tCellIncluir = new TableCell();
                    tCellIncluir.Controls.Add(new LiteralControl(""));
                    System.Web.UI.WebControls.HyperLink h = new HyperLink();
                    h.Text = "Associar membros";
                    h.NavigateUrl = "http://www.microsoft.com/net";
                    tCellIncluir.Controls.Add(h);
                    tRow.Cells.Add(tCellIncluir);
                }
            }
        }


    }
}