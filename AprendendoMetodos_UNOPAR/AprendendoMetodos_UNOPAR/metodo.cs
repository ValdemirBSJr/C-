using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AprendendoMetodos_UNOPAR
{
    class metodo
    {

        private string  _pilha;

        public string Pilha
        {
            get { return _pilha; }
            set { _pilha = value; }

        }

        public static int SomaNumeros(int numero1, int numero2)
        {
            return numero1 + numero2;
        }

    }
}
