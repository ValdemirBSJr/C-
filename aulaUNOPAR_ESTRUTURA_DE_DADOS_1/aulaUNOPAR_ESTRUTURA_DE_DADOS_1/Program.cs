using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace aulaUNOPAR_ESTRUTURA_DE_DADOS_1
{
    class Program
    {
        static void Main(string[] args) //tem que colocar unsafe pra trabalhar com ponteiros
        {//solve

            //ponteiros();

            //exemplo3();
            atividadeTrocaNumeros();
            

            /*
            Console.WriteLine(ch);
            Console.WriteLine(a);

            Console.Read();
             */ 
             



        }

        

        public static unsafe void ponteiros () //precisa ir em propriedades clicando com botão esquerdo no projeto e marcando unsafe na guia build e coloca a palavra chave unsafe no void
        {


            int num, valor;
            int* p;

            num = 55;

            p = &num; //aqui eu boto o endereço de memória e não o valor de num

            valor = *p;

            Console.WriteLine("VALOR...: " + valor);
            Console.WriteLine("ENDEREÇO PARA ONDE O PONTEIRO APONTA...: " + new IntPtr(p));
            Console.WriteLine("VALOR DA VARIÁVEL APONTADA...: " + *p);


            int numer;
            int *p1; 
            int *p2;

            numer = 66;

            p1 = &numer;
            p2 = p1;

            Console.WriteLine("Conteúdo de p1: "+ new IntPtr(p1));
            Console.WriteLine("Valor apontado p1: " + *p1);

            Console.WriteLine("Conteúdo de p2: " + new IntPtr(p2));
            Console.WriteLine("Valor apontado p2: " + *p2);

            Console.Read();

            /*
            Console.WriteLine("Teste de ponteiro");
            Console.Read();
             * */
        }

        private static unsafe void exemplo3()

    {

        int num;
        int *p;
        num = 77;
            p = &num;

            Console.WriteLine("ENDEREÇO DE PONTEIRO..: " + new IntPtr(p));
            Console.WriteLine("ENDEREÇO DE PONTEIRO INCREMENTADO...: " + new IntPtr(++p)); //aqui incrementa o endereço

            Console.Read();


    }

        private static unsafe void atividadeTrocaNumeros()
        {

            int valor1, valor2; //criar dois ponteiros e trocar os valores deles, eu pego os valores de forma indireta pelo endereço

            valor1 = 22;
            valor2 = 33;
            

            int* ponteiro1;
            int* ponteiro2;

            ponteiro1 = &valor1;
            ponteiro2 = &valor2;

            


            Console.WriteLine("VALOR DO PONTEIRO 1...: "+ *ponteiro1);
            Console.WriteLine("VALOR DO PONTEIRO 2...: " + *ponteiro2);
            Console.WriteLine("AGORA TROCAMOS O VALOR...:");
            Console.WriteLine("");

            ponteiro1 = &valor2;
            ponteiro2 = &valor1;

            Console.WriteLine("VALOR DO PONTEIRO 1...:" + *ponteiro1);
            Console.WriteLine("VALOR DO PONTEIRO 2...: " + *ponteiro2);

            Console.Read();




        }


    }
}
