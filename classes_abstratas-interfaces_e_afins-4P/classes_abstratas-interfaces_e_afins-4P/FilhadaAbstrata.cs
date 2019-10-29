using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classes_abstratas_interfaces_e_afins_4P
{
    class FilhadaAbstrata : ClasseAbstrata
    {//Abaixo chamo o método que é obrigatória ter, acima, herdo a classe abstrata. mas isso se eu quiser

        int x, y;
        // Se não for implementado o método Area()
        // será gerado um compile-time error.
        public override int Area()
        {
            return x * y;
        }


     
    }
}
