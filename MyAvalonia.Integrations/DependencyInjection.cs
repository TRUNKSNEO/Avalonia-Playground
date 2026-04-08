using Microsoft.Extensions.DependencyInjection;
using MyAvalonia.Integrations.Interfaces;
using MyAvalonia.Integrations.Services;

namespace MyAvalonia.Integrations
{
	public static class DependencyInjection
	{
		public static IServiceCollection AddIntegrations(this IServiceCollection services)
		{
			// ApiClient
			services.AddHttpClient<IApiClient, ApiClient>(client =>
			{
				client.BaseAddress = new Uri("https://api.ipma.pt/open-data/");
			});

			// IpmaService
			services.AddTransient<IIpmaService, IpmaService>();

			return services;
		}
	}
}
