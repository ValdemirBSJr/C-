using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Login_PREPARA_PORTIFOLIO_3P
{
    class Status //dá a mensagem de status
    {
        private static string mensagem;

        public static string Mensagem
        {
            get { return mensagem; }
            set { mensagem = value; }
        }

    }
}
