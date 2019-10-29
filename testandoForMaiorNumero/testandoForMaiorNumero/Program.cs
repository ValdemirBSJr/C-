using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace testandoForMaiorNumero
{
    class Program
    {
        static void Main(string[] args)
        {//INICIO

           
            const int numeroQtd = 10;
int[] numeros = new int[numeroQtd];
int menor = 0, maior = 0, posicao_menor = 0, posicao_maior = 0;

Console.WriteLine( "Informe 10 números inteiros:" );

for( int i = 0; i < numeroQtd; i++ )
{

    Console.WriteLine( ( i + 1 ) + "º número:" );
    numeros[i] = Convert.ToInt32( Console.ReadLine() );

    if( i == 0 )
    {
        menor = numeros[0];
        maior = numeros[0];
    }

    if( numeros[i] < menor )
    {

        menor = numeros[i];
        posicao_menor = i;

    }
    else if( numeros[i] > maior )
    {
        maior = numeros[i];
        posicao_maior = i;
    }

}

Console.WriteLine( "O menor número é:" + menor );
Console.WriteLine( "A posição do menor número é:" + posicao_menor );
Console.WriteLine( "O maior número é:" + maior );
Console.WriteLine( "A posição do maior número é:" + posicao_maior );

Console.Read();
            
            
          
            int numMaior, numMenor, posicaoMenor, posicaoMaior;

            Console.WriteLine("Digite os 10 números..:");

            for (int x = 0; x <= 9; x++)
            {
                Console.WriteLine("Digite o "+(x+1)+"º número..:");
                numeros[x] = Convert.ToInt16(Console.ReadLine());
            }

            

            foreach (int resultados in numeros)
            {
                Console.WriteLine("O "+(resultados)+"º número digitado foi: " +resultados);
            }

            Console.ReadLine();



        }//FIM
    }
}
