using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Configuration;

namespace BradyPlcCodeChallenge
{
    public static class ReferenceData
    {
        public static readonly decimal ValueFactorLow;

        public static readonly decimal ValueFactorMedium;

        public static readonly decimal ValueFactorHigh;

        public static readonly decimal EmissionsFactorLow;

        public static readonly decimal EmissionsFactorMedium;

        public static readonly decimal EmissionsFactorHigh;        

        static ReferenceData()
        {
            ValueFactorLow = GetReferenceData("ValueFactor", "Low");
            ValueFactorMedium = GetReferenceData("ValueFactor", "Medium");
            ValueFactorHigh = GetReferenceData("ValueFactor", "High");
            EmissionsFactorLow = GetReferenceData("EmissionsFactor", "Low");
            EmissionsFactorMedium = GetReferenceData("EmissionsFactor", "Medium");
            EmissionsFactorHigh = GetReferenceData("EmissionsFactor", "High");            
        }


        private static decimal GetReferenceData(string parentnodeName, string childnodeName)
        {
            decimal result = 0.0M;
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(ConfigFileHelper.ReferenceDataFilePath);
            XmlNode node = xmlDoc.DocumentElement.FirstChild;
            XmlNodeList lstFields = node.ChildNodes;

            for (int i = 0; i < lstFields.Count; i++)
            {
                if (lstFields[i].Name == parentnodeName)
                {
                    XmlNodeList lstCrap = lstFields[i].ChildNodes;
                    for (int j = 0; j < lstCrap.Count; j++)
                    {
                        if (lstCrap[j].Name == childnodeName)
                        {
                            //Console.WriteLine(lstCrap[j].InnerText);
                            result = Convert.ToDecimal(lstCrap[j].InnerText);
                            break;
                        }
                    }
                }
            }

            return result;

        }

        
    }
}
