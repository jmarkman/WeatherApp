﻿using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace WeatherAPI
{
    public class WeatherClient
    {
        private string apiKey;
        private string urlParams;
        private static HttpClient httpClient = new HttpClient();

        public string ZipCode { get; set; }

        public WeatherClient(string apiKey)
        {
            this.apiKey = apiKey;
            httpClient.BaseAddress = new Uri("https://api.openweathermap.org/data/2.5/weather");
        }

        /// <summary>
        /// Fetch the current weather data for the provided US Zip code
        /// </summary>
        /// <param name="zipCode"></param>
        /// <returns>The associated weather data as a JSON object</returns>
        public async Task<WeatherData> GetWeatherDataAsync(string zipCode)
        {
            ZipCode = zipCode;
            WeatherData weatherData = null;
            urlParams = $"weather?zip={ZipCode},us&units=Imperial&appid={apiKey}";

            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await httpClient.GetAsync(urlParams);
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                weatherData = JsonConvert.DeserializeObject<WeatherData>(data);
            }

            return weatherData;
        }
    }
}
