using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unidad4Lab03Ej3
{
    class Program
    {
        static void Main(string[] args)
        {
            //Creacion de tablas
            dsUniversidad miUniversidad = new dsUniversidad();
            dsUniversidad.dtAlumnosDataTable dtAlumnos = new dsUniversidad.dtAlumnosDataTable();
            dsUniversidad.dtCursosDataTable dtCursos = new dsUniversidad.dtCursosDataTable();
            dsUniversidad.dtAlumnos_CursosDataTable dtAlumnos_Cursos = new dsUniversidad.dtAlumnos_CursosDataTable();

            //Carga de datos
            dsUniversidad.dtAlumnosRow rowAlumno = dtAlumnos.NewdtAlumnosRow();
            rowAlumno.Apellido = "Perez";
            rowAlumno.Nombre = "Jorge";
            dtAlumnos.AdddtAlumnosRow(rowAlumno);
            dsUniversidad.dtCursosRow rowCurso = dtCursos.NewdtCursosRow();
            rowCurso.Curso = "Informatica";
            dtCursos.AdddtCursosRow(rowCurso);
            dtAlumnos_Cursos.AdddtAlumnos_CursosRow(rowAlumno, rowCurso);
            rowAlumno = dtAlumnos.NewdtAlumnosRow();
            rowAlumno.Apellido = "Rodriguez";
            rowAlumno.Nombre = "Juan";
            dtAlumnos.AdddtAlumnosRow(rowAlumno);
            dtAlumnos_Cursos.AdddtAlumnos_CursosRow(rowAlumno, rowCurso);
        }
    }
}
