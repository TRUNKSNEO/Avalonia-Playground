using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MyAvalonia.Models.Locations
{
	public class LocationDto
	{
		public int IdRegiao { get; set; }

		public string IdAreaAviso { get; set; } = String.Empty;

		public int IdConcelho { get; set; }

		public int GlobalIdLocal { get; set; }

		public string Latitude { get; set; } = String.Empty;

		public string Longitude { get; set; } = String.Empty;

		public int IdDistrito { get; set; }

		public string Name { get; set; } = String.Empty;

		public double LatitudeValue => double.TryParse(Latitude, out var v) ? v : 0;

		public double LongitudeValue => double.TryParse(Longitude, out var v) ? v : 0;
	}
}
