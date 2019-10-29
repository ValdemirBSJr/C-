using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace validaCampos_e_formata_objetos
{
    class Usuario
    {
        //criei e encapsulei objeto
        private string cpf;
        private string nome;

        public string Cpf
        {
            get { return cpf; }
            set { cpf = formataCPF(value); }
        }
        

        public string Nome
        {
            get { return nome; }
            set { nome = formataNome(value); }
        }

        public string formataCPF(string cpfDigitado)
        {
            //aqui criamos um método para formatar o campo cpf
            return cpfDigitado.Substring(0, 3) + "." + cpfDigitado.Substring(3, 3) + "." + cpfDigitado.Substring(6, 3) + "-" + cpfDigitado.Substring(9, 2);
            
        }

        public string formataNome(string nomeDigitado)
        {
            //aqui criei um metodo que apenas converte o digitado em caixa alta
            return nomeDigitado.ToUpper();
        }
    }
}
