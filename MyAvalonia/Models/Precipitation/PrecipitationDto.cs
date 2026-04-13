using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAvalonia.Models.Precipitation
{
	public class PrecipitationDto
	{
		public string DescriptionEN { get; set; } = string.Empty;

		public string DescriptionPT { get; set; } = string.Empty;

		public int IntensityLevel { get; set; }
	}
}
