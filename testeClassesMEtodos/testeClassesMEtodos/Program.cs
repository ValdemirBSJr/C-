using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace testeClassesMEtodos
{
    class Program
    {
        static void Main(string[] args)
        {

            metodo NomePessoa = new metodo();

            Console.WriteLine("Digite o nome da pessoa..: ");
            NomePessoa.Objeto = Console.ReadLine();

            Console.WriteLine("O nome da pessoa digitado em minúsculo..: " + NomePessoa.Objeto);
            Console.WriteLine("O nome da pessoa em caixa alta..: " + metodo.NomeMaiuscula(NomePessoa.Objeto));
            Console.Read();
            Console.Read();
            Console.ReadKey();
           


        }
    }
}
