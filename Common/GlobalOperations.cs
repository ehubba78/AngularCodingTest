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
using AngularCodingTest.Models;
using Newtonsoft.Json;

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
            var result = GetCurrentTemperatureFromCity(City);

            return "Forecasting " + result.TemperatureC + " C (" + result.TemperatureF + " F) with a humitity of " + result.relative_humidity + " in the area of " + result.city + "...Last Updated on: " + result.LocalTime;
                    
        }

        /// <summary>
        /// If connected online depending on location this would contact a weather API forcast.  For the demo the temperature will be a random number
        /// </summary>
        /// <param name="City"></param>
        /// <returns></returns>
        private static CurrentTemperature GetCurrentTemperatureFromCity(string City)
        {
            //var rng = new Random();
            //return rng.Next(-40, 55);
            var foundentry = new CurrentTemperature();

            var WULink = "http://api.wunderground.com/api/77c9b6614c88bc8a/conditions/q/CA/" + City + ".xml";

            using (var w = new WebClient())
            {
                var weather = w.DownloadString(WULink);

                using (var reader = XmlReader.Create(new StringReader(weather)))
                {
                    while (reader.Read())
                    {
                        switch (reader.NodeType)
                        {
                            case XmlNodeType.Element:
                                if (reader.Name.Equals("local_time_rfc822"))
                                {
                                    reader.Read();
                                    foundentry.LocalTime = reader.Value;
                                }
                                else if (reader.Name.Equals("weather"))
                                {
                                    reader.Read();
                                    foundentry.Weather = reader.Value;
                                }
                                else if (reader.Name.Equals("temp_f"))
                                {
                                    reader.Read();
                                    foundentry.TemperatureF = reader.Value;
                                }
                                else if (reader.Name.Equals("temp_c"))
                                {
                                    reader.Read();
                                    foundentry.TemperatureC = reader.Value;
                                }
                                else if (reader.Name.Equals("full"))
                                {
                                    reader.Read();
                                    foundentry.city = reader.Value;
                                }
                                else if (reader.Name.Equals("relative_humidity"))
                                {
                                    reader.Read();
                                    foundentry.relative_humidity = reader.Value;
                                }
                                break;
                        }
                    }
                }
            }
            

            return foundentry;
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
