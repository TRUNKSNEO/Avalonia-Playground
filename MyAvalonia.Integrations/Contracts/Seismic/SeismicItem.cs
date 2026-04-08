namespace MyAvalonia.Integrations.Contracts.Seismic
{
	using System.Text.Json.Serialization;

	public class SeismicItem
	{
		[JsonPropertyName("googlemapref")]
		public string GoogleMapRef { get; set; } = String.Empty;

		[JsonPropertyName("degree")]
		public string Degree { get; set; } = String.Empty;

		[JsonPropertyName("sismoId")]
		public string SismoId { get; set; } = String.Empty;

		[JsonPropertyName("dataUpdate")]
		public DateTime DataUpdate { get; set; }

		[JsonPropertyName("magType")]
		public string MagnitudeType { get; set; } = String.Empty;

		[JsonPropertyName("obsRegion")]
		public string ObservedRegion { get; set; } = String.Empty;

		[JsonPropertyName("lon")]
		public string Longitude { get; set; } = String.Empty;

		[JsonPropertyName("lat")]
		public string Latitude { get; set; } = String.Empty;

		[JsonPropertyName("source")]
		public string Source { get; set; } = String.Empty;

		[JsonPropertyName("depth")]
		public int Depth { get; set; }

		[JsonPropertyName("tensorRef")]
		public string TensorRef { get; set; } = String.Empty;

		[JsonPropertyName("sensed")]
		public string Sensed { get; set; } = String.Empty;

		[JsonPropertyName("shakemapid")]
		public string ShakemapId { get; set; } = String.Empty;

		[JsonPropertyName("time")]
		public DateTime Time { get; set; }

		[JsonPropertyName("shakemapref")]
		public string ShakemapRef { get; set; } = String.Empty;

		[JsonPropertyName("local")]
		public string Local { get; set; } = String.Empty;

		[JsonPropertyName("magnitud")]
		public string Magnitude { get; set; } = String.Empty;

	}
}
