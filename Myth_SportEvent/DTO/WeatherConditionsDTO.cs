namespace Myth_SportEvent.API.DTO
{
    public class WeatherConditionsDTO
    {
        public int Id { get; set; }
        public int? TemperatureFahrenheit { get; set; }
        public float? TemperatureCelsius { get; set; }
        public int? WindSpeedMiles { get; set; }
        public float? WindSpeedKilometers { get; set; }
        public int? WindDirection { get; set; }
        public int? WeatherType { get; set; }
        public int? TailWindSpeed { get; set; }
        public int? BaseballHomePlateWindDirection { get; set; }

    }
}
