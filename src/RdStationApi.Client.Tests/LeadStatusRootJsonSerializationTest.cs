using Newtonsoft.Json;
using NUnit.Framework;

namespace RdStationApi.Client.Tests
{
    [TestFixture, SetCulture("pt-BR")]
    public class LeadStatusRootJsonSerializationTest
    {
        private LeadStatusRoot _sut;

        [SetUp]
        public void SetUp()
        {
            var leadStatus = new LeadStatus(LifeCycleLeadStage.LeadQualificado, true);
            _sut = new LeadStatusRoot("FakeAtuToken", leadStatus);
        }

        [Test]
        public void JsonShouldHaveProperlyPropertyNames()
        {
            var serializeObject = JsonConvert.SerializeObject(_sut);

            StringAssert.Contains($"\"auth_token\":\"{_sut.AuthToken}\"", serializeObject);
            StringAssert.Contains($"\"lead\":", serializeObject);
            StringAssert.Contains($"\"lifecycle_stage\":{_sut.LeadStatus.LifecycleStage:D}", serializeObject);
            StringAssert.Contains($"\"opportunity\":{_sut.LeadStatus.Opportunity.ToString().ToLower()}", serializeObject);
        }

        [Test]
        public void IfOpportunityPropertyIsNullJsonShouldNotHaveThisProperty()
        {
            _sut = new LeadStatusRoot("FakeAtuToken", new LeadStatus(LifeCycleLeadStage.LeadQualificado, null));
            var serializeObject = JsonConvert.SerializeObject(_sut);
            StringAssert.DoesNotContain("\"opportunity\":null", serializeObject);
        }
    }
}