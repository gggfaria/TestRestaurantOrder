using System.ComponentModel.DataAnnotations;

namespace RestaurantOrder.Service.DTOs.Areas
{
    public class CreateAreaDTO
    {
        [Required]
        public string Name { get; set; }
    }
}
