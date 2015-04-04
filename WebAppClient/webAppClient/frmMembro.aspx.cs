using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAppClient
{
    public partial class frmMembro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void BIncluirMembro_Click(object sender, EventArgs e)
        {
            WSAppTTSCP.WSAppTTSCPSoapClient cliente = new WSAppTTSCP.WSAppTTSCPSoapClient();
            
            if (TBNomeMembro.Text.Length<3)
            {
                LResultado.Text = "Resultado: Preencha o nome do membro!";
                return;
            }

            if (TBEmailMembro.Text.Length < 3)
            {
                LResultado.Text = "Resultado: Preencha o e-mail do membro!";
                return;
            }

            LResultado.Text = "Resultado: " + cliente.criarMembro(TBNomeMembro.Text, TBEmailMembro.Text, Convert.ToInt32(DDLTipoMembro.SelectedValue));
        }

        protected void BVerMembros_Click(object sender, EventArgs e)
        {
            WSAppTTSCP.WSAppTTSCPSoapClient cliente = new WSAppTTSCP.WSAppTTSCPSoapClient();
            string membros = cliente.dadosTodosMembros();

            if (membros.CompareTo("Não existem membros cadastrados!") != 0)
            {
                string[] m = membros.Split(new Char[] { '&' });

                TMembros.BorderStyle = BorderStyle.Double;
                TableRow tRow = new TableRow();
                tRow.BorderStyle = BorderStyle.Double;
                TMembros.Rows.Add(tRow);

                TableCell tCell = new TableCell();
                tCell.Text = "Nome do Membro";
                tCell.BorderStyle = BorderStyle.Groove;
                tRow.Cells.Add(tCell);

                tCell = new TableCell();
                tCell.Text = "E-mail do Membro";
                tCell.BorderStyle = BorderStyle.Groove;
                tRow.Cells.Add(tCell);

                tCell = new TableCell();
                tCell.Text = "Tipo do Membro";
                tCell.BorderStyle = BorderStyle.Groove;
                tRow.Cells.Add(tCell);

                for (int i = 0; i < m.Length; i++)
                {
                    if ((!String.IsNullOrEmpty(m[i])) & (m[i].CompareTo("\0") != 0))
                    {
                        string[] mIndividual = m[i].Split(new Char[] { '|' });

                        tRow = new TableRow();
                        tRow.BorderStyle = BorderStyle.Double;
                        TMembros.Rows.Add(tRow);

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

                        //tipo do membr
                        tCell = new TableCell();
                        tCell.BorderStyle = BorderStyle.Groove;
                        tCell.Text = mIndividual[2];
                        tRow.Cells.Add(tCell);
                    }
                }
            }
        }
        
    }
}