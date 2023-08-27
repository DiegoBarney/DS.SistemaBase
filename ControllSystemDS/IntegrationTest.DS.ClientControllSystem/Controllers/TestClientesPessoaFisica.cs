using DS.Domain.ClientControll;
using DS.Infrastructure.ClientControll.Repository.Interface;
using IntegrationTest.DS.ClientControllSystem.Mocks;
using IntegrationTest.DS.ClientControllSystem.Response;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace IntegrationTest.DS.ClientControllSystem.Controllers
{
    [TestClass]
    public class TestClientesPessoaFisica
    {
        private TestServer _server;
        private HttpClient _httpClient;

        [TestMethod]
        public async Task TestGetFullListClientePessoaFisicaWithSuccess()
        {
            //arrange
            ClientePessoaFisica cliente = new ClientePessoaFisica();
            cliente.cpf = "1112523528";
            cliente.apelido = "teste2";

            List<ClientePessoaFisica> clientes = new List<ClientePessoaFisica>();
            clientes.Add(cliente);

            var _baseMock = new Mock<IClientePessoaFisicaRepository>();
            _baseMock.Setup(x => x.FullList()).Returns(clientes);

            _server = new TestServer
                (
                    new WebHostBuilder().
                    UseStartup<StartupMock>().
                    ConfigureServices(
                        x => x.AddScoped(s => _baseMock.Object)
                    ).UseEnvironment("IntegrationTest")
                );

            _httpClient = _server.CreateClient();
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("teste");

            //act
            var response = await _httpClient.GetAsync("/api/clientespessoafisica");
            var responseAsString = await response.Content.ReadAsStringAsync();
            var responseGetUser = JsonConvert.DeserializeObject<ResponseGetClientesPessoaFisica>(responseAsString);

            //assert
            Assert.IsTrue(responseGetUser.StatusCode == (int)HttpStatusCode.OK);
            Assert.IsTrue(responseGetUser.data.First().cpf.Equals("1112523528"));
        }

        [TestMethod]
        public async Task TestGetFullListClientePessoaFisicaWithException()
        {
            //arrange
            var _baseMock = new Mock<IClientePessoaFisicaRepository>();
            _baseMock.Setup(x => x.FullList()).Throws(new Exception("fatal error"));

            _server = new TestServer
                (
                    new WebHostBuilder().
                    UseStartup<StartupMock>().
                    ConfigureServices(
                        x => x.AddScoped(s => _baseMock.Object)
                    ).UseEnvironment("IntegrationTest")
                );

            _httpClient = _server.CreateClient();
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("teste");

            //act
            var response = await _httpClient.GetAsync("/api/clientespessoafisica");
            var responseAsString = await response.Content.ReadAsStringAsync();
            var responseGetUser = JsonConvert.DeserializeObject<ResponseGetClientesPessoaFisica>(responseAsString);

            //assert
            Assert.IsTrue(responseGetUser.StatusCode == (int)HttpStatusCode.InternalServerError);
            Assert.IsTrue(responseGetUser.Error != null);
            Assert.IsTrue(responseGetUser.Error.ToString().Contains("Não foi possivel capturar as informações."));
        }


        [TestMethod]
        public async Task TestGetByIdClientePessoaFisicaWithSuccess()
        {
            //arrange
            ClientePessoaFisica cliente = new ClientePessoaFisica();
            cliente.cpf = "1112523528";
            cliente.apelido = "teste2";

            var _baseMock = new Mock<IClientePessoaFisicaRepository>();
            _baseMock.Setup(x => x.SelectById(1234)).Returns(cliente);
            _baseMock.Setup(x => x.FullSearch(cliente)).Returns(cliente);

            _server = new TestServer
                (
                    new WebHostBuilder().
                    UseStartup<StartupMock>().
                    ConfigureServices(
                        x => x.AddScoped(s => _baseMock.Object)
                    ).UseEnvironment("IntegrationTest")
                );

            _httpClient = _server.CreateClient();
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("teste");

            //act
            var response = await _httpClient.GetAsync("/api/clientespessoafisica/1234");
            var responseAsString = await response.Content.ReadAsStringAsync();
            var responseGetUser = JsonConvert.DeserializeObject<ResponseGetClientePessoaFisica>(responseAsString);

            //assert
            Assert.IsTrue(responseGetUser.StatusCode == (int)HttpStatusCode.OK);
            Assert.IsTrue(responseGetUser.data.cpf.Equals("1112523528"));
        }

    }
}
