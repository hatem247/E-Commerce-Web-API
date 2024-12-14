using Holistic_Mission.DTOs.ProductDto;

namespace Holistic_Mission.Repository.ProductRepo
{
    public interface IProductRepo
    {
        void AddProduct(ProductRequstDto ProductRequstDto);
    }
}
