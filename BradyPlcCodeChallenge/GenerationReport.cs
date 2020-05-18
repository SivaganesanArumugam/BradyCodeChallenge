using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace BradyPlcCodeChallenge
{
    [XmlRoot(ElementName = "GenerationReport")]
    public class GenerationReport
    {
        [XmlArray("Wind")]
        [XmlArrayItem("WindGenerator", typeof(WindGenerator))]
        public List<WindGenerator> WindGenerators = new List<WindGenerator>();       

        [XmlArray("Gas")]
        [XmlArrayItem("GasGenerator", typeof(GasGenerator))]
        public List<GasGenerator> GasGenerators = new List<GasGenerator>();

        [XmlArray("Coal")]
        [XmlArrayItem("CoalGenerator", typeof(CoalGenerator))]
        public List<CoalGenerator> CoalGenerators = new List<CoalGenerator>();
    }
}
