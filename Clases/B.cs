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

        //M�todos

        public void M4()
        {
            Console.WriteLine("M�todo del hijo invocado");
        }
    }
}