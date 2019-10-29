using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lista_encadeada_UNOPAR
{
    class Lista
    {

        private No _cabeca, _cauda;

            public void insere(string elemento)
            {

                No novoNo = new No();
                novoNo.Valor = elemento;

                if (_cabeca == null) //se o objeto não tiver elementos na lista, ele será o primeiro
                {
                    _cabeca = novoNo;
                }

                else //aqui ele mantem o proximo, valores intermediarios
                {

                    _cauda = novoNo;

                }

                _cauda = novoNo; //se tiver elementos vai pro fim da lista

            }

    }
}
