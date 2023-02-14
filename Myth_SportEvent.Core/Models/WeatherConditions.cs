using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Myth_SportEvent.Core.Models
{
    public class WeatherConditions
    {
        [Key]
        public int WeatherConditionsId { get; set; }
        
        [JsonProperty("temperature_fahrenheit")]
        public int TemperatureFahrenheit { get; set; }
        
        [JsonProperty("temperature_fahrenheitSpecified")]
        public bool TemperatureFahrenheitSpecified { get; set; }
        
        [JsonProperty("temperature_celsius")]
        public float TemperatureCelsius { get; set; }

        [JsonProperty("temperature_celsiusSpecified")]
        public bool TemperatureCelsiusSpecified { get; set; }

        [JsonProperty("wind_speed_miles")]
        public int WindSpeedMiles { get; set; }

        [JsonProperty("wind_speed_milesSpecified")]
        public bool WindSpeedMilesSpecified { get; set; }

        [JsonProperty("wind_speed_kilometers")]
        public float WindSpeedKilometers { get; set; }

        [JsonProperty("wind_speed_kilometersSpecified")]
        public bool WindSpeedKilometersSpecified { get; set; }

        [JsonProperty("wind_direction")]
        public int WindDirection { get; set; }

        [JsonProperty("wind_directionSpecified")]
        public bool WindDirectionSpecified { get; set; }

        [JsonProperty("weather_type")]
        public int WeatherType { get; set; }

        [JsonProperty("weather_typeSpecified")]
        public bool WeatherTypeSpecified { get; set; }

        [JsonProperty("tail_wind_speed")]
        public int? TailWindSpeed { get; set; }

        [JsonProperty("baseball_home_plate_wind_direction")]
        public int BaseballHomePlateWindDirection { get; set; }

        [JsonProperty("baseball_home_plate_wind_directionSpecified")]
        public bool BaseballHomePlateWindDirectionSpecified { get; set; }
    }
}
