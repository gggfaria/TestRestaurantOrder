using RestaurantOrder.Domain.Entities.Orders;
using System.Collections.Generic;
using Xunit;

namespace RestaurantOrder.UnitTest.DomainTest.Orders
{
    public  class OrderTest
    {
        //AAA Arrange, Act, Assert

        //TestsName 
        //MothodName_TestStat_ExpectedBehavior

        public OrderTest()
        {

        }

        [Fact]
        [Trait("Category", "Order")]
        public void CreateOrder_IsValid_ReturnTrue()
        {
            //Arrange
            var order = CreateValidOrder();

            //Act
            var isValid = order.IsValid();

            //Assert
            Assert.True(isValid, "Order is not valid");
        }

        [Fact]
        [Trait("Category", "Order")]
        public void CreateOrder_IsValid_InvalidAmount()
        {
            //Arrange
            var order = CreateInvalidAmountItemOrder();

            //Act
            var isValid = order.IsValid();

            //Assert
            Assert.False(isValid, "Order must be invalid");
        }


        private Order CreateValidOrder()
        {
            var itemOrder = new List<ItemOrder>
            { 
                {new ItemOrder("Banana", 2, 2.5m) }, 
                {new ItemOrder("Ice", 3, 5.5m) },
                {new ItemOrder("Apple", 2, 3.5m) } 
            };

            var area = new Area("Area1");
            return new Order("123a", 200, itemOrder, area, area.Id);
        }

        private Order CreateInvalidAmountItemOrder()
        {
            var itemOrder = new List<ItemOrder>
            {
                {new ItemOrder("Banana", 0, 2.5m) },
                {new ItemOrder("Ice", 3, 5.5m) },
                {new ItemOrder("Apple", 2, 3.5m) }
            };

            var area = new Area("Area1");
            return new Order("123a", 200, itemOrder, area, area.Id);
        }
    }
}
