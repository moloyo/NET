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
            int cantIteraciones;
            cantIteraciones = 5;
            string[] cadena = new string[cantIteraciones];
            for (int i = 0; i < cantIteraciones; i++)
            {
                cadena[i] = Console.ReadLine();
            }

            for (int i = cantIteraciones-1; i >= 0; i--)
            {
                Console.WriteLine(cadena[i]);
            }
            Console.ReadKey();


        }
    }
}
