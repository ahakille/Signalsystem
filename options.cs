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
        public string XmltoString(string opt)
        {
            string path;
            path = ("options.xml");
           
            XmlDocument doc = new XmlDocument();
            doc.Load(path);
            XmlNodeList options = doc.SelectNodes("/options/"+opt);
            string value = "COM1";
            foreach (XmlNode node in options)
            {


                value = node["value"].InnerText;
            }

                return value;
        }
    }
}
