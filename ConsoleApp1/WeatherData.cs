using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class WeatherData
    {
        private string apiKey;
        private HttpClient client;

        public WeatherData(string apiKey)
        {
            this.apiKey = apiKey;
            this.client = new HttpClient();
        }

        public async Task<string> GetWeatherData(double latitude, double longitude)
        {
            try
            {
                string apiUrl = $"https://archive-api.open-meteo.com/v1/archive?latitude={latitude}&longitude={longitude}&start_date=2020-10-14&end_date=2023-10-28&hourly=temperature_2m";

                HttpResponseMessage response = await client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }
                else
                {
                    return "Błąd podczas pobierania danych z API OpenWeatherMap.";
                }
            }
            catch (Exception ex)
            {
                return $"Wystąpił błąd: {ex.Message}";
            }
        }

        public void Dispose()
        {
            client.Dispose();
        }
    }
}
