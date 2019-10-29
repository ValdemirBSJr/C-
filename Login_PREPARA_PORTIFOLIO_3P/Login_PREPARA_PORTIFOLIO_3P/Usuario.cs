using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Login_PREPARA_PORTIFOLIO_3P
{
    class Usuario
    {
        private string _login, _senha, _confSenha;
        
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



    }
}
