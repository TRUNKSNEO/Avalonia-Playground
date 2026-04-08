using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MyAvalonia.Integrations.Contracts.Forecast
{
	public class ForecastItem
	{
		[JsonPropertyName("forecastDate")]
		public DateTime ForecastDate { get; set; }

		[JsonPropertyName("precipitaProb")]
		public string PrecipitationProbability { get; set; } = String.Empty;

		[JsonPropertyName("tMin")]
		public string TemperatureMin { get; set; } = String.Empty;

		[JsonPropertyName("tMax")]
		public string TemperatureMax { get; set; } = String.Empty;

		[JsonPropertyName("predWindDir")]
		public string PredictedWindDirection { get; set; } = String.Empty;

		[JsonPropertyName("idWeatherType")]
		public int WeatherTypeId { get; set; }

		[JsonPropertyName("classWindSpeed")]
		public int WindSpeedClass { get; set; }

		[JsonPropertyName("classPrecInt")]
		public int? PrecipitationIntensityClass { get; set; }

		[JsonPropertyName("latitude")]
		public string Latitude { get; set; } = String.Empty;

		[JsonPropertyName("longitude")]
		public string Longitude { get; set; } = String.Empty;

		[JsonIgnore]
		public double? TemperatureMinValue => double.TryParse(TemperatureMin, out var v) ? v : null;
	}
}
