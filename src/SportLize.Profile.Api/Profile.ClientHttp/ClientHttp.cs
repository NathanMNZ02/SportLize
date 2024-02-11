using System;
using System.Globalization;
using System.Threading;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SportLize.Profile.Api.Profile.ClientHttp.Abstraction;
using SportLize.Profile.Api.Profile.Shared.Dto;

namespace SportLize.Profile.Api.Profile.ClientHttp
{
	public class ClientHttp : IClientHttp
	{
		private readonly HttpClient _httpClient;

		public ClientHttp(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

        public async Task<List<UserReadDto>?> GetAllUsers(CancellationToken cancellationToken = default){
            var response = await _httpClient.GetAsync($"/Profile/GetAllUsers", cancellationToken);
            return await response.EnsureSuccessStatusCode().Content.ReadFromJsonAsync<List<UserReadDto>?>(cancellationToken: cancellationToken);
        }

        public async Task<UserReadDto?> GetUser(int userId, CancellationToken cancellationToken = default)
        {
            var queryString = QueryString.Create(new Dictionary<string, string?>() {
                { "userId", userId.ToString(CultureInfo.InvariantCulture) }
            });
            var response = await _httpClient.GetAsync($"/Profile/GetUser{queryString}", cancellationToken);
            return await response.EnsureSuccessStatusCode().Content.ReadFromJsonAsync<UserReadDto?>(cancellationToken: cancellationToken);
        }
    }
}

