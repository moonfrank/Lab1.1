using System;
using System.Collections.Generic;
using System.Text;

namespace Clases
{
    
        public class C
        {
            //Metodos

            public void F()
            {
                Console.WriteLine("C.F");
            }
            public virtual void G()
            {
                Console.WriteLine("C.G");
            }
        }

        public class D : C
        {
            //Metodos
            new public void F()
            {
                Console.WriteLine("D.F");
            }
            public override void G()
            {
                Console.WriteLine("D.G");
            }
        }
    
}
