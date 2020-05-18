using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace BradyPlcCodeChallenge
{
    public static class ConfigFileHelper
    { 
        public static string GenerationReportFilePath;

        public static string GenerationOutputFilePath;

        public static string ReferenceDataFilePath;

        public static void ParseConfigFile()
        {
            GenerationReportFilePath = ConfigurationManager.AppSettings["GenerationReportFilePath"];
            GenerationOutputFilePath = ConfigurationManager.AppSettings["GenerationOutputFilePath"];
            ReferenceDataFilePath = ConfigurationManager.AppSettings["ReferenceDataFilePath"];
        }
    }
}
