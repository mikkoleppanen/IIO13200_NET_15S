using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Tehtava8
{
    class XmlDataModel
    {
        [XmlElement(ElementName = "pvm")]
        public String date { get; set; }

        [XmlElement(ElementName = "tekija")]
        public String name { get; set; }

        [XmlElement(ElementName = "opittu")]
        public String learned { get; set; }

        [XmlElement(ElementName = "haluanoppia")]
        public String wantToLearn { get; set; }

        [XmlElement(ElementName = "hyvaa")]
        public String good { get; set; }

        [XmlElement(ElementName = "parannettavaa")]
        public String bad { get; set; }

        [XmlElement(ElementName = "muuta")]
        public String other { get; set; }

    }
}
