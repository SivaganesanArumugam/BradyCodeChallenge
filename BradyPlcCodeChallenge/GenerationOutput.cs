using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace BradyPlcCodeChallenge
{
    public class GenerationOutput
    {
        [XmlArray("Totals")]
        [XmlArrayItem("Generator", typeof(GeneratorTotals))]
        public List<GeneratorTotals> GeneratorTotals = new List<GeneratorTotals>();

        [XmlArray("MaxEmissionGenerators")]
        [XmlArrayItem("Day", typeof(GeneratorMaxEmissions))]
        public List<GeneratorMaxEmissions> GeneratorMaxEmissions = new List<GeneratorMaxEmissions>();

        [XmlElement("ActualHeatRates")]
        public List<CoalActualHeatRates> CoalActualHeatRates = new List<CoalActualHeatRates>();        

        private GenerationReport generationReport;

        public GenerationOutput(GenerationReport generationReport)
        {
            this.generationReport = generationReport;
            GenerateOutput();
        }

        public GenerationOutput()
        {

        }

        private void GenerateOutput()
        {
            GetGeneratorTotals();
            GetGeneratorMaxEmissions();
            GetActualHeatRates();
        }

        private void GetGeneratorTotals()
        {
            foreach (var CoalGenerator in generationReport.CoalGenerators)
            {
                GeneratorTotals.Add(new GeneratorTotals { Name = CoalGenerator.Name, Total = CoalGenerator.TotalGeneration() });
                Console.WriteLine(string.Format("CoalGenerator {0} {1}", CoalGenerator.Name, CoalGenerator.TotalGeneration()));
            }

            foreach (var GasGenerator in generationReport.GasGenerators)
            {
                GeneratorTotals.Add(new GeneratorTotals { Name = GasGenerator.Name, Total = GasGenerator.TotalGeneration() });
                Console.WriteLine(string.Format("GasGenerator {0} {1}", GasGenerator.Name, GasGenerator.TotalGeneration()));
            }

            foreach (var WindGenerator in generationReport.WindGenerators)
            {
                GeneratorTotals.Add(new GeneratorTotals { Name = WindGenerator.Name, Total = WindGenerator.TotalGeneration() });
                Console.WriteLine(string.Format("WindGenerator {0} {1}", WindGenerator.Name, WindGenerator.TotalGeneration()));
            }    

            
        }

        private void GetActualHeatRates()
        {
            foreach (var CoalGenerator in generationReport.CoalGenerators)
            {
                CoalActualHeatRates.Add(new CoalActualHeatRates { Name = CoalGenerator.Name, HeatRate = CoalGenerator.CalculateActualHeatRate() });
                Console.WriteLine(string.Format("CoalGenerator Actual Heat Generator {0} {1}", CoalGenerator.Name, CoalGenerator.CalculateActualHeatRate()));
            }            
        }

        private List<DailyEmissions> GetFossyGeneratorDailyEmissions()
        {
            List<DailyEmissions> DailyEmissions = new List<DailyEmissions>();

            foreach (var CoalGenerator in generationReport.CoalGenerators)
            {
                DailyEmissions.AddRange(CoalGenerator.CalculateDailyEmissions());

                //Console.WriteLine(string.Format("CoalGenerator {0} {1}", CoalGenerator.Name, CoalGenerator.TotalGeneration()));
            }

            foreach (var GasGenerator in generationReport.GasGenerators)
            {
                DailyEmissions.AddRange(GasGenerator.CalculateDailyEmissions());

                //Console.WriteLine(string.Format("GasGenerator {0} {1}", GasGenerator.Name, GasGenerator.TotalGeneration()));
            }

            return DailyEmissions;
        } 
        

        private void GetGeneratorMaxEmissions()
        {
            List<DailyEmissions> DailyEmissions = GetFossyGeneratorDailyEmissions().ToList();

            //Get the number of Generator Days
            var generatorDays = DailyEmissions.Where(r => r.Date != null)
                        .Select(r => r.Date)
                        .Distinct();         


            foreach (var generatorDay in generatorDays)
            {
                //Get all the generator daily emissions on the selected date
                //Then Get the MaximumEmission on the selected date
                var employee = DailyEmissions.Where(x => x.Date == generatorDay);                
                var maxemission = employee.Aggregate((i1, i2) => i1.Emission > i2.Emission ? i1 : i2);

                GeneratorMaxEmissions.Add(new GeneratorMaxEmissions { Name = maxemission.Name, Date = maxemission.Date, Emission = maxemission.Emission });
                
                Console.WriteLine(string.Format("Max Emission {0} {1} {2}", maxemission.Date, maxemission.Name, maxemission.Emission));

            }            
        }
    }
}
