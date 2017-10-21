using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularCodingTest.Models
{
    public class CurrentTemperature
    {
        internal string city;

        public string TemperatureC { get; set; }
        public string TemperatureF { get; set; }
        public string LocalTime { get; set; }
        public string Message { get; set; }
        public string Weather { get; set; }
        public string relative_humidity { get; set; }
    }
}
