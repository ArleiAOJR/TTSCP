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
            string membros = cliente.associaMembroTurma(btn.ID, GlobalVar.TurmaAAssociar);
        }

         protected void todosMembrosTurma()
         {
             WSAppTTSCP.WSAppTTSCPSoapClient cliente = new WSAppTTSCP.WSAppTTSCPSoapClient();
             string membros = cliente.dadosTodosMembrosTurma(GlobalVar.TurmaAAssociar);
             if (membros.CompareTo("Não existem alunos associados a esta turma!") != 0)
             { 
                 string[] m = membros.Split(new Char[] { '&' });

                 for (int i = 0; i < m.Length; i++)
                 {
                     if ((!String.IsNullOrEmpty(m[i])) & (m[i].CompareTo("\0") != 0))
                     {
                         string[] mIndividual = m[i].Split(new Char[] { '|' });

                         TableRow tRow = new TableRow();
                         TMembrosAssociados.Rows.Add(tRow);

                         TableCell tCell = new TableCell();
                         tCell.Text = "Nome: " + mIndividual[0];
                         tRow.Cells.Add(tCell);

                         TableCell tCell2 = new TableCell();
                         tCell2.Text = "e-Mail: " + mIndividual[1];
                         tRow.Cells.Add(tCell2);

                         string tipoMembro = "";

                         if (mIndividual[2].CompareTo("0") == 0)
                         {
                             tipoMembro = "Professor(a)";
                         }
                         else
                         {
                             tipoMembro = "Aluno(a)";
                         }

                         TableCell tCell3 = new TableCell();
                         tCell3.Text = "Tipo: " + tipoMembro;
                         tRow.Cells.Add(tCell3);
                     }
                 }
             }
         }

        protected void todosMembros()
        {
            WSAppTTSCP.WSAppTTSCPSoapClient cliente = new WSAppTTSCP.WSAppTTSCPSoapClient();
            string membros = cliente.dadosTodosMembros();
            string[] m = membros.Split(new Char[] { '&' });
            
            for (int i = 0; i<m.Length; i++)
            {
                if ((!String.IsNullOrEmpty(m[i])) & (m[i].CompareTo("\0") != 0))
                {
                    string[] mIndividual = m[i].Split(new Char[] { '|' });
                               
                    TableRow tRow = new TableRow();
                    TTodosOsMembros.Rows.Add(tRow);
                    
                    TableCell tCell = new TableCell();
                    tCell.Text = "Nome: " + mIndividual[0];
                    tRow.Cells.Add(tCell);

                    TableCell tCell2 = new TableCell();
                    tCell2.Text = "e-Mail: " + mIndividual[1];
                    tRow.Cells.Add(tCell2);
                    
                    TableCell tCell3 = new TableCell();
                    tCell3.Text = "Tipo: " + mIndividual[2];
                    tRow.Cells.Add(tCell3);

                    TableCell tCellIncluir = new TableCell();
                    Button b = new Button { ID =  mIndividual[1], Text = "Associar este membro..." };
                    b.Click += new EventHandler(btn_click);
                    tCellIncluir.Controls.Add(b);
                    tRow.Cells.Add(tCellIncluir);
                }
            }
        }
        
    }

}