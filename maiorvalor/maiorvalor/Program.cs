using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace maiorvalor
{
    class Program
    {
        static void Main(string[] args)
        {//Algoritmo para verificar o maior número
            double var1, var2, var3, max;

            Console.WriteLine("Digite o primeiro valor");

            var1 = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Digite o segundo valor");

            var2 = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Digite o terceiro número");

            var3 = Convert.ToDouble(Console.ReadLine());

            if (var1 > var2)
            {
                if (var1 > var3)
                {
                    max = var1;
                }
                else
                {
                    max = var3;
                }
            }

            else
            {
                if (var2 > var3)
                {
                    max = var2;
                }
                else
                {
                    max = var3;
                }

            }
                 Console.WriteLine("Dentre os números digitados: " + var1+ ", "+ var2+ ", "+ var3+ ". O maior valor digitado foi: " + max);
                 Console.ReadLine();


        }//fim do programa
    }
}
