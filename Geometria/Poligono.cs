using System;
using System.Collections.Generic;
using System.Text;

namespace Geometria
{
    abstract class Poligono
    {
        //Metodos

        public abstract float CalcularPerimetro();
        public abstract float CalcularSuperficie();
    }

        class Rectangulo : Poligono
        {
            //Propiedades

            public float flLado1 { get; set; }
            public float flLado2 { get; set; }

            //Constructores
            public Rectangulo() { }
            public Rectangulo(float lado1, float lado2)
            {
                this.flLado1 = lado1;
                this.flLado2 = lado2;
            }
        
            //Metodos
            public override float CalcularPerimetro()
            { return (this.flLado1 * 2 + this.flLado2 * 2); }
            public override float CalcularSuperficie()
            { return (this.flLado1*this.flLado2); }
        }

        class Cuadrado : Rectangulo
        {
            //Constructores

            public Cuadrado(float lado)
            {
                this.flLado1 = lado;
            }
        
            //Metodos

            public override float CalcularPerimetro()
            {
                return this.flLado1 * 4;
            }
            
            public override float CalcularSuperficie()
            {
                return this.flLado1 * 2;
            }
        }
}
