using MyAvalonia.Integrations.Exceptions;
using MyAvalonia.Integrations.Interfaces;
using System.Text.Json;

namespace MyAvalonia.Integrations.Services
{
	public class ApiClient : IApiClient
	{
		private readonly HttpClient _httpClient;

		public ApiClient(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task<T> GetAsync<T>(string endpoint)
		{
			try
			{
				var response = await _httpClient.GetAsync(endpoint);

				response.EnsureSuccessStatusCode();

				var json = await response.Content.ReadAsStringAsync();

				return JsonSerializer.Deserialize<T>(json,
					new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
			}
			catch (Exception ex)
			{
				throw new ApiException($"API Error calling '{endpoint}'", ex);
			}
		}
	}
}
