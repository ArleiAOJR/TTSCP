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
            LResultado.Text = "Resultado: " + cliente.criarMembro(TBNomeMembro.Text, TBEmailMembro.Text, Convert.ToInt32(DDLTipoMembro.SelectedValue));
        }

        protected void BVerMembros_Click(object sender, EventArgs e)
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
                    TMembros.Rows.Add(tRow);
                    
                    TableCell tCell = new TableCell();
                    tCell.Text = "Nome: " + mIndividual[0];
                    tRow.Cells.Add(tCell);

                    TableCell tCell2 = new TableCell();
                    tCell2.Text = "e-Mail: " + mIndividual[1];
                    tRow.Cells.Add(tCell2);

                    TableCell tCell3 = new TableCell();
                    tCell3.Text = "Tipo: " + mIndividual[2];
                    tRow.Cells.Add(tCell3);
                }
            }
        }
        
    }
}