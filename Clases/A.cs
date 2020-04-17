using System;

namespace Clases
{
    public class A
    {
        //Variables

        private string _strNombreInstancia;
        public string strNombreInstancia
        {
            get { return _strNombreInstancia; }
            set { }
        }

        //Constructores

        public A()
        {
            this._strNombreInstancia = "Instancia sin nombre";
        }
        public A(string strReadLine)
        {
            this._strNombreInstancia = strReadLine;
        }

        //Métodos

        public void Show()
        {
            Console.WriteLine(strNombreInstancia);
        }

        public void M1()
        {
            Console.WriteLine("El método M1 fue invocado");
        }
        public void M2()
        {
            Console.WriteLine("El método M2 fue invocado");
        }
        public void M3()
        {
            Console.WriteLine("El método M3 fue invocado");
        }
    }
        
    
}
    
