using AutoMapper;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using MyAvalonia.Data;
using MyAvalonia.Integrations.Interfaces;
using MyAvalonia.Models.Awarness;
using MyAvalonia.Models.Forecast;
using MyAvalonia.Models.Locations;
using MyAvalonia.Models.Weather;
using MyAvalonia.Models.Wind;
using MyAvalonia.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace MyAvalonia.ViewModels
{
    public partial class WeatherForecastPageViewModel : PageViewModel
    {
        private readonly IMapper _mapper;
        private readonly IIpmaService _apiClient;
        public Window? OwnerWindow { get; set; }

        [ObservableProperty]
        private ForecastItemDto? _selectedTab;

        [ObservableProperty]
        private LocationDto _selectedLocation;

        [ObservableProperty]
        private AwarnessItemDto _awarness;

        private ProgressDialog _progressDialog;

        public ObservableCollection<LocationDto> Locations { get; } = new();

        public ObservableCollection<ForecastItemDto> Forecasts { get; } = new();

        private List<WeatherTypeDto> WeatherTypes { get; set; } = new();
        private List<WindSpeedDto> WindSpeeds { get; set; } = new();

        private List<AwarnessItemDto> AwarnessTypes { get; set; } = new();

        // =========================
        // RUNTIME CONSTRUCTOR
        // =========================
        public WeatherForecastPageViewModel(IIpmaService apiClient, IMapper mapper)
        {
            PageName = ApplicationPageNames.WeatherForecast;
            _progressDialog = new ProgressDialog();
            _mapper = mapper;
            _apiClient = apiClient;

            _ = LoadWindAsync();
            _ = LoadLocationsAsync();
            _ = LoadWeatherTypesAsync();
            _ = LoadAwarnessAsync();
        }

        // =========================
        // DESIGN MODE CONSTRUCTOR
        // =========================
        public WeatherForecastPageViewModel()
        {
            if (Design.IsDesignMode)
            {
                PageName = ApplicationPageNames.WeatherForecast;

                Locations.Clear();
                Locations.Add(new LocationDto { GlobalIdLocal = 1, Name = "Braga" });
                Locations.Add(new LocationDto { GlobalIdLocal = 2, Name = "Porto" });

                WeatherTypes = new List<WeatherTypeDto>
                {
                    new WeatherTypeDto { IdWeatherType = 1, DescriptionPT = "Limpo"},
                    new WeatherTypeDto { IdWeatherType = 10, DescriptionPT = "Chuva" }
                };

                WindSpeeds = new List<WindSpeedDto>
                {
                    new WindSpeedDto { ClassWindSpeed = "1", DescriptionPT = "NW" }
                };

                Forecasts.Clear();

                Forecasts.Add(new ForecastItemDto
                {
                    DisplayDate = "03/04/2014",
                    WeatherTypeId = 1,
                    WeatherInformation = WeatherTypes[0]
                });

                Forecasts.Add(new ForecastItemDto
                {
                    DisplayDate = "04/04/2014",
                    WeatherTypeId = 10,
                    WeatherInformation = WeatherTypes[1]
                });

                SelectedLocation = Locations.First();
                SelectedTab = Forecasts.First();

                return;
            }
        }

        // =========================
        // EVENTS
        // =========================
        partial void OnSelectedLocationChanged(LocationDto value)
        {
            RunWithProgressSelectedLocationChanged(value);
        }

        private async void RunWithProgressSelectedLocationChanged(LocationDto value)
        {
            var dlg = ProgressDialog.StartShowProgressDialog(OwnerWindow, "Loading", "Please wait...");

            if (value != null && !Design.IsDesignMode)
            {
                await LoadForecastAsync(value.GlobalIdLocal);
            }

            ProgressDialog.CloseShowProgressDialog(dlg);
        }


        #region API Methods

        private async Task LoadAwarnessAsync()
        {
            try
            {
                AwarnessTypes.Clear();

                var response = await _apiClient.GetAwarnessAsync();

                if (response != null)
                {
                    var mapped = _mapper.Map<List<AwarnessItemDto>>(response);


                    foreach (var item in mapped)
                    {
                        AwarnessTypes.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                App.Current.HandleException(ex);
            }
        }

        private async Task LoadWindAsync()
        {
            try
            {
                WindSpeeds.Clear();

                var response = await _apiClient.GetWindAsync();
                if (response.Data != null)
                {
                    var mapped = _mapper.Map<List<WindSpeedDto>>(response.Data);
                    foreach (var item in mapped)
                    {
                        WindSpeeds.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                App.Current.HandleException(ex);
            }
        }

        private async Task LoadLocationsAsync()
        {
            try
            {
                Locations.Clear();

                var response = await _apiClient.GetLocationsAsync();

                if (response.Data != null)
                {
                    var mapped = _mapper.Map<List<LocationDto>>(response.Data);


                    foreach (var item in mapped)
                    {
                        Locations.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                App.Current.HandleException(ex);
            }
        }

        private async Task LoadWeatherTypesAsync()
        {
            try
            {
                var response = await _apiClient.GetWeatherTypesAsync();
                if (response.Data != null)
                {
                    var mapped = _mapper.Map<List<WeatherTypeDto>>(response.Data);
                    WeatherTypes.Clear();
                    foreach (var item in mapped)
                    {
                        WeatherTypes.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                App.Current.HandleException(ex);
            }
        }

        private async Task LoadForecastAsync(int locationId)
        {
            try
            {
                Forecasts.Clear();

                var response = await _apiClient.GetForecastByCityAsync(locationId);

                if (response.Data != null)
                {
                    var mapped = _mapper.Map<List<ForecastItemDto>>(response.Data);

                    foreach (var item in mapped)
                    {
                        item.WeatherInformation =
                            WeatherTypes.FirstOrDefault(x => x.IdWeatherType == item.WeatherTypeId);

                        item.WindInformation =
                            WindSpeeds.FirstOrDefault(x => x.ClassWindSpeedValue == item.WindSpeedClass);

                        var awarnessForDay = AwarnessTypes
                           .Where(a =>
                               item.Date >= a.StartTime &&
                               item.Date <= a.EndTime &&
                               SelectedLocation.IdAreaAviso == a.Area)

                           .ToList();

                        // se tiveres uma propriedade
                        item.AwarnessInformation = awarnessForDay;

                        Forecasts.Add(item);
                    }

                    SelectedTab = Forecasts.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                App.Current.HandleException(ex);
            }
        }

        #endregion
    }
}