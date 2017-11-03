using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    public class Padre
    {
        private string nombreInstancia;

        public Padre()
        {
            nombreInstancia = "Instancia sin nombre";
        }
        public Padre(string n) 
        {
            nombreInstancia = n;
        }

        public string getNombre()
        {
            return nombreInstancia;
        }

        public void M1()
        {
            Console.WriteLine("Metodo M1 invocado");
        }
        public void M2()
        {
            Console.WriteLine("Metodo M2 invocado");
        }
        public void M3()
        {
            Console.WriteLine("Metodo M3 invocado");
        }
    }
}
