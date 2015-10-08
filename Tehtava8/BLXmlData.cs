using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Tehtava8
{
    class BLXmlData
    {
        private List<XmlDataModel> list = new List<XmlDataModel>();
        public List<XmlDataModel> getDataFromXml()
        {
            XElement xmlDoc = new XElement(XDocument.Load("Palautteet2.xml").Root);

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
            XDocument doc = XDocument.Load("test.xml");

            XmlDataModel tempData = new XmlDataModel
            {
                Name = "Coffee restraurant",
                PhoneNumber = "0xFF",
                Type = "Coffee shop"
            };
            doc.Root.Add(tempData);

            doc.Save("test.xml");
        }
    }
}
