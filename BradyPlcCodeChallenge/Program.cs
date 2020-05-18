using System;
using System.IO;
using System.Threading;
using System.Xml.Serialization;


namespace BradyPlcCodeChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Brady PLC Code Challenge Application Running..");

            try
            {
                //Parsing config file
                ConfigFileHelper.ParseConfigFile();

                //check the File exists in the directory
                //If not check evey 10 seconds
                while(!File.Exists(ConfigFileHelper.GenerationReportFilePath))
                {
                    Console.WriteLine(string.Format("File Not Available in the directory : {0}", ConfigFileHelper.GenerationReportFilePath));
                    Console.WriteLine("Will check evey ten seconds");
                    Thread.Sleep(10000);

                }

                GenerationReport GenerationReport = XMLHelper.ParsingXML();                

                GenerationOutput GenerationOutput = new GenerationOutput(GenerationReport);

                XMLHelper.CreateXML(GenerationOutput);                
            }
            catch(Exception e)
            {
                Console.WriteLine(string.Format("Caught an Exception {0}", e.Message));
            }
            finally
            {
                Console.WriteLine("Press Any Key to Exit...");
                Console.ReadLine();
            }
        }        
    }
}
