using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometria
{
    public class Circulo
    {
        private int m_radio;

        public int Radio
        {
            get
            {
                return Radio;
            }
            set
            {
            }
        }

        public double CalcularPerimetro()
        {
           return 2 * Math.PI * Radio;
        }

        public double CalcularSuperficie()
        {
            return Math.PI * Radio * Radio * Radio;
        }
    }
}
