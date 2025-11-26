using TenkiApp.Model;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using System;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text.Json;

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

            SearchCommand = new RelayCommand(
                async () => await ExecuteSearch(),
                () => !string.IsNullOrWhiteSpace(SearchText)
            );
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
            }
            catch (HttpRequestException) {
                return (0, 0);
            }
            catch (JsonException) {
                return (0, 0);
            }
        }

        public async Task<string> GetLocationFromIpAsync() {
            using (var client = new HttpClient()) {
                var response = await client.GetStringAsync("http://ip-api.com/json/");
                try {
                    using (JsonDocument doc = JsonDocument.Parse(response)) {
                        var root = doc.RootElement;
                        string city = root.GetProperty("city").GetString();
                        string region = root.GetProperty("region").GetString();
                        return $"{region},{city} ";
                    }
                }
                catch (Exception) {
                    return "座標取得失敗";
                }
            }
        }

        private async Task ExecuteSearch() {
            if (string.IsNullOrWhiteSpace(SearchText))
                return;

            string locationName = SearchText.Trim();

            CurrentSummary = new WeatherSummary { LocationName = "座標検索中...", Temperature = "--°C", WeatherIcon = "🌍", WeatherDescription = "位置情報を確認しています" };
            OnPropertyChanged(nameof(CurrentSummary));

            var (lat, lon) = await GetCoordinatesFromAddressAsync(locationName);

            if (lat == 0 && lon == 0) {
                CurrentSummary = new WeatherSummary { LocationName = $"{locationName}の座標取得失敗", Temperature = "N/A", WeatherIcon = "❌", WeatherDescription = "指定された地名/住所の座標が見つかりませんでした" };
                return;
            }

            try {
                CurrentSummary.WeatherDescription = "天気データを取得中...";
                OnPropertyChanged(nameof(CurrentSummary));

                string apiUrl = $"https://api.open-meteo.com/v1/forecast?latitude={lat}&longitude={lon}&hourly=temperature_2m,weather_code&current=temperature_2m,apparent_temperature,wind_speed_10m&timezone=Asia%2FTokyo&forecast_days=1";
                var response = await _httpClient.GetStringAsync(apiUrl);
                var apiResponse = JsonSerializer.Deserialize<OpenMeteoResponse>(response);

                if (apiResponse?.Hourly?.Time == null || apiResponse.Hourly.Time.Count == 0) {
                    CurrentSummary = new WeatherSummary { LocationName = $"{locationName}のデータなし", Temperature = "N/A", WeatherIcon = "❌", WeatherDescription = "天気予報データがありません" };
                    HourlyForecast.Clear();
                    return;
                }

                if (apiResponse.Current == null || apiResponse.Hourly.WeatherCode.Count == 0) {
                    CurrentSummary = new WeatherSummary { LocationName = $"{locationName}のデータなし", Temperature = "N/A", WeatherIcon = "❌", WeatherDescription = "データが不完全" };
                    HourlyForecast.Clear();
                    return;
                }

                int currentWeatherCode = apiResponse.Hourly.WeatherCode.First();
                double currentTemp = apiResponse.Current.Temperature2m; // 取得した現在の気温
                double currentApparentTemp = apiResponse.Current.ApparentTemperature; // 取得した体感気温
                double currentWindSpeed = apiResponse.Current.WindSpeed10m; // 取得した風速

                CurrentSummary = new WeatherSummary {
                    LocationName = $"{locationName.ToUpper()} (緯度:{lat:F2}, 経度:{lon:F2})",
                    Temperature = $"{currentTemp:F1}°C", // 現在の気温
                    WeatherIcon = GetWeatherEmoji(currentWeatherCode),
                    WeatherDescription = GetWeatherDescription(currentWeatherCode),
                    ApparentTemperature = $"{currentApparentTemp:F1}°C",
                    WindSpeed = $"{currentWindSpeed:F1} km/h"
                };

                HourlyForecast.Clear();
                var hourlyTimes = apiResponse.Hourly.Time;
                var hourlyTemps = apiResponse.Hourly.Temperature2m;
                var hourlyCodes = apiResponse.Hourly.WeatherCode;

                for (int i = 0; i < Math.Min(hourlyTimes.Count, 24); i++) {
                    HourlyForecast.Add(new HourlyForecast {
                        Time = DateTime.Parse(hourlyTimes[i]),
                        WeatherIcon = GetWeatherEmoji(hourlyCodes[i]),
                        Temperature = hourlyTemps[i]
                    });
                }
            }
            catch (HttpRequestException) {
                CurrentSummary = new WeatherSummary { LocationName = "通信エラー", Temperature = "N/A", WeatherIcon = "🔌", WeatherDescription = "ネットワーク接続を確認してください" };
            }
            catch (Exception) {
                CurrentSummary = new WeatherSummary { LocationName = "データ処理エラー", Temperature = "N/A", WeatherIcon = "💥", WeatherDescription = "データ解析に失敗" };
            }
            finally {
                OnPropertyChanged(nameof(CurrentSummary));
            }
        }

        private string GetWeatherDescription(int code) {
            return code switch {
                0 => "快晴",
                1 or 2 or 3 => "薄曇り/曇り",
                45 or 48 => "霧",
                51 or 53 or 55 => "霧雨",
                61 or 63 or 65 => "雨",
                80 or 81 or 82 => "にわか雨",
                95 => "雷雨",
                _ => "その他"
            };
        }

        private string GetWeatherEmoji(int code) {
            return code switch {
                0 => "☀️",
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
}