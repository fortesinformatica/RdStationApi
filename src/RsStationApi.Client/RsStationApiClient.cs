using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace RsStationApi.Client
{
    public class RsStationApiClient : IRsStationApiClient
    {
        private const string BASE_ADDRESS = @"https://www.rdstation.com.br/api/1.3";
        private readonly HttpClient _httpClient;

        public RsStationApiClient()
        {
#if !NCRUNCH
            _httpClient = new HttpClient { BaseAddress = new Uri(BASE_ADDRESS) };
#endif
        }

        internal RsStationApiClient(HttpClient client)
            : this()
        {
            _httpClient = client;
        }

        public async Task<bool> SendLead(ILead lead)
        {
            var response = await _httpClient.PostAsJsonAsync("conversions", lead);
            return response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.Created;
        }
    }
}