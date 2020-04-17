using System;
using System.Collections.Generic;
using System.Text;

namespace AdivineElNumero
{
    class Jugada
    {
        //Variables
        
        //Propiedades

        public bool IntAdivina { get;set; }
        public int IntNumero { get; set; }
        public int IntIntentos { get; set; }
                    
        //Constructores y Destructores

        public Jugada(int maxNumero)
        {
            Random rnd = new Random();
            this.IntNumero = rnd.Next(maxNumero);
        }

        //Metodos

        /// <summary>
        /// Compara el número que adivinó el jugador con el generado y retorna si acertó o no.
        /// </summary>
        /// <returns></returns>
        public bool Comparar(int intInput)
        {
           return (intInput==this.IntNumero);
        }
    }

    class JugadaConAyuda : Jugada
    {
        public JugadaConAyuda(int maxNumero):base(maxNumero)
        {

        }
        
        //Métodos

        new public bool Comparar(int intInput)
        {
            if (Math.Abs(intInput - this.IntNumero) > 100) Console.WriteLine("El número ingresado está muy lejos del que debe adivinar!");
            else if (Math.Abs(intInput - this.IntNumero) < 5) Console.WriteLine("Está muy cerca del número correcto!");
            return (intInput == this.IntNumero);
        }
    }
}
