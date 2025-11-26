using System.Text.Json.Serialization;

namespace TenkiApp.Model {
    // APIレスポンス全体のルート
    public class OpenMeteoResponse {
        [JsonPropertyName("latitude")]
        public double Latitude { get; set; }

        [JsonPropertyName("longitude")]
        public double Longitude { get; set; }

        // 現在の気象データ
        [JsonPropertyName("current")]
        public CurrentData Current { get; set; }

        // 時間ごとのデータ
        [JsonPropertyName("hourly")]
        public HourlyData Hourly { get; set; }
    }

    //  currentフィールドの中身
    public class CurrentData {
        [JsonPropertyName("temperature_2m")]
        public double Temperature2m { get; set; } // 現在の気温

        [JsonPropertyName("apparent_temperature")]
        public double ApparentTemperature { get; set; } // 体感気温

        [JsonPropertyName("wind_speed_10m")]
        public double WindSpeed10m { get; set; } // 風速
    }

    // hourlyフィールド
    public class HourlyData {

        [JsonPropertyName("time")]
        public List<string> Time { get; set; }

        [JsonPropertyName("temperature_2m")]
        public List<double> Temperature2m { get; set; }

        [JsonPropertyName("weather_code")]
        public List<int> WeatherCode { get; set; }
    }
}