using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MyAvalonia.Models.Wind
{
	public class WindSpeedDto
	{
		public string ClassWindSpeed { get; set; } = String.Empty;

		public string DescriptionPT { get; set; } = String.Empty;

		public string DescriptionEN { get; set; } = String.Empty;

		public int ClassWindSpeedValue => int.TryParse(ClassWindSpeed, out var v) ? v : -99;
	}
}
