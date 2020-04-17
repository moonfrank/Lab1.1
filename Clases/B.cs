using System;

namespace Clases
{
    public class B:A
    {
        //Variables

        //Constructores

        public B() : base("Instancia de B")
        {
                
        }

        //Métodos

        public void M4()
        {
            Console.WriteLine("Método del hijo invocado");
        }
    }
}