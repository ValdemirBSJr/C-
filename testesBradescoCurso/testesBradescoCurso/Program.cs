using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows;

namespace testesBradescoCurso
{
    class Program
    {
        static void metodo()
        {
            int i, j;

            j = 0;

            for (i = 0; i <= 100; i++)
            {
                if (j == 10)
                {
                    Console.WriteLine(i);
                    j = 1;
                }
                else
                {
                    j++;
                }
            }
            
        }
        //############################################################################
        //### COMENTEI AS COISAS AO AVANÇAR, PARA VER FUNCIONANDO, Só DESCOMENTAR ####
        //############################################################################
        static void Main(string[] args)
        {//Solve

           // Console.Write("Bem-vindo ao C#");
           // Console.WriteLine();
           // Console.WriteLine("Linha 1");
           // Console.WriteLine("Linha 2");
           // string retorna = Console.ReadLine();
            
           ////abaixo limpa o console
           // Console.Clear();
           // Console.WriteLine(retorna);

           // //pega valor digitado e converte para inteiro e multiplica
           // Console.Write("Digite um valor para ser multiplicado por 2..: ");
           // String numero = Console.ReadLine();
           // int numer = Convert.ToInt16(numero) * 2;
           // Console.WriteLine(numero = Convert.ToString(numer));

           

           // metodo();

            //########## FILE STREAM ###############################

            //byte[] byteArray;
            //UnicodeEncoding uniEnconding = new UnicodeEncoding();
            
            //FileStream fss = new FileStream(@"D:\testeBradesco.txt", FileMode.Create, FileAccess.ReadWrite);

            //byteArray = uniEnconding.GetBytes("Meu arquivo de texto - dados! :D");
            //fss.Write(byteArray, 0, byteArray.Length);

            //fss.Close();

            //------------------ STREAM WRITER (ACHEI MELHOR)--------------------------

            //StreamWriter sw = new StreamWriter(@"D:\testeBradesco.txt", true);
            //sw.WriteLine("Meus dados escritos no arquivo.");
            //sw.Close();

            //string dadosArquivo;
            //StreamReader sr = new StreamReader(@"D:\testeBradesco.txt", true);
            //dadosArquivo = sr.ReadToEnd();
            //Console.Write(dadosArquivo);

            Console.Title = "Curso técnico - AGENDA CONSOLE";
            Contato.criaMenu();









            Console.ReadKey();
        
        }//coagula
    }
}
