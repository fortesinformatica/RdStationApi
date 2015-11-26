using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace RdStationApi.Client
{
    public class RdStationApiClient : IRdStationApiClient
    {
        public const string BASE_ADDRESS = @"https://www.rdstation.com.br/api/1.3/";
        private readonly HttpClient _httpClient;

        public RdStationApiClient(HttpClient client = default(HttpClient))
        {
            _httpClient = client ?? new HttpClient { BaseAddress = new Uri(BASE_ADDRESS) };
        }

        public async Task<bool> SendLead(ILead lead)
        {
            var response = await _httpClient.PostAsJsonAsync(BASE_ADDRESS + "conversions", lead);
            return response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.Created;
        }

        public bool SendLeadSync(ILead lead)
        {
            var response = _httpClient.PostAsJsonAsync(BASE_ADDRESS + "conversions", lead).Result;
            return response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.Created;
        }
    }
}