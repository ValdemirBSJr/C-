using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lista_encadeada_UNOPAR
{
    class No
    {//inicio

        //vamos criar os atributos que são caracteristicas do objeto, qual o tipo de dados que vai ser trabalhado

        //public string _valor;

        //pra fazer o encapsulamento (proteção dos atributos), temos que usar os métodos get e set
        private string _valor;

        public string Valor
        {
            get { return _valor; }
            set { _valor = value; }
        }

            /*
            public void setValor(string Valor) //aqui colocamos o valor encapsulado tem void pois nao retorna valor
            {

                _valor = Valor;

            }

            public string getValor() //aqui é o método que entrega o valor pra quem está chamando
            {
                return _valor;
            }
             */

        private string _proximo;

        public string Proximo
        {
            get { return _proximo; }
            set { _proximo = value; }
        }



    }//fim
}
