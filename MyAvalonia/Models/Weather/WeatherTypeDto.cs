using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MyAvalonia.Models.Weather
{
	public class WeatherTypeDto
	{
		public int IdWeatherType { get; set; }

		public string DescriptionPT { get; set; } = String.Empty;

		public string DescriptionEN { get; set; } = String.Empty;

		public bool IsValid => IdWeatherType >= 0;

		public string WeatherIcon => IdWeatherType switch
		{
			1 => "\uE472",
			2 or 3 => "\uE540",
			4 or 5 => "\uE1AA",
			6 => "\uE53C",
			7 or 8 or 9 => "\uE1B4",
			10 or 11 or 12 => "\uE1B4",
			13 or 14 or 15 => "\uE3BB",
			16 or 17 or 18 => "\uE1B8",
			20 => "\uE53C",
			21 => "\uE53C",
			30 => "\uE1B2",
			_ => "\uE3B7"
		};
	}
}
