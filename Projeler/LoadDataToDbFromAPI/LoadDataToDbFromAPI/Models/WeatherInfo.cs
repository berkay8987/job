using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoadDataToDbFromAPI.Models
{
    public class WeatherInfo
    {
        public int Id { get; set; }

        public string CountryName { get; set; } = string.Empty;

        public string RegionName { get; set; } = string.Empty;

        public string CityName { get; set; } = string.Empty;

        public string Localtime { get; set; } = string.Empty;

        [Column(TypeName = "decimal(6,2)")]
        public decimal Temp_c { get; set; }

        [Column(TypeName = "decimal(6,2)")]
        public decimal Feelslike_c { get; set; }

        public int Humidity { get; set; }

        [Column(TypeName = "decimal(6,2)")]
        public decimal Wind_kph { get; set; }

        public string WeatherConditionText { get; set; } = string.Empty;

        public string IconUrl { get; set; } = string.Empty;

        public int isActive { get; set; }

        public int isDeleted { get; set; }
    }
}
