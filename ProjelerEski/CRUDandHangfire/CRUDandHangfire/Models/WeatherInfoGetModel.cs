namespace CRUDandHangfire.Models
{
    public class WeatherInfoGetModel
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
    }
}
