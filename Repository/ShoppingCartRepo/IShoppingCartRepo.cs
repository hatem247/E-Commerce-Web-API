using Holistic_Mission.DTOs.ShoppinCartDTO;

namespace Holistic_Mission.Repository.ShoppingCartRepo
{
    public interface IShoppingCartRepo
    {
        void AddShoppingCart(ShoppingCartRequstDto shoppingCartRequstDto);
    }
}
