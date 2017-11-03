using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Unidad4Lab03Ej2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Creacion tabla alumnos
            DataTable dtAlumnos = new DataTable("Alumnos");
            DataColumn colID = new DataColumn("ID", typeof(int));
            colID.ReadOnly = true;
            colID.AutoIncrement = true;
            colID.AutoIncrementSeed = 0;
            colID.AutoIncrementStep = 1;
            DataColumn colNombre = new DataColumn("Nombre", typeof(String));
            DataColumn colApellido = new DataColumn("Apellido", typeof(String));
            dtAlumnos.Columns.Add(colID);
            dtAlumnos.Columns.Add(colNombre);
            dtAlumnos.Columns.Add(colApellido);
            dtAlumnos.PrimaryKey = new DataColumn[] { colID };
            
            //Creacion tabla cursos
            DataTable dtCursos = new DataTable("Cursos");
            DataColumn colIDCurso = new DataColumn("IDCurso", typeof(int));
            colIDCurso.ReadOnly = true;
            colIDCurso.AutoIncrement = true;
            colIDCurso.AutoIncrementSeed = 1;
            colIDCurso.AutoIncrementStep = 1;
            DataColumn colCurso = new DataColumn("Curso", typeof(string));
            dtCursos.Columns.Add(colIDCurso);
            dtCursos.Columns.Add(colCurso);
            dtCursos.PrimaryKey = new DataColumn[] { colIDCurso };

            //Carga de cursos
            DataRow rwCurso = dtCursos.NewRow();
            rwCurso[colCurso] = "Informatica";
            dtCursos.Rows.Add(rwCurso);

            //Creacion DataSet
            DataSet dsUniversidad = new DataSet();
            dsUniversidad.Tables.Add(dtCursos);
            dsUniversidad.Tables.Add(dtAlumnos);

            //Tabla relacional
            DataTable dtAlumnos_Cursos = new DataTable("Alumnos_Cursos");
            DataColumn col_ac_IDAlumno = new DataColumn("IDAlumno", typeof(int));
            DataColumn col_ac_IDCurso = new DataColumn("IDCurso", typeof(int));
            dtAlumnos_Cursos.Columns.Add(col_ac_IDAlumno);
            dtAlumnos_Cursos.Columns.Add(col_ac_IDCurso);
            dsUniversidad.Tables.Add(dtAlumnos_Cursos);

            //Objeto relacional
            DataRelation relAlumno_ac = new DataRelation("Alumno_Cursos", colID, col_ac_IDAlumno);
            DataRelation relCurso_ac = new DataRelation("Curso_Alumnos", colIDCurso, col_ac_IDCurso);
            dsUniversidad.Relations.Add(relAlumno_ac);
            dsUniversidad.Relations.Add(relCurso_ac);

            //Carga de datos
            DataRow rwAlumno = dtAlumnos.NewRow();
            rwAlumno[colNombre] = "Juan";
            rwAlumno[colApellido] = "Robinson";
            dtAlumnos.Rows.Add(rwAlumno);
            DataRow rwAlumno2 = dtAlumnos.NewRow();
            rwAlumno2[colNombre] = "Marcelo";
            rwAlumno2[colApellido] = "Perez";
            dtAlumnos.Rows.Add(rwAlumno2);
            DataRow rwAlumnosCursos = dtAlumnos_Cursos.NewRow();
            rwAlumnosCursos[col_ac_IDAlumno] = 0;
            rwAlumnosCursos[col_ac_IDCurso] = 1;
            dtAlumnos_Cursos.Rows.Add(rwAlumnosCursos);
            rwAlumnosCursos = dtAlumnos_Cursos.NewRow();
            rwAlumnosCursos[col_ac_IDAlumno] = 1;
            rwAlumnosCursos[col_ac_IDCurso] = 1;
            dtAlumnos_Cursos.Rows.Add(rwAlumnosCursos);

            //Vista en consola
            Console.Write("Por favor ingrese el nombre del curso: ");
            string materia = Console.ReadLine();
            Console.WriteLine("Listado de alumnos de " + materia);
            DataRow[] rowCursoInf = dtCursos.Select("Curso = '" + materia + "'");
            foreach(DataRow rowCu in rowCursoInf)
            {
                DataRow[] rowAlumnoInf = rowCu.GetChildRows(relCurso_ac);
                foreach(DataRow rowAl in rowAlumnoInf)
                {
                    Console.WriteLine(rowAl.GetParentRow(relAlumno_ac)[colApellido].ToString() + ", " 
                        + rowAl.GetParentRow(relAlumno_ac)[colNombre].ToString());
                }
                Console.ReadLine();
            }


        }
    }
}
