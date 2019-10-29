using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO; //classe pra gravar txt

namespace heranca_e_polimorfismo_unopar
{
    public class Pessoa //vem com public para que todos possam enchergar, nao capsulei
    {
        private int id; //aqui ele usa ao contrario... vi na aula

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private string nome;

        public string Nome
        {
            get { return CAIXA_ALTA(nome); }
            set { nome = CAIXA_ALTA(value); }
        }
        private string endereco;

        public string Endereco
        {
            get { return endereco; }
            set { endereco = value; }
        }
        private string bairro;

        public string Bairro
        {
            get { return bairro; }
            set { bairro = value; }
        }
        private string cidade;

        public string Cidade
        {
            get { return cidade; }
            set { cidade = value; }
        }
        private string estado;

        public string Estado
        {
            get { return estado; }
            set { estado = value; }
        }
        private string cpf;

        public string Cpf
        {
            get { return cpf; }
            set { cpf = value; }
        }

        public virtual void Salvar() //método salvar. O 'virtual' indica que as classes que herdarem serão sobrescritos
        {
            StreamWriter Arquivo = new StreamWriter(System.Windows.Forms.Application.StartupPath + @"/Pessoa.txt", false, UTF8Encoding.UTF8); //crio um novo arquivo

            Arquivo.WriteLine("ID: "+ Id.ToString());
            Arquivo.WriteLine("Nome: " + nome);
            Arquivo.WriteLine("Endereço: "+ endereco);
            Arquivo.WriteLine("Bairro: " + bairro);
            Arquivo.WriteLine("Cidade: " + cidade);
            Arquivo.WriteLine("Estado: " + estado);
            Arquivo.WriteLine("CPF: " + cpf);
            //Se ficar só nisso, nao iriamos salvar nada da classe professor. PAra fazer isso, temos que sobrescrever ele

           
            Arquivo.Flush(); //salva
            Arquivo.Close();//fecha

        }

        public string CAIXA_ALTA( string result) //metodo que retorna o nome em caixa alta
        {
            return result.ToUpper();
        }   
    }
}
