using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace teste_heranca_e_polimorfismo_classe
{
    class Professor: Aluno
    {
        private string formacao;
        private List<string> retornoReport = new List<string>();

        public List<string> RetornoReport
        {
            get { return retornoReport; }
            set { retornoReport = value; }
        }

        public string Formacao
        {
            get { return formacao; }
            set { formacao = value; }
        }

        public override void CadastraUsuario()
        {
            base.CadastraUsuario();

            StreamWriter professor = new StreamWriter(System.Windows.Forms.Application.StartupPath + @"/professor.txt", true, UTF8Encoding.UTF8);

            professor.WriteLine("Nome: " + Nome);
            professor.WriteLine("CPF: " + Cpf);
            professor.WriteLine("Fone: " + Fone);
            professor.WriteLine("Formação: " + formacao);

            professor.Flush();
            professor.Close();
        }

        public static List<string> retornaLista()
        {
            List<string> retornada = new List<string>();

            return retornada;
        }

    }
}
