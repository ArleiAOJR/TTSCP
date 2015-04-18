using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebAppClient;

public partial class MyMaster : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
       
    }

    public void LoadNomeMembroAutenticado()
    {
        Label l = (Label)Master.FindControl("LAutenticado");
        l.Text = GlobalVar.NomeMembroAutenticado;
    }
    
    protected string RenderMenu()
    {
        var result = new StringBuilder();
        
        if (!GlobalVar.MembroAutenticado)
        {
            RenderMenuItem("Login", "frmLogin.aspx", result);
        }
        
        if (GlobalVar.MembroAutenticado)
        {
            if (GlobalVar.TipoMembro == 0) //professor
            {
                RenderMenuItem("Turmas", "frmTurma.aspx", result);
                RenderMenuItem("Membros", "frmMembro.aspx", result);
            }
            if (GlobalVar.TipoMembro == 1) //aluno
            {
                RenderMenuItem("Turmas", "frmTurmasMembro.aspx", result);
            }
            RenderMenuItem("Altera Senha", "frmAlteraSenha.aspx", result);
            RenderMenuItem("Logout", "frmLogout.aspx", result);
        }
        return result.ToString();
    }

    void RenderMenuItem(string title, string address, StringBuilder output)
    {
        output.AppendFormat("<li><a href=\"{0}\" ", address);

        var requestUrl = HttpContext.Current.Request.Url;        
        if (requestUrl.Segments[requestUrl.Segments.Length - 1].Equals(address, StringComparison.OrdinalIgnoreCase)) // If the requested address is this menu item.
            output.Append("class=\"ActiveMenuButton\"");
        else
            output.Append("class=\"MenuButton\"");

        output.AppendFormat("><span>{0}</span></a></li> ", title);
    }
}