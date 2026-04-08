using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MyAvalonia.Integrations.Contracts.Seismic
{
	public class SeismicResponse
	{
		[JsonPropertyName("idArea")]
		public int IdArea { get; set; }

		[JsonPropertyName("country")]
		public string Country { get; set; } = String.Empty;

		[JsonPropertyName("lastSismicActivityDate")]
		public DateTime LastSismicActivityDate { get; set; }

		[JsonPropertyName("updateDate")]
		public DateTime UpdateDate { get; set; }

		[JsonPropertyName("owner")]
		public string Owner { get; set; } = String.Empty;

		[JsonPropertyName("data")]
		public List<SeismicItem> Data { get; set; } = new();
	}
}
