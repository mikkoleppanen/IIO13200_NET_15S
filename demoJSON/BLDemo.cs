using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demoJSON
{
    public class Person
    {
        public String Name { get; set; }
        public String Gender { get; set; }
        public DateTime Birthday { get; set; }
    }

    public class Politic : Person
    {
        public String Party { get; set; }
        public String Position { get; set; }
    }
}
