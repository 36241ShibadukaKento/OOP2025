using System.Text.Json.Serialization;

namespace TenkiApp.Model {
    public class GsiFeature {
        [JsonPropertyName("geometry")]
        public GsiGeometry? Geometry { get; set; }
    }

    public class GsiGeometry {
        [JsonPropertyName("coordinates")]
        public double[]? Coordinates { get; set; } // [経度, 緯度]
    }
}