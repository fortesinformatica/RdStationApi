using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace RdStationApi.Client
{
    public class RdStationApiClient : IRdStationApiClient
    {
        public const string BASE_ADDRESS = @"https://www.rdstation.com.br/api/";
        public const string CONVERSION_URL = BASE_ADDRESS + "1.3/conversions";
        public const string CHANGE_LEAD_URL = BASE_ADDRESS + "1.2/leads/";
        private readonly HttpClient _httpClient;

        public RdStationApiClient(HttpClient client = default(HttpClient))
        {
            _httpClient = client ?? new HttpClient { BaseAddress = new Uri(BASE_ADDRESS) };
        }

        public async Task<bool> SendLead(ILead lead)
        {
            var response = await _httpClient.PostAsJsonAsync(CONVERSION_URL, lead);
            return response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.Created;
        }

        public bool SendLeadSync(ILead lead)
        {
            var response = _httpClient.PostAsJsonAsync(CONVERSION_URL, lead).Result;
            return response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.Created;
        }

        public bool ChangeLeadStatusSync(LeadStatusRoot leadStatusRoot)
        {
            var response = _httpClient.PutAsJsonAsync(CHANGE_LEAD_URL, leadStatusRoot).Result;
            return response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.Created;
        }

        public async Task<bool> ChangeLeadStatus(LeadStatusRoot leadStatusRoot)
        {
            var response = await _httpClient.PutAsJsonAsync(CHANGE_LEAD_URL, leadStatusRoot);
            return response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.Created;
        }

    }
}