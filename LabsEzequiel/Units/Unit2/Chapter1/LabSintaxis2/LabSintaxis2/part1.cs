using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabSintaxis2
{
    class part1
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
            if (ConsoleKey.D1 == option.Key)
            {
                common.MostrarMay(inputTexto);
            }
            else if (ConsoleKey.D2 == option.Key)
            {
                common.MostrarMin(inputTexto);
            }
            else if (ConsoleKey.D3 == option.Key)
            {
                common.MostrarCant(inputTexto);
            }
            else
            {
                Console.WriteLine("No ingresó una opcion válida");
            }
        }


    }
}
