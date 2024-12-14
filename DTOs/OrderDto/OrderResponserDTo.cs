using Holistic_Mission.DTOs.CustomerDto;
using Holistic_Mission.DTOs.ProductDto;
using Holistic_Mission.Models;
using System.ComponentModel.DataAnnotations;

namespace Holistic_Mission.DTOs.OrderDto
{
    public class OrderResponserDTo
    {

        public int Id { get; set; }
        [Required]
        public int TotalPrice { get; set; }
        public IList<ProductRequstDto> ProductRequstDto { get; set; }
        public CustomerforOrderDto CustomerforOrderDto { get; set; }
    }
}
