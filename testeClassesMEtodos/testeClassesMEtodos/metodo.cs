using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace testeClassesMEtodos
{
    class metodo
    {

        private string _objeto;

        public string Objeto
        {
            get { return _objeto; }
            set { _objeto = value; }
        }

      

        public static string NomeMaiuscula(string digitado)
        {
             return digitado.ToUpper();

            
        }

    }
}
