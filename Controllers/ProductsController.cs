using Holistic_Mission.DTOs.ProductDto;
using Holistic_Mission.DTOs.ShoppinCartDTO;
using Holistic_Mission.Repository.ProductRepo;
using Holistic_Mission.Repository.ShoppingCartRepo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Holistic_Mission.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepo productRepo;


        public ProductsController(IProductRepo _productRepo)
        {
            productRepo = _productRepo;
        }

        public IActionResult AddProduct(ProductRequstDto productRequstDto)
        {
            if (productRequstDto == null)
            {
                return BadRequest("Invalid product data.");
            }
            productRepo.AddProduct(productRequstDto);
            return Created(); 
         
        }
    }
}
