using Holistic_Mission.DTOs.CustomerDto;
using Holistic_Mission.Repository.CustomerRepo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Holistic_Mission.Controllers
{
    
    public class CustomersController : ControllerBase
    {

        public CustomersController(ICustomerRepo customerRepo)
        {
              customerRepo= customerRepo;

        }


        [HttpGet]
        public IActionResult GetAllCustomer()
        {
            var customers = customerRepo.customerResponseDtos(new CustomerResponseDto());
            if (customers == null)
            {
                return NotFound();
            }
            return Ok(customers);
        }


        [HttpGet("{id}")]
        public IActionResult GetCustomer(int id) {
            var customerDto = customerRepo.getCustomerById(new CustomerResponseDto { Id = id });
            if (customerDto == null)
            {
                return NotFound();
            }
            return Ok(customerDto);


        }

        [HttpPost]
        public IActionResult AddCustomer(CustomerRequstDto customerRequstDto)
        {
            if (customerRequstDto == null)
            {
                return BadRequest();
            }
            customerRepo.AddedCustomer(customerRequstDto);
            return Created();

          
        }




    }
}
