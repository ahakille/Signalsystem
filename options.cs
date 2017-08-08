using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Signalsystem
{
    class options
    {
        public string XmltoString()
        {
            string path;
            path = ("options.xml");
           
            XmlDocument doc = new XmlDocument();
            doc.Load(path);
            XmlNodeList options = doc.SelectNodes("/options/port");
            string port = "COM1";
            foreach (XmlNode node in options)
            {


                port = node["name"].InnerText;
            }

                return port;
        }
    }
}
