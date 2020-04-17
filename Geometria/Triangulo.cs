using System;
using System.Collections.Generic;
using System.Text;

namespace Geometria
{
    class Triangulo
    {
        //Variables

        public float flBase { get; set; }
        public float flLado2 { get; set; }
        public float flLado3 { get; set; }
        public float flAltura { get; set; }

        //Metodos

        public float CalcularPerimetro()
        {
            return this.flBase + this.flLado2 + this.flLado3;
        }

        public float CalcularSuperficie()
        {
            return (this.flBase * this.flAltura) / 2;
        }
    }

}
