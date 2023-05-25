using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RestaurantOrder.Service.DTOs.Orders
{
    public class CreateOrderDTO
    {
        [Required]
        public int TotalPrice { get; set; }
        [Required]
        public ICollection<CreateItemOrderDTO> ItemOrder { get; set; }
        [Required]
        public Guid AreaId { get; set; }
        [Required]
        public string Code { get; set; }

    }
}
