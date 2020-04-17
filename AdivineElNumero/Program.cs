using System;
using System.Collections.Generic;
using System.Text;

namespace AdivineElNumero
{
    public class Program
    {
        public static void Main()
        {
            bool jugar = true;
            Juego juego = new Juego();
            while (jugar)
            {
                jugar = juego.ComenzarJuego();
            }
        }
    }
}
