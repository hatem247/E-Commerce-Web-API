using Holistic_Mission.DTOs.CustomerDto;
using System.Runtime.InteropServices;

namespace Holistic_Mission.Repository.CustomerRepo
{
    public interface ICustomerRepo
    {
        List<CustomerResponseDto> customerResponseDtos(CustomerResponseDto customerResponseDto);
        CustomerResponseDto getCustomerById(CustomerResponseDto id);
        void AddedCustomer(CustomerRequstDto customerRequstDto);

    }
}
