﻿using Newtonsoft.Json;

namespace WeatherAPI
{
    public class WeatherData
    {
        [JsonProperty(PropertyName = "coord")]
        public Coord Coordinates { get; set; }
        [JsonProperty(PropertyName = "clouds")]
        public Clouds CloudInfo { get; set; }
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
        [JsonProperty(PropertyName = "id")]
        public int ID { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string CityName { get; set; }
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
        public float WindDirectionDegrees { get; set; }
    }

    public class Clouds
    {
        [JsonProperty(PropertyName = "all")]
        public int CloudCoveragePercent { get; set; }
    }

    public class Sys
    {
        [JsonProperty(PropertyName = "country")]
        public string CountryCode { get; set; }
        [JsonProperty(PropertyName = "sunrise")]
        public int SunriseTime { get; set; }
        [JsonProperty(PropertyName = "sunset")]
        public int SunsetTime { get; set; }
    }
}
