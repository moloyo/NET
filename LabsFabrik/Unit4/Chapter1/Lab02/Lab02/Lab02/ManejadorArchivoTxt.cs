using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;

namespace Lab02
{
    public class ManejadorArchivoTxt: ManejadorArchivo
    {
       protected string connectionString
       {
            get
            {
                return @"Provider=Microsoft.Jet.OLEDB.4.0;
                       Data Source=C:\Users\usuario\Documents\net\unidad 4\Lab02\Lab02\Lab02\bin\Debug;" +
                       "Extended Properties='text;HDR=Yes;FMT=Delimited'";
                
            }
        }

        public override DataTable getTabla()
        {
            using (OleDbConnection Conn = new OleDbConnection(connectionString))
            {
                OleDbCommand cmdSelect = new OleDbCommand("select * from agenda.txt", Conn);
                Conn.Open();
                OleDbDataReader reader = cmdSelect.ExecuteReader();
                DataTable contactos = new DataTable();
                if (reader != null)
                {
                    contactos.Load(reader);
                }
                Conn.Close();
                return contactos;
            }
        }

        public override void aplicaCambios()
        {
            using (OleDbConnection Conn = new OleDbConnection(connectionString))
            {
                OleDbCommand cmdInsert = new OleDbCommand("insert into agenda.txt values(@ID,@Nombre,@Apellido,@Email,@Telefono)", Conn);
                cmdInsert.Parameters.Add("@ID", OleDbType.Integer);
                cmdInsert.Parameters.Add("@Nombre", OleDbType.VarChar);
                cmdInsert.Parameters.Add("@Apellido", OleDbType.VarChar);
                cmdInsert.Parameters.Add("@Email", OleDbType.VarChar);
                cmdInsert.Parameters.Add("@Telefono", OleDbType.VarChar);

                OleDbCommand cmdUpdate = new OleDbCommand(
                    "update agenda.txt set Nombre=@Nombre, Apellido=@Apellido, Email=@Email,Telefono=@Telefono where ID=@ID", Conn);
                cmdUpdate.Parameters.Add("@ID", OleDbType.Integer);
                cmdUpdate.Parameters.Add("@Nombre", OleDbType.VarChar);
                cmdUpdate.Parameters.Add("@Apellido", OleDbType.VarChar);
                cmdUpdate.Parameters.Add("@Email", OleDbType.VarChar);
                cmdUpdate.Parameters.Add("@Telefono", OleDbType.VarChar);

                OleDbCommand cmdDelete = new OleDbCommand("delete from agenda.txt where ID=@ID", Conn);
                cmdDelete.Parameters.Add("@ID", OleDbType.Integer);

                DataTable filasNuevas = this.misContactos.GetChanges(DataRowState.Added);
                DataTable filasBorradas = this.misContactos.GetChanges(DataRowState.Deleted);
                DataTable filasModificadas = this.misContactos.GetChanges(DataRowState.Modified);

                Conn.Open();

                if (filasNuevas != null)
                {
                    foreach (DataRow fila in filasNuevas.Rows)
                    {
                        cmdInsert.Parameters["@ID"].Value = fila["ID"];
                        cmdInsert.Parameters["@Nombre"].Value = fila["Nombre"];
                        cmdInsert.Parameters["@Apellido"].Value = fila["Apellido"];
                        cmdInsert.Parameters["@Email"].Value = fila["Email"];
                        cmdInsert.Parameters["@Telefono"].Value = fila["Telefono"];
                        cmdInsert.ExecuteNonQuery();
                    }
                }

                if (filasBorradas != null)
                {
                    foreach (DataRow fila in filasBorradas.Rows)
                    {
                        cmdDelete.Parameters["@ID"].Value = fila["ID", DataRowVersion.Original];
                        cmdDelete.ExecuteNonQuery();

                    }
                }

                if (filasModificadas != null)
                {
                    foreach (DataRow fila in filasModificadas.Rows)
                    {
                        cmdUpdate.Parameters["@ID"].Value = fila["ID"];
                        cmdUpdate.Parameters["@Nombre"].Value = fila["Nombre"];
                        cmdUpdate.Parameters["@Apellido"].Value = fila["Apellido"];
                        cmdUpdate.Parameters["@Email"].Value = fila["Email"];
                        cmdUpdate.Parameters["@Telefono"].Value = fila["Telefono"];
                        cmdUpdate.ExecuteNonQuery();
                    }
                }
                  

            }
            

        }

    }
}
