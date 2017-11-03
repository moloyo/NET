using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unidad4Lab01 
{
    class Program 
    {
        static void Main(string[] args) 
        {
            leer("agenda.txt");
            Console.ReadKey();
            escribir("agenda.txt");
            leer("agenda.txt");
            Console.ReadKey();
        }

        private static void leer(string archivo) {
            StreamReader carla = File.OpenText(archivo);
            string puta;
            Console.WriteLine("Nombre\tApellido\temail\t\t\ttelefono");
            do {
                puta = carla.ReadLine();
                if (puta != null) {
                    string[] piernas = puta.Split(';');
                    Console.WriteLine(piernas[0] + "\t" + piernas[1] + "\t" + piernas[2] + "\t" + piernas[3]);
                }
            } while (puta != null);
            carla.Close();
        }

        private static void escribir(string archivo) 
        {
            StreamWriter jorgito = File.AppendText(archivo);
            Console.WriteLine("Ingrese nuevo contacto: ");
            string rta = "S";
            while (rta == "S") 
            {
                Console.WriteLine("Ingrese nombre: ");
                string nombre = Console.ReadLine();
                Console.WriteLine("Ingrese apellido: ");
                string apellido = Console.ReadLine();
                Console.WriteLine("Ingrese email: ");
                string email = Console.ReadLine();
                Console.WriteLine("Ingrese telefono: ");
                string telefono = Console.ReadLine();
                jorgito.WriteLine(nombre + ";" + apellido + ";" + email + ";" + telefono);

                do {
                    Console.WriteLine("Desea ingresar otro? (S/N)");
                    rta = Console.ReadLine();
                } while (rta != "S" && rta != "N");
            }
            jorgito.Close();
            
 

        } 
    }
}
