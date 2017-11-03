using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Unidad4Lab02
{
    class ManejadorArchivo
    {
        protected DataTable misContactos;

        public ManejadorArchivo()
        {
            misContactos = getTabla();
        }

        public virtual DataTable getTabla()
        {
            return new DataTable();
        }

        public virtual void aplicaCambios()
        {

        }

        public void listar()
        {
            foreach(DataRow fila in misContactos.Rows)
            {
                if(fila.RowState != DataRowState.Deleted)
                {
                    foreach(DataColumn col in misContactos.Columns)
                    {
                        Console.WriteLine("{0}: {1}", col.ColumnName, fila[col]);
                    }
                    Console.WriteLine();
                }
            }
        }

        public void nuevaFila()
        {
            DataRow fila = misContactos.NewRow();
            foreach(DataColumn col in misContactos.Columns)
            {
                Console.Write("Ingrese: " + col.ColumnName);
                fila[col] = Console.ReadLine();
            }
            misContactos.Rows.Add(fila);
        }

        public void editarFila()
        {
            Console.Write("Ingrse el numero de fila a editar: ");
            int nroFila = Convert.ToInt32(Console.ReadLine());
            DataRow fila = misContactos.Rows[nroFila - 1];
            for(int nroCol = 1; nroCol < misContactos.Columns.Count; nroCol++)
            {
                DataColumn col = misContactos.Columns[nroCol];
                Console.Write("Ingrse {0}: ", col.ColumnName);
                fila[col] = Console.ReadLine();
            }
        }

        public void eliminarFila()
        {
            Console.Write("Ingrse el numero de fila a eliminar: ");
            int nroFila = Convert.ToInt32(Console.ReadLine());
            misContactos.Rows[nroFila - 1].Delete();
        }
    }
}
