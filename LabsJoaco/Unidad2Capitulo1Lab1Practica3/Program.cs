using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabSintaxis4
{
    class Program
    {
        static void Main(string[] args)
        {
            int cantIteraciones = 5;
            string[] palabras = new string[5];
            for (int i = 0; i < cantIteraciones; i++)
            {
                palabras[i] = Console.ReadLine(); 
            }
            for (int i = cantIteraciones-1; i >= 0; i--)
            {
                Console.WriteLine(palabras[i]);
            }
            Console.ReadLine();
        }
    }
}
