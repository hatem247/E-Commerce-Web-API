using Holistic_Mission.DTOs.ProductDto;
using Holistic_Mission.Models;
using System.ComponentModel.DataAnnotations;

namespace Holistic_Mission.DTOs.OrderDto
{
    public class OrderRequstDto
    {
        [Required]
        public int TotalPrice { get; set; }

        public List<ProductRequstDto> ProductRequstdto { get; set; }
        public int customerId { get; set; }
        
    }
}
