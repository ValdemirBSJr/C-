using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Login_PREPARA_PORTIFOLIO_3P
{
    class Usuario //aqui setamos os atributos pertencentes ao objeto usuario, tratada na classe usuario
    {
        private string _login, _senha, _confSenha, _telefone, _cpf, _cnh, _rg, _endereco;
        
        public string Login
        {
            get { return _login;}
            set { _login = value; }
        }

        public string Senha
        {
            get { return _senha; }
            set { _senha = value; }
        }

        public string ConfSenha
        {
            get { return _confSenha;}
            set { _confSenha = value; }
        }


        public string Telefone
        {
            get { return _telefone;}
            set { _telefone = value; }
        }

        public string Rg
        {
            get { return _rg;}
            set { _rg = value; }
        }

        public string Cnh
        {
            get { return _cnh; }
            set { _cnh = value; }
        }

        public string Cpf
        {
            get { return _cpf; }
            set { _cpf = value; }
        }

        public string Endereco
        {
            get { return _endereco; }
            set { _endereco = value; }
        }

    }
}
