using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace usando_report_teste1
{
    class Estudante
    {

        private int estudanteID, estudanteIdade;

        public int EstudanteIdade
        {
            get { return estudanteIdade; }
            set { estudanteIdade = value; }
        }

        public int EstudanteID
        {
            get { return estudanteID; }
            set { estudanteID = value; }
        }

        private string estudanteNome, estudanteCurso;

        public string EstudanteCurso
        {
            get { return estudanteCurso; }
            set { estudanteCurso = value; }
        }

        public string EstudanteNome
        {
            get { return estudanteNome; }
            set { estudanteNome = value; }
        }






    }
}
