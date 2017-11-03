using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Unidad4Lab03
{
    class Program
    {
        static void Main(string[] args)
        {
            DataTable dtAlumnos = new DataTable();

            DataRow rwAlumno = dtAlumnos.NewRow();

            DataColumn colNombre = new DataColumn();
            DataColumn colApellido = new DataColumn();

            dtAlumnos.Columns.Add(colNombre);
            dtAlumnos.Columns.Add(colApellido);

            rwAlumno[colNombre] = "Juan";
            rwAlumno[colApellido] = "Perez";

            dtAlumnos.Rows.Add(rwAlumno);

            DataRow rwAlumno2 = dtAlumnos.NewRow();

            rwAlumno2[colNombre] = "Marcelo";
            rwAlumno2[colApellido] = "Perez";

            dtAlumnos.Rows.Add(rwAlumno2);

            Console.WriteLine("Listado de Alumnos:");

            foreach(DataRow row in dtAlumnos.Rows)
            {
                Console.WriteLine(row[colApellido].ToString() + ", " + row[colNombre].ToString());
            }

            Console.ReadLine();
        }
    }
}
