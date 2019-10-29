using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Segunda_atividade_UNOPAR
{
    class Tratamento
    {


        private string _nomesRecebidos;

        public string NomesRecebidos
        {
            get { return _nomesRecebidos; }
            set { _nomesRecebidos = value; }
        }

        public static string RetornaOpcao(string retorna)
        {
            Console.WriteLine("Qual o próximo passo?(O que fazer)");
            return retorna;
        }

        

    }
}
