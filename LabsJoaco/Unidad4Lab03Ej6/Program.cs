using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Unidad4Lab03Ej4
{
    class Program
    {
        static void Main(string[] args)
        {
            //Tabla
            DataTable dtEmpresas = new DataTable("Empresas");
            dtEmpresas.Columns.Add("CustomerID", typeof(string));
            dtEmpresas.Columns.Add("CompanyName", typeof(string));

            //Conexion SQL
            SqlConnection myConn = new SqlConnection();
            myConn.ConnectionString = "Data Source = BEYOND07; Initial Catalog = Northwind; User ID = sa; Pwd = 123;";
            SqlCommand myComando = new SqlCommand();
            myComando.CommandText = "SELECT CustomerID, CompanyName FROM Empresas";
            myComando.Connection = myConn;
            SqlDataAdapter myAdapter = new SqlDataAdapter(myComando.CommandText,myConn);
            myConn.Open();
            SqlDataReader myDataReader = myComando.ExecuteReader();
            dtEmpresas.Load(myDataReader);
            myConn.Close();

            //Mostrar en consola
            Console.WriteLine("Listado de empresas: ");
            foreach(DataRow rowEmpresa in dtEmpresas.Rows)
            {
                string idEmpresa = rowEmpresa["CustomerID"].ToString();
                string nombreEmpresa = rowEmpresa["CompanyName"].ToString();
                Console.WriteLine(idEmpresa + " - " + nombreEmpresa);
            }
            Console.ReadLine();

            //modificar
            Console.Write("Indique el ID que quiere modificar: ");
            string custID = Console.ReadLine();
            DataRow[] rowEmpresas = dtEmpresas.Select("CustomerID ='" + custID +"'");
            if(rowEmpresas.Length != 1)
            {
                Console.WriteLine("ID no encontrado");
                Console.ReadLine();
                return;
            }
            DataRow rowMiEmpresa = rowEmpresas[0];
            string nombreActual = rowMiEmpresa["CompanyName"].ToString();
            Console.WriteLine("Nombre actual: " + nombreActual);
            Console.Write("Escriba el nuevo nombre: ");
            string nuevoNombre = Console.ReadLine();
            rowMiEmpresa.BeginEdit();
            rowMiEmpresa["CompanyName"] = nuevoNombre;
            rowMiEmpresa.EndEdit();

            //update
            SqlCommand updateCommand = new SqlCommand();
            updateCommand.Connection = myConn;
            updateCommand.CommandText = ("UPDATE Empresas SET @CompanyName WHERE CustomerID = @CustomerID");
            updateCommand.Parameters.Add("@CustomerID", SqlDbType.NVarChar, 5, "CustomerID");
            updateCommand.Parameters.Add("@CompanyName", SqlDbType.NVarChar, 50, "CompanyName");
            myAdapter.UpdateCommand = updateCommand;
            myAdapter.Update(dtEmpresas);
        }
    }
}
