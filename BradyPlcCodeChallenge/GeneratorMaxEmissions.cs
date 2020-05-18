using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace BradyPlcCodeChallenge
{
    public class GeneratorMaxEmissions
    {
        [XmlElement("Name")]
        public string Name { get; set; }

        [XmlElement("Date")]
        public DateTime Date { get; set; }

        [XmlElement("Emission")]
        public decimal Emission { get; set; }
    }
}
