using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace exer_pilha_UNOPAR_COPIA
{
    class tratamento
    {

        private string _valor;

        public string Valor
        {
            get { return _valor; }
            set { _valor = value; }
        }

        private string _proximo;

        public string Proximo
        {
            get { return _proximo; }
            set { _proximo = value;}
        }


        private tratamento _cabeca, _cauda;

        public void insere(string elemento)
        {
            tratamento novoValor = new tratamento();

            novoValor.Valor = elemento;

            if (_cabeca == null)
            {
                _cabeca = novoValor;
            }
            else
            {
                _cauda = novoValor;
            }

            _cauda = novoValor;
        }


    }
}
