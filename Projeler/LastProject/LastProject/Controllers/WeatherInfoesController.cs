using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LastProject.Models;
using System.Text.Json;

namespace LastProject.Controllers
{
    public class WeatherInfoesController : Controller
    {
        private readonly WeatherInfoDatabaseContext _context;
        private readonly IHttpClientFactory _httpClientFactory;

        public WeatherInfoesController(WeatherInfoDatabaseContext context, IHttpClientFactory httpClientFactory)
        {
            _context = context;
            _httpClientFactory = httpClientFactory;
        }

        // GET: WeatherInfoes
        public async Task<IActionResult> Index()
        {
            var allData = new List<WeatherInfo>();
            foreach (var data in _context.WeatherInfos)
            {
                if (data.IsDeleted == 0 && data.IsActive == 1)
                {
                    allData.Add(data);
                }
            }
      
              return _context.WeatherInfos != null ? 
                          View(allData) :
                          Problem("Entity set 'WeatherInfoDatabaseContext.WeatherInfos'  is null.");
        }

        // GET: WeatherInfoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.WeatherInfos == null)
            {
                return NotFound();
            }

            var weatherInfo = await _context.WeatherInfos.FirstOrDefaultAsync(m => m.Id == id);
            if (weatherInfo == null)
            {
                return NotFound();
            }

            return View(weatherInfo);
        }

        // GET: WeatherInfoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: WeatherInfoes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(WeatherInfo weatherInfo)
        {
            var temp = _context.WeatherInfos.Where(x => x.CityName == weatherInfo.CityName).FirstOrDefault();
            if (temp != null)
            {
                if (temp.IsDeleted == 1 && temp.IsActive == 0)
                {
                    temp.IsActive = 1;
                    temp.IsDeleted = 0;
                    _context.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
                else if (temp.IsDeleted == 0 && temp.IsActive == 1)
                {
                    return RedirectToAction(nameof(AlreadyExistsPage));
                }
            }

            using var client = _httpClientFactory.CreateClient();
            string apiKey = "ef5f44f0f7fd4e83bb3190630231505";

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"http://api.weatherapi.com/v1/current.json?q={weatherInfo.CityName}"),
                Headers =
                    {
                        { "Key", $"{apiKey}"}
                    }
            };

            using (var response = client.Send(request))
            {
                // If the city user gave is not found, then return not found.
                try
                {
                    response.EnsureSuccessStatusCode();
                }
                catch
                {
                    return RedirectToAction(nameof(FailedExecution));
                    // return BadRequest($"{weatherInfo.CityName} Not Found");
                }

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
                    CityName = cityName,
                    RegionName = regionName,
                    CountryName = countryName,
                    Localtime = localtime,
                    TempC = temp_c,
                    FeelslikeC = feelslike_c,
                    WeatherConditionText = weather,
                    IconUrl = iconUrl,
                    Humidity = humidity,
                    WindKph = wind_kph,
                    IsDeleted = 0,
                    IsActive = 1
                };

                _context.Add(w);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

        }

        // GET: WeatherInfoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.WeatherInfos == null)
            {
                return NotFound();
            }

            var weatherInfo = await _context.WeatherInfos.FindAsync(id);
            if (weatherInfo == null)
            {
                return NotFound();
            }
            return View(weatherInfo);
        }

        // POST: WeatherInfoes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, WeatherInfo weatherInfo)
        {
            /*
            if (id != weatherInfo.Id)
            {
                return NotFound();
            }
            */

            try
            {
                var data = _context.WeatherInfos.Where(x => x.Id == weatherInfo.Id).FirstOrDefault();
                data.Humidity = weatherInfo.Humidity;

                _context.WeatherInfos.Update(data);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WeatherInfoExists(weatherInfo.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw new NullReferenceException();
                }
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: WeatherInfoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.WeatherInfos == null)
            {
                return NotFound();
            }

            var weatherInfo = await _context.WeatherInfos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (weatherInfo == null)
            {
                return NotFound();
            }

            return View(weatherInfo);
        }

        // POST: WeatherInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.WeatherInfos == null)
            {
                return Problem("Entity set 'WeatherInfoDatabaseContext.WeatherInfos'  is null.");
            }
            var weatherInfo = await _context.WeatherInfos.FindAsync(id);
            if (weatherInfo == null)
            {
                return NotFound();
            }

            weatherInfo.IsActive = 0;
            weatherInfo.IsDeleted = 1;

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WeatherInfoExists(int id)
        {
          return (_context.WeatherInfos?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        public async Task<IActionResult> FailedExecution()
        {
            return View();
        }

        public async Task<IActionResult> AlreadyExistsPage()
        {
            return View();
        }

        public async Task<IActionResult> RefreshData(int? id)
        {
            var weatherInfo = await _context.WeatherInfos.FirstOrDefaultAsync(m => m.Id == id);

            using var client = _httpClientFactory.CreateClient();
            string apiKey = "ef5f44f0f7fd4e83bb3190630231505";

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"http://api.weatherapi.com/v1/current.json?q={weatherInfo.CityName}"),
                Headers =
                    {
                        { "Key", $"{apiKey}"}
                    }
            };

            using (var response = client.Send(request))
            {
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

                weatherInfo.CityName = cityName;
                weatherInfo.RegionName = regionName;
                weatherInfo.CountryName = countryName;
                weatherInfo.Localtime = localtime;
                weatherInfo.TempC = temp_c;
                weatherInfo.FeelslikeC = feelslike_c;
                weatherInfo.WeatherConditionText = weather;
                weatherInfo.IconUrl = iconUrl;
                weatherInfo.Humidity = humidity;
                weatherInfo.WindKph = wind_kph;
                weatherInfo.IsDeleted = 0;
                weatherInfo.IsActive = 1;

                _context.SaveChanges();
                return View("Details", weatherInfo);
            }
        }
    }
}
