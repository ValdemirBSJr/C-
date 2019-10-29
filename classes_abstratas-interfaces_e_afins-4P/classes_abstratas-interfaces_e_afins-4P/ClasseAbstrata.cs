using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//A classe abstrata é um tipo de classe que somente pode ser herdada e não instanciada. De certa forma, 
//pode-se dizer que este tipo de classe é uma classe conceitual que pode definir funcionalidades para que as suas 
//subclasses possam implementá-las.

//O conjunto de métodos na classe abstrata é obrigatoriedade, assim como a implementação nas suas subclasses. 
//Em uma classe abstrata, os métodos declarados podem ser abstratos ou não, e suas implementações devem ser 
//obrigatórias na subclasse. Quando criamos um método abstrato em uma classe abstrata, sua implementação é obrigatória. 
//Caso você não implemente o mesmo, o compilador criará um erro em tempo de compilação.

namespace classes_abstratas_interfaces_e_afins_4P
{
    abstract class ClasseAbstrata //usa a palavra chave abstract
    {
        abstract public int Area();
           
  

    }
}
