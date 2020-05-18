using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace BradyPlcCodeChallenge
{
    public abstract class GeneratorBase
    {
        [XmlElement("Name")]
        public string Name { get; set; }

        [XmlArray("Generation")]
        [XmlArrayItem("Day", typeof(GenerationDay))]
        public List<GenerationDay> Days = new List<GenerationDay>();

        [XmlElement("Total")]
        public decimal Total { get; set; }


        public abstract decimal TotalGeneration();


    }
}
