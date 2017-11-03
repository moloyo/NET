using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabSintaxis5
{
    class Program
    {
        private static void Fibonacci()
        {
            Console.WriteLine("Ingrese un numero de longitud de la serie");
            int largo = Convert.ToInt32(Console.ReadLine());
            int n1 = 1, n2 = 1;
            Console.Write(n1 + " " + n2);
            for (int i = 0; i < largo; i++)
            {
                n2 = n2 + n1;
                n1 = n2 - n1;
                Console.Write(" " + n2);
            }
        }

        private static void Suma()
        {
            int a, b;
            Console.WriteLine("Sumemos a + b");
            Console.Write("a: ");
            a = Convert.ToInt32(Console.ReadLine());
            Console.Write("b: ");
            b = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("El resultado de la suma de " + a + " y " + b + " es " + (a + b));
        }

        private static void Meses()
        {
            string[] mes = { "enero", "febrero", "marzo", "abril", "mayo", "junio", "julio", "agosto", "septiembre", "octubre", "noviembre", "diciembre" };
            string mesIn;
            mesIn = Console.ReadLine().ToLower();
            for (int i = 0; i <= mes.Length; i++)
            {
                if (mes[i] == mesIn) { Console.WriteLine(mesIn + i); break; }
            }
        }

        private static void Romano()
        {
            string inputNum, romano = "";
            char[] sim = new char[7];
            sim[0] = 'I';
            sim[1] = 'V';
            sim[2] = 'X';
            sim[3] = 'L';
            sim[4] = 'C';
            sim[5] = 'D';
            sim[6] = 'M';
            int i;
            do
            {
                Console.WriteLine("Ingrese un numero (máximo 3999)");
                inputNum = Console.ReadLine();
            } while (Convert.ToInt32(inputNum) > 3999);
            for (int j = 0; j < inputNum.Length; j++)
            {
                i = (inputNum.Length - 1 - j) * 2;
                switch (inputNum[j])
                {
                    case '1': romano = romano + sim[i];
                        break;
                    case '2': romano = romano + sim[i] + sim[i];
                        break;
                    case '3': romano = romano + sim[i] + sim[i] + sim[i];
                        break;
                    case '4': romano = romano + sim[i] + sim[i + 1];
                        break;
                    case '5': romano = romano + sim[i + 1];
                        break;
                    case '6': romano = romano + sim[i + 1] + sim[i];
                        break;
                    case '7': romano = romano + sim[i + 1] + sim[i] + sim[i];
                        break;
                    case '8': romano = romano + sim[i + 1] + sim[i] + sim[i] + sim[i];
                        break;
                    case '9': romano = romano + sim[i] + sim[i + 2];
                        break;
                    case '0': romano = romano + sim[i + 2];
                        break;

                }
                
            }
            Console.WriteLine(romano);
            Console.ReadKey();
            
        }
        

        private static void Pares()
        {
            for (int i = 0; i <= 100; i += 2)
            {
                Console.WriteLine(i);
            }
        }

        private static void Year()
        {
            int year;
            Console.Write("Ingrese un año: ");
            year = Convert.ToInt32(Console.ReadLine());
            if ((year % 4 == 0 && year % 100 != 0) || year % 400 == 0)
            {
                Console.WriteLine("Es bisiesto");
           
            }
            else
            {
                Console.WriteLine("No es bisiesto");
            }

        } 

        private static void Primos()
        {
            int num;
            Console.Write("Ingrese un numero: ");
            num = Convert.ToInt32(Console.ReadLine());
            bool[] band = new bool[num];
            
            for (int i = num; i >= 5; i--)
            {
                band[i-1] = true;
                for (int j = i / 2; j > 1; j-- )
                {
                    if (i % j == 0)
                    {
                        band[i-1] = false;
                        break;
                    }
                }
                if (i < num - 1) { if (band[i - 1] && band[i + 1]) { Console.WriteLine(i + " y " + (i + 2) + " son primos gemelos"); } }
                
            }
            Console.ReadKey();



        }

        private static void Clave()
        {
            int intentos = 0;
            string pass;
            while (intentos < 4)
            {
                intentos++;
                Console.Write("Clave: ");
                pass = Console.ReadLine();
                if (pass != "chocolate") { continue; }
                Console.WriteLine("Coooooorrecto!");
                break;
            }
            Console.ReadKey();

        }

        private static void Menu()
        {
            int op = 9;
            do
            {
                Console.Clear();
                Console.WriteLine("Menu: ");
                Console.WriteLine("1 - Suma ");
                Console.WriteLine("2 - Año ");
                Console.WriteLine("3 - Fibonacci ");
                Console.WriteLine("4 - Pares ");
                Console.WriteLine("5 - Meses ");
                Console.WriteLine("6 - Romano ");
                Console.WriteLine("7 - Primos ");
                Console.WriteLine("8 - Clave ");
                Console.WriteLine("9 - Salir ");
                op = Convert.ToInt16(Console.ReadLine());
                Console.Clear();
                switch (op)
                {
                    case 1:
                        Suma();
                        break;
                    case 2:
                        Year();
                        break;
                    case 3:
                        Fibonacci();
                        break;
                    case 4:
                        Pares();
                        break;
                    case 5:
                        Meses();
                        break;
                    case 6: Romano();
                        break;
                    case 7: Primos();
                        break;
                    case 8: Clave();
                        break;
                }
            } while (op != 9);
        }

        static void Main(string[] args)
        {
            Menu();
        }
    }
}
