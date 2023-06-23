using LoadDataToDbFromAPI;
using System.Net.Http;
using System.Text.Json;
using LoadDataToDbFromAPI.Data;
using LoadDataToDbFromAPI.Models;

const string API_KEY = "lolllzzzz";

MockDataClass mockDataClass = new MockDataClass();
string[] cityNames = mockDataClass.mockData;

var context = new DataContext();

int realCount = 0;
foreach (string _cityName in cityNames)
{
    var client = new HttpClient();
    var request = new HttpRequestMessage
    {
        Method = HttpMethod.Get,
        RequestUri = new Uri($"http://api.weatherapi.com/v1/current.json?q={_cityName}"),
        Headers =
        {
            { "Key", $"{API_KEY}" },
        }
    };

    try
    {
        using (var response = await client.SendAsync(request))
        {
            response.EnsureSuccessStatusCode();
            var body = await response.Content.ReadAsStringAsync();
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

            WeatherInfo w = new WeatherInfo()
            {
                CountryName = countryName,
                RegionName = regionName,
                CityName = cityName,
                Localtime = localtime,
                Temp_c = temp_c,
                Feelslike_c = feelslike_c,
                Humidity = humidity,
                Wind_kph = wind_kph,
                WeatherConditionText = weather,
                IconUrl = iconUrl
            };

            context.WeatherInfos.Add(w);
            context.SaveChanges();

            Console.WriteLine(
                $"CityName: {cityName}, " +
                $"RegionName: {regionName}, " +
                $"CountryName: {countryName}, " +
                $"LocalTime: {localtime}, " +
                $"Temp_c: {temp_c}, " +
                $"Feelslike_c: {feelslike_c}, " +
                $"Weather: {weather}, " +
                $"IconUrl: {iconUrl}, " +
                $"Humidity: {humidity}, " +
                $"Wind_kph: {wind_kph}");


        }
        realCount++;
    }
    catch
    {
        continue;
    }

}

Console.WriteLine($"\n\n\nTotalCities: 1000\nRealCount: {realCount}\nDiff: {1000-realCount}");
