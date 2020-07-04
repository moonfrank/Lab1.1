﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4._2
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
            menu(manejadorArch);
        }

        static void menu(FileHandler manejadorArch)
        {
            string rta = "";
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
                        manejadorArch.Listar();
                        break;
                    case "2":
                        manejadorArch.NuevaFila();
                        break;
                    case "3":
                        manejadorArch.EditarFila();
                        break;
                    case "4":
                        manejadorArch.EliminarFila();
                        break;
                    case "5":
                        manejadorArch.AplicaCambios();
                        break;
                    default:
                        break;
                }
            } while (rta != "6");
        }

    }
}
