using System;

namespace RestaurantOrder.Service.DTOs.Orders
{
    public class ViewItemOrderDTO
    {
        public string ProductName { get; set; }
        public int Amount { get; set; }
        public decimal UnitPrice { get; set; }
        public Guid OrderId { get; set; }
    }
}