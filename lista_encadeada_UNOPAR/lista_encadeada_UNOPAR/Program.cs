using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lista_encadeada_UNOPAR
{
    class Program
    {
        static void Main(string[] args)
        {//inicio
           
            //abaixo crio uma instancia para trabalhar, vai o nome da classe Nó criada
            /*assim abaixo é sem encapsulamento
            No objeto = new No();
            objeto._valor = "Valdemir";

            Console.WriteLine(objeto._valor);
            Console.Read();
            */


            No objeto = new No();
            //objeto.Valor = "Valdemir";

            Lista lista = new Lista();
            lista.insere("1");
            lista.insere("2");
            lista.insere("3");


           /* Console.WriteLine(objeto.Valor);
            Console.Read();
            */
 

        }//fim
    }
}
