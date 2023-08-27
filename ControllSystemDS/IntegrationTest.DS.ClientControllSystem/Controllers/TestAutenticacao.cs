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
    public class TestAutenticacao
    {
        private TestServer _server;
        private HttpClient _httpClient;

        [TestMethod]
        public async Task TestGetUserWithSuccess()
        {
            //arrange
            User usuario = new User();
            usuario.username = "teste1";
            usuario.password = "teste2";

            List<User> users = new List<User>();
            users.Add(usuario);

            var _baseMock = new Mock<IUserRepository>();
            _baseMock.Setup(x => x.Get()).Returns(users);

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
            var response = await _httpClient.GetAsync("/api/autenticacao");
            var responseAsString = await response.Content.ReadAsStringAsync();
            var responseGetUser = JsonConvert.DeserializeObject<ResponseGetUser>(responseAsString);

            //assert
            Assert.IsTrue(responseGetUser.StatusCode == (int)HttpStatusCode.OK);
            Assert.IsTrue(responseGetUser.data.First().username.Equals("teste1"));
        }

        [TestMethod]
        public async Task TestGetUserWithException()
        {
            //arrange
            var _baseMock = new Mock<IUserRepository>();
            _baseMock.Setup(x => x.Get()).Throws(new Exception("fatal error"));

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
            var response = await _httpClient.GetAsync("/api/autenticacao");
            var responseAsString = await response.Content.ReadAsStringAsync();
            var responseGetUser = JsonConvert.DeserializeObject<ResponseGetUser>(responseAsString);

            //assert
            Assert.IsTrue(responseGetUser.StatusCode == (int)HttpStatusCode.InternalServerError);
        }
    }
}
