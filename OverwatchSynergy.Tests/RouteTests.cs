using System.Net;
using System.Net.Http;
using FluentAssertions;
using Microsoft.Owin.Testing;
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
    }
}