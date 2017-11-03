using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParaPensar
{
    class Program
    {
        static void Main(string[] args)
        {
            // Invoque el metodo correspondiente al ejercicio deseado
            excercise4();
        }

        static void excercise1()
        {
            int n1 = int.Parse(Console.ReadLine());
            int n2 = int.Parse(Console.ReadLine());
            int suma = n1 + n2;
            String stringresult = String.Format("El resultado de la suma de {0} y {1} es {2}.", n1, n2, suma);
            Console.WriteLine(stringresult);
            Console.ReadKey();
        }

        static void excercise2()
        {
            int year = int.Parse(Console.ReadLine());
            bool bisiesto = year % 400 == 0 || (year % 4 == 0) && !(year % 100 == 0);
            if (bisiesto)
            {
                Console.WriteLine("Yes");
            }else
            {
                Console.WriteLine("No");
	        }
            Console.ReadKey();
        }

        static void excercise3()
        {
            int limit = int.Parse(Console.ReadLine());
            int n1 = 1;
            int n2 = 1;
            if (limit == 1)
            {
                Console.WriteLine("1");
                Console.ReadKey();
                return;
            }
            else if (limit == 2)
            {
                Console.WriteLine("2");
                Console.ReadKey();
                return;
            }
            int index = 2;
            int total = 2;
            int aux;
            while (index < limit)
            {
                aux = n2;
                n2 += n1;
                n1 = aux;
                total += n2;
                index++;
            }
            Console.WriteLine(total.ToString());
            Console.ReadKey();
        }
        static void excercise4()
        {
            int length = 100;
            for (int i = 0; i < length; i+=2)
            {
                Console.WriteLine(i);
            }
            Console.ReadKey();
        }

        public enum Month
        {
            NotSet = 0,
            January = 1,
            February = 2,
            March = 3,
            April = 4,
            May = 5,
            June = 6,
            July = 7,
            August = 8,
            September = 9,
            October = 10,
            November = 11,
            December = 12
        }

        static void excercise5()
        {

            string m = Enum.GetName(typeof(Month), value);
        }

    }
}
