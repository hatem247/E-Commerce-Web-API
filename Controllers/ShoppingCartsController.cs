using Holistic_Mission.DTOs.ShoppinCartDTO;
using Holistic_Mission.Repository.ShoppingCartRepo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Holistic_Mission.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartsController : ControllerBase
    {
        private readonly IShoppingCartRepo _shoppingCartRepo;


        public ShoppingCartsController(IShoppingCartRepo shoppingCartRepo)
        {
            _shoppingCartRepo = shoppingCartRepo;

        }
        [HttpPost]
        public IActionResult AddShoppingCart(ShoppingCartRequstDto shoppingCartRequstDto)
        {
            if (shoppingCartRequstDto == null)
            {
                return BadRequest("Invalid shopping cart data.");
            }


            _shoppingCartRepo.AddShoppingCart(shoppingCartRequstDto);

            return Created();


        }
    }
}
