using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;

namespace Unidad4Lab01Practica2
{
    class Program
    {
        static void Main(string[] args)
        {
            EscribirXML();
            Console.WriteLine("Archivo XML Creado con exito\nPresione una tecla para mostrarlo...");
            Console.ReadKey();
            LeerXML();
            Console.WriteLine("Presione una tecla para salir...");
            Console.ReadKey();
        }

        private static void EscribirXML()
        {
            XmlTextWriter escritorXML = new XmlTextWriter("agenda.xml", null);
            escritorXML.Formatting = Formatting.Indented;
            escritorXML.WriteStartDocument(true);
            escritorXML.WriteStartElement("DocumentElement");
            StreamReader lector = File.OpenText("agenda.txt");
            string linea;
            do
            {
                linea = lector.ReadLine();
                if (linea != null)
                {
                    string[] valores = linea.Split(';');
                    escritorXML.WriteStartElement("contactos");
                    escritorXML.WriteStartElement("nombre");
                    escritorXML.WriteValue(valores[0]);
                    escritorXML.WriteEndElement();
                    escritorXML.WriteStartElement("apellido");
                    escritorXML.WriteValue(valores[1]);
                    escritorXML.WriteEndElement();
                    escritorXML.WriteStartElement("email");
                    escritorXML.WriteValue(valores[2]);
                    escritorXML.WriteEndElement();
                    escritorXML.WriteStartElement("telefono");
                    escritorXML.WriteValue(valores[3]);
                    escritorXML.WriteEndElement();
                    escritorXML.WriteEndElement();
                }
            } while (linea != null);
            escritorXML.WriteEndElement();
            escritorXML.WriteEndDocument();
            escritorXML.Close();
            lector.Close();
        }

        private static void LeerXML()
        {
            XmlTextReader lectoXML = new XmlTextReader("agenda.xml");
            string tagAnterior = "";
            while(lectoXML.Read())
            {
                if(lectoXML.NodeType == XmlNodeType.Element)
                {
                    tagAnterior = lectoXML.Name;
                }
                else if(lectoXML.NodeType == XmlNodeType.Text)
                {
                    Console.WriteLine(tagAnterior + ": " + lectoXML.Value);
                }
            }
            lectoXML.Close();
        }
    }
}
