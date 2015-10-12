using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Tehtava8
{
    class BLXmlData
    {
        private List<XmlDataModel> list = new List<XmlDataModel>();
        private String xmlFilePath = "Palautteet2.xml";
        public void setFilePath()
        {
            this.xmlFilePath = ConfigurationManager.AppSettings["DataFile"];
        }
        public List<XmlDataModel> getDataFromXml()
        {
            XElement xmlDoc = new XElement(XDocument.Load(xmlFilePath).Root);

            list = (from el in xmlDoc.Descendants("palaute")
                     select new XmlDataModel
                     {
                         date = el.Element("pvm").Value,
                         name = el.Element("tekija").Value,
                         learned = el.Element("opittu").Value,
                         wantToLearn = el.Element("haluanoppia").Value,
                         good = el.Element("hyvaa").Value,
                         bad = el.Element("parannettavaa").Value,
                         other = el.Element("muuta").Value
                     }).ToList();

            return list;
        }

        public void writeDataToXml(String name, String learned, String wantToLearn, String good, String bad, String other)
        {
            XDocument doc = XDocument.Load(xmlFilePath);
            XElement restaurant = new XElement("palaute",
                new XElement("pvm", DateTime.Now.ToString("yyyyMMdd")),
                new XElement("tekija", name),
                new XElement("opittu", learned),
                new XElement("haluanoppia", wantToLearn),
                new XElement("hyvaa", good),
                new XElement("parannettavaa", bad),
                new XElement("muuta", other));
            doc.Root.Add(restaurant);
            doc.Save(xmlFilePath);
        }
    }
}
