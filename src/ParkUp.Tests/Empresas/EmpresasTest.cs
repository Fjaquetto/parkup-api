using Newtonsoft.Json;
using ParkUp.Application.ViewModels;
using ParkUp.Services.Api;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace ParkUp.Tests.Empresas
{
    [Collection(nameof(IntegrationTestsFixtureCollection))]
    public class EmpresasTest
    {
        private readonly IntegrationTestsFixture<StartupApiTests> _testsFixture;
        public EmpresasViewModel data;

        public EmpresasTest(IntegrationTestsFixture<StartupApiTests> testsFixture)
        {
            _testsFixture = testsFixture;

            data = new EmpresasViewModel
            {
                TipoEmpresa = "Estacionamento",
                Endereco = "rua testeteste, 123",
                CEP = "123410011",
                Cidade = "São Paulo",
                Estado = "São Paulo",
                Email = "Teste@teste.com",
                Telefone = "(11)98988-3232",
                DataCadastro = DateTime.Now,
                FlgAtivo = true
            };
        }

        [Fact]
        public async Task ListarEmpresas()
        {
            //Arrange

            //Act
            var initialResponse = await _testsFixture.Client.GetAsync("/api/empresas");

            //Assert
            initialResponse.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task ObterEmpresaPorId()
        {
            //Arrange

            //Act
            var initialResponse = await _testsFixture.Client.GetAsync("/api/empresas?id=1");

            //Assert
            initialResponse.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task CadastroEmpresas()
        {
            //Arrange
            _testsFixture.GerarDadosEmpresa();

            data.NomeEmpresa = _testsFixture.NomeEmpresa;
            data.CNPJ = _testsFixture.CNPJ;
            data.IE = _testsFixture.IE;


            var request = new HttpRequestMessage(HttpMethod.Post, "/api/empresas")
            {
                Content = _testsFixture.ConverterParaByteArrayContent(data)
            };

            //Act
            var initialResponse = await _testsFixture.Client.SendAsync(request);
            var result = JsonConvert.DeserializeObject<EmpresasViewModel>(await initialResponse.Content.ReadAsStringAsync());

            //Assert
            initialResponse.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task AtualizarEmpresa()
        {
            //Arrange
            _testsFixture.GerarDadosEmpresa();

            data.Id = 1;
            data.NomeEmpresa = _testsFixture.NomeEmpresa;
            data.CNPJ = _testsFixture.CNPJ;
            data.IE = _testsFixture.IE;

            var request = new HttpRequestMessage(HttpMethod.Put, "/api/empresas")
            {
                Content = _testsFixture.ConverterParaByteArrayContent(data)
            };

            //Act
            var initialResponse = await _testsFixture.Client.SendAsync(request);
            var result = JsonConvert.DeserializeObject<EmpresasViewModel>(await initialResponse.Content.ReadAsStringAsync());

            //Assert
            initialResponse.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task DesativarEmpresa()
        {
            //Arrange
            _testsFixture.GerarDadosEmpresa();

            data.Id = 1;
            data.NomeEmpresa = _testsFixture.NomeEmpresa;
            data.CNPJ = _testsFixture.CNPJ;
            data.IE = _testsFixture.IE;

            var request = new HttpRequestMessage(HttpMethod.Delete, "/api/empresas")
            {
                Content = _testsFixture.ConverterParaByteArrayContent(data)
            };

            //Act
            var initialResponse = await _testsFixture.Client.SendAsync(request);
            var result = JsonConvert.DeserializeObject<EmpresasViewModel>(await initialResponse.Content.ReadAsStringAsync());

            //Assert
            initialResponse.EnsureSuccessStatusCode();
        }
    }
}