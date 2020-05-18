using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace BradyPlcCodeChallenge
{
    public class CoalActualHeatRates
    {
        [XmlElement("Name")]
        public string Name { get; set; }

        [XmlElement("HeatRate")]
        public decimal HeatRate { get; set; }
    }
}
