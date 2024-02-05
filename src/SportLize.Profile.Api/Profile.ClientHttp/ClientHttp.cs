using System;
using System.Globalization;
using System.Threading;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SportLize.Profile.Api.Profile.ClientHttp.Abstraction;
using SportLize.Profile.Api.Profile.Repository.Enumeration;
using SportLize.Profile.Api.Profile.Shared;

namespace SportLize.Profile.Api.Profile.ClientHttp
{
	public class ClientHttp : IClientHttp
	{
		private readonly HttpClient _httpClient;

		public ClientHttp(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

    }
}

