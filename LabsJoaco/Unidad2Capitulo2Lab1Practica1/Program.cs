using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clases;

namespace LabClases1
{
    class Program
    {
        static void Main(string[] args)
        {
            Padre Pepe = new Padre("Pepe");
            Hijo Don = new Hijo();
            Console.WriteLine(Pepe.getNombre());
            Pepe.M1();
            Pepe.M2();
            Pepe.M3();
            Console.WriteLine(Don.getNombre());
            Don.M1();
            Don.M2();
            Don.M3();
            Console.ReadKey();
        }
    }
}
