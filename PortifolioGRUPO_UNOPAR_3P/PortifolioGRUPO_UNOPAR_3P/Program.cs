using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace PortifolioGRUPO_UNOPAR_3P
{
    class Program
    {
        static void Main(string[] args)
        {//SOLVE
            AlugaComPonteiros();
            
        }//COAGULA



        private static unsafe void AlugaComPonteiros()
        {
            Console.WriteLine("Bem vindo a Locadora de Buggy's");

            Queue<string> buggys = new Queue<string>(); //usar a classe queue para tratar a fila
            int  controle = 5;
            int* ponteiro = &controle; //ponteiro

            do
            {
                Console.WriteLine("");
                Console.WriteLine("O que gostaria de fazer? Tecle 1 para LOCAR BUGGY / 2 para ENTREGAR BUGGY / 3 para LISTAR OS  BUGGYS's EXISTENTES NA LISTA DE BUGGY'S / 4 PARA CADASTRAR CLIENTE / 0 PARA SAIR..:");
                *ponteiro = Int16.Parse(Console.ReadLine());

                if ((controle == 3) && buggys.Count == 0)
                {
                    Console.WriteLine("Não há Buggys disponíveis para serem locados! Favor devolver algum buggy para podermos Lista-los!");
                }
                else if ((controle == 3) && buggys.Count >= 1)
                {
                    Console.WriteLine("Buggys disponíveis no momento..:");
                    Console.WriteLine("");



                    
                    Console.WriteLine("<--INÍCIO DA LISTA-->");

                    foreach (string buggyDisponivel in buggys)
                    {
                        Console.WriteLine(buggyDisponivel);
                    }

                    Console.WriteLine("<--FIM DA LISTA-->");
                    Console.WriteLine("");
                }

                if (controle == 2)
                {
                    Console.WriteLine("Digite o modelo do buggy que deseja entregar..:");
                    
                    
                    string modeloEntregue = Console.ReadLine();
                    buggys.Enqueue(modeloEntregue);


                    controle = 5;

                }

                if (controle == 1 && buggys.Count >= 1)
                {
                    

                    Console.WriteLine("");

                    Console.WriteLine("Totais de Buggys disponíveis no momento..: " + buggys.Count);
                    Console.WriteLine("");

                    Console.WriteLine("O Buggy Disponível para alugar é o: " + buggys.Peek() + ". Deseja Aluga-lo? [S/N]"); //peek mostra o primeiro da fila, mas nao o exclui
                    string modeloAlugado = Console.ReadLine();
                    if (modeloAlugado == "S" || modeloAlugado == "s")
                    {
                        buggys.Dequeue();//retira o primeiro da fila

                        Console.WriteLine("");
                        Console.WriteLine("Totais de Buggys após a locação..: " + buggys.Count);
                        Console.WriteLine("Buggys disponíveis para locação..:");

                        Console.WriteLine("");
                        Console.WriteLine("<--INÍCIO DA LISTA-->");

                        foreach (string buggyDisponivel in buggys)
                        {
                            Console.WriteLine(buggyDisponivel);
                        }

                        Console.WriteLine("<--FIM DA LISTA-->");

                    }

                    else
                    {
                        controle = 5;
                    }

                }
                else if (controle == 1 && buggys.Count == 0)
                {
                    Console.WriteLine("Não há nenhum Buggy para Alugar no momento. Volte mais tarde!!!");
                }

                if (controle == 4)
                {
                    Console.WriteLine("Digite o nome do cliente:"); //recebo os dados dos clientes
                   string nome = Console.ReadLine();

                    Console.WriteLine("Digite o endereço do cliente:");
                    string endereco = Console.ReadLine();

                    Console.WriteLine("Digite o telefone do cliente:");
                    string fone = Console.ReadLine();

                    Console.WriteLine("Digite o CNH do cliente:");
                    string cnh = Console.ReadLine();

                    Console.WriteLine("Digite o RG do cliente:");
                    string rg = Console.ReadLine();

                    Console.WriteLine("Digite o CPF do cliente:");
                    string cpf = Console.ReadLine();

                    Console.WriteLine("Digite a senha do Cliente: ");
                    string senha = ReadPassword();


                    Console.WriteLine("Registrando cliente em nosso banco de dados...");

                    //Aqui chamo as classes que tratam do BD
                    ConsoleApplication1.modelo mo = new ConsoleApplication1.modelo();
                    ConsoleApplication1.dal da = new ConsoleApplication1.dal();

                    //Aqui seto os dados colhidos no console para o BD
                    mo.Nome = nome;
                    mo.Endereco = endereco;
                    mo.Telefone = fone;
                    mo.Cpf = cpf;
                    mo.Cnh = cnh;
                    mo.Rg = rg;
                    mo.Cpf = cpf;
                    mo.Senha = senha;

                    //Aqui mando tudo pro BD:
                    da.cadastro(mo);

                    Console.WriteLine("Cliente " + mo.Nome + " cadastrado com sucesso!");
                    controle = 5;
                }



            } while (controle != 0);



            Console.WriteLine("OBRIGADO POR USAR OS SERVIÇOS DA ALUGA BUGGY!!!");


            Console.Read(); //Fim cursor
        }

        //ABAIXO FUNÇÃO PARA NÃO MOSTRAR A SENHA DIGITADA

        public static string ReadPassword()
        {

            string password = "";

            ConsoleKeyInfo info = Console.ReadKey(true);

            while (info.Key != ConsoleKey.Enter)
            {

                if (info.Key != ConsoleKey.Backspace)
                {

                    Console.Write("*");

                    password += info.KeyChar;

                }

                else if (info.Key == ConsoleKey.Backspace)
                {

                    if (!string.IsNullOrEmpty(password))
                    {

                        // remove um caractere da lista de caracteres da senha
                        
                        password = password.Substring(0, password.Length - 1);

                        // pega a localização do cursor

                        int pos = Console.CursorLeft;

                        // move o cursor para a esquerda por um caractere

                        Console.SetCursorPosition(pos - 1, Console.CursorTop);

                        // rearanja com espaço

                        Console.Write(" ");

                        // move o cursor para a esquerda para receber um caractere de novo

                        Console.SetCursorPosition(pos - 1, Console.CursorTop);

                    }

                }

                info = Console.ReadKey(true);

            }



            // adicionar uma nova linha, pois o usuário entrar pressionado no final da sua senha

            Console.WriteLine();

            return password;

        } 
    }
}
