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

		public string WeatherIconPath => $"avares://MyAvalonia/Assets/Images/Weather/w_ic_d_{IdWeatherType:D2}.svg";

	}
}
