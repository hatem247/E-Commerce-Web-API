using System.ComponentModel.DataAnnotations;

namespace Holistic_Mission.DTOs.ProductDto
{
    public class ProductRequstDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public int stockQuantity { get; set; }
    }
}
