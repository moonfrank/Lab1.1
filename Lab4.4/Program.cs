using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab4._2;

namespace Lab4._4
{
    class Program
    {
        static void Main(string[] args)
        {
            FileHandler manejadorArch;
            Console.WriteLine("Elija el modo:");
            Console.WriteLine("1 - TXT");
            Console.WriteLine("2 - XML");
            if (Console.ReadLine() == "2")
            {
                manejadorArch = new XmlHandler();
            }
            else
            {
                manejadorArch = new TxtHandler();
            }
            manejadorArch.Listar();
            Menu(manejadorArch);
        }

        static void Menu(FileHandler contactos)
        {
            string rta;
            do
            {
                Console.WriteLine("1 - Listar");
                Console.WriteLine("2 - Agregar");
                Console.WriteLine("3 - Modificar");
                Console.WriteLine("4 - Eliminar");
                Console.WriteLine("5 - Guardar Cambios");
                Console.WriteLine("6 - Salir");
                rta = Console.ReadLine();
                switch (rta)
                {
                    case "1":
                        contactos.Listar();
                        break;
                    case "2":
                        contactos.NuevaFila();
                        break;
                    case "3":
                        contactos.EditarFila();
                        break;
                    case "4":
                        contactos.EliminarFila();
                        break;
                    case "5":
                        contactos.AplicaCambios();
                        break;
                    default:
                        break;
                }
            } while (rta != "6");
        }
    }
}
