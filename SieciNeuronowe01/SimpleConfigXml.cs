using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SieciNeuronowe01
{
    public class SimpleConfigXml
    {
        const string XML_ROOT = "params";
        string filename;
        XDocument xmlFile;

        FileStream CreateFile(string filename)
        {
            FileStream file = File.Create(filename);
            file.Close();
            return file;
        }

        public SimpleConfigXml(string filename)
        {
            this.filename = filename;
            if (!File.Exists(filename))
            {
                CreateFile(filename);
                xmlFile = new XDocument(new XElement(XML_ROOT));
                xmlFile.Save(filename);
            }
            else xmlFile = XDocument.Load(filename);
        }

        public double GetDoubleValue(string name)
        {
            XElement xelement = xmlFile.Element(XML_ROOT).Element(name);
            return xelement == null ? 0.0 : Double.Parse(xelement.Value, System.Globalization.CultureInfo.InvariantCulture);
        }

        public void SetDoubleValue(string name, double value)
        {
            if (xmlFile.Element(XML_ROOT).Element(name) != null)
                xmlFile.Element(XML_ROOT).Element(name).SetValue(value.ToString(System.Globalization.CultureInfo.InvariantCulture));
            else xmlFile.Element(XML_ROOT).AddFirst(new XElement(name, value.ToString(System.Globalization.CultureInfo.InvariantCulture)));
            xmlFile.Save(filename);
        }

    }
}