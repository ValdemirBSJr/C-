using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            List <string> meses_ano = new List<string>();


            meses_ano.Add("31");
            meses_ano.Add("28");

            foreach (string mes in meses_ano)
            {
                Console.WriteLine(mes);
            }

            Console.Read();

        }
    }
}
