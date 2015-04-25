using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Services;

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
    
    [TestFixture]
    
    public class WSAppTTSCP : System.Web.Services.WebService
    {
        private const string folderName = @"c:\TTSCP";
        //private const string folderName = @"~\TTSCP";

//-------------------------------------------------------------------------------------------------------------------------------
//--IMPLEMENTAÇÃO DOS TESTES-----------------------------------------------------------------------------------------------------
//-------------------------------------------------------------------------------------------------------------------------------

        [Test]
        public void config_testes()
        {
            criarTurma("Teste0001");
            associaMembroTurma("arlei.aojr@gmail.com", "Teste0001");
            associaMembroTurma("arlei.aojr2@gmail.com", "Teste0001");
            criarTurma("Teste0002");
            associaMembroTurma("arlei.aojr@gmail.com", "Teste0002");
            associaMembroTurma("arlei.aojr2@gmail.com", "Teste0002");
        }

        [Test]
        public void test_adicionaPesquisa_CaracterePipeNoTituloDaPesquisa()
        {
            string result = adicionaPesquisa("Teste0001", "Pesq|0001", "Teste 0001", "10/03/2015");
            if (result.CompareTo("Erro: O caracter | não pode ser usado para o título da pesquisa!") == 0)
            {
                Assert.Pass();
            }
        }

        [Test]
        public void test_adicionaPesquisa_CaracterePipeNaDescricaoDaPesquisa()
        {
            string result = adicionaPesquisa("Teste0001", "Pesq0001", "Teste |0001", "10/03/2015");
            if (result.CompareTo("Erro: O caracter | não pode ser usado para a descrição da pesquisa!") == 0)
            {
                Assert.Pass();
            }
        }

        [Test]
        public void test_adicionaPesquisa_TamanhoMaiorQuePermitidoNoTituloDaPesquisa()
        {
            string result = adicionaPesquisa("Teste0001", "123456789012345678901234567890123456789012345678901", "Teste0001", "10/03/2015");
            if (result.CompareTo("Erro: Título da pesquisa não pode ter mais de 50 caracteres!") == 0)
            {
                Assert.Pass();
            }
        }

        [Test]
        public void test_adicionaPesquisa_TamanhoMaiorQuePermitidoNaDescricaoDaPesquisa()
        {
            string result = adicionaPesquisa("Teste0001", "12345678901234567890123456789012345678901234567890",
                "1234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890" +
                "1234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890" +
                "123456789012345678901234567890123456789012345678901", "10/03/2015");
            if (result.CompareTo("Erro: Descrição da pesquisa não pode ter mais de 250 caracteres!") == 0)
            {
                Assert.Pass();
            }
        }

        [Test]
        public void test_adicionaPesquisa_NaoFoiPossivelRecuperarIdDaPesquisa()
        {
            string result = adicionaPesquisa("TesteNaoExiste", "TesteNaoExiste", "TesteNaoExiste", "10/03/2015");
            if (result.CompareTo("Erro: Não foi possível adicionar pesquisa!") == 0)
            {
                Assert.Pass();
            }
        }

        [Test]
        public void test_adicionaPesquisa_PesquisaAdicionadaComSucesso()
        {
            string result = adicionaPesquisa("Teste0002", "PesquisaTeste0002", "PesquisaTeste0002", "10/03/2015");
            if (result.CompareTo("Pesquisa adicionada com sucesso!") == 0)
            {
                Assert.Pass();
            }
        }

        [Test]
        public void test_adicionaPesquisa_NaoExistemMembrosNaTurma()
        {
            string result = adicionaPesquisa("Teste0001", "PesquisaTeste0001", "PesquisaTeste0001", "10/03/2015");
            if (result.CompareTo("Erro: Não existem membros para esta turma. Pesquisa não pode ser adicionada!") == 0)
            {
                Assert.Pass();
            }
        }

        [Test]
        public void test_adicionaVotoPesquisa_Sucesso()
        {
            string result = adicionaVotoPesquisa("Teste0002", "1", "arlei.aojr@gmail.com", true);
            if (result.CompareTo("Voto computado com sucesso!") == 0)
            {
                Assert.Pass();
            }
        }

        [Test]
        public void test_adicionaVotoPesquisa_NaoFoiPossivelAdicionarVotoNaPesquisa()
        {
            string result = adicionaVotoPesquisa("", "", "", true);
            if (result.CompareTo("Erro: Este arquivo de pesquisas não existe!") == 0)
            {
                Assert.Pass();
            }
        }

        [Test]
        public void test_adicionaVotoPesquisa_MembroJaRespondeuPesquisa()
        {
            string result = adicionaVotoPesquisa("Teste0002", "1", "arlei.aojr@gmail.com", true);
            if (result.CompareTo("Erro: Este membro já respondeu esta pesquisa!") == 0)
            {
                Assert.Pass();
            }
        }
        
        [Test]
        public void test_emailJaInlcuidoTurma_Success()
        {
            bool result = emailJaInlcuidoTurma("arlei.aojr@gmail.com", "Turma0001");
            Assert.IsTrue(result);
        }

        [Test]
        public void test_emailJaInlcuidoTurma_IsEmailEmpty()
        {
            bool result = emailJaInlcuidoTurma("", "Turma0001");
            Assert.IsFalse(result);
        }

        [Test]
        public void test_emailJaInlcuidoTurma_IsTurmaEmpty()
        {
            bool result = emailJaInlcuidoTurma("arlei.aojr@gmail.com", "");
            Assert.IsFalse(result);
        }

        [Test]
        public void test_emailJaInlcuidoTurma_IsEmailTurmaEmpty()
        {
            bool result = emailJaInlcuidoTurma("", "");
            Assert.IsFalse(result);
        }

        [Test]
        public void test_emailExists_Success()
        {
            bool result = emailExists("arlei.aojr@gmail.com");
            Assert.IsTrue(result);
        }

        [Test]
        public void test_emailExists_Fail()
        {
            bool result = emailExists("arle.aojr@gmail.com");
            Assert.IsFalse(result);
        }

        [Test]
        public void test_emailExists_IsEmailEmpty()
        {
            bool result = emailExists("");
            Assert.IsFalse(result);
        }

        [Test]
        public void test_dadosMembro_IsEmailEmpty()
        {
            string result = dadosMembro("");
            if (result.CompareTo("Email informado vazio!") == 0)
            {
                Assert.Pass();
            }
        }

        [Test]
        public void test_dadosMembro_EmailNaoEncontrado()
        {
            string result = dadosMembro("arlei.");
            if (result.CompareTo("Membro não encontrado!") == 0)
            {
                Assert.Pass();
            }
        }

        [Test]
        public void test_dadosMembro_EmailEncontrado()
        {
            string result = dadosMembro("arlei.aojr@gmail.com");
            if (result.CompareTo("Arlei de Almeida|arlei.aojr@gmail.com|0") == 0)
            {
                Assert.Pass();
            }
        }

        [Test]
        public void test_idPesquisa_Work()
        {
            int id = Convert.ToInt32(idPesquisa("Teste0001"));
            int nextId = Convert.ToInt32(idPesquisa("Teste0001"));
            Assert.AreEqual(id + 1, nextId);
        }

        [Test]
        public void test_idPesquisa_ArquivoNaoExiste()
        {
            string id = idPesquisa("TesteNaoExiste");
            if (id.CompareTo("Não foi possível recuperar o ID da pesquisa!") == 0)
            {
                Assert.Pass();
            }
        }

        

        [Test]
        public void test_autenticaMembroTest_Success()
        {
            bool result = autenticaMembro("arlei.aojr@gmail.com", "123");
            Assert.IsTrue(result);
        }

        [Test]
        public void test_autenticaMembroTest_Fail()
        {
            bool result = autenticaMembro("", "");
            Assert.IsFalse(result);
        }

        [Test]
        public void z_config_testes()
        {
            excluirTurma("Teste0001");
            excluirTurma("Teste0002");
        }
//-------------------------------------------------------------------------------------------------------------------------------
//--FINAL DA IMPLEMENTAÇÃO DOS TESTES--------------------------------------------------------------------------------------------
//-------------------------------------------------------------------------------------------------------------------------------

//-------------------------------------------------------------------------------------------------------------------------------
//--IMPLEMENTAÇÃO DOS SERVIÇOS---------------------------------------------------------------------------------------------------
//-------------------------------------------------------------------------------------------------------------------------------

        private bool emailJaInlcuidoTurma(string email, string turma)
        {
            if ((!String.IsNullOrEmpty(email)) && (!String.IsNullOrEmpty(turma)))
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
            }
            return false;
        }

   
        private bool emailExists(string email)
        {
            if (!String.IsNullOrEmpty(email))
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
            }
            return false;
        }            

        [WebMethod]
        public string dadosMembro(string email)
        {
            if (!String.IsNullOrEmpty(email))
            {
                string dadosReturn = "";
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
                                dadosReturn = dados[0] + "|" + dados[2] + "|" + dados[3];
                                return dadosReturn;
                            }
                        }
                    }
                }
                return "Membro não encontrado!";
            }
            return "Email informado vazio!";
        }

        private string idPesquisa(string turma)
        {
            string pesquisaNextID = System.IO.Path.Combine(folderName, turma, "Pesquisas_NextID.txt");
            string nextID = "1";
            try
            {
                FileMode fm = new FileMode();
                if (File.Exists(pesquisaNextID))
                {
                    fm = FileMode.Open;
                    using (System.IO.FileStream f = new FileStream(pesquisaNextID, fm, FileAccess.ReadWrite))
                    {
                        using (StreamReader sr = new StreamReader(f, Encoding.ASCII))
                        {
                            nextID = Convert.ToString(Convert.ToInt32(sr.ReadLine()) + 1);
                            sr.Close();
                        }
                    }
                    fm = FileMode.Create;
                    using (System.IO.FileStream f = new FileStream(pesquisaNextID, fm, FileAccess.ReadWrite))
                    {
                        using (StreamWriter sw = new StreamWriter(f, Encoding.ASCII))
                        {
                            sw.WriteLine(nextID);
                            sw.Close();
                        }
                    }
                }
                else
                {
                    fm = FileMode.Create;
                    using (System.IO.FileStream f = new FileStream(pesquisaNextID, fm, FileAccess.ReadWrite))
                    {
                        using (StreamWriter sw = new StreamWriter(f, Encoding.ASCII))
                        {
                            sw.WriteLine("1");
                            sw.Close();
                        }
                    }
                }
            }
            catch (Exception e)
            {
                return "Não foi possível recuperar o ID da pesquisa!";
            }
            return nextID;
        }

        private static string dataCorrente()
        {
            DateTime dt = DateTime.Now;
            return String.Format("{0:yyyyMMdd}", dt);
        }

        [WebMethod]
        public string presencaInicia(string turma)
        {
            if (String.IsNullOrEmpty(turma))
            {
                return "";
            }
            
            if (turma.IndexOf('\0')>-1)
            {
                return "";
            }

            string codigoPresenca = System.IO.Path.Combine(folderName, turma, "codigo_presenca.txt");
            string membrosTurma = System.IO.Path.Combine(folderName, turma, turma+"_membros.txt");
            string nextCode = "";
           
            Random randNum = new Random();
            nextCode = Convert.ToString(randNum.Next());
                               
            using (System.IO.FileStream f = new FileStream(codigoPresenca, FileMode.Create, FileAccess.Write))
            {
                using (StreamWriter sw = new StreamWriter(f, Encoding.ASCII))
                {
                    sw.WriteLine(nextCode);
                    sw.Close();
                }
            }

            string arquivoPresenca = System.IO.Path.Combine(folderName, turma, "presencaApontamento" + dataCorrente()+ ".txt");
            string arquivoPresencaTemp = System.IO.Path.Combine(folderName, turma, "presencaApontamento" + dataCorrente() + ".tmp");
            string arquivoPresencaBkp = System.IO.Path.Combine(folderName, turma, "presencaApontamento" + dataCorrente() + ".bkp");

            System.IO.File.Copy(membrosTurma, arquivoPresenca, true);

            using (FileStream fs = new FileStream(arquivoPresenca, FileMode.Open, FileAccess.Read))
            {
                using (StreamReader sr = new StreamReader(fs, Encoding.ASCII))
                {
                    using (FileStream fsTmp = new FileStream(arquivoPresencaTemp, FileMode.Create, FileAccess.Write))
                    {
                        using (StreamWriter sw = new StreamWriter(fsTmp, Encoding.ASCII))
                        {
                            string strLinha = null;
                            while ((strLinha = sr.ReadLine()) != null)
                            {
                                sw.WriteLine(strLinha+"|F");
                            }
                        }
                    }
                }
            }

            try
            {
                System.IO.File.Move(arquivoPresenca, arquivoPresencaBkp);
                System.IO.File.Move(arquivoPresencaTemp, arquivoPresenca);
                System.IO.File.Delete(arquivoPresencaBkp);
            }
            catch (Exception e)
            {
                return "Não foi possível iniciar a chamada!";
            }

            return nextCode;
        }

        [WebMethod]
        public string presencaAtualiza(string turma, string membro, string codigoPresenca)
        {
            string codigoPresencaInFile = "";
            string arquivoCodigoPresenca = System.IO.Path.Combine(folderName, turma, "codigo_presenca.txt");
            string arquivoPresenca = System.IO.Path.Combine(folderName, turma, "presencaApontamento" + dataCorrente() + ".txt");
            string arquivoPresencaTemp = System.IO.Path.Combine(folderName, turma, "presencaApontamento" + dataCorrente() + ".tmp");
            string arquivoPresencaBkp = System.IO.Path.Combine(folderName, turma, "presencaApontamento" + dataCorrente() + ".bkp");

            using (System.IO.FileStream f = new FileStream(arquivoCodigoPresenca, FileMode.Open, FileAccess.Read))
            {
                using (StreamReader sr = new StreamReader(f, Encoding.ASCII))
                {
                    codigoPresencaInFile = sr.ReadLine();
                    sr.Close();
                }
            }

            if (!String.IsNullOrEmpty(codigoPresencaInFile))
            {
                if (codigoPresencaInFile.CompareTo(codigoPresenca) == 0)
                {
                    using (FileStream fs = new FileStream(arquivoPresenca, FileMode.Open, FileAccess.Read))
                    {
                        using (StreamReader sr = new StreamReader(fs, Encoding.ASCII))
                        {
                            using (FileStream fsTmp = new FileStream(arquivoPresencaTemp, FileMode.Create, FileAccess.Write))
                            {
                                using (StreamWriter sw = new StreamWriter(fsTmp, Encoding.ASCII))
                                {
                                    string strLinha = null;
                                    while ((strLinha = sr.ReadLine()) != null)
                                    {
                                        if (strLinha.IndexOf(membro) > -1)
                                        {
                                            sw.WriteLine(membro + "|P");
                                        }
                                        else
                                        {
                                            sw.WriteLine(strLinha);
                                        }
                                    }
                                }
                            }
                        }
                    }

                    try
                    {
                        System.IO.File.Move(arquivoPresenca, arquivoPresencaBkp);
                        System.IO.File.Move(arquivoPresencaTemp, arquivoPresenca);
                        System.IO.File.Delete(arquivoPresencaBkp);
                    }
                    catch (Exception e)
                    {
                        return "Não foi possível computar sua presença!";
                    }
                }
                else
                {
                    return "Código de presença informado inválido!";
                }
            }
            else
            {
                return "A chamada para hoje já foi encerrada!";
            }

            return "Presença computada com sucesso!";
        }

        [WebMethod]
        public string presencaBoletim(string turma, int filtro)
        {
            //filtro 0 - Todos, 1 - Faltantes, 2 - Presentes

            string result = "";

            string caminhoTurma = System.IO.Path.Combine(folderName, turma);
            DirectoryInfo Dir = new DirectoryInfo(caminhoTurma);
            // Busca automaticamente todos os arquivos em todos os subdiretórios
            FileInfo[] Files = Dir.GetFiles("*", SearchOption.AllDirectories);
            foreach (FileInfo File in Files)
            {
                string nomeFile = File.FullName.ToString();
                if (nomeFile.IndexOf("presencaApontamento")>-1)
                {
                    string linha;
                    string nomeCurto = File.Name.ToString();
                    string data = nomeCurto.Substring(25, 2) + "/" + nomeCurto.Substring(23, 2) + "/" + nomeCurto.Substring(19, 4);
                    result = result + "-----" + data + "-----&";
                    using (System.IO.FileStream f = new FileStream(nomeFile, FileMode.Open, FileAccess.Read))
                    {
                        using (StreamReader sr = new StreamReader(f, Encoding.ASCII))
                        {
                            while ((linha = sr.ReadLine()) != null)
                            {
                                if (!String.IsNullOrEmpty(linha))
                                {
                                    if (filtro == 0)
                                    {
                                        result = result + linha + "&";
                                    }
                                    else if (filtro == 1)
                                    {
                                        if (linha.IndexOf("|F") > -1)
                                        {
                                            result = result + linha + "&";
                                        }
                                    }
                                    else if (filtro == 2)
                                    {
                                        if (linha.IndexOf("|P") > -1)
                                        {
                                            result = result + linha + "&";
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return result;
        }

        [WebMethod]
        public string presencaFinaliza(string turma)
        {
            string codigoPresenca = System.IO.Path.Combine(folderName, turma, "codigo_presenca.txt");

            using (System.IO.FileStream f = new FileStream(codigoPresenca, FileMode.Create, FileAccess.Write))
            {
                using (StreamWriter sw = new StreamWriter(f, Encoding.ASCII))
                {
                    sw.WriteLine("");
                    sw.Close();
                }
            }
            return "Lançamento de faltas finalizado!";
        }

        [WebMethod]
        public string excluirPesquisa(string turma, string idPesquisa)
        {
            //o arquivo de pesquisas terá o seguinte formato
            //ID|Titulo|Descricao|Data

            string pesquisaDesc = System.IO.Path.Combine(folderName, turma, "Pesquisas_Desc.txt");
            string pesquisaDescTemp = System.IO.Path.Combine(folderName, turma, "Pesquisas_Desc.tmp");
            string pesquisaDescBkp = System.IO.Path.Combine(folderName, turma, "Pesquisas_Desc.bkp");
            string pesquisaVotos = System.IO.Path.Combine(folderName, turma, "Pesquisa" + idPesquisa + ".txt");


            if (File.Exists(pesquisaVotos))
            {
                using (FileStream fs = new FileStream(pesquisaDesc, FileMode.Open, FileAccess.Read))
                {
                    using (StreamReader sr = new StreamReader(fs, Encoding.ASCII))
                    {
                        using (FileStream fsTmp = new FileStream(pesquisaDescTemp, FileMode.Create, FileAccess.Write))
                        {
                            using (StreamWriter sw = new StreamWriter(fsTmp, Encoding.ASCII))
                            {
                                string strLinha = null;
                                while ((strLinha = sr.ReadLine()) != null)
                                {
                                    if (!(strLinha.IndexOf(idPesquisa + "|") > -1))
                                    {
                                        sw.WriteLine(strLinha);
                                    }
                                }
                            }
                        }
                    }
                }
                try
                {
                    System.IO.File.Move(pesquisaDesc, pesquisaDescBkp);
                    System.IO.File.Move(pesquisaDescTemp, pesquisaDesc);
                    System.IO.File.Delete(pesquisaDescBkp);
                    System.IO.File.Delete(pesquisaVotos);
                }
                catch (Exception e0)
                {
                    return "Não foi possível exlcuir a pesquisa " + idPesquisa;
                }
                return "Pesquisa excluída com sucesso!";
            }
            else
            {
                return "Pesquisa não encontrada!";
            }
        }

        [WebMethod]
        public string adicionaPesquisa(string turma, string pesquisa, string descricao, string data)
        {
            //o arquivo de pesquisas terá o seguinte formato
            //ID|Titulo|Descricao|Data
            string pesquisaDesc = System.IO.Path.Combine(folderName, turma, "Pesquisas_Desc.txt");
            
            if (pesquisa.IndexOf('|')>-1)
            {
                return "Erro: O caracter | não pode ser usado para o título da pesquisa!";
            }

            if (descricao.IndexOf('|')>-1)
            {
                return "Erro: O caracter | não pode ser usado para a descrição da pesquisa!";
            }

            if (pesquisa.Length>50)
            {
                return "Erro: Título da pesquisa não pode ter mais de 50 caracteres!";
            }

            if (descricao.Length>250)
            {
                return "Erro: Descrição da pesquisa não pode ter mais de 250 caracteres!";
            }

            string nextID = idPesquisa(turma);

            if (nextID.CompareTo("Não foi possível recuperar o ID da pesquisa!") == 0)
            {
                return "Erro: Não foi possível adicionar pesquisa!";
            }
            else
            {
                string pesquisaVotos = System.IO.Path.Combine(folderName, turma, "Pesquisa"+nextID+".txt");
                try
                {
                    string membrosTurma = System.IO.Path.Combine(folderName, turma, turma + "_membros.txt");

                    try
                    {
                        System.IO.File.Copy(membrosTurma, pesquisaVotos);
                    }
                    catch (Exception e)
                    {
                        return "Erro: Não existem membros para esta turma. Pesquisa não pode ser adicionada!";
                    }
                                 
                    FileMode fm = new FileMode();
                    if (File.Exists(pesquisaDesc))
                    {
                        fm = FileMode.Append;
                    }
                    else
                    {
                        fm = FileMode.Create;
                    }

                    using (System.IO.FileStream fs = new FileStream(pesquisaDesc, fm, FileAccess.Write))
                    {
                        using (StreamWriter sw = new StreamWriter(fs, Encoding.ASCII))
                        {
                            //ID|Titulo|Descricao|Data
                            sw.WriteLine(nextID+"|"+pesquisa+"|"+descricao+"|"+data);
                            sw.Close();
                        }
                    }
                }
                catch (Exception e)
                {
                    return "Erro: Não foi possível adicionar pesquisa!";
                }
            }

            return "Pesquisa adicionada com sucesso!";
        }


        [WebMethod]
        public string adicionaVotoPesquisa(string turma, string idPesquisa, string email, bool voto)
        {
            string pesquisaVotos = System.IO.Path.Combine(folderName, turma, "Pesquisa" + idPesquisa + ".txt");
            string pesquisaVotosTemp = System.IO.Path.Combine(folderName, turma, "Pesquisa" + idPesquisa + ".temp");
            string pesquisaBKP = System.IO.Path.Combine(folderName, turma, "Pesquisa" + idPesquisa + ".bkp");
            string strVoto = "";

            if (!File.Exists(pesquisaVotos))
            {
                return "Erro: Este arquivo de pesquisas não existe!";
            }

            if (voto) 
            {
                strVoto="1";
            }
            else 
            {
                strVoto="0";
            }
            
            using (FileStream fs = new FileStream(pesquisaVotos, FileMode.Open, FileAccess.Read))
            {
                using (StreamReader sr = new StreamReader(fs, Encoding.ASCII))
                {
                    using (FileStream fsTmp = new FileStream(pesquisaVotosTemp, FileMode.Create, FileAccess.Write))
                    {
                        using (StreamWriter sw = new StreamWriter(fsTmp, Encoding.ASCII))
                        {
                            string strLinha = null;
                            while ((strLinha = sr.ReadLine()) != null)
                            {
                                if (strLinha.IndexOf(email) > -1)
                                {
                                    if (strLinha.IndexOf("|") > -1)
                                    {
                                        return "Erro: Este membro já respondeu esta pesquisa!";
                                    }
                                    strLinha = strLinha.Replace(email, email+"|"+strVoto);
                                }
                                sw.WriteLine(strLinha);
                            }
                        }
                    }
                }
            }
            try
            {
                System.IO.File.Move(pesquisaVotos, pesquisaBKP);
                System.IO.File.Move(pesquisaVotosTemp, pesquisaVotos);
                System.IO.File.Delete(pesquisaBKP);
            }
            catch (Exception e0)
            {
                return "Não foi possível adicionar o voto!";
            }
            return "Voto computado com sucesso!";
        }

        [WebMethod]
        public string resultadoPesquisa(string turma, string idPesquisa)
        {
            string pesquisaVotos = System.IO.Path.Combine(folderName, turma, "Pesquisa" + idPesquisa + ".txt");
            int sim = 0;
            int nao = 0;
            int nulo = 0;
            int total = 0;

            using (FileStream fs = new FileStream(pesquisaVotos, FileMode.Open, FileAccess.Read))
            {
                using (StreamReader sr = new StreamReader(fs, Encoding.ASCII))
                {
                    string strLinha = null;
                    while ((strLinha = sr.ReadLine()) != null)
                    {
                        if (strLinha.IndexOf("|0") > -1)
                        {
                            nao++;
                        }
                        else if (strLinha.IndexOf("|1") > -1)
                        {
                            sim++;
                        }
                        else
                        {
                            nulo++;
                        }
                        total++;
                    }
                }
            }
            return "Total: " + Convert.ToString(total) + " Sim: " + Convert.ToString(sim) + " Não: " + Convert.ToString(nao) + " Não votaram: " + Convert.ToString(nulo);
        }

        [WebMethod]
        public string listaPesquisasDaTurma(string turma)
        {
            //o arquivo de pesquisas terá o seguinte formato
            //ID|Titulo|Descricao|Data
            string pesquisaDesc = System.IO.Path.Combine(folderName, turma, "Pesquisas_Desc.txt");
            String listaPesquisas = "";

            if (File.Exists(pesquisaDesc))
            {
                using (FileStream fs = new FileStream(pesquisaDesc, FileMode.Open, FileAccess.Read))
                {
                    using (StreamReader sr = new StreamReader(fs, Encoding.ASCII))
                    {
                        string strLinha = null;
                        while ((strLinha = sr.ReadLine()) != null)
                        {
                            listaPesquisas = listaPesquisas + strLinha + "&";
                        }
                    }
                }
            }
            else
            {
                return "Não existem pesquisas associados a esta turma!";
            }
            return listaPesquisas;
        }

        [WebMethod]
        public string dadosTodosMembrosTurma(string turma)
        {
            string caminhoArquivoTurma = System.IO.Path.Combine(folderName, turma, turma + "_membros.txt");
            String listaAlunos = "";

            if (File.Exists(caminhoArquivoTurma))
            {
                using (FileStream fs = new FileStream(caminhoArquivoTurma, FileMode.Open, FileAccess.Read))
                {
                    using (StreamReader sr = new StreamReader(fs, Encoding.ASCII))
                    {
                        string strLinha = null;
                        while ((strLinha = sr.ReadLine()) != null)
                        {
                            listaAlunos = listaAlunos + dadosMembro(strLinha) + "&";         
                        }
                    }
                }
            }
            else
            {
                return "Não existem alunos associados a esta turma!";
            }
            return listaAlunos;
        }

        [WebMethod]
        public string dadosTodosMembros()
        {
            string caminhoArquivo = System.IO.Path.Combine(folderName, "membros.txt");
            String listaMembros = "";

            if (File.Exists(caminhoArquivo))
            {
                using (FileStream fs = new FileStream(caminhoArquivo, FileMode.Open, FileAccess.Read))
                {
                    using (StreamReader sr = new StreamReader(fs, Encoding.ASCII))
                    {
                        string strLinha = null;
                        while ((strLinha = sr.ReadLine()) != null)
                        {
                            string[] dados = strLinha.Split(new Char[] { '|' });
                            string tipoMembro = "";
                            if (dados[3].CompareTo("0")==0)
                            {
                                tipoMembro = "Professor(a)";
                            }
                            else
                            {
                                tipoMembro = "Aluno(a)";
                            }
                            listaMembros = listaMembros + dados[0] + "|" + dados[2] + "|" + tipoMembro + "&";
                        }
                    }
                }
            }
            else
            {
                return "Não existem membros cadastrados!";
            }
            return listaMembros;
        }

        [WebMethod]
        public string retiraMembroTurma(string email, string turma)
        {
            string membrosTurmaFile = System.IO.Path.Combine(folderName, turma, turma + "_membros.txt");
            string membrosTurmaFileTemp = System.IO.Path.Combine(folderName, turma, turma + "_membros.tmp");
            string membrosTurmaFileBkp = System.IO.Path.Combine(folderName, turma, turma + "_membros.bkp");

            if (emailJaInlcuidoTurma(email, turma))
            {
                using (FileStream fs = new FileStream(membrosTurmaFile, FileMode.Open, FileAccess.Read))
                {
                    using (StreamReader sr = new StreamReader(fs, Encoding.ASCII))
                    {
                        using (FileStream fsTmp = new FileStream(membrosTurmaFileTemp, FileMode.Create, FileAccess.Write))
                        {
                            using (StreamWriter sw = new StreamWriter(fsTmp, Encoding.ASCII))
                            {
                                string strLinha = null;
                                while ((strLinha = sr.ReadLine()) != null)
                                {
                                    if (!(strLinha.IndexOf(email) > -1))
                                    {
                                        sw.WriteLine(strLinha);
                                    }
                                }
                            }
                        }
                    }
                }
                try
                {
                    System.IO.File.Move(membrosTurmaFile, membrosTurmaFileBkp);
                    System.IO.File.Move(membrosTurmaFileTemp, membrosTurmaFile);
                    System.IO.File.Delete(membrosTurmaFileBkp);
                }
                catch (Exception e0)
                {
                    return "Não foi possível retirar o membro "+email+" desta turma!";
                }
                return "Membro retirado da base da turma com sucesso!";
            }
            else
            {
                return "Este membro não pertence a esta turma!";
            }
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

        protected bool membroDestaTurma(string turma, string email)
        {
            string caminhoMembrosTurma = System.IO.Path.Combine(folderName, turma, turma+"_membros.txt");
            if (File.Exists(caminhoMembrosTurma))
            {
                string[] linhas = System.IO.File.ReadAllLines(caminhoMembrosTurma);

                foreach (string l in linhas)
                {
                    //a estrutra da linha é sempre Nome|senha|email|tipo
                    if ((!String.IsNullOrEmpty(l)) & (l.CompareTo("\0") != 0))
                    {
                        if (l.CompareTo(email) == 0)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        
        [WebMethod]
        public string listaTurmasPorMembro(string email)
        {
            if (email.Length<5)
            {
                return "Informe o email para busca!";
            }
            
            string lista_aux = listaTurmas();
            string lista = "";

            if (lista_aux.CompareTo("Não há turmas cadastradas!")!=0)
            {
                string[] turmas = lista_aux.Split(new Char[] { '|' });
                for (int i=0; i<turmas.Length; i++)
                {
                    if (turmas[i].Length > 3)
                    {
                        if (membroDestaTurma(turmas[i], email))
                        {
                            lista = lista + turmas[i] + "|";
                        }
                    }
                }
                if (lista.CompareTo("")==0)
                {
                    return "Este membro não está associado a nenhuma turma!";
                }
                return lista;
            }
            return "Não foram encontradas turmas para este membro!";
        }

        protected bool membroDestaPesquisa(string turma, string pesquisa, string email)
        {
            string caminhoMembrosTurmaPesquisa = System.IO.Path.Combine(folderName, turma, pesquisa);
            if (File.Exists(caminhoMembrosTurmaPesquisa))
            {
                string[] linhas = System.IO.File.ReadAllLines(caminhoMembrosTurmaPesquisa);

                foreach (string l in linhas)
                {
                    //a estrutra da linha é sempre Nome|senha|email|tipo
                    if ((!String.IsNullOrEmpty(l)) & (l.CompareTo("\0") != 0))
                    {
                        if (l.CompareTo(email) == 0)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }


        [WebMethod]
        public string listaPesquisaPorTurmaMembro(string turma, string email)
        {
            if (email.Length < 5)
            {
                return "Informe o email para busca!";
            }

            if (email.Length < 3)
            {
                return "Informe o turma para busca!";
            }

            string listaPesquisasTurma = listaPesquisasDaTurma(turma);

            if (listaPesquisasTurma.CompareTo("Não existem pesquisas associados a esta turma!") != 0)
            {
                string lPesquisasMembro = "";
                string[] pesquisas = listaPesquisasTurma.Split(new Char[] { '&' });
                
                //lista de todas as pesquisas da turma
                for (int i=0; i<pesquisas.Length; i++)
                {
                    if (pesquisas[i].Length > 3)
                    {
                        string[] pesquisa = pesquisas[i].Split(new Char[] { '|' });

                        //formato dos dados Ex:
                        //1|Pesquisa 1|Pesquisa 1|2015-04-05
                        if (membroDestaPesquisa(turma, "Pesquisa"+pesquisa[0]+".txt", email))
                        {
                            lPesquisasMembro = lPesquisasMembro + pesquisa[0] + "|" + pesquisa[1] + "|" + pesquisa[2] + "|" + pesquisa[3] + "&";
                        }
                    }
                }
                if (lPesquisasMembro.CompareTo("")==0)
                {
                    return "Não foram encontradas pesquisas para este membro!";
                }
                return lPesquisasMembro;
            }
            return "Não foram encontradas pesquisas para este membro nesta turma!";
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
        public string excluirTurma(string turma)
        {
            string caminhoCompleto = System.IO.Path.Combine(folderName, turma);

            if (Directory.Exists(caminhoCompleto))
            {
                try
                {
                    System.IO.Directory.Delete(caminhoCompleto, true);
                    return "Turma excluída com sucesso!";
                }
                catch (Exception e)
                {
                    string erro = e.InnerException.ToString();
                    return "Não foi possível excluir a turma!\n" + e.Message.ToString() + erro;
                }
            }
            else
            {
                return "Turma não encontrada!";
            }
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

        [WebMethod]
        public string exlcuirMembro(string emailMembro)
        {
            string membrosFile = System.IO.Path.Combine(folderName, "membros.txt");
            string membrosFileTemp = System.IO.Path.Combine(folderName, "membros.tmp");
            string membrosFileBkp = System.IO.Path.Combine(folderName, "membros.bkp");

            string turmasDoMembro = listaTurmasPorMembro(emailMembro);

            if ((turmasDoMembro.CompareTo("Este membro não está associado a nenhuma turma!") == 0) ||
                (turmasDoMembro.CompareTo("Não foram encontradas turmas para este membro!") == 0))
            {
                using (FileStream fs = new FileStream(membrosFile, FileMode.Open, FileAccess.Read))
                {
                    using (StreamReader sr = new StreamReader(fs, Encoding.ASCII))
                    {
                        using (FileStream fsTmp = new FileStream(membrosFileTemp, FileMode.Create, FileAccess.Write))
                        {
                            using (StreamWriter sw = new StreamWriter(fsTmp, Encoding.ASCII))
                            {
                                string strLinha = null;
                                while ((strLinha = sr.ReadLine()) != null)
                                {
                                    if (!(strLinha.IndexOf(emailMembro) > -1))
                                    {
                                        sw.WriteLine(strLinha);
                                    }
                                }
                            }
                        }
                    }
                }
                try
                {
                    System.IO.File.Move(membrosFile, membrosFileBkp);
                    System.IO.File.Move(membrosFileTemp, membrosFile);
                    System.IO.File.Delete(membrosFileBkp);
                }
                catch (Exception e0)
                {
                    return "Não foi possível exlcuir o membro " + emailMembro;
                }
                return "Membro excluído com sucesso!";
            }
            else
            {
                return "Este membro não pode ser excluído! As seguintes turmas estão associadas a ele: " + turmasDoMembro;
            }

        }
//-------------------------------------------------------------------------------------------------------------------------------
//--FINAL IMPLEMENTAÇÃO DOS SERVIÇOS---------------------------------------------------------------------------------------------
//-------------------------------------------------------------------------------------------------------------------------------
    }
}