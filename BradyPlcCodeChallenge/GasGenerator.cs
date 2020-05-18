using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace BradyPlcCodeChallenge
{
    public class GasGenerator : GeneratorBase
    {
        [XmlElement("EmissionsRating")]
        public decimal EmissionsRating { get; set; }

        public override decimal TotalGeneration()
        {
            foreach (var Day in Days)
            {
                Total = Total + Day.Price * Day.Energy * ReferenceData.ValueFactorMedium;
            }

            return Total;
        }

        public List<DailyEmissions> CalculateDailyEmissions()
        {
            List<DailyEmissions> dailyEmissions = new List<DailyEmissions>();

            foreach (var Day in Days)
            {
                dailyEmissions.Add(new DailyEmissions { Name = Name, Date = Day.Date, Emission = Day.Energy * EmissionsRating * ReferenceData.EmissionsFactorMedium });
            }

            return dailyEmissions;
        }
    }
}
