using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MyAvalonia.Integrations.Contracts.Weather
{
	public class WeatherTypeItem
	{
		[JsonPropertyName("idWeatherType")]
		public int IdWeatherType { get; set; }

		[JsonPropertyName("descWeatherTypePT")]
		public string DescriptionPT { get; set; } = String.Empty;

		[JsonPropertyName("descWeatherTypeEN")]
		public string DescriptionEN { get; set; } = String.Empty;

	}
}
