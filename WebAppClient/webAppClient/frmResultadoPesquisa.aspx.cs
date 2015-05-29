using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAppClient
{
    public partial class frmResultadoPesquisa : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            resultadoPesquisa();
        }

        protected void resultadoPesquisa()
        {
            WSAppTTSCP.WSAppTTSCPSoapClient cliente = new WSAppTTSCP.WSAppTTSCPSoapClient();
            String result = cliente.resultadoPesquisa(GlobalVar.TurmaAAssociar, GlobalVar.idPesquisa);
            result = result.Replace(" ", "|");
            result = result.Replace(":", "");
            result = result.Replace("Não|votaram", "Não votaram");
            string[] t = result.Split(new Char[] { '|' });

            TPesquisa.BorderStyle = BorderStyle.Solid;
            TPesquisa.BorderWidth = 1;

            TableRow tRow = new TableRow();
            TableCell tCell = new TableCell();

            int cor=0;

            for (int i = 0; i < t.Length; i+=2)
            {
                //a estrutra da linha é sempre Nome|senha|email|tipo
                if ((!String.IsNullOrEmpty(t[i])) & (t[i].CompareTo("\0") != 0))
                {
                    tRow = new TableRow();
                    tRow.BorderStyle = BorderStyle.Solid;
                    tRow.BorderColor = Color.Black;
                    tRow.BackColor = (cor % 2 == 0 ? Color.White : Color.FromArgb(100, 196, 210));
                    tRow.BorderWidth = 1;
                    TPesquisa.Rows.Add(tRow);

                    tCell = new TableCell();
                    //tCell.BorderStyle = BorderStyle.None;
                    Label l = new Label { ID = "L" + t[i], Text = t[i] };
                    tCell.Controls.Add(l);
                    tRow.Cells.Add(tCell);

                    tCell = new TableCell();
                    //tCell.BorderStyle = BorderStyle.None;
                    l = new Label { ID = "L" + t[i+1], Text = t[i+1] };
                    tCell.Controls.Add(l);
                    tRow.Cells.Add(tCell);

                    cor++;
                }
            }

        }

        protected void BVoltar_Click(object sender, EventArgs e)
        {
            Server.Transfer("frmAssociaPesquisaTurma.aspx", true);
        }
    }
}