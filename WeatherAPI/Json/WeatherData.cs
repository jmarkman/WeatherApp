using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WeatherAPI
{
    public class WeatherData
    {
        [JsonProperty(PropertyName = "coord")]
        public Coord Coordinates { get; set; }
        [JsonProperty(PropertyName = "weather")]
        public Weather[] Weather { get; set; }
        [JsonProperty(PropertyName = "main")]
        public Main TemperatureAndPressure { get; set; }
        [JsonProperty(PropertyName = "visibility")]
        public int Visibility { get; set; }
        [JsonProperty(PropertyName = "wind")]
        public Wind WindInfo { get; set; }
        [JsonProperty(PropertyName = "dt")]
        public int UnixTimeWhenGathered { get; set; }
        [JsonProperty(PropertyName = "sys")]
        public Sys RegionInfo { get; set; }

    }

    public class Weather
    {
        [JsonProperty(PropertyName = "id")]
        public int WeatherConditionId { get; set; }
        [JsonProperty(PropertyName = "main")]
        public string WeatherParameters { get; set; }
        [JsonProperty(PropertyName = "description")]
        public string WeatherCondition { get; set; }
        [JsonProperty(PropertyName = "icon")]
        public string WeatherConditionIcon { get; set; }
    }

    public class Coord
    {
        [JsonProperty(PropertyName = "lon")]
        public float Longitude { get; set; }
        [JsonProperty(PropertyName = "lat")]
        public float Latitude { get; set; }
    }

    public class Main
    {
        [JsonProperty(PropertyName = "temp")]
        public float Temperature { get; set; }
        [JsonProperty(PropertyName = "pressure")]
        public int Pressure { get; set; }
        [JsonProperty(PropertyName = "humidity")]
        public int Humidity { get; set; }
        [JsonProperty(PropertyName = "temp_min")]
        public float MinimumTemperature { get; set; }
        [JsonProperty(PropertyName = "temp_max")]
        public float MaximumTemperature { get; set; }
    }

    public class Wind
    {
        [JsonProperty(PropertyName = "speed")]
        public float WindSpeed { get; set; }
        [JsonProperty(PropertyName = "deg")]
        public int WindDirectionDegrees { get; set; }
    }

    public class Clouds
    {
        [JsonProperty(PropertyName = "all")]
        public int CloudCoveragePercent { get; set; }
    }

    public class Sys
    {

        public int type { get; set; }
        public int id { get; set; }
        public float message { get; set; }
        public string country { get; set; }
        public int sunrise { get; set; }
        public int sunset { get; set; }
    }
}
