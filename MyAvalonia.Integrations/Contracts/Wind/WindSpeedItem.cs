using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MyAvalonia.Integrations.Contracts.Wind
{
	public class WindSpeedItem
	{
		[JsonPropertyName("classWindSpeed")]
		public string ClassWindSpeed { get; set; } = String.Empty;

		[JsonPropertyName("descClassWindSpeedDailyPT")]
		public string DescriptionPT { get; set; } = String.Empty;

		[JsonPropertyName("descClassWindSpeedDailyEN")]
		public string DescriptionEN { get; set; } = String.Empty;

	}
}
