using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unidad2Capitulo2Lab1Practica5
{
    class Program
    {
   
        static void Main(string[] args)
        {
            
            Juego partida = new Juego();
            partida.ComenzarJuego();
            Console.WriteLine("Gracias por jugar!");
            Console.ReadKey();
        }
    }
}
