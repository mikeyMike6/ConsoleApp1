using ConsoleApp1;
using Newtonsoft.Json;

class Program
{
    static async Task Main()
    {
        // Zastąp 'YOUR_API_KEY' swoim kluczem API od OpenWeatherMap
        string apiKey = "14c0aa01bfea6e1c4367ba7beba6c697";

        var getLocation = new GetLocation(apiKey);

        Console.WriteLine("Podaj miasto: ");
        string city = "Bielsko-Biala";
        string jsonResponse = await getLocation.GetCoordOfCity(city);

        if (getLocation.success)
        {
            var cityData = JsonConvert.DeserializeObject<List<CityData>>(jsonResponse)[0];
            var weatherData = new WeatherData(apiKey);
            var weaterDataResponse = await weatherData.GetWeatherData(cityData.lat, cityData.lon);
            var weatherObject = JsonConvert.DeserializeObject<WeatherObject>(weaterDataResponse);
            var timeAndTemperature = weatherObject.Hourly;
            for (int i = 0; i < timeAndTemperature.Time.Count; i++)
            {
                Console.Write(timeAndTemperature.Time[i] + " : ");
                if (timeAndTemperature.Temperature_2m[i] != null) Console.WriteLine(timeAndTemperature.Temperature_2m[i]);
                else Console.WriteLine("null");
            }
        }
    }
}
