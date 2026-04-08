using AutoMapper;
using MyAvalonia.Integrations.Contracts.Forecast;
using MyAvalonia.Integrations.Contracts.Localtions;
using MyAvalonia.Integrations.Contracts.Seismic;
using MyAvalonia.Integrations.Contracts.Weather;
using MyAvalonia.Integrations.Contracts.Wind;
using MyAvalonia.Models.Forecast;
using MyAvalonia.Models.Locations;
using MyAvalonia.Models.Seismic;
using MyAvalonia.Models.Weather;
using MyAvalonia.Models.Wind;

namespace MyAvalonia.Mapping
{
	public class IpmaMappingProfile : Profile
	{
		public IpmaMappingProfile()
		{
			// =========================
			// LOCATION
			// =========================
			CreateMap<LocationItem, LocationDto>()
			.ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Local));

			// =========================
			// FORECAST
			// =========================
			CreateMap<ForecastItem, ForecastItemDto>()
			.ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.ForecastDate.ToString("dd/MM/yyyy")));

			// =========================
			// WEATHER TYPES (DRTO)
			// =========================
			CreateMap<WeatherTypeItem, WeatherTypeDto>();

			// =========================
			// WIND SPEED
			// =========================
			CreateMap<WindSpeedItem, WindSpeedDto>();

			// =========================
			// SEISMIC ACTIVITY
			// =========================
			CreateMap<SeismicItem, SeismicActivityDto>();
		}
	}
}
