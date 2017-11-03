using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Unidad2Capitulo2Lab1Practica5
{
    public class Jugada
    {
        private int numero,intento;
        private bool adivino;

        public int Numero { get => numero; set => numero = value; }
        public bool Adivino { get => adivino; set => adivino = value; }
        public int Intento { get => intento; set => intento = value; }

        public Jugada(int maxNumero)
        {
            Random rnd = new Random();
            Numero = rnd.Next(maxNumero);
            Intento = 0;
            Adivino = false;
        }
        public bool Comparar(int rta)
        {
            Intento++;
            return rta == Numero;
        }
    }
}
