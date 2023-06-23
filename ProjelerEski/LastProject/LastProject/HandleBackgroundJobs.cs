using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using LastProject.Models;

namespace LastProject
{
    public class HandleBackgroundJobs
    {
        WeatherInfoDatabaseContext _context;

        public HandleBackgroundJobs(WeatherInfoDatabaseContext context)
        {
            _context = context;
        }

        public void UpdateDb()
        {
            Console.WriteLine("\n***************************************");
            Console.WriteLine("\nDb Update Started!");
            Console.WriteLine("\n***************************************");

            string apiKey = "ef5f44f0f7fd4e83bb3190630231505";

            var data = _context.WeatherInfos;

            foreach (var item in data)
            {
                try
                {
                    var client = new HttpClient();
                    var request = new HttpRequestMessage
                    {
                        Method = HttpMethod.Get,
                        RequestUri = new Uri($"http://api.weatherapi.com/v1/current.json?q={item.CityName}"),
                        Headers =
                        {
                            { "Key", $"{apiKey}"}
                        }
                    };

                    using (var response = client.Send(request))
                    {
                        response.EnsureSuccessStatusCode();
                        var body = response.Content.ReadAsStringAsync().Result;
                        var bodyObject = JsonSerializer.Deserialize<JsonElement>(body);

                        // Get City Name
                        string cityName = bodyObject.GetProperty("location").GetProperty("name").GetString();

                        // Get Region Name
                        string regionName = bodyObject.GetProperty("location").GetProperty("region").GetString();

                        // Get Country Name
                        string countryName = bodyObject.GetProperty("location").GetProperty("country").GetString();

                        // Get Localtime
                        string localtime = bodyObject.GetProperty("location").GetProperty("localtime").GetString();

                        // Get Current Temp in Celcius
                        decimal temp_c = bodyObject.GetProperty("current").GetProperty("temp_c").GetDecimal();

                        // Get Current Feels Like Temp in Celcius
                        decimal feelslike_c = bodyObject.GetProperty("current").GetProperty("feelslike_c").GetDecimal();

                        // Get Weather Condition
                        string weather = bodyObject.GetProperty("current").GetProperty("condition").GetProperty("text").GetString();

                        // Get Icon Url
                        string iconUrl = bodyObject.GetProperty("current").GetProperty("condition").GetProperty("icon").GetString();

                        // Get Humidity
                        int humidity = bodyObject.GetProperty("current").GetProperty("humidity").GetInt32();

                        // Get Windspeed in Kph
                        decimal wind_kph = bodyObject.GetProperty("current").GetProperty("wind_kph").GetDecimal();

                        item.CityName = cityName;
                        item.RegionName = regionName;
                        item.CountryName = countryName;
                        item.Localtime = localtime;
                        item.TempC = temp_c;
                        item.FeelslikeC = feelslike_c;
                        item.WeatherConditionText = weather;
                        item.IconUrl = iconUrl;
                        item.Humidity = humidity;
                        item.WindKph = wind_kph;

                        _context.SaveChanges();

                        Console.WriteLine($"Updated {item.Id}, {item.CityName}");
                    }
                }
                catch
                {
                    Console.WriteLine("***************************************");
                    Console.WriteLine("Something Went Wrong?");
                    Console.WriteLine($"Couldn't update {item.Id}, {item.CityName}");
                    Console.WriteLine("***************************************");
                }

            }

            Console.WriteLine("\n***************************************");
            Console.WriteLine("\nDb Update Ended!");
            Console.WriteLine("\n***************************************");
        }
    }
}