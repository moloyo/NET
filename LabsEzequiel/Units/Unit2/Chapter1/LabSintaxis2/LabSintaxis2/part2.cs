using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabSintaxis2
{
    class part2
    {
        public void Main()
        {
            String inputTexto = common.ingresarTexto();
            if (!common.Validar(inputTexto)) { return; }
            common.MostrarMenu();
            ConsoleKeyInfo option = Console.ReadKey();
            Console.WriteLine();
            Handler(option, inputTexto);
            Console.ReadKey();

        }
        private void Handler(ConsoleKeyInfo option, String inputTexto)
        {
            switch (option.Key)
            {
                case ConsoleKey.D1:
                    common.MostrarMay(inputTexto);
                    break;
                case ConsoleKey.D2:
                    common.MostrarMin(inputTexto);
                    break;
                case ConsoleKey.D3:
                    common.MostrarCant(inputTexto);
                    break;
                default:
                    Console.WriteLine("No ingresó una opcion válida");
                    break;
            }         

        }
    }
}
