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

        private bool emailJaInlcuidoTurma(string email, string turma)
        {
            string caminhoArquivo = System.IO.Path.Combine(folderName, turma, turma + "_membros.txt");
            if (File.Exists(caminhoArquivo))
            {
                //verificando se o membro já foi adicionado
                using (FileStream fs = new FileStream(caminhoArquivo, FileMode.Open, FileAccess.Read))
                {
                    using (StreamReader sr = new StreamReader(fs, Encoding.ASCII))
                    {
                        string strLinha = null;
                        while ((strLinha = sr.ReadLine()) != null)
                        {
                            if (strLinha.IndexOf(email) > -1)
                            {
                                return true;         
                            }
                                    
                        }
                    }
                }
            }
            return false;
        }

        private bool emailExists(string email)
        {
            string caminhoArquivo = System.IO.Path.Combine(folderName, "membros.txt");

            if (File.Exists(caminhoArquivo))
            {
                string[] linhas = System.IO.File.ReadAllLines(caminhoArquivo);

                foreach (string l in linhas)
                {
                    //a estrutra da linha é sempre Nome|senha|email|tipo
                    if ((!String.IsNullOrEmpty(l)) & (l.CompareTo("\0") != 0))
                    {
                        string[] dados = l.Split(new Char[] { '|' });
                        if (dados[2].CompareTo(email) == 0)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        [WebMethod]
        public string associaMembroTurma(string email, string turma)
        {
            string caminhoCompleto = System.IO.Path.Combine(folderName, turma, turma+"_membros.txt");

            if (!emailJaInlcuidoTurma(email, turma))
            {
                try
                {
                    FileMode fm = new FileMode();
                    if (File.Exists(caminhoCompleto))
                    {
                        fm = FileMode.Append;
                    }
                    else
                    {
                        fm = FileMode.Create;
                    }

                    using (System.IO.FileStream fs = new FileStream(caminhoCompleto, fm, FileAccess.Write))
                    {
                        using (StreamWriter sw = new StreamWriter(fs, Encoding.ASCII))
                        {
                            sw.WriteLine(email);
                            sw.Close();
                        }
                    }
                }
                catch (Exception e)
                {
                    return "Não foi possível adicionar o membro na turma. Erro na base de dados!";
                }
            }
            else
            {
                return "Este membro já foi adicionado a turma!";
            }
            return "Membro adicionado na base da turma com sucesso!";
        }


        [WebMethod]
        public bool autenticaMembro(string email, string pass)
        {
            string caminhoArquivo = System.IO.Path.Combine(folderName, "membros.txt");
            if (File.Exists(caminhoArquivo))
            {
                string[] linhas = System.IO.File.ReadAllLines(caminhoArquivo);

                foreach (string l in linhas)
                {
                    //a estrutra da linha é sempre Nome|senha|email|tipo
                    if ((!String.IsNullOrEmpty(l)) & (l.CompareTo("\0") != 0))
                    {
                        string[] dados = l.Split(new Char[] { '|' });
                        if ((dados[2].CompareTo(email) == 0) & (dados[1].CompareTo(pass) == 0))
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        [WebMethod]
        public string alteraSenha(string email, string currentPass, string newPass)
        {
            string caminhoArquivo = System.IO.Path.Combine(folderName, "membros.txt");
            string caminhoArquivoTemp = System.IO.Path.Combine(folderName, "membrosTemp.txt");

            if (newPass.IndexOf("|") > -1)
            {
                return "Senha não pode conter o caracter | !";
            }

            if (newPass.Length > 15) 
            {
                return "Senha não pode ter mais que 15 caracteres!";
            }
            
            if (autenticaMembro(email, currentPass))
            {
                try
                {
                    if (File.Exists(caminhoArquivo))
                    {
                        //encontrando o password e alterando
                        using (FileStream fs = new FileStream(caminhoArquivo, FileMode.Open, FileAccess.Read))
                        {
                            using (StreamReader sr = new StreamReader(fs, Encoding.ASCII))
                            {
                                using (FileStream fsTmp = new FileStream(caminhoArquivoTemp, FileMode.Create, FileAccess.Write))
                                {
                                    using (StreamWriter sw = new StreamWriter(fsTmp, Encoding.ASCII))
                                    {
                                        string strLinha = null;
                                        while ((strLinha = sr.ReadLine()) != null)
                                        {
                                            if (strLinha.IndexOf(email) > -1)
                                            {
                                                strLinha = strLinha.Replace(currentPass, newPass);
                                            }
                                            sw.WriteLine(strLinha);
                                        }
                                    }
                                }
                            }
                        }
                    }
                    //renomear o arquivo com o nome novo.
                    string dataCorrente = DateTime.Now.ToString("yyyyMMddHmmss");
                    try
                    {
                        System.IO.File.Move(caminhoArquivo, caminhoArquivo.Replace(".txt", dataCorrente) + ".txt");
                        System.IO.File.Move(caminhoArquivoTemp, caminhoArquivo);
                        return "Senha alterada com sucesso!";
                    }
                    catch (Exception e0) {
                        return "Não foi possível alterar a senha. Erro ao atualizar a base de dados!";
                    } 
                }
                catch (Exception e1)
                {
                    return "Não foi possível alterar a senha. Erro ao acessar a base de dados!";
                }
            }
            else
            {
                return "Senha atual não confere!";
            }
        }

        [WebMethod]
        public string listaTurmas()
        {
            if (!Directory.Exists(folderName))
            {
                return "Não há turmas cadastradas!";
            }

            DirectoryInfo dir = new DirectoryInfo(folderName);
            string lista = "";
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
        public string criarMembro(string nomeMembro, string emailMembro, int tipoMembro)
        {
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

            if (emailMembro.Length > 50)
            {
                return "E-mail não pode ter mais que 50 caracteres!";
            }

            string nomeMask = @"^([\'\.\^\~\´\`\\áÁ\\àÀ\\ãÃ\\âÂ\\éÉ\\èÈ\\êÊ\\íÍ\\ìÌ\\óÓ\\òÒ\\õÕ\\ôÔ\\úÚ\\ùÙ\\çÇaA-zZ]+)+((\s[\'\.\^\~\´\`\\áÁ\\àÀ\\ãÃ\\âÂ\\éÉ\\èÈ\\êÊ\\íÍ\\ìÌ\\óÓ\\òÒ\\õÕ\\ôÔ\\úÚ\\ùÙ\\çÇaA-zZ]+)+)?$";
            match = Regex.Match(nomeMembro, nomeMask);
            if (!match.Success)
            {
                return "Nome inválido!";
            }

            if (nomeMembro.Length > 50)
            {
                return "Nome não pode ter mais que 50 caracteres!";
            }

            if ((tipoMembro != 0) & (tipoMembro != 1))
            {
                return "Tipo de membro inválido!";
            }
            //validacoes dos dados----------------------------------------------------------------------------

            //verifica se email já não está na base-----------------------------------------------------------
            if (emailExists(emailMembro))
            {
                return "Este e-mail já foi adicionado na base!";
            }
            //verifica se email já não está na base-----------------------------------------------------------

            string caminhoCompleto = System.IO.Path.Combine(folderName, "membros.txt");
            string pass = "password";

            try
            {
                FileMode fm = new FileMode();
                if (File.Exists(caminhoCompleto)) 
                {
                    fm = FileMode.Append;
                }
                else
                {
                    fm = FileMode.Create;
                }
                
                using (System.IO.FileStream fs = new FileStream(caminhoCompleto, fm, FileAccess.Write))
                {
                    using (StreamWriter sw = new StreamWriter(fs, Encoding.ASCII))
                    {
                        sw.WriteLine(nomeMembro + "|" + pass + "|" + emailMembro + "|" + Convert.ToString(tipoMembro));
                        sw.Close();
                    }
                }
            }
            catch (Exception e)
            {
                return "Não foi possível adicionar o membro!";
            }

            return "Membro adicionado com sucesso!";
        }

    }

}