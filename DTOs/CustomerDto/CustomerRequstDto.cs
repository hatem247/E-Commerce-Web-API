using Holistic_Mission.Models;
using System.ComponentModel.DataAnnotations;

namespace Holistic_Mission.DTOs.CustomerDto
{
    public class CustomerRequstDto
    {
     
        [Required]
        public string Name { get; set; }
        [Phone]
        public string phone { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        
    }
}
