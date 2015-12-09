using System;
using Newtonsoft.Json;
using NUnit.Framework;

namespace RdStationApi.Client.Tests
{
    [TestFixture, SetCulture("pt-BR")]
    public class LeadJsonSerializationTest
    {
        private Lead _sut;

        [SetUp]
        public void SetUp()
        {
            _sut = new Lead("FakeToken", "FakeIdentificador", "FakeEmail")
            {
                Nome = "Value",
                Cargo = "Value",
                Telefone = "Value",
                Celular = "Value",
                Empresa = "Value",
                Estado = "Value",
                Cidade = "Value",
                Website = "Value",
                Twitter = "Value",
                CUtmz = "Value",
                TrafficSource = "Value",
                Tags = "Value",
                CreatedAt = DateTime.Today
            };
        }

        [Test]
        public void JsonShouldHaveProperlyPropertyNames()
        {
            var serializeObject = JsonConvert.SerializeObject(_sut);

            StringAssert.Contains($"\"token_rdstation\":\"{_sut.TokenRdStation}\"", serializeObject);
            StringAssert.Contains($"\"identificador\":\"{_sut.Identificador}\"", serializeObject);
            StringAssert.Contains($"\"email\":\"{_sut.Email}\"", serializeObject);
            StringAssert.Contains($"\"nome\":\"{_sut.Nome}\"", serializeObject);
            StringAssert.Contains($"\"cargo\":\"{_sut.Cargo}\"", serializeObject);
            StringAssert.Contains($"\"empresa\":\"{_sut.Empresa}\"", serializeObject);
            StringAssert.Contains($"\"telefone\":\"{_sut.Telefone}\"", serializeObject);
            StringAssert.Contains($"\"celular\":\"{_sut.Celular}\"", serializeObject);
            StringAssert.Contains($"\"estado\":\"{_sut.Estado}\"", serializeObject);
            StringAssert.Contains($"\"cidade\":\"{_sut.Cidade}\"", serializeObject);
            StringAssert.Contains($"\"website\":\"{_sut.Website}\"", serializeObject);
            StringAssert.Contains($"\"twitter\":\"{_sut.Twitter}\"", serializeObject);
            StringAssert.Contains($"\"c_utmz\":\"{_sut.CUtmz}\"", serializeObject);
            StringAssert.Contains($"\"traffic_source\":\"{_sut.TrafficSource}\"", serializeObject);
            StringAssert.Contains($"\"tags\":\"{_sut.Tags}\"", serializeObject);
            StringAssert.Contains($"\"created_at\":\"{_sut.CreatedAt.Value.ToString("yyyy-MM-ddTHH:mm:sszzz")}\"", serializeObject);
        }
    }
}