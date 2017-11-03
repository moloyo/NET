using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabSintaxis2
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputTexto;
            inputTexto = Console.ReadLine();
            if (inputTexto.Length == 0)
            {
                Console.WriteLine("No ingreso texto");
            }
            else
            {
                Console.WriteLine("1 - En mayusculas");
                Console.WriteLine("2 - En minusculas");
                Console.WriteLine("3 - Cantidad de caracteres");
                ConsoleKeyInfo opcion = Console.ReadKey();
                if (opcion.Key == ConsoleKey.D1)
                {
                    Console.WriteLine(inputTexto.ToUpper());
                }
                else if (opcion.Key == ConsoleKey.D2)
                {
                    Console.WriteLine(inputTexto.ToLower());
                }
                else if(opcion.Key == ConsoleKey.D3)
                {
                    Console.WriteLine(inputTexto.Length);
                }
                else
                {
                    Console.WriteLine("Opcion no valida");
                }
            }


            Console.ReadLine();

        }
    }
}
