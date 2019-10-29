using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrabalhandoComoTempo
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime inicio;
            DateTime fim;
            string pegavalor;

            inicio = DateTime.Now;
            Console.WriteLine("Clique enter para pegar primeiro tempo");
            Console.Read();

            fim = DateTime.Now;

            TimeSpan diferenca = new TimeSpan();

            diferenca = fim.Subtract(inicio);
            pegavalor = diferenca.TotalSeconds.ToString("0.000000");

            Console.WriteLine(pegavalor);

            int seconds = 1045;
            var timespan = TimeSpan.FromSeconds(seconds);
            Console.WriteLine(timespan.ToString(@"mm\:ss"));
            Console.ReadLine();
            Console.Read();
        }
    }
}
