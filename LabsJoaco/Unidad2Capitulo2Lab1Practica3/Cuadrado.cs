using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Geometria
{
    public class Cuadrado : Rectangulo
    {
        public override int Lado1
        {
            get { return lado1; }
            set
            {
                lado1 = value;
                lado2 = value;
            }
        }
        public override int Lado2
        {
            get { return lado2; }
            set
            {
                lado1 = value;
                lado2 = value;
            }
        }
    }
}
