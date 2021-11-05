using Newtonsoft.Json;
using ParkUp.Application.ViewModels;
using ParkUp.Services.Api;
using ParkUp.Tests.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace ParkUp.Tests.Empresas
{
    [Collection(nameof(IntegrationTestsFixtureCollection))]
    [TestCaseOrderer("ParkUp.Tests.Config.PriorityOrderer", "ParkUp.Tests")]
    public class EmpresasTest
    {
        private readonly IntegrationTestsFixture<StartupApiTests> _testsFixture;
        public EmpresasViewModel empresa;
        public IEnumerable<EmpresasViewModel> lstEmpresas;

        public EmpresasTest(IntegrationTestsFixture<StartupApiTests> testsFixture)
        {
            _testsFixture = testsFixture;

            empresa = new EmpresasViewModel
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

        [Fact, TestPriority(1)]
        public async Task CadastroEmpresas()
        {
            //Arrange
            _testsFixture.GerarDadosEmpresa();

            empresa.NomeEmpresa = _testsFixture.NomeEmpresa;
            empresa.CNPJ = _testsFixture.CNPJ;
            empresa.IE = _testsFixture.IE;

            var request = new HttpRequestMessage(HttpMethod.Post, "/api/empresas")
            {
                Content = _testsFixture.ConverterParaByteArrayContent(empresa)
            };

            //Act
            var initialResponse = await _testsFixture.Client.SendAsync(request);
            var result = JsonConvert.DeserializeObject<EmpresasViewModel>(await initialResponse.Content.ReadAsStringAsync());

            //Assert
            initialResponse.EnsureSuccessStatusCode();
        }

        [Fact, TestPriority(2)]
        public async Task ListarEmpresas()
        {
            //Arrange

            //Act
            var initialResponse = await _testsFixture.Client.GetAsync("/api/empresas");
            lstEmpresas = JsonConvert.DeserializeObject<IEnumerable<EmpresasViewModel>>(await initialResponse.Content.ReadAsStringAsync());

            //Assert
            initialResponse.EnsureSuccessStatusCode();
        }

        [Fact, TestPriority(3)]
        public async Task ObterEmpresaPorId()
        {
            //Arrange
            await ListarEmpresas();

            //Act
            var initialResponse = await _testsFixture.Client.GetAsync("/api/empresas?id=" + lstEmpresas.OrderByDescending(a => a.Id).FirstOrDefault().Id);

            //Assert
            initialResponse.EnsureSuccessStatusCode();
        }

        [Fact, TestPriority(4)]
        public async Task AtualizarEmpresa()
        {
            //Arrange
            await ListarEmpresas();

            _testsFixture.GerarDadosEmpresa();

            empresa.Id = lstEmpresas.OrderByDescending(a => a.Id).FirstOrDefault().Id;
            empresa.NomeEmpresa = _testsFixture.NomeEmpresa;
            empresa.CNPJ = _testsFixture.CNPJ;
            empresa.IE = _testsFixture.IE;

            var request = new HttpRequestMessage(HttpMethod.Put, "/api/empresas")
            {
                Content = _testsFixture.ConverterParaByteArrayContent(empresa)
            };

            //Act
            var initialResponse = await _testsFixture.Client.SendAsync(request);
            var result = JsonConvert.DeserializeObject<EmpresasViewModel>(await initialResponse.Content.ReadAsStringAsync());

            //Assert
            initialResponse.EnsureSuccessStatusCode();
        }

        [Fact, TestPriority(5)]
        public async Task DesativarEmpresa()
        {
            //Arrange
            await ListarEmpresas();

            _testsFixture.GerarDadosEmpresa();

            empresa.Id = lstEmpresas.OrderByDescending(a => a.Id).FirstOrDefault().Id;
            empresa.NomeEmpresa = _testsFixture.NomeEmpresa;
            empresa.CNPJ = _testsFixture.CNPJ;
            empresa.IE = _testsFixture.IE;

            var request = new HttpRequestMessage(HttpMethod.Delete, "/api/empresas")
            {
                Content = _testsFixture.ConverterParaByteArrayContent(empresa)
            };

            //Act
            var initialResponse = await _testsFixture.Client.SendAsync(request);
            var result = JsonConvert.DeserializeObject<EmpresasViewModel>(await initialResponse.Content.ReadAsStringAsync());
            await ExcluirEmpresa();

            //Assert
            initialResponse.EnsureSuccessStatusCode();
        }

        #region "Private Area"

        private async Task ExcluirEmpresa()
        {
            //Arrange
            empresa.Id = lstEmpresas.OrderByDescending(a => a.Id).FirstOrDefault().Id;

            var request = new HttpRequestMessage(HttpMethod.Delete, "/api/empresas/excluir")
            {
                Content = _testsFixture.ConverterParaByteArrayContent(empresa)
            };

            //Act
            var initialResponse = await _testsFixture.Client.SendAsync(request);
            var result = JsonConvert.DeserializeObject<EmpresasViewModel>(await initialResponse.Content.ReadAsStringAsync());

            //Assert
            initialResponse.EnsureSuccessStatusCode();
        }

        #endregion
    }
}