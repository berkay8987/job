using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CRUDandHangfire.Models;
using Hangfire.Storage.Monitoring;
using Microsoft.EntityFrameworkCore;
using Hangfire;
using System.Text.Json;

namespace CRUDandHangfire.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherInfoController : ControllerBase
    {
        WeatherInfoDatabaseContext _context;

        public WeatherInfoController(WeatherInfoDatabaseContext context)
        {
            _context = context;
        }
        

        [HttpGet]
        public async Task<ActionResult<List<WeatherInfoGetModel>>> Get()
        {
            var data = _context.WeatherInfos;

            var returnData = new List<WeatherInfoGetModel>();

            // Ensure an element is not deleted.
            // If an element is deleted, don't include it.
            foreach (var item in data)
            {
                if (item.IsActive == 1 && item.IsDeleted == 0)
                {
                    var tempItem = new WeatherInfoGetModel() 
                    { 
                        Id = item.Id,
                        CountryName = item.CountryName,
                        RegionName = item.RegionName,
                        CityName = item.CityName,
                        Localtime = item.Localtime,
                        TempC = item.TempC,
                        FeelslikeC = item.FeelslikeC,
                        Humidity = item.Humidity,
                        WindKph = item.WindKph,
                        WeatherConditionText = item.WeatherConditionText,
                        IconUrl = item.IconUrl
                    };

                    returnData.Add(tempItem);
                }
            }

            return Ok(returnData); 
        }

        [HttpGet("GetById/{id}")]
        public async Task<ActionResult<WeatherInfoGetModel>> GetById(int id)
        {
            var data = _context.WeatherInfos.Where(x => x.Id == id).FirstOrDefault();
            if ((data.IsActive == 0 && data.IsDeleted == 1) || data == null)
            {
                return BadRequest("This element does not exist.");
            }

            var newItem = new WeatherInfoGetModel()
            {
                Id = data.Id,
                CountryName = data.CountryName,
                RegionName = data.RegionName,
                CityName = data.CityName,
                Localtime = data.Localtime,
                TempC = data.TempC,
                FeelslikeC = data.FeelslikeC,
                Humidity = data.Humidity,
                WindKph = data.WindKph,
                WeatherConditionText = data.WeatherConditionText,
                IconUrl = data.IconUrl
            };

            return Ok(newItem);
        }

        [HttpDelete("DeleteById/{id}")]
        public async Task<ActionResult<WeatherInfoGetModel>> DeleteById(int id)
        {
            var data = _context.WeatherInfos.Where(x => x.Id == id).FirstOrDefault();
            if ((data.IsActive == 0 && data.IsDeleted == 1) || data == null)
            {
                return BadRequest("Element not found");
            }

            data.IsDeleted = 1;
            data.IsActive = 0;

            _context.SaveChanges();

            return Ok(data);
        }

        [HttpPut("UpdateElement")]
        public async Task<ActionResult<WeatherInfoPutModel>> UpdateElement([FromBody]WeatherInfoPutModel data)
        {
            var oldData = _context.WeatherInfos.Where(x => x.Id == data.Id).FirstOrDefault();
            if ((oldData.IsActive == 0 && oldData.IsDeleted == 1) || oldData == null)
            {
                return BadRequest("Element not found");
            }

            oldData.Humidity = data.Humidity;
            oldData.WeatherConditionText = data.WeatherConditionText;

            _context.SaveChanges();

            return Ok(oldData);
        }

        [HttpPost("CreateNewElement")]
        public async Task<ActionResult<WeatherInfoPostModel>> CreateNewElement([FromBody] WeatherInfoPostModel data)
        {
            var _data = _context.WeatherInfos.Where(x => x.CityName == data.CityName).FirstOrDefault();
            if (_data != null && _data.IsDeleted == 0 && _data.IsActive == 1)
            {
                return BadRequest("That element already exits.");
            }

            if (_data.IsDeleted == 1 && _data.IsActive == 0)
            {
                _data.IsDeleted = 0;
                _data.IsActive = 1;
                _context.SaveChanges();
                return Ok(_data);
            }


            try
            {
                string apiKey = "";

                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri($"http://api.weatherapi.com/v1/current.json?q={data.CityName}"),
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

                    WeatherInfo w = new WeatherInfo
                    {
                        CountryName = countryName,
                        RegionName = regionName,
                        CityName = cityName,
                        Localtime = localtime,
                        TempC = temp_c,
                        FeelslikeC = feelslike_c,
                        WeatherConditionText = weather,
                        IconUrl = iconUrl,
                        Humidity = humidity,
                        WindKph = wind_kph,
                        IsActive = 1,
                        IsDeleted = 0
                    };

                    _context.WeatherInfos.Add(w);

                    _context.SaveChanges();

                    return Ok(w);
                }
            }
            catch
            {
                return BadRequest("Didn't found that city:(");
            }
        }
    }
}
