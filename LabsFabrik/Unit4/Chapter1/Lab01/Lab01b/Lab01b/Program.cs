using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Lab01b
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader lector = File.OpenText("agenda.txt");
            string linea;
            do
            {
                linea = lector.ReadLine();
                if (linea != null)
                {
                    Console.WriteLine(linea);
                }
            }
            while (linea != null);
            lector.Close();
            Console.ReadKey();
        }
    }
}
