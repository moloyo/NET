using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Geometria
{
    public class Triangulo
    {
        private int lado1;
        private int lado2;
        private int m_base;
        private int altura;
   
        public int Base
        {
            get
            {
                return m_base;
            }
            set
            {
                m_base = value;
            }
        }

        public int Altura
        {
            get
            {
                return altura;
            }
            set
            {
                altura = value;
            }
        }

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
            return lado1 + lado2 + m_base;
        }

        public int CalcularSuperficie()
        {
            return (altura * m_base) /2;
        }
    }
}
