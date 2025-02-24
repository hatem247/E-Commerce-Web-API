using Holistic_Mission.DTOs.OrderDto;
using Holistic_Mission.Repository.OrderRepo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Holistic_Mission.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {   
        public OrdersController(IOrderRepo orderRepo)
        {
             orderRepo= _orderRepo;
        }
        private readonly IOrderRepo _orderRepo;

        [HttpGet]
        public ActionResult<List<OrderResponserDTo>> GetOrders()
        {
           
           
             var orders = _orderRepo.GetOrders(new OrderResponserDTo());
            if (orders == null) { 
                return NotFound();  
            
            }

            return Ok(orders);
            
           
        }

        [HttpPost]
        public ActionResult AddOrder([FromBody] OrderRequstDto orderDto)
        {
            if (orderDto == null)
            {
                return BadRequest("Order data is null");
            }

            
             _orderRepo.AddOrder(orderDto);
            return Created(); 
            
           
        }

      
        [HttpPut("{id}")]
        public ActionResult UpdateOrder(int id, [FromBody] OrderRequstDto orderDto)
        {
            if (orderDto == null)
            {
                return BadRequest("Order data is null");
            }

            _orderRepo.UpdateOrder(orderDto, id);
             return Accepted(); 
            
         
        }
    }

}

