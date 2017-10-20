using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Text;
using System.IO;
using System.Xml;
using System.Net;
using System.Net.Sockets;

namespace AngularCodingTest.Common
{
    internal class GlobalOperations
    {
        /// <summary>
        /// IP Address would be pulled from the server based on where the user was located at.  As this was running locally the IP was from my router. Using my Telus IP Address as an example 
        /// </summary>
        /// <param name="IP">50.99.70.163</param>
        /// <returns></returns>
        internal static string GetCurrentTemperature(string IP)
        {
            IP = "50.99.70.163"; //For testing since when running locally this was pulling from my router instead from my actual Provider IP Address

            string City = "";                                   
            //Initializing a new xml document object to begin reading the xml file returned
            XmlDocument doc = new XmlDocument();
            doc.Load("http://www.freegeoip.net/xml");
            XmlNodeList nodeLstCity = doc.GetElementsByTagName("City");
            City = "" + nodeLstCity[0].InnerText;
            int Temperature = GetCurrentTemperatureFromCity(City);
            string TempSummary = GetSummaryFromTemperature(Temperature);

            return "It's going to be " + TempSummary + " today in the city of " + City + ", a high of " + Temperature + "C.  Be sure to dress accordingly outside!";
                    
        }

        /// <summary>
        /// If connected online depending on location this would contact a weather API forcast.  For the demo the temperature will be a random number
        /// </summary>
        /// <param name="City"></param>
        /// <returns></returns>
        private static int GetCurrentTemperatureFromCity(string City)
        {            
            var rng = new Random();
            return rng.Next(-40, 55);
        }

        internal static string GetSummaryFromTemperature(int TemperatureC)
        {
            if (TemperatureC > 39)
            {
                return "Scorching";
            }
            else if (TemperatureC > 29)
            {
                return "Sweltering";
            }
            else if (TemperatureC > 19)
            {
                return "Hot";
            }
            else if (TemperatureC > 14)
            {
                return "Warm";
            }
            else if (TemperatureC > 9)
            {
                return "Mild";
            }
            else if (TemperatureC > -1)
            {
                return "Cool";
            }
            else if (TemperatureC > -6)
            {
                return "Chilly";
            }
            else if (TemperatureC > -11)
            {
                return "Bracing";
            }
            else
            {
                return "Freezing";
            }            
        }
    }
}
