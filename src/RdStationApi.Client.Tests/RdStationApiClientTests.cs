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
        private LeadStatusRoot _leadStatus;

        [SetUp]
        public void SetUp()
        {
            _httpClient = Substitute.For<HttpClient>();
            _sut = new RdStationApiClient(_httpClient);
            _lead = new Lead("FakeToken", "FakeIdentificador", "FakeEmail");
            _leadStatus = new LeadStatusRoot("FakeAuthToken", new LeadStatus(LifeCycleLeadStage.LeadQualificado, true));
        }

        [Test]
        public async Task SendLeadShouldSendAPost()
        {
            _httpClient.PostAsJsonAsync("conversions", Arg.Any<HttpContent>()).ReturnsForAnyArgs(new HttpResponseMessage(HttpStatusCode.OK));
            await _sut.SendLead(_lead);

            await _httpClient.Received().SendAsync(Arg.Is<HttpRequestMessage>(h => h.Method == HttpMethod.Post), Arg.Any<CancellationToken>());
        }

        [Test]
        public async Task SendLeadShouldSendAPostWithJsonObjectInBody()
        {
            _httpClient.PostAsJsonAsync("conversions", Arg.Any<HttpContent>()).ReturnsForAnyArgs(new HttpResponseMessage(HttpStatusCode.OK));
            await _sut.SendLead(_lead);

            await _httpClient.Received().SendAsync(Arg.Is<HttpRequestMessage>(h => h.Content.Headers.ContentType.MediaType == "application/json"), Arg.Any<CancellationToken>());
        }

        [Test]
        public async Task SendLeadShouldSendAPostToConversions()
        {
            _httpClient.PostAsJsonAsync("conversions", Arg.Any<HttpContent>()).ReturnsForAnyArgs(new HttpResponseMessage(HttpStatusCode.OK));
            await _sut.SendLead(_lead);

            await _httpClient.Received().SendAsync(Arg.Is<HttpRequestMessage>(h => h.RequestUri.ToString() == RdStationApiClient.CONVERSION_URL), Arg.Any<CancellationToken>());
        }

        [Test]
        public void SendLeadSyncShouldSendAPost()
        {
            _httpClient.PostAsJsonAsync("conversions", Arg.Any<HttpContent>()).ReturnsForAnyArgs(new HttpResponseMessage(HttpStatusCode.OK));
            _sut.SendLeadSync(_lead);

            _httpClient.Received().SendAsync(Arg.Is<HttpRequestMessage>(h => h.Method == HttpMethod.Post), Arg.Any<CancellationToken>());
        }

        [Test]
        public void SendLeadSyncShouldSendAPostWithJsonObjectInBody()
        {
            _httpClient.PostAsJsonAsync("conversions", Arg.Any<HttpContent>()).ReturnsForAnyArgs(new HttpResponseMessage(HttpStatusCode.OK));
            _sut.SendLeadSync(_lead);

            _httpClient.Received().SendAsync(Arg.Is<HttpRequestMessage>(h => h.Content.Headers.ContentType.MediaType == "application/json"), Arg.Any<CancellationToken>());
        }

        [Test]
        public void SendLeadSyncShouldSendAPostToConversions()
        {
            _httpClient.PostAsJsonAsync("conversions", Arg.Any<HttpContent>()).ReturnsForAnyArgs(new HttpResponseMessage(HttpStatusCode.OK));
            ILead lead = _lead;
            _sut.SendLeadSync(lead);

            _httpClient.Received().SendAsync(Arg.Is<HttpRequestMessage>(h => h.RequestUri.ToString() == RdStationApiClient.CONVERSION_URL), Arg.Any<CancellationToken>());
        }

        [Test]
        public async Task ChangeLeadStatusShouldSendAPut()
        {
            _httpClient.PutAsJsonAsync("leads", Arg.Any<HttpContent>()).ReturnsForAnyArgs(new HttpResponseMessage(HttpStatusCode.OK));
            await _sut.ChangeLeadStatus("email@email.com", _leadStatus);

            await _httpClient.Received().SendAsync(Arg.Is<HttpRequestMessage>(h => h.Method == HttpMethod.Put), Arg.Any<CancellationToken>());
        }

        [Test]
        public async Task ChangeLeadStatusShouldSendAPostWithJsonObjectInBody()
        {
            _httpClient.PutAsJsonAsync("leads", Arg.Any<HttpContent>()).ReturnsForAnyArgs(new HttpResponseMessage(HttpStatusCode.OK));
            await _sut.ChangeLeadStatus("email@email.com", _leadStatus);

            await _httpClient.Received().SendAsync(Arg.Is<HttpRequestMessage>(h => h.Content.Headers.ContentType.MediaType == "application/json"), Arg.Any<CancellationToken>());
        }

        [Test]
        public async Task ChangeLeadStatusShouldSendAPostToConversions()
        {
            _httpClient.PutAsJsonAsync("leads", Arg.Any<HttpContent>()).ReturnsForAnyArgs(new HttpResponseMessage(HttpStatusCode.OK));
            await _sut.ChangeLeadStatus("email@email.com", _leadStatus);

            await _httpClient.Received().SendAsync(Arg.Is<HttpRequestMessage>(h => h.RequestUri.ToString() == RdStationApiClient.CHANGE_LEAD_URL + "email@email.com"), Arg.Any<CancellationToken>());
        }


        [Test]
        public void ChangeLeadStatusSyncShouldSendAPost()
        {
            _httpClient.PutAsJsonAsync("leads", Arg.Any<HttpContent>()).ReturnsForAnyArgs(new HttpResponseMessage(HttpStatusCode.OK));
            _sut.ChangeLeadStatusSync("email@email.com", _leadStatus);

            _httpClient.Received().SendAsync(Arg.Is<HttpRequestMessage>(h => h.Method == HttpMethod.Put), Arg.Any<CancellationToken>());
        }

        [Test]
        public void ChangeLeadStatusSyncShouldSendAPostWithJsonObjectInBody()
        {
            _httpClient.PutAsJsonAsync("leads", Arg.Any<HttpContent>()).ReturnsForAnyArgs(new HttpResponseMessage(HttpStatusCode.OK));
            _sut.ChangeLeadStatusSync("email@email.com", _leadStatus);

            _httpClient.Received().SendAsync(Arg.Is<HttpRequestMessage>(h => h.Content.Headers.ContentType.MediaType == "application/json"), Arg.Any<CancellationToken>());
        }

        [Test]
        public void ChangeLeadStatusSyncShouldSendAPostToConversions()
        {
            _httpClient.PutAsJsonAsync("leads", Arg.Any<HttpContent>()).ReturnsForAnyArgs(new HttpResponseMessage(HttpStatusCode.OK));
            _sut.ChangeLeadStatusSync("email@email.com", _leadStatus);

            _httpClient.Received().SendAsync(Arg.Is<HttpRequestMessage>(h => h.RequestUri.ToString() == RdStationApiClient.CHANGE_LEAD_URL + "email@email.com"), Arg.Any<CancellationToken>());
        }
    }
}
