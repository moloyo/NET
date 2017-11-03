using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Unidad2Capitulo2Lab1Practica5
{
    public class JugadaConAyuda : Jugada
    {
        public JugadaConAyuda(int maxNumero) : base(maxNumero)
        {
        }

        public override bool Comparar(int rta)
        {
            if (rta < Numero)
            {
                Console.WriteLine("El numero es mas grande ");
            }
            else if (rta > Numero)
            {
                Console.WriteLine("El numero es mas chico ");
            }

            if (Math.Abs(rta - Numero) > 100)
            {
                Console.WriteLine("y esta muy lejos!");
            }
            else if (Math.Abs(rta - Numero) < 5)
            {
                Console.WriteLine("y esta muy cerca!");
            }


            return base.Comparar(rta);
        }


    }
}
