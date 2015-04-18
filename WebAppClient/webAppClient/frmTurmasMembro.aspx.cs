using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAppClient
{
    public partial class frmTurmasMembro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            carregaTurmas();
        }

        protected void BVerTurmas_Click(object sender, EventArgs e)
        {

        }
        
        protected void btn_click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            GlobalVar.TurmaAAssociar = btn.CommandArgument;
            Server.Transfer("frmMembroTurmaPesquisa.aspx", true);
        }

        protected void btnPresenca_click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            GlobalVar.TurmaAAssociar = btn.CommandArgument;
            Server.Transfer("frmMembroTurmaPresenca.aspx", true);
        }

        protected void carregaTurmas()
        {
            WSAppTTSCP.WSAppTTSCPSoapClient cliente = new WSAppTTSCP.WSAppTTSCPSoapClient();
            string turmas = cliente.listaTurmasPorMembro(GlobalVar.EmailMembroAutenticado);

            if (turmas.Length > 3)
            {

                string[] t = turmas.Split(new Char[] { '|' });

                TTurmas.BorderStyle = BorderStyle.Double;

                TableRow tRow = new TableRow();
                tRow.BorderStyle = BorderStyle.Double;
                TTurmas.Rows.Add(tRow);

                TableCell tCell = new TableCell();
                tCell.Text = "Turma";
                tCell.BorderStyle = BorderStyle.Groove;
                tRow.Cells.Add(tCell);

                tCell = new TableCell();
                tCell.Text = "Pesquisas";
                tCell.BorderStyle = BorderStyle.Groove;
                tRow.Cells.Add(tCell);

                tCell = new TableCell();
                tCell.Text = "Presença";
                tCell.BorderStyle = BorderStyle.Groove;
                tRow.Cells.Add(tCell);

                for (int i = 0; i < t.Length; i++)
                {
                    //a estrutra da linha é sempre Nome|senha|email|tipo
                    if ((!String.IsNullOrEmpty(t[i])) & (t[i].CompareTo("\0") != 0))
                    {
                        tRow = new TableRow();
                        tRow.BorderStyle = BorderStyle.Double;
                        TTurmas.Rows.Add(tRow);

                        //label da turma
                        tCell = new TableCell();
                        tCell.BorderStyle = BorderStyle.Groove;
                        Label l = new Label { ID = "L" + t[i], Text = t[i] };
                        tCell.Controls.Add(l);
                        tRow.Cells.Add(tCell);

                        //Botões acessar as pesquisas desta turma
                        tCell = new TableCell();
                        tCell.BorderStyle = BorderStyle.Groove;
                        Button b = new Button { ID = "AP" + t[i], Text = "Pesquisas", CommandArgument = t[i] };
                        b.Click += new EventHandler(btn_click);
                        tCell.Controls.Add(b);
                        tRow.Cells.Add(tCell);

                        //Botões acessar as presencas
                        tCell = new TableCell();
                        tCell.BorderStyle = BorderStyle.Groove;
                        b = new Button { ID = "Presenca" + t[i], Text = "Presença", CommandArgument = t[i] };
                        b.Click += new EventHandler(btnPresenca_click);
                        tCell.Controls.Add(b);
                        tRow.Cells.Add(tCell);
                    }
                }
            }
        }
    }
}