using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Holistic_Mission.Models
{
    public class ShoppingCart
    {
        public int Id { get; set; }
        [Required]
        public int NumOfItems { get; set; }

        public int ?CustomerId { get; set; }
        public Customer ?customer { get; set; }
    }
}


