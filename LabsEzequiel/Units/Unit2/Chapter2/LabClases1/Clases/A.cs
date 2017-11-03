using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Console;

namespace Clases
{
    public class A
    {
        public A()
        {
            NombreInstancia = "Instancia sin nombre";
        }
        public A(string cadena)
        {
            NombreInstancia = cadena;
        }

        public void MostrarNombre()
        {
            Console.WriteLine(NombreInstancia);
        }
        public string NombreInstancia { get; set; }

        public void M1()
        {
            Console.WriteLine("Invocaste el metodo M1");
        }
        public void M2()
        {
            Console.WriteLine("Invocaste el metodo M2");
        }
        public void M3()
        {
            Console.WriteLine("Invocaste el metodo M3");
        }
    }
}
