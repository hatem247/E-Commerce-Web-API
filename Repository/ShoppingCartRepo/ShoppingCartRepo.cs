using Holistic_Mission.Data;
using Holistic_Mission.DTOs.ShoppinCartDTO;
using Holistic_Mission.Models;

namespace Holistic_Mission.Repository.ShoppingCartRepo
{
    public class ShoppingCartRepo : IShoppingCartRepo
    {
        private readonly ApplicationDbContext _context;
        public ShoppingCartRepo(ApplicationDbContext context)
        {
            _context = context;
        }
        public void AddShoppingCart(ShoppingCartRequstDto shoppingCartRequstDto)
        {
            var shoppingCart = new ShoppingCart
            {
                NumOfItems= shoppingCartRequstDto.NumOfItems,
            };
            _context.Add(shoppingCart);
            _context.SaveChanges();
        }
    }
}
