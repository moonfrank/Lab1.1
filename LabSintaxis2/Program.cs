using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabSintaxis2
{
    class Program
    {
        static void Main(string[] args)
        {
            string strInputTexto = Console.ReadLine();
            if (strInputTexto == null) { Console.WriteLine("No se ha ingresado texto."); }
            else
            {
                Console.WriteLine("Ingrese una de las siguientes opciones:\n" +
                                  "1. Convertir texto a mayúsculas.\n" +
                                  "2. Convertir texto a minúsculas.\n" +
                                  "3. Contar número de caracteres.");
                ConsoleKeyInfo opcion = Console.ReadKey();
                char charOpc = opcion.KeyChar;
                /*
                if (opopc == '1') Console.WriteLine(strInputTexto.ToUpper());
                else if (opopc == '2') Console.WriteLine(strInputTexto.ToLower());
                else if (opopc == '3') Console.WriteLine(strInputTexto.Length);
                else Console.WriteLine("Opción incorrecta.");
                */
                switch (charOpc)
                {
                    case '1': Console.WriteLine(strInputTexto.ToUpper()); break;
                    case '2': Console.WriteLine(strInputTexto.ToLower()); break;
                    case '3': Console.WriteLine(strInputTexto.Length); break;
                    default: Console.WriteLine("Opción incorrecta."); break;
                }
            }
        Console.WriteLine("Presione una tecla para continuar...");
        Console.ReadKey();
        }
    }
}
