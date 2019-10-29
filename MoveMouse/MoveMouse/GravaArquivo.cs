using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading; //as duas classes que precisamos
using System.IO;
using System.Diagnostics;

namespace MoveMouse
{
    class GravaArquivo
    {
        


        public static void GravaTxt(Mensagem meeen)
        {
            
           

            try
            {
                

                //Aqui verifico se o arquivo existe, se sim, ele é aberto
                if (System.IO.File.Exists(System.Windows.Forms.Application.StartupPath + @"\EmpataBloqueio.txt"))
                {
                    //System.Diagnostics.Process.Start(@"D:\EmpataBloqueio.txt");

                    meeen.Mensa = "s";
                }

                else
                {
                    //Abaixo usamos a classe IO para criar um txt novo
                    System.IO.StreamWriter file = new System.IO.StreamWriter(System.Windows.Forms.Application.StartupPath + @"\EmpataBloqueio.txt");
                    //System.Diagnostics.Process.Start(@"D:\EmpataBloqueio.txt");
                    meeen.Mensa = "s";
                    file.Close();
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Desculpe, ocorreu um erro na tratativa do arquivo: \"EmpataBloqueio.txt\". Comunique o erro ao administrador. Erro: " + ex.Message, " ERRO AO TRATAR ARQUIVO .txt", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                meeen.Mensa = "n";
            }

       

        }

        public static void EscreveTxt()
        {
            
            try
            {
                string escrita = "DATACENTER & HEAD END - JPA. - DATA/HORA DA MOVIMENTAÇÃO: " + DateTime.Now.ToString("dd/MM/yyyy - hh:mm");
                
                //O código abaixo abre o arquivo ou o cria caso ele não exista
                StreamWriter valorEscrito = new StreamWriter(System.Windows.Forms.Application.StartupPath + @"\EmpataBloqueio.txt", true, Encoding.UTF8);

                valorEscrito.WriteLine(escrita);

                valorEscrito.Close(); //fechamos o arquivo.
                System.Diagnostics.Process.Start(System.Windows.Forms.Application.StartupPath + @"\EmpataBloqueio.txt");

               //Ocódigo abaixo mata o notepad pra que nao se abra outra janela
              
                Process[] processes = Process.GetProcessesByName("notepad");

               foreach (Process process in processes)
               {
                   process.Kill();
               }
                
                
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Desculpe, ocorreu um erro na escrita do arquivo: \"EmpataBloqueio.txt\". Comunique o erro ao administrador. Erro: " + ex.Message, " ERRO AO ESCREVER NO ARQUIVO .txt", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);

            }
        }

        
       
    }


}
