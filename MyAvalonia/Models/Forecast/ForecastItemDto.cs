using MyAvalonia.Models.Weather;
using MyAvalonia.Models.Wind;
using System;

namespace MyAvalonia.Models.Forecast
{
	public class ForecastItemDto
	{
		public string Date { get; set; } = String.Empty;

		public string PrecipitationProbability { get; set; } = String.Empty;

		public string TemperatureMin { get; set; } = String.Empty;

		public string TemperatureMax { get; set; } = String.Empty;

		public string PredictedWindDirection { get; set; } = String.Empty;

		public int WeatherTypeId { get; set; }

		public int WindSpeedClass { get; set; }

		public int? PrecipitationIntensityClass { get; set; }

		public string Latitude { get; set; } = String.Empty;

		public string Longitude { get; set; } = String.Empty;

		public string TemperatureDisplay => $"{TemperatureMin}º / {TemperatureMax}º";

		public WeatherTypeDto WeatherInformation { get; set; } = new();

		public WindSpeedDto WindInformation { get; set; } = new();


	}
}
