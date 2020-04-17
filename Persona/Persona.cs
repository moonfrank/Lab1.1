using System;

namespace Persona
{
    public class Persona
    {
        //Propiedades

        public string strNombre { get; set; }
        public string strApellido { get; set; }
        public int intEdad { get; set; }
        public int intDNI { get; set; }

        //Constructores y Destructores

        public Persona(int dni,int edad, string nombre, string apellido)
        {
            this.intDNI = dni;
            this.intEdad = edad;
            this.strNombre = nombre;
            this.strApellido = apellido;
            Console.WriteLine("Instancia de persona creada con éxito.");
        }

        ~Persona()
        {
            Console.WriteLine("El objeto ha sido destruido.");
        }

        //Metodos

        public string GetFullName()
        {
            return (this.strNombre + this.strApellido);
        }

        public void GetAge()
        {
            Console.WriteLine("La edad de la persona es " + this.intEdad);
        }

    }
}
