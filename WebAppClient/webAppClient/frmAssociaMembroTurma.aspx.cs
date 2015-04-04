using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAppClient
{
    public partial class frmAssociaMembroTurma : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LTurma.Text = "Turma: " + GlobalVar.TurmaAAssociar;
            todosMembros();
            todosMembrosTurma();
        }

         protected void btn_click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            WSAppTTSCP.WSAppTTSCPSoapClient cliente = new WSAppTTSCP.WSAppTTSCPSoapClient();
            LUltimaAcao.Text = "Última ação: " + cliente.associaMembroTurma(btn.ID, GlobalVar.TurmaAAssociar);
        }

         protected void todosMembrosTurma()
         {
             WSAppTTSCP.WSAppTTSCPSoapClient cliente = new WSAppTTSCP.WSAppTTSCPSoapClient();
             string membros = cliente.dadosTodosMembrosTurma(GlobalVar.TurmaAAssociar);
             if (membros.CompareTo("Não existem alunos associados a esta turma!") != 0)
             { 
                 string[] m = membros.Split(new Char[] { '&' });

                 TableRow tRow = new TableRow();
                 tRow.BorderStyle = BorderStyle.Double;
                 TMembrosAssociados.Rows.Add(tRow);

                 //nome do membro
                 TableCell tCell = new TableCell();
                 tCell.BorderStyle = BorderStyle.Groove;
                 tCell.Text = "Nome do Membro";
                 tRow.Cells.Add(tCell);

                 //email do membro
                 tCell = new TableCell();
                 tCell.BorderStyle = BorderStyle.Groove;
                 tCell.Text = "Email do Membro";
                 tRow.Cells.Add(tCell);

                 //tipo do membro
                 tCell = new TableCell();
                 tCell.BorderStyle = BorderStyle.Groove;
                 tCell.Text = "Tipo do Membro";
                 tRow.Cells.Add(tCell);

                 for (int i = 0; i < m.Length; i++)
                 {
                     if ((!String.IsNullOrEmpty(m[i])) & (m[i].CompareTo("\0") != 0))
                     {
                         string[] mIndividual = m[i].Split(new Char[] { '|' });

                         tRow = new TableRow();
                         tRow.BorderStyle = BorderStyle.Double;
                         TMembrosAssociados.Rows.Add(tRow);

                         //nome do membro
                         tCell = new TableCell();
                         tCell.BorderStyle = BorderStyle.Groove;
                         tCell.Text = mIndividual[0];
                         tRow.Cells.Add(tCell);

                         //email do membro
                         tCell = new TableCell();
                         tCell.BorderStyle = BorderStyle.Groove;
                         tCell.Text = mIndividual[1];
                         tRow.Cells.Add(tCell);

                         string tipoMembro = "";

                         if (mIndividual[2].CompareTo("0") == 0)
                         {
                             tipoMembro = "Professor(a)";
                         }
                         else
                         {
                             tipoMembro = "Aluno(a)";
                         }

                         //tipo do membro
                         tCell = new TableCell();
                         tCell.BorderStyle = BorderStyle.Groove;
                         tCell.Text = tipoMembro;
                         tRow.Cells.Add(tCell);
                     }
                 }
             }
         }

        protected void todosMembros()
        {
            WSAppTTSCP.WSAppTTSCPSoapClient cliente = new WSAppTTSCP.WSAppTTSCPSoapClient();
            string membros = cliente.dadosTodosMembros();

            if (membros.CompareTo("Não existem membros cadastrados!") != 0)
            {
                string[] m = membros.Split(new Char[] { '&' });

                TableRow tRow = new TableRow();
                tRow.BorderStyle = BorderStyle.Double;
                TTodosOsMembros.Rows.Add(tRow);

                //nome do membro
                TableCell tCell = new TableCell();
                tCell.BorderStyle = BorderStyle.Groove;
                tCell.Text = "Nome do Membro";
                tRow.Cells.Add(tCell);

                //email do membro
                tCell = new TableCell();
                tCell.BorderStyle = BorderStyle.Groove;
                tCell.Text = "Email do Membro";
                tRow.Cells.Add(tCell);

                //tipo do membro
                tCell = new TableCell();
                tCell.BorderStyle = BorderStyle.Groove;
                tCell.Text = "Tipo do Membro";
                tRow.Cells.Add(tCell);

                //botão de adicionar membro
                tCell = new TableCell();
                tCell.BorderStyle = BorderStyle.Groove;
                tCell.Text = "Add Membro";
                tRow.Cells.Add(tCell);
                
                for (int i = 0; i < m.Length; i++)
                {
                    if ((!String.IsNullOrEmpty(m[i])) & (m[i].CompareTo("\0") != 0))
                    {
                        string[] mIndividual = m[i].Split(new Char[] { '|' });

                        tRow = new TableRow();
                        tRow.BorderStyle = BorderStyle.Double;
                        TTodosOsMembros.Rows.Add(tRow);

                        //nome do membro
                        tCell = new TableCell();
                        tCell.BorderStyle = BorderStyle.Groove;
                        tCell.Text = mIndividual[0];
                        tRow.Cells.Add(tCell);

                        //email do membro
                        tCell = new TableCell();
                        tCell.BorderStyle = BorderStyle.Groove;
                        tCell.Text = mIndividual[1];
                        tRow.Cells.Add(tCell);

                        //tipo do membro
                        tCell = new TableCell();
                        tCell.BorderStyle = BorderStyle.Groove;
                        tCell.Text = mIndividual[2];
                        tRow.Cells.Add(tCell);

                        //botão para adicionar membro
                        tCell = new TableCell();
                        tCell.BorderStyle = BorderStyle.Groove;
                        Button b = new Button { ID = mIndividual[1], Text = " + " };
                        b.Click += new EventHandler(btn_click);
                        tCell.Controls.Add(b);
                        tRow.Cells.Add(tCell);
                    }
                }
            }
        }

        protected void BAtualiza_Click(object sender, EventArgs e)
        {

        }
        
    }

}