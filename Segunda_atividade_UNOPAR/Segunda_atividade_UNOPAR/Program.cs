using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections; //classe cloection pra usar coleção

namespace Segunda_atividade_UNOPAR
{
    class Program
    {
        static void Main(string[] args)
        {

            Stack nomes = new Stack(); //pilha de objetos


            string opcao = null;
            string selecao = null;

            int contador = 0;

            Console.WriteLine("Bem-vindo. Para inserir um nome, digite 1. Para visualizar os nomes, digite 2. Para excluir um nome digite 3. Para sair digite 4.");

            opcao = Console.ReadLine();

            while (opcao == "1" || opcao == "2" || opcao == "3")
            {

                do
                {
                    Console.WriteLine("Digite o nome..: ");
                    nomes.Push(Console.ReadLine());
                    Console.WriteLine("Qual o próximo passo?(O que fazer)");
                    opcao = Console.ReadLine();
                    contador += 1;
                }
                while (opcao == "1");

                if (opcao == "2")
                {

                    foreach (Object obj in nomes)
                    {
                        Console.WriteLine(obj);
                    }

                   
                   // Tratamento.RetornaOpcao(opcao);
                    Console.WriteLine("Qual o próximo passo?(O que fazer)");
                    opcao = Console.ReadLine();
                }

                if (opcao == "3")
                {
                    Console.WriteLine("Qual o nome deseja cancelar?");
                    selecao = Console.ReadLine();

                    if (nomes.Contains(selecao))
                    {
                        Console.WriteLine("O último nome da pilha será apagado!");
                        nomes.Pop();
                    }

                    else
                    {
                        Console.WriteLine("Nome não registrado!");
                    }

                    Console.WriteLine("Qual o próximo passo?(O que fazer)");
                    opcao = Console.ReadLine();

                }
                if (opcao == "4")
                {
                    Console.WriteLine("FIM!");
                }
                

                Console.ReadKey();
            }
        }
    }
}
