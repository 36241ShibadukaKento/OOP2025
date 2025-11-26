using TenkiApp.Model;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text.Json;
using System.Linq;
using System.Collections.Generic;

namespace TenkiApp.ViewModel {
public class MainViewModel : ViewModelBase {
    private static readonly HttpClient _httpClient = new HttpClient();

    private string _searchText;
    public string SearchText {
        get => _searchText;
        set {
            _searchText = value;
            OnPropertyChanged(nameof(SearchText));
            CommandManager.InvalidateRequerySuggested();
        }
    }

    private WeatherSummary _currentSummary;
    public WeatherSummary CurrentSummary {
        get => _currentSummary;
        set {
            _currentSummary = value;
            OnPropertyChanged(nameof(CurrentSummary));
        }
    }

    public ObservableCollection<HourlyForecast> HourlyForecast { get; set; } = new ObservableCollection<HourlyForecast>();

    public ICommand SearchCommand { get; private set; }

    public MainViewModel() {
        CurrentSummary = new WeatherSummary();
        SearchCommand = new RelayCommand(async () => await ExecuteSearch(), () => !string.IsNullOrWhiteSpace(SearchText));
    }

    public async Task InitializeAsync() {
        var (lat, lon) = await GetCoordinatesFromIpAsync();
        if (lat != 0 && lon != 0) {
            string address = await GetAddressFromCoordinatesAsync(lat, lon);
            CurrentSummary.LocationName = $"{address}（現在地）";
            await ExecuteSearchByCoordinates(lat, lon, address);
        }
    }

    private async Task<(double lat, double lon)> GetCoordinatesFromIpAsync() {
        try {
            var response = await _httpClient.GetStringAsync("http://ip-api.com/json/");
            using var doc = JsonDocument.Parse(response);
            var root = doc.RootElement;
            double lat = root.GetProperty("lat").GetDouble();
            double lon = root.GetProperty("lon").GetDouble();
            return (lat, lon);
        } catch { return (0, 0); }
    }

    private async Task<string> GetAddressFromCoordinatesAsync(double lat, double lon) {
        string url = $"https://mreversegeocoder.gsi.go.jp/reverse-geocoder/LonLatToAddress?lat={lat}&lon={lon}";
        try {
            var response = await _httpClient.GetStringAsync(url);
            using var doc = JsonDocument.Parse(response);
            var root = doc.RootElement;
            var address = root.GetProperty("results").GetProperty("lv01Nm").GetString();
            return address ?? "住所不明";
        } catch { return "住所取得失敗"; }
    }

    private async Task ExecuteSearch() {
        if (string.IsNullOrWhiteSpace(SearchText)) return;
        var (lat, lon) = await GetCoordinatesFromAddressAsync(SearchText.Trim());
        if (lat == 0 && lon == 0) {
            CurrentSummary = new WeatherSummary { LocationName = $"{SearchText}の座標取得失敗", Temperature = "N/A", WeatherIcon = "❌", WeatherDescription = "指定された地名の座標が見つかりません" };
            return;
        }
        await ExecuteSearchByCoordinates(lat, lon, SearchText.Trim());
    }

    private async Task ExecuteSearchByCoordinates(double lat, double lon, string displayName) {
        try {
            string apiUrl = $"https://api.open-meteo.com/v1/forecast?latitude={lat}&longitude={lon}&hourly=temperature_2m,weather_code&current=temperature_2m,apparent_temperature,wind_speed_10m&timezone=Asia%2FTokyo&forecast_days=1";
            var response = await _httpClient.GetStringAsync(apiUrl);
            var apiResponse = JsonSerializer.Deserialize<OpenMeteoResponse>(response);

            if (apiResponse?.Hourly?.Time == null || apiResponse.Hourly.Time.Count == 0) {
                CurrentSummary = new WeatherSummary { LocationName = $"{displayName}のデータなし", Temperature = "N/A", WeatherIcon = "❌", WeatherDescription = "天気予報データがありません" };
                HourlyForecast.Clear();
                return;
            }

            int currentWeatherCode = apiResponse.Hourly.WeatherCode.First();
            double currentTemp = apiResponse.Current.Temperature2m;
            double currentApparentTemp = apiResponse.Current.ApparentTemperature;
            double currentWindSpeed = apiResponse.Current.WindSpeed10m;

            CurrentSummary = new WeatherSummary {
                LocationName = $"{displayName} (緯度:{lat:F2}, 経度:{lon:F2})",
                Temperature = $"{currentTemp:F1}°C",
                WeatherIcon = GetWeatherEmoji(currentWeatherCode),
                WeatherDescription = GetWeatherDescription(currentWeatherCode),
                ApparentTemperature = $"{currentApparentTemp:F1}°C",
                WindSpeed = $"{currentWindSpeed:F1} km/h"
            };

            HourlyForecast.Clear();
            for (int i = 0; i < Math.Min(apiResponse.Hourly.Time.Count, 24); i++) {
                HourlyForecast.Add(new HourlyForecast {
                    Time = DateTime.Parse(apiResponse.Hourly.Time[i]),
                    WeatherIcon = GetWeatherEmoji(apiResponse.Hourly.WeatherCode[i]),
                    Temperature = apiResponse.Hourly.Temperature2m[i]
                });
            }
        } catch {
            CurrentSummary = new WeatherSummary { LocationName = "通信エラー", Temperature = "N/A", WeatherIcon = "🔌", WeatherDescription = "ネットワーク接続を確認してください" };
        }
    }

    private async Task<(double lat, double lon)> GetCoordinatesFromAddressAsync(string address) {
        string encodedAddress = Uri.EscapeDataString(address);
        string geoApiUrl = $"https://msearch.gsi.go.jp/address-search/AddressSearch?q={encodedAddress}";
        try {
            var response = await _httpClient.GetStringAsync(geoApiUrl);
            var features = JsonSerializer.Deserialize<List<GsiFeature>>(response);
            if (features != null && features.Count > 0 && features[0].Geometry?.Coordinates?.Length == 2) {
                double longitude = features[0].Geometry.Coordinates[0];
                double latitude = features[0].Geometry.Coordinates[1];
                return (latitude, longitude);
            }
            return (0, 0);
        } catch { return (0, 0); }
    }

    private string GetWeatherDescription(int code) => code switch {
        0 => "快晴",
        1 or 2 or 3 => "薄曇り/曇り",
        45 or 48 => "霧",
        51 or 53 or 55 => "霧雨",
        61 or 63 or 65 => "雨",
        80 or 81 or 82 => "にわか雨",
        95 => "雷雨",
        _ => "その他"
    };

    private string GetWeatherEmoji(int code) => code switch {
        0 => "☀",
        1 or 2 or 3 => "☁️",
        45 or 48 => "🌫️",
        51 or 53 or 55 => "🌧️",
        61 or 63 or 65 => "☔",
        80 or 81 or 82 => "🌦️",
        95 => "⛈️",
        _ => "❓"
    };
}
}