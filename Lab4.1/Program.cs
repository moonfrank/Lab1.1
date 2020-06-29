using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;

namespace Lab4._1
{
    class Program
    {
        static void Main(string[] args)
        {
            Leer();
            Escribir();
            Leer();
            Console.ReadKey();
            Console.WriteLine("Presione una tecla para generar archivo .xml");
            Console.ReadKey();
            EscribirXML();
            Console.WriteLine("Archivo generado coorectamente. Presione una tecla para ver su contenido.");
            Console.ReadKey();
            LeerXML();
            Console.ReadKey();

        }

        private static void Leer()
        {
            #region Código reemplazado
            /*
            FileStream lector = new FileStream("agenda.txt", FileMode.Open, FileAccess.Read, FileShare.Read);
            while(lector.Length > lector.Position)
                {
                    Console.Write((char)lector.ReadByte());
                }
            */

            /*
            StreamReader lector = File.OpenText("agenda.txt");
            string linea;
            do
            {
                linea = lector.ReadLine();
                if (linea != null) Console.WriteLine(linea);
            }
            while (linea != null);
            */
            #endregion

            StreamReader lector = File.OpenText("agenda.txt");
            string linea;
            Console.WriteLine("Nombre\tApellido\te-mail\t\t\tTeléfono");
            do
            {
                linea = lector.ReadLine();
                if (linea != null)
                {
                    string[] valores = linea.Split(';');
                    Console.WriteLine("{0}\t{1}\t{2}\t{3}", valores[0], valores[1], valores[2], valores[3]);
                }
            } while (linea != null);
            lector.Close();
        }

        private static void Escribir()
        {
            StreamWriter escritor = File.AppendText("agenda.txt");
            Console.Write("Desea ingresar un contacto? (S/N) ");
            string rta = Console.ReadLine();
            while (rta=="S")
            {
                Console.WriteLine("Ingrese nuevo contacto");
                Console.WriteLine();
                Console.WriteLine("Ingrese nombre");
                string nombre = Console.ReadLine();
                Console.WriteLine();
                Console.WriteLine("Ingrese apellido");
                string apellido = Console.ReadLine();
                Console.WriteLine();
                Console.WriteLine("Ingrese e-mail");
                string email = Console.ReadLine();
                Console.WriteLine();
                Console.WriteLine("Ingrese teléfono");
                string telefono = Console.ReadLine();
                Console.WriteLine();
                Console.WriteLine();

                escritor.WriteLine(nombre + ";" + apellido + ";" + email + ";" + telefono);

                Console.Write("Desea ingresar otro contacto? (S/N) ");
                rta = Console.ReadLine();
            }
            escritor.Close();
        }

        private static void EscribirXML()
        {
            XmlTextWriter escritorXML = new XmlTextWriter("agendaxml.xml", null);
            escritorXML.Formatting = Formatting.Indented;
            escritorXML.WriteStartDocument(true);
            escritorXML.WriteStartElement("DocumentElement");
            StreamReader lector = File.OpenText("agenda.txt");
            string linea;
            do
            {
                if ((linea = lector.ReadLine()) != null)
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
            XmlTextReader lectorXML = new XmlTextReader("agendaxml.xml");

            string tagAnterior = "";
            while (lectorXML.Read())
            {
                if (lectorXML.NodeType == XmlNodeType.Element) tagAnterior = lectorXML.Name;
                else if (lectorXML.NodeType == XmlNodeType.Text) Console.WriteLine(tagAnterior + " " + lectorXML.Value);
            }
            lectorXML.Close();
        }
        
    }
}
