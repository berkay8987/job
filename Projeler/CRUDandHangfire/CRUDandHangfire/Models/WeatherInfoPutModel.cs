namespace CRUDandHangfire.Models
{
    public class WeatherInfoPutModel
    {
        public int Id { get; set; }

        public int Humidity { get; set; }

        public string WeatherConditionText { get; set; } = null!;
    }
}
