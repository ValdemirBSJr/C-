using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.Common;
using System.Data.OleDb;
using ICSharpCode.SharpZipLib.Zip; //adicionamos a dll que consta nesse projeto e as referencias a partir daqui
using ICSharpCode.SharpZipLib.Core;
using ICSharpCode.SharpZipLib.Checksums;
using ICSharpCode.SharpZipLib.GZip;
using System.Configuration; //precisa desa classe adicionado tbm em referencia


namespace CATAPORA_BKP
{
    class Classe
    {


        //aqui pega o usuario logado
        private String usuarioLogado;

        public String UsuarioLogado
        {
            get { return pegaUsuario(usuarioLogado); }
            set { usuarioLogado = pegaUsuario(value); }
        }

        public string pegaUsuario(string retornoUsuario)
        {//Funcao pra pegar o usuario logado
            retornoUsuario = Environment.UserName;
            return retornoUsuario;
        }


        public ToolTip retornaInfo(ToolTip retorna) //método para retornar info no tooltip
        {
            retorna.AutoPopDelay = 60000; //tempo que fica exibido se o mouse está parado
            retorna.InitialDelay = 1; //O tempo que conta para ele aparecer após o mouse parar
            retorna.ReshowDelay = 500; //O tempo que ela precisa para aparecer de novo quando o mouse para
            // Força o texto ToolTip text a ser exibido se o formulario for ativo ou não
            retorna.ShowAlways = true;
            

            return retorna;
        }

        public void SalvaCompactado(string caminhoZIP, string [] colecaoArquivos)
        {
            //para a função funcionar falta passar os valores da openfiledialog

            char delimitador = '\\'; //delimitador das pastas, vai separar pastas dos arquivos
            string nomeArquivoFim; //variavel que vai pegar o nome do arquivo pra salvar
            string[] nomeArquivo; //array que vai pegar separadamente cada pasta e por fim o nome do arquivo
            string nomeZip = caminhoZIP;
            nomeArquivo = nomeZip.Split(delimitador);
            nomeArquivoFim = nomeArquivo.Last();

            ZipOutputStream zipOutPut = new ZipOutputStream(File.Create(System.Windows.Forms.Application.StartupPath + @"\image\Exemplo.zip")); //cria um arquivo zipado na pasta para ser incluido dentro arquivos

            zipOutPut.SetLevel(5); //nível de compactação. 9 é o máximo
            //zipOutPut.Password = "12345"; bota senha no zip

           // ZipEntry arquivoSalvo = new ZipEntry(nomeArquivoFim);//Aqui vai o arquivo que será salvo
            //zipOutPut.PutNextEntry(arquivoSalvo); //aqui seto ele no arquivo

            zipOutPut.Finish(); //finaliza o arquivo
            zipOutPut.Close(); //fecha o arquivo

            ZipFile arquivoZip = new ZipFile(System.Windows.Forms.Application.StartupPath + @"\image\Exemplo.zip"); //aqui converto o arquivo criado para zip da biblioteca

            arquivoZip.BeginUpdate(); //inicia a criação do ZIP



            // arquivoZip.NameTransform = new ZipNameTransform(nomeZip.Substring(1, nomeZip.LastIndexOf("/")));
            foreach (string arquivos in colecaoArquivos)
            {
                string[] pegaNomesFinal;
                pegaNomesFinal = arquivos.Split(delimitador);
                string final = pegaNomesFinal.Last();

                arquivoZip.Add(arquivos.ToString(), final); //primeiro parametro é o caminho do arquivo, segundo o arquivo em si
            }

            arquivoZip.CommitUpdate();

            arquivoZip.Close();

        }

       


        

    }
}
