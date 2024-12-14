using static System.Runtime.InteropServices.JavaScript.JSType;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Numerics;

namespace Holistic_Mission.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Phone]
        public string phone { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public ShoppingCart ?ShoppingCart { get; set; }
        public IList<Order>? Orders { get; set; }    = new List<Order>();

    }
}


