using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Tehtava8
{

    public class XmlDataModel
    {
        public String date { get; set; }

        public String name { get; set; }

        public String learned { get; set; }

        public String wantToLearn { get; set; }

        public String good { get; set; }

        public String bad { get; set; }

        public String other { get; set; }

    }
}
