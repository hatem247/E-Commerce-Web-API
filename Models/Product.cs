using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Holistic_Mission.Models
{
    public class Product
    {
        public int Id {  get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required] 
        public int stockQuantity {  get; set; }
        public Order ?order { get; set; }
    }
}


