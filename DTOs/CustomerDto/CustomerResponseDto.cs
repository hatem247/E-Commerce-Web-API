using Holistic_Mission.DTOs.OrderDto;
using Holistic_Mission.DTOs.ShoppinCartDTO;
using Holistic_Mission.Models;
using System.ComponentModel.DataAnnotations;

namespace Holistic_Mission.DTOs.CustomerDto
{
    public class CustomerResponseDto
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Phone]
        public string phone { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public ShoppingCartRequstDto ShoppingCartdto { get; set; }
    }
}
