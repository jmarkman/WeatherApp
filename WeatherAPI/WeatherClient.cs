using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace WeatherAPI
{
    public class WeatherClient
    {
        private string apiKey;
        private static HttpClient httpClient = new HttpClient()
        {
            BaseAddress = new Uri("https://api.openweathermap.org/data/2.5/weather")
        };

        public WeatherClient(string apiKey)
        {
            this.apiKey = apiKey;
        }

        /// <summary>
        /// Fetch the current weather data for the provided US Zip code
        /// </summary>
        /// <param name="zipCode">The 5-digit numeric code representing a neighborhood in the United States</param>
        /// <returns>The associated weather data as a JSON object</returns>
        public async Task<WeatherData> GetWeatherDataAsync(string zipCode)
        {
            WeatherData weatherData;
            string urlParams = $"weather?zip={zipCode},us&units=Imperial&appid={apiKey}";

            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await httpClient.GetAsync(urlParams);
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                weatherData = JsonConvert.DeserializeObject<WeatherData>(data);
            }
            else
            {
                throw new Exception($"The weather data for ZIP code '{zipCode}' could not be retrieved!");
            }

            return weatherData;
        }
    }
}
