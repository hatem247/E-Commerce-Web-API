using Holistic_Mission.DTOs.CustomerDto;
using Holistic_Mission.Repository.CustomerRepo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Holistic_Mission.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerRepo _customerRepo;
        public CustomersController(ICustomerRepo customerRepo)
        {
            _customerRepo = customerRepo;
        }


        [HttpGet("GetAll")]
        public IActionResult GetAllCustomer()
        {
            var customers = _customerRepo.customerResponseDtos(new CustomerResponseDto());
            if (customers == null)
            {
                return NotFound();
            }
            return Ok(customers);
        }


        [HttpGet("{id}")]
        public IActionResult GetCustomer(int id) {
            var customerDto = _customerRepo.getCustomerById(new CustomerResponseDto { Id = id });
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
            _customerRepo.AddedCustomer(customerRequstDto);
            return Created();
        }
    }
}
