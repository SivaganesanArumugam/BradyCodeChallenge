using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace BradyPlcCodeChallenge
{
    public static class XMLHelper
    {
        public static GenerationReport ParsingXML()
        {
            GenerationReport GenerationReport = null;

            XmlSerializer serializer = new XmlSerializer(typeof(GenerationReport));

            StreamReader reader = new StreamReader(ConfigFileHelper.GenerationReportFilePath);

            GenerationReport = (GenerationReport)serializer.Deserialize(reader);

            reader.Close();

            return GenerationReport;            
        }

        public static void CreateXML(GenerationOutput generationOutput)
        {
            //Code to remove the Name and Serialize
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add("", "");
            XmlSerializer x = new XmlSerializer(typeof(GenerationOutput));
            TextWriter writer = new StreamWriter(ConfigFileHelper.GenerationOutputFilePath);
            x.Serialize(writer, generationOutput, ns);
        }
    }
}
