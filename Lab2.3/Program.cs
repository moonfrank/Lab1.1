using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Security.Cryptography;

namespace Lab2._3
{
    class Program
    {
        static readonly ArrayList ciudades = Ciudad.Ciudades();
        public static List<Empleado> ListaEmpleados = new List<Empleado>();
        public static string[] Provincias = new string[] { "Santa Fe", "Santa Cruz", "Corrientes", "Chaco", "Tucumán", "Entre Ríos" };

        static void Main()
        {
            Console.WriteLine("Ingrese opción:\n"
                               +"1) Filtrar provincias\n"
                               +"2) Mayores a 20\n"
                               +"3) Código Postal\n"
                               +"4) Lista de empleados\n");
            int intChoice;
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out intChoice)) { if (intChoice >= 1 && intChoice <= 4) break; }
            }
            switch(intChoice)
            {
                case 1:
                    {
                        MostrarSyT(); break;
                    }
                case 2:
                    {
                        MayoresA20(); break;
                    }
                case 3:
                    {
                        CodigoPostal(); break;
                    }
                case 4:
                    {
                        ListaEmpleado(); break;
                    }
            }
            Console.ReadKey();
        }

        public static void MostrarSyT()
        {
            Console.WriteLine("Provincias que comienzan con S y T: ");
            var strLista = from s in Provincias
                           where s[0] == 'S' || s[0] == 'T'
                           select s;
            foreach (string s in strLista) Console.WriteLine(s);
        }

        static void MayoresA20()
        {
            List<int> listEnteros = new List<int>();
            while (true)
            {
                string c;
                Console.Write("Ingrese número: ");
                while (true)
                {
                    if (int.TryParse(Console.ReadLine(), out int entero)) { listEnteros.Add(entero); break; }
                    else Console.Write("Formato de dato inválido. Intente otra vez: ");
                }
                Console.Write("Quiere ingresar otro número? (Y/N)");
                while (true)
                {
                    c = Console.ReadLine();
                    if (c.ToUpper() == "Y" || c.ToUpper() == "N") break;
                    else Console.Write("Formato de dato inválido. Intente otra vez: ");
                }
                if (c.ToUpper() == "N") break;
            }

            var mayores = from e in listEnteros
                          where e > 20
                          select e;
            foreach (int e in mayores) Console.WriteLine(e);
        }

        static void CodigoPostal()
        {
            string aBuscar;
            while (true)
            {
                Console.Write("Ingrese subcadena de longitud 3 a buscar: ");
                aBuscar = Console.ReadLine();
                if (aBuscar.Length == 3) break;
                else Console.WriteLine("Longitud de cadena ingresada distinta a 3.");
            }
            var mostrar = from Ciudad c in ciudades
                          where c.StrNombre.ToLower().Contains(aBuscar.ToLower())
                          select c.IntCP;
            foreach (int i in mostrar) Console.WriteLine(i);
        }

        static void ListaEmpleado()
        {
            while (true)
            {
                string c;
                Console.Write("Desea agregar un nuevo empleado? (Y/N): ");
                while (true)
                {
                    c = Console.ReadLine();
                    if (c.ToUpper() == "Y" || c.ToUpper() == "N") break;
                    else Console.Write("Ingreso inválido. Intente otra vez: ");
                }
                if (c.ToUpper() == "N") break;
                int id; string nombre; float sueldo;
                Console.Write("Ingrese ID: ");
                while (!int.TryParse(Console.ReadLine(), out id)) Console.Write("Ingreso inválido. Intente nuevamente: ");
                Console.Write("Ingrese nombre: ");
                nombre = Console.ReadLine();
                Console.Write("Ingrese sueldo: ");
                while (!float.TryParse(Console.ReadLine(), out sueldo)) Console.Write("Ingreso inválido. Intente nuevamente: ");
                ListaEmpleados.Add(new Empleado(id, nombre, sueldo));
            }
            var listaAsc = from Empleado e in ListaEmpleados
                                orderby e.FlSueldo ascending
                                select e;
            var listaDesc = from Empleado e in ListaEmpleados
                           orderby e.FlSueldo descending
                           select e;
            Console.WriteLine("Listado ordenado por sueldo en forma creciente:");
            foreach (Empleado e in listaAsc) Console.Write(e.IntID.ToString()+" "+e.StrNombre+" "+e.FlSueldo+"\n");
            Console.WriteLine("\nListado ordenado por sueldo en forma decreciente:");
            foreach (Empleado e in listaDesc) Console.Write(e.IntID.ToString() + " " + e.StrNombre + " " + e.FlSueldo+"\n");
        }
    }


    public class Ciudad
    {
        public string StrNombre { get; set; }
        public int IntCP { get; set; }

        public Ciudad(string s, int i)
        {
            StrNombre = s;
            IntCP = i;
        }

        public static ArrayList Ciudades()
        {
            ArrayList ciudades = new ArrayList();
            ciudades.Add(new Ciudad("Santa Fe", 3000));
            ciudades.Add(new Ciudad("Rosario", 2000));
            ciudades.Add(new Ciudad("San Lorenzo", 2200));
            ciudades.Add(new Ciudad("Aldao", 2214));
            ciudades.Add(new Ciudad("Arroyo Seco", 2128));
            ciudades.Add(new Ciudad("Barrancas", 2246));
            ciudades.Add(new Ciudad("Capitán Bermúdez", 2154));
            ciudades.Add(new Ciudad("Puerto San Martín", 2202));
            ciudades.Add(new Ciudad("Reconquista", 3560));
            ciudades.Add(new Ciudad("Rufino", 6100));
            return ciudades;
        }
    }

    public class Empleado
    {
        public int IntID { get; set; }
        public string StrNombre { get; set; }
        public float FlSueldo { get; set; }

        public Empleado(int i, string s, float f)
        {
            this.IntID = i;
            this.StrNombre = s;
            this.FlSueldo = f;
        }
    }

}
