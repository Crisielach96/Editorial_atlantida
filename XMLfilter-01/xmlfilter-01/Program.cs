
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;

namespace xmlfilter_01
{
    class Program
    {
        static void Main(string[] args)
        {

            string nombreA;
            string fecha, anioYmes, anio, fechaCompleta;
            string opcionST;
            int opcion = 0;
            bool salir = true;
            string resp;

            Console.Write("Ingrese nomber del archivo sin extension: ");
            nombreA = Console.ReadLine();
            Console.Clear();

            while (salir)
            {

                Console.WriteLine("1.Ingresar Fecha");
                Console.WriteLine("2.Salir");

                opcionST = Console.ReadLine();
                opcion = int.Parse(opcionST);
                Console.Clear();

                switch (opcion)
                {
                    case 1:
                        Console.Write("ingrese fecha (AAAA) o (AAAA-MM): ");
                        fecha = Console.ReadLine();

                        XmlDocument xmldoc = new XmlDocument();
                        XmlDocument xmldoc2 = new XmlDocument();

                        xmldoc.Load(nombreA + ".xml");
                        xmldoc2.Load("empty.xml");

                        XmlNodeList lista = xmldoc.SelectNodes("data/post");
                        XmlNode data = xmldoc2.SelectSingleNode("data");

                        int c = 0;
                        for (var i = 0; i < lista.Count - 1; i++)
                        {
                            XmlNode post = lista[i];
                            fechaCompleta = post.SelectSingleNode("Date").InnerText;
                            anioYmes = fechaCompleta.Substring(0, 7);
                            anio = fechaCompleta.Substring(0, 4);

                            if (anioYmes == fecha)
                            {
                                data.AppendChild(data.OwnerDocument.ImportNode(post, true));
                                c++;
                                Console.WriteLine("encontre " + c);
                            }
                            else if (anio == fecha)
                            {
                                data.AppendChild(data.OwnerDocument.ImportNode(post, true));
                                c++;
                                Console.WriteLine("encontre " + c);
                            }

                        }
                        xmldoc2.Save(fecha + ".xml");
                        Console.WriteLine("Done");
                        Console.ReadKey();
                        break;


                    case 2:
                        Console.Write("Quiere salir?  Y/N ");
                        resp = Console.ReadLine();
                        if (resp == "y")
                        {
                            salir = false;
                        }
                        break;
                }
                Console.Clear();

            }
            Console.WriteLine("PRESS ANY KEY");
            Console.ReadKey();
        }
    }
}
