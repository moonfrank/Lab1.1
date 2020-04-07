using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabSintaxis3
{
    class Program
    {
        static void Main(string[] args)
        {
            int cantIteraciones = 5;
            string[] strArray;
            strArray = new string[cantIteraciones];
            for (int i = 0; i < cantIteraciones; i++)
            {
                strArray[i] = Console.ReadLine();
            };
            for (int i = cantIteraciones; i > 0; i--)
            {
                 Console.WriteLine(strArray[i-1]);
            };
            Console.WriteLine("Presione una tecla para continuar...");
            Console.ReadKey();
        }
    }
}
