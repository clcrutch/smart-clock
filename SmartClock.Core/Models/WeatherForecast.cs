using System;
using System.Collections.Generic;
using System.Text;

namespace SmartClock.Core.Models
{
    public class WeatherForecast
    {
        public WeatherCondition Condition { get; set; }
        public DateTime Date { get; set; }
        public float Temperature { get; set; }
    }
}
