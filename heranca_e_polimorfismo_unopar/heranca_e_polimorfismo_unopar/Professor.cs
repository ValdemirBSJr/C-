using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace heranca_e_polimorfismo_unopar
{
    public class Professor : Pessoa //Essa classe herda da classe Pessoa ou seja ela usa os recursos de lá. '':Pessoa''
    {//só pode sobrescrever metodos se uma classe herdar a outra
        private string formacao, titulo;

        public string Titulo
        {
            get { return CAIXA_ALTA(titulo); }
            set { titulo = CAIXA_ALTA(value); }
        }

        public string Formacao
        {
            get { return formacao; }
            set { formacao = value; }
        }

        //abaixo iremos sobrescrever o método salvar que tá na classe pessoa. O metodo salvar recebeu a palavra chave 'virtual' que libera pra ele sobrescrever

        public override void Salvar() //note aqui a palavra override que indica que estou sobescrevendo o metodo salvar da classe pessoa
        {
            base.Salvar();//aqui é padrão tbm indica sobescrita, indica a classe pai 'pessoa'

            StreamWriter Arquivo = new StreamWriter(System.Windows.Forms.Application.StartupPath + @"/Professor.txt", false, UTF8Encoding.UTF8);
            Arquivo.WriteLine("Nome: " + Nome);
            Arquivo.WriteLine("Formação: " + formacao);
            Arquivo.WriteLine("Título: " + titulo);

            Arquivo.Flush();
            Arquivo.Close();

        
        }

    }
}
