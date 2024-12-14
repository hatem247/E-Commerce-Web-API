using Holistic_Mission.Data;
using Holistic_Mission.DTOs.ProductDto;
using Holistic_Mission.Models;

namespace Holistic_Mission.Repository.ProductRepo
{
    public class ProductRepo : IProductRepo
    {
        private readonly ApplicationDbContext _context;
        public ProductRepo(ApplicationDbContext context)
        {
            _context = context;
        }
      
        public void AddProduct(ProductRequstDto ProductRequstDto)
        {
            var product = new Product
            {
                Description = ProductRequstDto.Description,
                Name = ProductRequstDto.Name,   
                stockQuantity= ProductRequstDto.stockQuantity,
            };
            _context.Add(product);
            _context.SaveChanges();
        }
    }
}
