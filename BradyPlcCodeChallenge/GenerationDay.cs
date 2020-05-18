using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace BradyPlcCodeChallenge
{
    public class GenerationDay
    {
        [XmlElement("Date")]
        public DateTime Date { get; set; }

        [XmlElement("Energy")]
        public decimal Energy { get; set; }

        [XmlElement("Price")]
        public decimal Price { get; set; }
    }
}
