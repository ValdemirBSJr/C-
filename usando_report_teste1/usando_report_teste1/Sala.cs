using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace usando_report_teste1
{
    class Sala
    {

        public static List<Estudante> pegaEstudantes()
        {
            List<Estudante> listaAlunos = new List<Estudante>()
            {
                new Estudante
                {
                EstudanteID = 1,
                EstudanteIdade = 20,
                EstudanteCurso ="Psicologia",
                EstudanteNome = "Altemir"
                
                },

                new Estudante
                {
                EstudanteID = 2,
                EstudanteIdade = 25,
                EstudanteCurso ="Engenharia",
                EstudanteNome = "Rosa"
                
                }
            };



            return listaAlunos;
        }


    }
}
