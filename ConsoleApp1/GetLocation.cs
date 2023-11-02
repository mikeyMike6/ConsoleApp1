using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class GetLocation
    {
        private string _apiKey;
        private HttpClient client;
        public bool success;
        public GetLocation(string apiKey)
        {
            _apiKey = apiKey;
            client = new HttpClient();
            success = false;
        }

        public async Task<string> GetCoordOfCity(string cityName)
        {
            success = false;
            try
            {
                string url = $"http://api.openweathermap.org/geo/1.0/direct?q={cityName}&limit=1&appid={_apiKey}";
                HttpResponseMessage response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    success = true;
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
    }
}
