using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAppClient
{
    public partial class frmAssociaPesquisaTurma : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BIncluirMembro_Click(object sender, EventArgs e)
        {
            WSAppTTSCP.WSAppTTSCPSoapClient cliente = new WSAppTTSCP.WSAppTTSCPSoapClient();
            LResultado.Text = "Resultado: " + cliente.adicionaPesquisa(GlobalVar.TurmaAAssociar, TBTituloPesquisa.Text, TBDescricaoPesquisa.Text, TBData.Text);
        }

        protected void BVerPesquisas_Click(object sender, EventArgs e)
        {
            WSAppTTSCP.WSAppTTSCPSoapClient cliente = new WSAppTTSCP.WSAppTTSCPSoapClient();
            string pesquisas = cliente.listaPesquisasDaTurma(GlobalVar.TurmaAAssociar);
            string[] p = pesquisas.Split(new Char[] { '&' });

            TPesquisas.BorderStyle = BorderStyle.Double;

            TableRow tRow = new TableRow();
            tRow.BorderStyle = BorderStyle.Double;
            TPesquisas.Rows.Add(tRow);
            
            TableCell tCell = new TableCell();
            tCell.Text = "Título";
            tCell.BorderStyle = BorderStyle.Solid;
            tRow.Cells.Add(tCell);

            tCell = new TableCell();
            tCell.Text = "Descrição (pergunta)";
            tCell.BorderStyle = BorderStyle.Solid;
            tRow.Cells.Add(tCell);

            tCell = new TableCell();
            tCell.Text = "Data Final Para Votação";
            tCell.BorderStyle = BorderStyle.Solid;
            tRow.Cells.Add(tCell);

            for (int i = 0; i < p.Length; i++)
            {
                if ((!String.IsNullOrEmpty(p[i])) & (p[i].CompareTo("\0") != 0))
                {
                    string[] pDados = p[i].Split(new Char[] { '|' });

                    tRow = new TableRow();
                    tRow.BorderStyle = BorderStyle.Double;

                    TPesquisas.Rows.Add(tRow);
                    tCell = new TableCell();
                    tCell.Text = pDados[1];
                    tCell.BorderStyle = BorderStyle.Solid;
                    tRow.Cells.Add(tCell);

                    tCell = new TableCell();
                    tCell.Text = pDados[2];
                    tCell.BorderStyle = BorderStyle.Solid;
                    tRow.Cells.Add(tCell);
                    
                    tCell = new TableCell();
                    tCell.Text = pDados[3];
                    tCell.BorderStyle = BorderStyle.Solid;
                    tRow.Cells.Add(tCell);
                }
            }
        }

       
    }
}