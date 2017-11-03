using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabSintaxis2
{
    public class common
    {
        public static void MostrarMay(String inputTexto)
        {
            Console.WriteLine(inputTexto.ToUpper());
        }

        public static void MostrarMin(String inputTexto)
        {
            Console.WriteLine(inputTexto.ToLower());
        }

        public static void MostrarCant(String inputTexto)
        {
            Console.WriteLine(inputTexto.Length);
        }

        public static void MostrarMenu()
        {
            Console.WriteLine("¿Qué desea hacer?");
            Console.WriteLine("1. Mostrar la frase en mayusculas");
            Console.WriteLine("2. Mostrar la frase en minúsculas");
            Console.WriteLine("3. Mostrar la cantidad de caracteres");
        }

        public static String ingresarTexto()
        {
            Console.WriteLine("\nIngrese el texto:");
            return Console.ReadLine();
        }
        public static bool Validar(String inputTexto)
        {
            if (String.IsNullOrEmpty(inputTexto))
            {
                Console.WriteLine("\nNo ingresó texto");
                return false;
            }
            return true;
        }

    }
}
