using EasyTalents.API;
using EasyTalents.Domain.DTOs;
using EasyTalents.Domain.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace EasyTalents.Test
{
    [TestClass]
    public class EndpointTest
    {
        private readonly HttpClient _httpClient;
        private Guid candidateId { get; set; }       

        public EndpointTest()
        {
            var startupAssembly = typeof(Startup).GetTypeInfo().Assembly;
            var contentRoot = "D:\\Carolina\\EasyTalents\\EasyTalents\\EasyTalents.API";

            var configurationBuilder = new ConfigurationBuilder()
                .SetBasePath(contentRoot)
                .AddJsonFile("appsettings.json");

            var webHostBuilder = new WebHostBuilder()
                .UseContentRoot(contentRoot)
                .ConfigureServices(InitializeServices)
                .UseConfiguration(configurationBuilder.Build())
                .UseEnvironment("Development")
                .UseStartup(typeof(Startup));

            var server = new TestServer(webHostBuilder);

            // Add configuration for client
            _httpClient = server.CreateClient();
            _httpClient.BaseAddress = new Uri("http://localhost:5001");
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            candidateId = new Guid("2d044e06-a4f7-41ed-7ff1-08d8031bc1a9");
        }

        [TestMethod]
        public async Task CandidateGetApiTestAsync()
        {
            var result = await _httpClient.GetAsync("/candidate");

            Assert.AreEqual(result.StatusCode, HttpStatusCode.OK);
        }

        [TestMethod]
        public async Task CandidateGetByIdApiTestAsync()
        {
            var result = await _httpClient.GetAsync("/candidate/" + candidateId);

            Assert.AreEqual(result.StatusCode, HttpStatusCode.OK);
        }

        [TestMethod]
        public async Task CandidatePostApiTestAsync()
        {
            var result = await _httpClient.GetStringAsync("/candidate/" + candidateId);

            CandidateDTO candidate = JsonConvert.DeserializeObject<CandidateDTO>(result);

            candidate.Id = Guid.NewGuid();

            candidateId = candidate.Id.Value;

            var content = new StringContent(JsonConvert.SerializeObject(candidate), Encoding.UTF8, "application/json");

            var resultPost = await _httpClient.PostAsync("/candidate", content);

            Assert.AreEqual(resultPost.StatusCode, HttpStatusCode.OK);
        }

        [TestMethod]
        public async Task CandidatePutApiTestAsync()
        {
            var result = await _httpClient.GetStringAsync("/candidate/" + candidateId);

            CandidateDTO candidate = JsonConvert.DeserializeObject<CandidateDTO>(result);

            var content = new StringContent(JsonConvert.SerializeObject(candidate), Encoding.UTF8, "application/json");

            var resultPost = await _httpClient.PutAsync("/candidate", content);

            Assert.AreEqual(resultPost.StatusCode, HttpStatusCode.OK);
        }

        [TestMethod]
        public async Task CandidateDeleteApiTestAsync()
        {
            var result = await _httpClient.GetStringAsync("/candidate");

            List<CandidateDTO> candidate = JsonConvert.DeserializeObject<List<CandidateDTO>>(result);

            var firstCandidate = candidate.LastOrDefault();

            var resultPost = await _httpClient.DeleteAsync("/candidate/" + firstCandidate.Id.Value);

            Assert.AreEqual(resultPost.StatusCode, HttpStatusCode.OK);
        }


        protected virtual void InitializeServices(IServiceCollection services)
        {
            var startupAssembly = typeof(Startup).GetTypeInfo().Assembly;

            var manager = new ApplicationPartManager
            {
                ApplicationParts =
                {
                    new AssemblyPart(startupAssembly)
                },
                FeatureProviders =
                {
                    new ControllerFeatureProvider(),
                    new ViewComponentFeatureProvider()
                }
            };

            services.AddSingleton(manager);
        }

    }
}
