using System.ComponentModel.DataAnnotations;

namespace Holistic_Mission.DTOs.ShoppinCartDTO
{
    public class ShoppingCartRequstDto
    {
        [Required]
        public int NumOfItems { get; set; }

        //public int CustomerId { get; set; }
    }
}
