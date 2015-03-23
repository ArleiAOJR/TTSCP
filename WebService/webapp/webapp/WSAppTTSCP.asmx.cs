using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.IO;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace webapp
{
       
    /// <summary>
    /// Summary description for WSAppTTSCP
    /// </summary>
    [WebService(Namespace = "WSAppTTSCP")] //deve-se colocar aqui o namespace a ser usado nas aplicações
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WSAppTTSCP : System.Web.Services.WebService
    {
        private const string folderName = @"c:\TTSCP";
        //private const string folderName = @"~\TTSCP";

        static byte[] stringToByteArray(string str)
        {
            byte[] bytes = new byte[str.Length * sizeof(char)];
            System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }
        
        private int randomPass()
        {
            Random randNum = new Random();
            return randNum.Next();
        }

        private bool emailExists(string email, string turma)
        {
            string caminhoArquivo = System.IO.Path.Combine(folderName, turma, "membros.txt");
            string[] linhas = System.IO.File.ReadAllLines(caminhoArquivo);

            foreach (string l in linhas)
            {
                //a estrutra da linha é sempre Nome|senha|email|tipo
                if ((!String.IsNullOrEmpty(l)) & (l.CompareTo("\0")!=0))
                {
                    string[] dados = l.Split(new Char[] { '|' });
                    if (dados[2].CompareTo(email) == 0)
                    {
                        return true;
                    }
                }
            }
            return false;
        }


        [WebMethod]
        public bool autenticaMembro(string email, string pass, string turma, int tipoMembro)
        {
            string caminhoArquivo = System.IO.Path.Combine(folderName, turma, "membros.txt");         
            string[] linhas = System.IO.File.ReadAllLines(caminhoArquivo);
            string tipo = Convert.ToString(tipoMembro);

            foreach (string l in linhas)
            {
                //a estrutra da linha é sempre Nome|senha|email|tipo
                if ((!String.IsNullOrEmpty(l)) & (l.CompareTo("\0") != 0))
                {
                    string[] dados = l.Split(new Char[] { '|' });
                    if ((dados[2].CompareTo(email) == 0) & (dados[1].CompareTo(pass) == 0) & (dados[3].CompareTo(tipo) == 0))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        [WebMethod]
        private string enviaSenha(string pass, string emailDestino, string turma)
        {
            try
            {
                SmtpClient email = new SmtpClient();
                email.Host = "smtp.gmail.com";
                email.Port = 465;
                email.EnableSsl = true;
                email.Credentials = new NetworkCredential("arlei.aojr@gmail.com", "@A4rl3!jr");
                email.UseDefaultCredentials = true;
                MailMessage mensagem = new MailMessage();
                mensagem.From = new MailAddress("arlei.aojr@gmail.com");
                mensagem.Subject = "Bem vindo!";
                mensagem.To.Add(emailDestino);
                mensagem.Body = "Bem vindo ao sistema TTSCP! Sua senha é: " + pass;
                email.Send(mensagem);
            }
            catch (Exception e)
            {
                string erro = e.InnerException.ToString();
                return e.Message.ToString() + erro;
            }
            return "Mensagem enviada para  " + emailDestino + " às " + DateTime.Now.ToString() + ".";
        }

        [WebMethod]
        public string listaTurmas()
        {
            if (!Directory.Exists(folderName))
            {
                return "Não há turmas cadastradas!";
            }
            
            DirectoryInfo dir = new DirectoryInfo(folderName);
            string lista="";
            // para cada sub-diretorio 
            foreach (DirectoryInfo dir2 in dir.GetDirectories())
            {
                // adiciona diretorio ao no corrente
                lista = lista + dir2.Name + '|';
            }
            return lista;
        }

        [WebMethod]
        public string criarTurma(string turma)
        {
            string turmaMask = "^[a-zA-Z0-9]+$";
            Match match = Regex.Match(turma, turmaMask);
            if (!match.Success)
            {
                return "Turma inválida!";
            }
            
            string caminhoCompleto = System.IO.Path.Combine(folderName, turma);

            if (Directory.Exists(caminhoCompleto)) 
            {
                return "Turma já existe!";
            }
                  
            try
            {
                System.IO.Directory.CreateDirectory(caminhoCompleto);
            }
            catch (Exception e)
            {
                string erro = e.InnerException.ToString();
                return "Não foi possível criar a turma!\n" + e.Message.ToString() + erro;
            }
            return "Turma criada com sucesso!";
        }
        
        
        [WebMethod]
        public string criarMembro(string turma, string nomeMembro, string emailMembro, int tipoMembro) {
            //formato dos dados dos membros
            //nome do membro|password|email do membro|tipo do membro
            //o divisor de dados é o PIPE | (então não se deve permitir nenhum dado com o PIPE no momento da criação
            //tipoMembro = 0 - Professor
            //tipoMembro = 1 - Aluno
            

            //validacoes dos dados----------------------------------------------------------------------------
            string emailMask = @"^([\w\-]+\.)*[\w\- ]+@([\w\- ]+\.)+([\w\-]{2,3})$";
            Match match = Regex.Match(emailMembro, emailMask);
            if (!match.Success)
            {
                return "Email inválido!";    
            }

            string nomeMask = @"^([\'\.\^\~\´\`\\áÁ\\àÀ\\ãÃ\\âÂ\\éÉ\\èÈ\\êÊ\\íÍ\\ìÌ\\óÓ\\òÒ\\õÕ\\ôÔ\\úÚ\\ùÙ\\çÇaA-zZ]+)+((\s[\'\.\^\~\´\`\\áÁ\\àÀ\\ãÃ\\âÂ\\éÉ\\èÈ\\êÊ\\íÍ\\ìÌ\\óÓ\\òÒ\\õÕ\\ôÔ\\úÚ\\ùÙ\\çÇaA-zZ]+)+)?$";
            match = Regex.Match(nomeMembro, nomeMask);
            if (!match.Success)
            {
                return "Nome inválido!";
            }

            if ((tipoMembro != 0) & (tipoMembro != 1))
            {
                return "Tipo de membro inválido!";
            }
            //validacoes dos dados----------------------------------------------------------------------------

            string caminhoCompleto = System.IO.Path.Combine(folderName, turma, "membros.txt"); 
            string pass = "|" + Convert.ToString(randomPass());

            if (!System.IO.File.Exists(caminhoCompleto))
            {
                try
                {
                    using (System.IO.FileStream fs = System.IO.File.Create(caminhoCompleto))
                    {
                        fs.Write(stringToByteArray(nomeMembro), 0, nomeMembro.Length * sizeof(char));
                        fs.Write(stringToByteArray(pass), 0, pass.Length * sizeof(char));
                        emailMembro = "|" + emailMembro;
                        fs.Write(stringToByteArray(emailMembro), 0, emailMembro.Length * sizeof(char));
                        string tipo = "|" + Convert.ToString(tipoMembro);
                        fs.Write(stringToByteArray(tipo), 0, tipo.Length * sizeof(char));
                        fs.Close();
                    }
                }
                catch (Exception e)
                {
                    return "Não foi possível adicionar o membro!";
                }
            }
            else //arquivo de membros já criado - apenas adicionar membro 
            {
                //verifica se email já não está na base-----------------------------------------------------------
                if (emailExists(emailMembro, turma))
                {
                    return "Este e-mail já foi adicionado na base!";
                }
                //verifica se email já não está na base-----------------------------------------------------------
                
                try
                {
                    using (System.IO.FileStream fs = System.IO.File.OpenWrite(caminhoCompleto))
                    {
                        byte[] newLine = Encoding.Unicode.GetBytes(Environment.NewLine);
                        fs.Seek(0, SeekOrigin.End);
                        fs.Write(newLine, 0, newLine.Length);
                        fs.Seek(0, SeekOrigin.End);
                        fs.Write(stringToByteArray(nomeMembro), 0, nomeMembro.Length * sizeof(char));
                        fs.Write(stringToByteArray(pass), 0, pass.Length * sizeof(char));
                        emailMembro = "|" + emailMembro;
                        fs.Write(stringToByteArray(emailMembro), 0, emailMembro.Length * sizeof(char));
                        string tipo = "|" + Convert.ToString(tipoMembro);
                        fs.Write(stringToByteArray(tipo), 0, tipo.Length * sizeof(char));
                        fs.Close();
                    }
                }
                catch (Exception e)
                {
                    return "Não foi possível adicionar o membro!";
                }
            
            }            
            //enviaSenha(pass, email, turma);
            return "Membro adicionado com sucesso!";
        }

    }
}
