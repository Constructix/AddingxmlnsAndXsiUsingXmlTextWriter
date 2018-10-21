using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace AddingxmlnsAndXsiUsingXmlTextWriter
{
    class Program
    {
        static void Main(string[] args)
        {

            MemoryStream ms  = new MemoryStream();

            XmlTextWriter writer =new XmlTextWriter(ms, null);
            writer.WriteStartElement("someElement");
            writer.WriteAttributeString("xmlns", null, "http://something");
            writer.WriteAttributeString("xmlns", "xsi", null, "http://www.w3.org/2001/XMLSchema-instance");
            writer.WriteAttributeString("xsi", "schemaLocation", null,"http://something.myschema.xsd");
            writer.WriteEndElement();
            writer.Flush();

            ms.Position = 0;
            using (StreamReader sr = new StreamReader(ms))
            {
                Console.WriteLine(sr.ReadToEnd());
            }

        }
    }
}
