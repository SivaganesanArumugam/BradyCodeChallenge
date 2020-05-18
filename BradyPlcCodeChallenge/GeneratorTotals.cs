using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace BradyPlcCodeChallenge
{
    public class GeneratorTotals
    {
        [XmlElement("Name")]
        public string Name { get; set; }

        [XmlElement("Total")]
        public decimal Total { get; set; }
    }
}
