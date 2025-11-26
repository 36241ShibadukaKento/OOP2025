namespace TenkiApp.Model {
    public class WeatherSummary {
        public string LocationName { get; set; } = "場所を検索してください";
        public string Temperature { get; set; } = "--°C";
        public string WeatherIcon { get; set; } = "❓";
        public string WeatherDescription { get; set; } = "___";

        public string ApparentTemperature { get; set; } = "--°C"; // 体感気温
        public string WindSpeed { get; set; } = "-- km/h"; // 風速
    }
}