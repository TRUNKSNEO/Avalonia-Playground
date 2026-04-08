using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MyAvalonia.Models.Seismic
{
	public class SeismicActivityDto
	{
		public string GoogleMapRef { get; set; } = String.Empty;

		public string Degree { get; set; } = String.Empty;

		public string SismoId { get; set; } = String.Empty;

		public DateTime DataUpdate { get; set; }

		public string MagnitudeType { get; set; } = String.Empty;

		public string ObservedRegion { get; set; } = String.Empty;

		public string Longitude { get; set; } = String.Empty;

		public string Latitude { get; set; } = String.Empty;

		public string Source { get; set; } = String.Empty;

		public int Depth { get; set; }

		public string TensorRef { get; set; } = String.Empty;

		public string Sensed { get; set; } = String.Empty;

		public string ShakemapId { get; set; } = String.Empty;

		public DateTime Time { get; set; }

		public string ShakemapRef { get; set; } = String.Empty;

		public string Local { get; set; } = String.Empty;

		public string Magnitude { get; set; } = String.Empty;

		public double? MagnitudeValue => double.TryParse(Magnitude, out var v) ? v : null;
	}
}
