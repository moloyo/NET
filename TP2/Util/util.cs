using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Controls;
using System.Windows.Data;

namespace Util {

    public class Util {
        public static List<T> DataReaderMapToList<T>(IDataReader dr) {
            var list = new List<T>();
            var columns = new List<string>();
            for (int i = 0; i < dr.FieldCount; i++) {
                columns.Add(dr.GetName(i).ToLower());
            }
            while (dr.Read()) {
                var obj = Activator.CreateInstance<T>();
                foreach (var prop in obj.GetType().GetProperties()) {
                    string name = prop.Name.ToLower();
                    if (columns.Contains(name) && !Equals(dr[name], DBNull.Value)) {
                        prop.SetValue(obj, dr[name], null);
                    }
                }
                list.Add(obj);
            }
            return list;
        }

        public static string Sha1HashString(string s) {
            byte[] bytes = Encoding.UTF8.GetBytes(s);

            using (var sha1 = SHA1.Create()) {
                byte[] hashBytes = sha1.ComputeHash(bytes);

                return HexStringFromBytes(hashBytes);
            }
        }

        private static string HexStringFromBytes(byte[] bytes) {
            StringBuilder sb = new StringBuilder();

            foreach (byte b in bytes) {
                var hex = b.ToString("x2");
                sb.Append(hex);
            }
            return sb.ToString();
        }

        public static void AddGridViewColumns<T>(T first, GridView allUserGridView) {
            allUserGridView.Columns.Clear();
            List<string> values = first.GetType().GetProperties()
                                    .Where(prop => prop.GetValue(first) != null)
                                    .Select(prop => prop.Name)
                                    .ToList();
            foreach (string prop in values) {
                GridViewColumn gvc = new GridViewColumn {
                    Header = prop,
                    DisplayMemberBinding = new Binding(prop)
                };
                allUserGridView.Columns.Add(gvc);
            }
        }
    }
}
