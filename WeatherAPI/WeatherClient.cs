using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace WeatherAPI
{
    public class WeatherClient
    {
        private readonly string apiKey;
        private readonly static HttpClient httpClient = CreateHttpClient();

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

        /// <summary>
        /// Instantiates and applies OpenWeatherMap settings to a <see cref="HttpClient"/> object
        /// </summary>
        /// <returns>The configured <see cref="HttpClient"/> object</returns>
        private static HttpClient CreateHttpClient()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://api.openweathermap.org/data/2.5/weather");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return client;
        }
    }
}
