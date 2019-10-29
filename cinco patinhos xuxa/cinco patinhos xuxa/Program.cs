using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cinco_patinhos_xuxa
{
    class Program
    {
        static void Main(string[] args)
        {//inicio do codigo

            //string cancaopatinhos;

            for (int patinhos = 5; patinhos >= 1; patinhos--)
            {
                
                
                if (patinhos == 1)
                {
                    Console.WriteLine(Convert.ToString(patinhos) + " patinho foi passear, além das montanhas para brincar.");
                    
                    
                    
                }
                else
                {
                    Console.WriteLine(Convert.ToString(patinhos) + " patinhos foram passear, além das montanhas para brincar.");
                    
                    
                }

              
                Console.Out.Write("A mamãe gritou: ");

                for (int quaqua = 5; quaqua > 1; quaqua--)
                {
                    Console.Write("quaquá ");
                }
                Console.WriteLine();

                if (patinhos <= 1)
                {
                    
                    Console.Out.WriteLine(" Mas só " + Convert.ToString(patinhos - 1) + " patinho voltou de lá");

                    goto finalcancao;
                }
               
                else
                {

                    Console.Out.WriteLine(" Mas só " + Convert.ToString(patinhos - 1) + " patinhos voltaram de lá");

                }
                

            }
        finalcancao:
            Console.WriteLine("Mas nenhum patinho voltou de lá");

           Console.WriteLine("A mamãe patinha foi procurar, Além das montanhas, Na beira do mar");

Console.WriteLine("A mamãe gritou: Quá, quá, quá, quá");
Console.WriteLine("E os cinco patinhos voltaram de lá.");

            Console.ReadLine();

           
           



        }//final do codigo
    }
}
