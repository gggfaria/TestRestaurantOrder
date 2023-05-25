using Microsoft.AspNetCore.Mvc.Testing;
using RestaurantOrder.WebApi;
using System;
using System.Net.Http;
using Xunit;

namespace RestaurantOrder.WebTests.Configs
{
    [CollectionDefinition(nameof(IntegrationTestsFixtureCollection))]
    public class IntegrationTestsFixtureCollection : ICollectionFixture<IntegrationTestsFixture<StartupTests>> { }

    public class IntegrationTestsFixture<TStartup> : IDisposable where TStartup : class
    {
        public readonly RestaurantTestsFactory<TStartup> Factory;
        public HttpClient Client;
        public IntegrationTestsFixture()
        {
            var clientOptions = new WebApplicationFactoryClientOptions
            {
                AllowAutoRedirect = true,
                BaseAddress = new Uri("https://localhost:44314/")
            };

            Factory = new RestaurantTestsFactory<TStartup>();
            Client = Factory.CreateClient(clientOptions);
        }


        public void Dispose()
        {
            Client.Dispose();
            Factory.Dispose();
        }
    }
}
