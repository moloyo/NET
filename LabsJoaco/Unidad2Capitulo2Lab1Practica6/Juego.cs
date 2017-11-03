using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Unidad2Capitulo2Lab1Practica5
{
    public class Juego
    {
        private int record;

        public int Record { get => record; set => record = value; }

        public void ComenzarJuego()
        {
            
            do
            {
                Console.Clear();
                JugadaConAyuda juga = new JugadaConAyuda(PreguntarMaximo());
                PreguntarNumero(juga);
                                         
            } while (Continuar());
        }
        private void CompararRecord(int actual)
        {
            if (actual < Record || Record == 0)
            {
                Console.WriteLine("Record Superado!");
                Record = actual;
            }
        }
        private bool Continuar()
        {
            char rta;
            Console.WriteLine("Nuevo juego? (S/N)");
            rta = Convert.ToChar(Console.ReadLine());
            if (rta == 'S')
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private int PreguntarMaximo()
        {
            int maximo;
            Console.Write("Numero maximo: ");
            maximo = Convert.ToInt32(Console.ReadLine());
            return maximo;
        }
        private void PreguntarNumero(Jugada juga)
        {
            int rta;
            do
            {
                Console.Write("Numero? ");
                rta = Convert.ToInt32(Console.ReadLine());
            } while (!juga.Comparar(rta));
            CompararRecord(juga.Intento);
            Console.WriteLine("Intentos: " + juga.Intento);
            Console.WriteLine("Record: " + Record);

        }
        public Juego() { Record = 0; }
    }
}
