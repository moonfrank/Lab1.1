using System;
using Clases;

namespace LabClases2
{
    class LabClases2
    {
        static void Main(string[] args)
        {
            D instD = new D();
            C instC = instD;
            instC.F();
            instD.F();
            instC.G();
            instD.G();
            Console.ReadKey();
        }
    }
}
