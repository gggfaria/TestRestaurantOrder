using System;
using System.ComponentModel.DataAnnotations;

namespace RestaurantOrder.Service.DTOs.Orders
{
    public class CreateItemOrderDTO
    {
        [Required]
        public string ProductName { get; set; }
        [Required]
        public int Amount { get; set; }
        [Required]
        public decimal UnitPrice { get; set; }
    }
}