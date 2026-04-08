using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAvalonia.Integrations.Exceptions
{
	public class ApiExceptionHandler : DelegatingHandler
	{
		protected override async Task<HttpResponseMessage> SendAsync(
			HttpRequestMessage request,
			CancellationToken cancellationToken)
		{
			try
			{
				var response = await base.SendAsync(request, cancellationToken);

				if (!response.IsSuccessStatusCode)
				{
					var content = await response.Content.ReadAsStringAsync();

					throw new ApiException(response.StatusCode, content);
				}

				return response;
			}
			catch (Exception ex)
			{
				// Log global / tracking
				Console.WriteLine($"HTTP Error: {ex.Message}");
				throw;
			}
		}
	}
}
