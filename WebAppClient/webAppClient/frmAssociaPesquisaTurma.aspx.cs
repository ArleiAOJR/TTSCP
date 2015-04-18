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
            carregaPesquisas();
        }

        protected void BIncluirMembro_Click(object sender, EventArgs e)
        {
            if (TBTituloPesquisa.Text.Length <5)
            {
                LResultado.Text = "Resultado: O título da pesquisa deve ter pelo menos 5 caracteres!";
                return;
            }

            if (TBDescricaoPesquisa.Text.Length < 10)
            {
                LResultado.Text = "Resultado: A descrição (pergunta) deve ter pelo menos 10 caracteres!";
                return;
            }
                  
            WSAppTTSCP.WSAppTTSCPSoapClient cliente = new WSAppTTSCP.WSAppTTSCPSoapClient();
            string result = cliente.adicionaPesquisa(GlobalVar.TurmaAAssociar, TBTituloPesquisa.Text, TBDescricaoPesquisa.Text, TBData.Text);    
            LResultado.Text = "Resultado: " + result;

            if (result.CompareTo("Pesquisa adicionada com sucesso!")==0)
            {
                TBData.Text = "";
                TBDescricaoPesquisa.Text = "";
                TBTituloPesquisa.Text = "";
            }

        }

        protected void btnResultado_click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            GlobalVar.idPesquisa = btn.CommandArgument;
            Server.Transfer("frmResultadoPesquisa.aspx", true);
        }

        protected void btnExcluiPesquisa_click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            GlobalVar.idPesquisa = btn.CommandArgument;
            Server.Transfer("frmPesquisaDelete.aspx", true);
        }
        

        protected void BVerPesquisas_Click(object sender, EventArgs e)
        {
            
        }

        protected void carregaPesquisas()
        {
            WSAppTTSCP.WSAppTTSCPSoapClient cliente = new WSAppTTSCP.WSAppTTSCPSoapClient();
            string pesquisas = cliente.listaPesquisasDaTurma(GlobalVar.TurmaAAssociar);

            if (pesquisas.CompareTo("Não existem pesquisas associados a esta turma!") != 0)
            {
                string[] p = pesquisas.Split(new Char[] { '&' });

                TPesquisas.BorderStyle = BorderStyle.Double;

                TableRow tRow = new TableRow();
                tRow.BorderStyle = BorderStyle.Double;
                TPesquisas.Rows.Add(tRow);

                TableCell tCell = new TableCell();
                tCell.Text = "ID Pesquisa";
                tCell.BorderStyle = BorderStyle.Groove;
                tRow.Cells.Add(tCell);

                tCell = new TableCell();
                tCell.Text = "Título";
                tCell.BorderStyle = BorderStyle.Groove;
                tRow.Cells.Add(tCell);

                tCell = new TableCell();
                tCell.Text = "Descrição (pergunta)";
                tCell.BorderStyle = BorderStyle.Groove;
                tRow.Cells.Add(tCell);

                tCell = new TableCell();
                tCell.Text = "Data Final Para Votação";
                tCell.BorderStyle = BorderStyle.Groove;
                tRow.Cells.Add(tCell);

                tCell = new TableCell();
                tCell.Text = "Resultado";
                tCell.BorderStyle = BorderStyle.Groove;
                tRow.Cells.Add(tCell);

                tCell = new TableCell();
                tCell.Text = "Excluir Pesquisa";
                tCell.BorderStyle = BorderStyle.Groove;
                tRow.Cells.Add(tCell);

                for (int i = 0; i < p.Length; i++)
                {
                    if ((!String.IsNullOrEmpty(p[i])) & (p[i].CompareTo("\0") != 0))
                    {
                        string[] pDados = p[i].Split(new Char[] { '|' });

                        tRow = new TableRow();
                        tRow.BorderStyle = BorderStyle.Double;

                        //id da pesquisa
                        TPesquisas.Rows.Add(tRow);
                        tCell = new TableCell();
                        tCell.Text = pDados[0];
                        tCell.BorderStyle = BorderStyle.Groove;
                        tRow.Cells.Add(tCell);

                        //titulo da pesquisa
                        TPesquisas.Rows.Add(tRow);
                        tCell = new TableCell();
                        tCell.Text = pDados[1];
                        tCell.BorderStyle = BorderStyle.Groove;
                        tRow.Cells.Add(tCell);

                        //descricao da pesquisa
                        tCell = new TableCell();
                        tCell.Text = pDados[2];
                        tCell.BorderStyle = BorderStyle.Groove;
                        tRow.Cells.Add(tCell);

                        //data final para votação
                        tCell = new TableCell();
                        tCell.Text = pDados[3];
                        tCell.BorderStyle = BorderStyle.Groove;
                        tRow.Cells.Add(tCell);

                        //Botão para ver resultado
                        tCell = new TableCell();
                        tCell.BorderStyle = BorderStyle.Groove;
                        Button bresultado = new Button { ID = "BR" + pDados[0], Text = "Resultado", CommandArgument = pDados[0] };
                        bresultado.Click += new EventHandler(btnResultado_click);
                        tCell.Controls.Add(bresultado);
                        tRow.Cells.Add(tCell);

                        //Botão para excluir pesquisa
                        tCell = new TableCell();
                        tCell.BorderStyle = BorderStyle.Groove;
                        Button bExlcuiPesq = new Button { ID = "BExlcuiPesquisa" + pDados[0], Text = "Excluir Pesquisa", CommandArgument = pDados[0] };
                        bExlcuiPesq.Click += new EventHandler(btnExcluiPesquisa_click);
                        tCell.Controls.Add(bExlcuiPesq);
                        tRow.Cells.Add(tCell);
                    }
                }
            }
        }


    }
}