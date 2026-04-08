using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MyAvalonia.Integrations.Contracts.Wind
{
	public class WindSpeedResponse
	{
		[JsonPropertyName("owner")]
		public string Owner { get; set; } = String.Empty;

		[JsonPropertyName("country")]
		public string Country { get; set; } = String.Empty;

		[JsonPropertyName("data")]
		public List<WindSpeedItem> Data { get; set; } = new();
	}
}
