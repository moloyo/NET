using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LabSintaxis2
{
    class main
    {
        static void Main(string[] args)
        {
            MostrarMenu();
            ConsoleKeyInfo option = Console.ReadKey();
            Handler(option);


        }

        static void MostrarMenu()
        {
            Console.WriteLine("¿Qué desea hacer?");
            Console.WriteLine("1. Ejecutar parte 1");
            Console.WriteLine("2. Ejecutar parte 2");
            Console.WriteLine("3. Ejecutar parte 3");
        }

        static void Handler(ConsoleKeyInfo option)
        {
            if (ConsoleKey.D1 == option.Key)
            {
                new part1().Main();
            }
            else if (ConsoleKey.D2 == option.Key)
            {
                new part2().Main();
            }
            else if (ConsoleKey.D3 == option.Key)
            {
                // new part3().Main();
            }
            else
            {
                Console.WriteLine("No ingresó una opcion válida");
            }
        }
    }
}
