using System;

namespace TenkiApp.Model {
    public class HourlyForecast {
        public DateTime Time { get; set; }
        public string? WeatherIcon { get; set; }
        public double Temperature { get; set; }
    }
}