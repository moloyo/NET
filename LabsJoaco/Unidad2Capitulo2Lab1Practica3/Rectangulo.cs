using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Geometria
{
    public class Rectangulo : IPoligono
    {
        protected int lado1;
        protected int lado2;
    
        public virtual int Lado1
        {
            get
            {
                return lado1;
            }
            set
            {
                lado1 = value;
            }
        }

        public virtual int Lado2
        {
            get
            {
                return lado2;
            }
            set
            {
                lado2 = value;
            }
        }

        public int CalcularPerimetro()
        {
            return lado1*2 + lado2*2;
        }

        public int CalcularSuperficie()
        {
            return lado1*lado2;
        }
    }
}
