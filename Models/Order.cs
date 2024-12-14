using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Holistic_Mission.Models
{
    public class Order
    {
        public int Id { get; set; }
        [Required]
        public int TotalPrice { get; set; }
        public IList<Product> Products { get; set; }
        public Customer? customer { get; set; }

    }
}


