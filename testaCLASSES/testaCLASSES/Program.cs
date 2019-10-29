using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace testaCLASSES
{
    class Program
    {
        static void Main(string[] args) //aqui abaixo temos nesse método a geração de 3 objetos clientes
        {
            CLIENTE cliente1 = new CLIENTE("DAVID", 22);
            CLIENTE cliente2 = new CLIENTE("VALDEMIR", 29);
            CLIENTE cliente3 = new CLIENTE();





            Console.Write("CLiente Nº 1: ");
            cliente1.DEMONSTRACLIENTE();
            Console.Write("Cliente Nº 2: ");
            cliente2.DEMONSTRACLIENTE();
            Console.Write("Cliente Nº 3: ");
            cliente3.DEMONSTRACLIENTE();

            Console.Read();
        }
    }

    class CLIENTE //aqui criamos a classe que irá tratar os clientes
    {
        private string nome;
        private int idade;
        

        public CLIENTE() //construtor padrão que dá um valor vazio para o objeto caso ele nao receba nada por referencia
        {
            nome = "Cliente não cadastrado";
            idade = 0;
        }

        public CLIENTE(string nome, int idade) //aqui é o construtor que irá receber os valores imputados dos clientes
        {
            this.nome = nome;
            this.idade = idade;
            
        }

        public void DEMONSTRACLIENTE() //metodo que retorna na tela os clientes.
        {
            Console.WriteLine("{0}, {1} anos de idade.", nome, idade);
        }
    }

   
    }

