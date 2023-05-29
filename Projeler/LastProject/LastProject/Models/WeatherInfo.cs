using System;
using System.Collections.Generic;

namespace LastProject.Models;

public partial class WeatherInfo
{
    public int Id { get; set; }

    public string CountryName { get; set; } = null!;

    public string RegionName { get; set; } = null!;

    public string CityName { get; set; } = null!;

    public string Localtime { get; set; } = null!;

    public decimal TempC { get; set; }

    public decimal FeelslikeC { get; set; }

    public int Humidity { get; set; }

    public decimal WindKph { get; set; }

    public string WeatherConditionText { get; set; } = null!;

    public string IconUrl { get; set; } = null!;

    public int IsActive { get; set; }

    public int IsDeleted { get; set; }
}
