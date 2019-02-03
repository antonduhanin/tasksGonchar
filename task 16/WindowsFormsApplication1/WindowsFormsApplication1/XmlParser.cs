using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace WindowsFormsApplication1
{
    class XmlParser
    {
        private string data;

        public XmlParser(string inputData)
        {
            this.data = inputData;
        }
        public string parse()
        {
            string[] rows = data.Split('\n');
            XElement[] elements = parseStringToElement(rows);
            XElement xmlTree1 = new XElement("Root", elements);
            return xmlTree1.ToString(); ;
        }

        private XElement[] parseStringToElement(string[] rows)
        {
            List<XElement> list = new List<XElement>();
            for (int i = 0; i < rows.Length; i++)
            {
                if(rows[i]!=""){
                    list.Add(new XElement("row", rows[i]));
                }
            }
            return list.ToArray();

        }

    }
}
