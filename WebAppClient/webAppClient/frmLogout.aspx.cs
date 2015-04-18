using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAppClient
{
    public partial class frmLogout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BLogout_Click(object sender, EventArgs e)
        {
            GlobalVar.TipoMembro = 1;
            GlobalVar.MembroAutenticado = false;
            GlobalVar.NomeMembroAutenticado = "";
            GlobalVar.EmailMembroAutenticado = "";
            GlobalVar.TurmaAAssociar = "";
            GlobalVar.idPesquisa = "";
            GlobalVar.emailMembroAExlcuir = "";
            Server.Transfer("frmLogin.aspx", true);
        }
    }
}