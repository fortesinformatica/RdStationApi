using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using NSubstitute;
using NUnit.Framework;

namespace RdStationApi.Client.Tests
{
    [TestFixture]
    public class RdStationApiClientTests
    {
        private IRdStationApiClient _sut;
        private HttpClient _httpClient;
        private Lead _lead;

        [SetUp]
        public void SetUp()
        {
            _httpClient = Substitute.For<HttpClient>();
            _sut = new RdStationApiClient(_httpClient);
            _lead = new Lead("FakeToken", "FakeIdentificador", "FakeEmail");
        }

        [Test]
        public async Task SendLeadShouldSendAPost()
        {
            _httpClient.PostAsJsonAsync("conversions", Arg.Any<HttpContent>()).ReturnsForAnyArgs(new HttpResponseMessage(HttpStatusCode.OK));
            ILead lead = _lead;
            await _sut.SendLead(lead);

            await _httpClient.Received().SendAsync(Arg.Is<HttpRequestMessage>(h => h.Method == HttpMethod.Post), Arg.Any<CancellationToken>());
        }

        [Test]
        public async Task SendLeadShouldSendAPostWithJsonObjectInBody()
        {
            _httpClient.PostAsJsonAsync("conversions", Arg.Any<HttpContent>()).ReturnsForAnyArgs(new HttpResponseMessage(HttpStatusCode.OK));
            ILead lead = _lead;
            await _sut.SendLead(lead);

            await _httpClient.Received().SendAsync(Arg.Is<HttpRequestMessage>(h => h.Content.Headers.ContentType.MediaType == "application/json"), Arg.Any<CancellationToken>());
        }

        [Test]
        public async Task SendLeadShouldSendAPostToConversions()
        {
            _httpClient.PostAsJsonAsync("conversions", Arg.Any<HttpContent>()).ReturnsForAnyArgs(new HttpResponseMessage(HttpStatusCode.OK));
            ILead lead = _lead;
            await _sut.SendLead(lead);

            await _httpClient.Received().SendAsync(Arg.Is<HttpRequestMessage>(h => h.RequestUri.ToString() == "conversions"), Arg.Any<CancellationToken>());
        }
    }
}
