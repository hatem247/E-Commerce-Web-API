using Holistic_Mission.DTOs.ShoppinCartDTO;
using System.ComponentModel.DataAnnotations;

namespace Holistic_Mission.DTOs.CustomerDto
{
    public class CustomerforOrderDto
    {
        public string Name { get; set; }
        [Phone]
        public string phone { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public ShoppingCartRequstDto ShoppingCartdto { get; set; }
    }
}
