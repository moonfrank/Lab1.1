using System;
using System.Runtime.CompilerServices;

namespace AdivineElNumero
{
    public class Juego
    {
        //Variables

        int record;

        //Propiedades

        public int Record { get { return record; } set { record = value; } }

        //Constructores y Destructores

        public Juego()
        {
            this.Record = -1;
        }

        //Metodos

        /// <summary>
        /// Método principal del juego desde el que se invocan todos los demás
        /// </summary>
        /// <returns></returns>
        public bool ComenzarJuego()
        {
            if (this.Continuar())
            {
                JugadaConAyuda jugada = new JugadaConAyuda(this.PreguntarMaximo());
                while(jugada.IntAdivina==false)
                {
                    jugada.IntIntentos++;
                    if (jugada.IntAdivina = jugada.Comparar(this.PreguntarNumero())) Console.WriteLine("Ha adivinado el número!");
                    else Console.WriteLine("Número equivocado! Intente nuevamente. ");
                }
                this.CompararRecord(jugada.IntIntentos);
                return true;
            }
            else return false;
        }

        void CompararRecord(int intIntentos)
        {
            if (this.Record==-1||this.Record > intIntentos)
            {
                this.Record = intIntentos;
                Console.WriteLine("Nuevo récord! Ha adivinado el número en tan solo " + this.Record + " intentos!");
            }
        }

        /// <summary>
        /// Método que pregunta al jugador si desea iniciar otra partida y retorna opción elegida.
        /// </summary>
        /// <returns></returns>
        bool Continuar()
        {
            Console.WriteLine("Desea jugar una nueva partida? Escriba \"si\" para jugar o presione Enter para salir.");
            string s = Console.ReadLine();
            if (s.Equals("si")) return true;
            else return false;
        }

        /// <summary>
        /// Método que pregunta al jugador entre qué números quiere tener que adivinar (el mínimo es siempre 1).
        /// </summary>
        /// <returns></returns>
        int PreguntarMaximo()
        {
            int intMaximo;
            while(true)
            {
                Console.Write("Usted quiere adivinar un número entre 0 y: ");
                if (int.TryParse(Console.ReadLine(), out intMaximo)) break;
                else Console.WriteLine("El número ingresado es inválido. Por favor intente nuevamente.");
            }
            return intMaximo;
        }

        /// <summary>
        /// Método que pregunta al jugador qué número quiere adivinar.
        /// </summary>
        int PreguntarNumero()
        {
            int intAdivinar;
            Console.Write("Cuál es el número? ");
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out intAdivinar)) break;
                else Console.WriteLine("El número ingresado es inválido. Por favor intente nuevamente.");
            }
            return intAdivinar;
        }
    }
}
