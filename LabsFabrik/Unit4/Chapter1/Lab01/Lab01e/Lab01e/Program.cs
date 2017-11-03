using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;

namespace Lab01e
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Presione una tecla para generar el archivo agendaxml.xml con los datos de agenda.txt");
            Console.ReadKey();
            escribirXML();
            Console.WriteLine("Archivo agendaxml.xml generado correcamente\n\nPresione una tecla para ver su contenido");
            Console.ReadKey();
            Console.WriteLine();
            leerXML();
            Console.ReadKey();
        }

        private static void escribirXML()
        {
            XmlTextWriter escritorXML = new XmlTextWriter("agendaxml.xml",null);
            escritorXML.Formatting = Formatting.Indented; //esto no es necesario pero hará mas facil para nosotros leer el contenido del archivo
            escritorXML.WriteStartDocument(true);
            escritorXML.WriteStartElement("DocumentElement");
            //este elemento no es necesario lo agregaremos para  compatibilidad con los xml generados en el siguiete laboratorio
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
                    escritorXML.WriteEndElement();//cerramos el tag de nombre
                    escritorXML.WriteStartElement("apellido");
                    escritorXML.WriteValue(valores[1]);
                    escritorXML.WriteEndElement();//cerramos el tag de apellido
                    escritorXML.WriteStartElement("email");
                    escritorXML.WriteValue(valores[2]);
                    escritorXML.WriteEndElement();//cerramos el tag de email
                    escritorXML.WriteStartElement("telefono");
                    escritorXML.WriteValue(valores[3]);
                    escritorXML.WriteEndElement();//cerramos el tag de telefono
                    escritorXML.WriteEndElement();//cerramos el tag de contacto
                }
            }
            while (linea != null);
            escritorXML.WriteEndElement();//cerramos el tag de DocumentElement
            escritorXML.WriteEndDocument();
            escritorXML.Close();

            lector.Close();
        }

        private static void leerXML()
        {
            XmlTextReader lectorXML = new XmlTextReader("agendaxml.xml");

            string tagAnterior = "";
            while (lectorXML.Read())
            {
                if (lectorXML.NodeType == XmlNodeType.Element)
                {
                    tagAnterior = lectorXML.Name;
                }
                else if(lectorXML.NodeType == XmlNodeType.Text)
                {
                    Console.WriteLine(tagAnterior + ": " + lectorXML.Value);
                }
            }
            lectorXML.Close();
        }

    }
}
