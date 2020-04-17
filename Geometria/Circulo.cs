using System;

namespace Geometria
{
    public class Circulo
    {
        public float flRadio {get;set;}

        public double CalcularPerimetro()
        {
            return (Math.PI*flRadio*2);
        }

        public double CalcularSuperficie()
        {
            return (Math.PI*flRadio*flRadio);
        }
    }
}
