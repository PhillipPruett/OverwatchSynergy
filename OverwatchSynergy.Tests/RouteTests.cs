using System;
using System.Net;
using System.Net.Http;
using System.Text;
using FluentAssertions;
using Microsoft.Owin.Testing;
using Newtonsoft.Json;
using NUnit.Framework;
using OverwatchSynergy.Api;

namespace OverwatchSynergy.Tests
{
    [TestFixture]
    public class RouteTests
    {
        [SetUp]
        public void SetUp()
        {
            server = TestServer.Create<Startup>();
            httpClient = server.HttpClient;
        }

        [TearDown]
        public void TearDown()
        {
            server.Dispose();
        }

        private TestServer server;
        private HttpClient httpClient;

        [Test]
        public void get_heroes_returns_OK()
        {
            httpClient.GetAsync("/heroes").Result.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Test]
        public void the_home_page_returned_OK()
        {
            httpClient.GetAsync("").Result.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Test]
        public void synergies_are_retrievable()
        {
            var result = httpClient.PostAsync("calculator",
                                 new StringContent(JsonConvert.SerializeObject(new[] {"Genji"}),
                                                   Encoding.UTF8,
                                                   "application/json")
                ).Result;

            Console.WriteLine(result.Content.ReadAsStringAsync().Result);

            result.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}