using Newtonsoft.Json;
using RestaurantOrder.Service.DTOs.Areas;
using RestaurantOrder.Service.DTOs.Orders;
using RestaurantOrder.WebApi;
using RestaurantOrder.WebTests.Configs;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace RestaurantOrder.WebTests
{
    [Collection(nameof(IntegrationTestsFixtureCollection))]
    public class OrderWebTsets
    {
        private readonly IntegrationTestsFixture<StartupTests> _testsFixture;

        public OrderWebTsets(IntegrationTestsFixture<StartupTests> testsFixture)
        {
            _testsFixture = testsFixture;
        }


        [Fact]
        [Trait("Category", "Order web test")]
        public async Task Order_PostNewOrder_ReturnOk()
        {
            //Arrange
            var areaDTO = await CreateNewArea();

            CreateOrderDTO createOrderDTO = new CreateOrderDTO
            {
                TotalPrice = 42,
                AreaId = areaDTO.Id,
                Code = $"bilbobaggins{ Guid.NewGuid() }",
                ItemOrder =
                new List<CreateItemOrderDTO> {
                    {
                        new CreateItemOrderDTO
                        { Amount = 10, ProductName = "pão de viagem", UnitPrice = 10}
                    }
                }
            };

            //act
            using var content = new StringContent(JsonConvert.SerializeObject(createOrderDTO), Encoding.UTF8,
                                    "application/json");
            Action response = () => _testsFixture.Client.PostAsync("/api/Order", content);

            //assert
            Assert.Throws(typeof(Exception), response);
            //response.EnsureSuccessStatusCode();
        }

        private async Task<ViewAreaDTO> CreateNewArea()
        {
            var createAreaDTO = new CreateAreaDTO { Name = Guid.NewGuid().ToString() };
            using var content = new StringContent(JsonConvert.SerializeObject(createAreaDTO), Encoding.UTF8,
                                    "application/json");
            var response = await _testsFixture.Client.PostAsync("/api/area", content);
            response.EnsureSuccessStatusCode();
            string result = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<ViewAreaDTO>(result);
        }
    }
}
