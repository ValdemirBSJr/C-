using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class modelo
    {
        private string nNome;
        private string nEndereco;
        private string nTelefone;
        private string nSenha;
        private string nCnh;
        private string nRg;
        private string nCpf;


        public string Nome
        {
            get { return nNome; }
            set { nNome = value; }
        }

        public string Endereco
        {
            get { return nEndereco; }
            set { nEndereco = value; }
        }

        public string Telefone
        {
            get { return nTelefone; }
            set { nTelefone = value; }
        }

        public string Cnh
        {
            get { return nCnh; }
            set { nCnh = value; }
        }

        public string Senha
        {
            get { return nSenha; }
            set { nSenha = value; }
        }

        public string Rg
        {
            get { return nRg; }
            set { nRg = value; }
        }

        public string Cpf
        {
            get { return nCpf; }
            set { nCpf = value; }
        }
    }
}
