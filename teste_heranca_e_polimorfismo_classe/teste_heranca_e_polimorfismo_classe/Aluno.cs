using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace teste_heranca_e_polimorfismo_classe
{
    class Aluno
    {
        private string nome, cpf, fone, tipo;

       

        public string Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }

        public string Fone
        {
            get { return fone; }
            set { fone = trataFone(value); }
        }

        public string Cpf
        {
            get { return cpf; }
            set { cpf = tataCPF(value); }
        }

        public string Nome
        {
            get { return trataNome(nome); }
            set { nome = trataNome(value); }
        }

       
        public virtual void CadastraUsuario() //virtual para herdar e sobescrever (polimorfismo)
        {
            StreamWriter cadastroFisico = new StreamWriter(System.Windows.Forms.Application.StartupPath + @"/CadastroAluno.txt", true, UTF8Encoding.UTF8);
            cadastroFisico.WriteLine("Nome: " + nome);
            cadastroFisico.WriteLine("CPF: " + cpf);
            cadastroFisico.WriteLine("Fone: " + fone);
            cadastroFisico.WriteLine("Tipo: " + tipo);

            cadastroFisico.Flush();
            cadastroFisico.Close();

        }

        public string trataNome(string NomeDigitado)
        {
            //Abaixo como capitalizar a primeira letra (deixar em maiúscula)
          char primeira = char.ToUpper(NomeDigitado[0]);
        NomeDigitado = primeira + NomeDigitado.Substring(1);
            return NomeDigitado;
        }

        private string trataFone(string FoneDigitado)
        {
            return FoneDigitado.Substring(0, 4) + "-" + FoneDigitado.Substring(4, 4);
        }

        private string tataCPF(string cpfDigitado)
        {
            return cpfDigitado.Substring(0, 3) + "." + cpfDigitado.Substring(3, 3) + "." + cpfDigitado.Substring(6, 3) + "-" + cpfDigitado.Substring(9,2);
        }

        //https://stackoverflow.com/questions/20860101/how-to-read-text-file-to-datatable

        

    }
}
