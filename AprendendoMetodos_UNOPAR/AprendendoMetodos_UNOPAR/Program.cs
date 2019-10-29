using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AprendendoMetodos_UNOPAR
{
    class Program
    {
        static void Main(string[] args)
        {

            int x, y;
            int resultado;

           /*
            Console.WriteLine("Digite o primeiro numero..: ");
            x = Convert.ToInt16(Console.Read());
            Console.WriteLine("Digite o segundo número..: ");
            y = Convert.ToInt16(Console.Read());
            */
            x = 1;
            y = 2;

            resultado = metodo.SomaNumeros(x, y);

            Console.WriteLine(resultado);
            Console.Read();
            Console.Read();

        }

        
    }
}
