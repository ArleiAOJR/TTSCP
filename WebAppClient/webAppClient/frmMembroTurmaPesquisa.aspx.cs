using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAppClient
{
    public partial class frmMembroTurmaPesquisa : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            carregaPesquisas();
        }

        protected void btnSim_click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            WSAppTTSCP.WSAppTTSCPSoapClient cliente = new WSAppTTSCP.WSAppTTSCPSoapClient();
            LResult.Text = cliente.adicionaVotoPesquisa(GlobalVar.TurmaAAssociar, btn.CommandArgument, GlobalVar.EmailMembroAutenticado, true);
        }

        protected void btnNao_click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            WSAppTTSCP.WSAppTTSCPSoapClient cliente = new WSAppTTSCP.WSAppTTSCPSoapClient();
            LResult.Text = cliente.adicionaVotoPesquisa(GlobalVar.TurmaAAssociar, btn.CommandArgument, GlobalVar.EmailMembroAutenticado, false);
        }

        protected void carregaPesquisas()
        {
            WSAppTTSCP.WSAppTTSCPSoapClient cliente = new WSAppTTSCP.WSAppTTSCPSoapClient();
            string listaPesquisas = cliente.listaPesquisaPorTurmaMembro(GlobalVar.TurmaAAssociar, GlobalVar.EmailMembroAutenticado);

            if (listaPesquisas.Length > 3)
            {

                string[] pesquisas = listaPesquisas.Split(new Char[] { '&' });

                TPesquisas.BorderStyle = BorderStyle.Double;

                TableRow tRow = new TableRow();
                tRow.BorderStyle = BorderStyle.Double;
                TPesquisas.Rows.Add(tRow);

                TableCell tCell = new TableCell();
                tCell.Text = "ID Pesquisa";
                tCell.BorderStyle = BorderStyle.Groove;
                tRow.Cells.Add(tCell);

                tCell = new TableCell();
                tCell.Text = "Título da Pesquisa";
                tCell.BorderStyle = BorderStyle.Groove;
                tRow.Cells.Add(tCell);

                tCell = new TableCell();
                tCell.Text = "Descrição da Pesquisa (pergunta/enquete)";
                tCell.BorderStyle = BorderStyle.Groove;
                tRow.Cells.Add(tCell);

                tCell = new TableCell();
                tCell.Text = "Data Final Para Responder";
                tCell.BorderStyle = BorderStyle.Groove;
                tRow.Cells.Add(tCell);

                tCell = new TableCell();
                tCell.Text = "Resposta (Sim)";
                tCell.BorderStyle = BorderStyle.Groove;
                tRow.Cells.Add(tCell);

                tCell = new TableCell();
                tCell.Text = "Resposta (Não)";
                tCell.BorderStyle = BorderStyle.Groove;
                tRow.Cells.Add(tCell);

                for (int i = 0; i < pesquisas.Length; i++)
                {
                    //a estrutra da linha é sempre Nome|senha|email|tipo
                    if ((!String.IsNullOrEmpty(pesquisas[i])) & (pesquisas[i].CompareTo("\0") != 0))
                    {
                        string[] pesquisa = pesquisas[i].Split(new Char[] { '|' });

                        if (pesquisa.Length > 1)
                        {
                            tRow = new TableRow();
                            tRow.BorderStyle = BorderStyle.Double;
                            TPesquisas.Rows.Add(tRow);

                            //formato dos dados Ex:
                            //1|Pesquisa 1|Pesquisa 1|2015-04-05

                            //ID da pesquisa
                            tCell = new TableCell();
                            tCell.BorderStyle = BorderStyle.Groove;
                            tCell.Text = pesquisa[0];
                            tRow.Cells.Add(tCell);

                            //Título da pesquisa
                            tCell = new TableCell();
                            tCell.BorderStyle = BorderStyle.Groove;
                            tCell.Text = pesquisa[1];
                            tRow.Cells.Add(tCell);

                            //Descricao da pesquisa
                            tCell = new TableCell();
                            tCell.BorderStyle = BorderStyle.Groove;
                            tCell.Text = pesquisa[2];
                            tRow.Cells.Add(tCell);

                            //Data da pesquisa
                            tCell = new TableCell();
                            tCell.BorderStyle = BorderStyle.Groove;
                            tCell.Text = pesquisa[3];
                            tRow.Cells.Add(tCell);

                            //Botão para votar sim
                            tCell = new TableCell();
                            tCell.BorderStyle = BorderStyle.Groove;
                            Button b = new Button { ID = "BVS" + pesquisa[0], Text = "SIM", CommandArgument = pesquisa[0] };
                            b.Click += new EventHandler(btnSim_click);
                            tCell.Controls.Add(b);
                            tRow.Cells.Add(tCell);

                            //Botão para votar não
                            tCell = new TableCell();
                            tCell.BorderStyle = BorderStyle.Groove;
                            b = new Button { ID = "BVN" + pesquisa[0], Text = "NÃO", CommandArgument = pesquisa[0] };
                            b.Click += new EventHandler(btnNao_click);
                            tCell.Controls.Add(b);
                            tRow.Cells.Add(tCell);

                        }
                    }
                }
            }
        }

        protected void BVerTurmas_Click(object sender, EventArgs e)
        {

        }
    }
}