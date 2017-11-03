using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;

namespace Unidad4Lab02
{
    class ManejadorArchivoTxt : ManejadorArchivo
    {
        protected string connectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source = E:\Joaquin\Documents\Workspaces\Labs\Unidad4Lab02\bin\Debug;" + "Extended Properties='text;HDR=Yes;FMT=Delimited'";

        public string ConnectionString { get => connectionString; }

        public override DataTable getTabla()
        {
            using (OleDbConnection conn = new OleDbConnection(ConnectionString))
            {
                OleDbCommand cmdSelect = new OleDbCommand("SELECT * FROM agenda.txt", conn);
                conn.Open();
                OleDbDataReader reader = cmdSelect.ExecuteReader();
                DataTable contactos = new DataTable();
                if (reader != null)
                {
                    contactos.Load(reader);
                }
                conn.Close();
                return contactos;
            }
        }

        public override void aplicaCambios()
        {
            using (OleDbConnection conn = new OleDbConnection(ConnectionString))
            {
                OleDbCommand cmdInsert = new OleDbCommand("INSERT INTO agenda.txt VALUES(@id, @nombre, @apellido, @email, @telefono)", conn);
                cmdInsert.Parameters.Add("@id", OleDbType.Integer);
                cmdInsert.Parameters.Add("@nombre", OleDbType.VarChar);
                cmdInsert.Parameters.Add("@apellido", OleDbType.VarChar);
                cmdInsert.Parameters.Add("@email", OleDbType.VarChar);
                cmdInsert.Parameters.Add("@telefono", OleDbType.VarChar);

                OleDbCommand cmdUpdate = new OleDbCommand("UPDATE agenda.txt SET nombre=@nombre, apellido=@apellido, e-mail=@email, telefono=@telefono WHERE id = @id", conn);
                cmdUpdate.Parameters.Add("@id", OleDbType.Integer);
                cmdUpdate.Parameters.Add("@nombre", OleDbType.VarChar);
                cmdUpdate.Parameters.Add("@apellido", OleDbType.VarChar);
                cmdUpdate.Parameters.Add("@email", OleDbType.VarChar);
                cmdUpdate.Parameters.Add("@telefono", OleDbType.VarChar);

                OleDbCommand cmdDelete = new OleDbCommand("DELETE FROM agenda.txt WHERE id = @id", conn);
                cmdDelete.Parameters.Add("@id", OleDbType.Integer);

                DataTable filasNuevas = misContactos.GetChanges(DataRowState.Added);
                DataTable filasBorradas = misContactos.GetChanges(DataRowState.Deleted);
                DataTable filasModificadas = misContactos.GetChanges(DataRowState.Modified);

                conn.Open();

                if (filasNuevas != null)
                {
                    foreach(DataRow fila in filasNuevas.Rows)
                    {
                        cmdInsert.Parameters["@id"].Value = fila["id"];
                        cmdInsert.Parameters["@nombre"].Value = fila["nombre"];
                        cmdInsert.Parameters["@apellido"].Value = fila["apellido"];
                        cmdInsert.Parameters["@telefono"].Value = fila["telefono"];
                        cmdInsert.Parameters["@email"].Value = fila["e-mail"];
                        cmdInsert.ExecuteNonQuery();
                    }
                }

                if (filasBorradas != null)
                {
                    foreach (DataRow fila in filasBorradas.Rows)
                    {
                        cmdDelete.Parameters["@id"].Value = fila["id", DataRowVersion.Original];
                        cmdInsert.ExecuteNonQuery();
                    }
                }

                if (filasModificadas != null)
                {
                    foreach (DataRow fila in filasModificadas.Rows)
                    {
                        cmdUpdate.Parameters["@id"].Value = fila["id"];
                        cmdUpdate.Parameters["@nombre"].Value = fila["nombre"];
                        cmdUpdate.Parameters["@apellido"].Value = fila["apellido"];
                        cmdUpdate.Parameters["@telefono"].Value = fila["telefono"];
                        cmdUpdate.Parameters["@email"].Value = fila["e-mail"];
                        cmdUpdate.ExecuteNonQuery();
                    }
                }
            }
        }
    }
}
