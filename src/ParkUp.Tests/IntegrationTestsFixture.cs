using Bogus;
using Bogus.Extensions.Brazil;
using Newtonsoft.Json;
using ParkUp.Services.Api;
using ParkUp.Tests.Config;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Xunit;

namespace ParkUp.Tests
{
    [CollectionDefinition(nameof(IntegrationTestsFixtureCollection))]
    public class IntegrationTestsFixtureCollection : ICollectionFixture<IntegrationTestsFixture<StartupApiTests>> { }

    public class IntegrationTestsFixture<T> : IDisposable where T : class
    {
        public string NomeEmpresa;
        public string CNPJ;
        public string IE;

        public readonly ParkUpAppFactory<T> Factory;
        public HttpClient Client;

        public IntegrationTestsFixture()
        {
            Factory = new ParkUpAppFactory<T>();
            Client = Factory.CreateClient();          
        }

        public ByteArrayContent ConverterParaByteArrayContent<Tdata>(Tdata data)
        {
            var content = new ByteArrayContent(System.Text.Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(data)));
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            return content;
        }

        public void GerarDadosEmpresa()
        {
            var faker = new Faker("pt_BR");
            NomeEmpresa = faker.Internet.UserName();
            CNPJ = faker.Random.ReplaceNumbers("##############");
            IE = faker.Random.ReplaceNumbers("##############");
        }

        public void Dispose()
        {
            Client.Dispose();
            Factory.Dispose();
        }
    }
}
