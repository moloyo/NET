using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabSintaxis3
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
                Console.WriteLine();
                switch (opcion.Key)
                {
                    case ConsoleKey.D1:
                        Console.WriteLine(inputTexto.ToUpper());
                        break;
                    case ConsoleKey.D2:
                        Console.WriteLine(inputTexto.ToLower());
                        break;
                    case ConsoleKey.D3:
                        Console.WriteLine(inputTexto.Length);
                        break;
                    default:
                        Console.WriteLine("No ha eleccionado una opcion valida");
                        break;
                }
            }


            Console.ReadLine();
        }
    }
}
