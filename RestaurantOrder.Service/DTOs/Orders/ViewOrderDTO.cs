using RestaurantOrder.Service.DTOs.Areas;
using System;
using System.Collections.Generic;

namespace RestaurantOrder.Service.DTOs.Orders
{
    public class ViewOrderDTO
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public int TotalPrice { get; set; }
        public ICollection<ViewItemOrderDTO> ItemOrder { get; set; }
        public ViewAreaDTO Area { get; set; }
    }
}
