using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unidad2Capitulo2Lab1Practica4
{
    class Program
    {
        static void Main(string[] args)
        {
            CrearPersona();
            Console.ReadKey();
        }

        private static void CrearPersona()
        {
            Persona juan = new Persona("Juan", "Perez", 37154223, 14);
            Console.ReadKey();
        }
    }
}
