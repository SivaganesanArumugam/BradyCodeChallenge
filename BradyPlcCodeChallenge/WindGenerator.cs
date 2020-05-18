using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace BradyPlcCodeChallenge
{
    public class WindGenerator : GeneratorBase
    {
        [XmlElement("Location")]
        public string Location { get; set; }

        public override decimal TotalGeneration()
        {
            if(Location == "Onshore")
            {
                foreach (var Day in Days)
                {
                    Total = Total + Day.Price * Day.Energy * ReferenceData.ValueFactorHigh;
                }

                return Total;
            }
            else
            {
                foreach (var Day in Days)
                {
                    Total = Total + Day.Price * Day.Energy * ReferenceData.ValueFactorLow;
                }

                return Total;
            }
        }        
    }
}
