using Holistic_Mission.Data;
using Holistic_Mission.DTOs.CustomerDto;
using Holistic_Mission.DTOs.OrderDto;
using Holistic_Mission.DTOs.ProductDto;
using Holistic_Mission.DTOs.ShoppinCartDTO;
using Holistic_Mission.Models;
using Microsoft.EntityFrameworkCore;

namespace Holistic_Mission.Repository.OrderRepo
{
    public class OrderRepo 
    {
        private readonly ApplicationDbContext _context;
        public OrderRepo(ApplicationDbContext context)
        {
            _context = context;
        }
        public void AddOrder(OrderResponserDTo orderDto)
        {
            Order order = new Order()
            {
                TotalPrice = orderDto.TotalPrice,
                Products = orderDto.ProductRequstDto.Select( p=>new Product
                {

                    Name = p.Name,
                    stockQuantity=p.stockQuantity,
                    Description = p.Description,
                    
                    
                }).ToList(),

                customer= new Customer
                {
                    Name=orderDto.CustomerforOrderDto.Name,
                    phone=orderDto.CustomerforOrderDto.phone,
                    //Email=orderDto.CustomerforOrderDto.Email,
                    ShoppingCart = new ShoppingCart
                    {
                        NumOfItems=orderDto.CustomerforOrderDto.ShoppingCartdto.NumOfItems,
                    }

                }

            };
        }

        public void AddOrder(OrderRequstDto orderDto)
        {

            Order order = new Order()
            {
                TotalPrice = orderDto.TotalPrice,
                Products = orderDto.ProductRequstdto.Select(p => new Product
                {
                    Name = p.Name,
                    Description = p.Description,
                    stockQuantity = p.stockQuantity,

                }).ToList()
            };
             
            _context.Add(order);

            _context.SaveChanges();
        }

        public List<OrderResponserDTo> GetOrders(OrderResponserDTo orderDto)
        {
            var order = _context.orders.Include(p => p.Products)
                                       .Include(c => c.customer)
                                       .ThenInclude(s => s.ShoppingCart)
                                       .ToList();

            return order.Select(order => new OrderResponserDTo
            {
                TotalPrice = order.TotalPrice,  
                ProductRequstDto = order.Products.Select(product => new ProductRequstDto
                {
                    Name = product.Name,
                    Description = product.Description,
                    stockQuantity = product.stockQuantity,
                }).ToList(),

                CustomerforOrderDto = order.customer != null ? new CustomerforOrderDto
                {
                    Name = order.customer.Name,
                    //Email = order.customer.Email,
                    phone = order.customer.phone,
                    ShoppingCartdto = new ShoppingCartRequstDto
                    {
                        NumOfItems = order.customer.ShoppingCart?.NumOfItems ?? 0  
                    }
                } : null  
            }).ToList();
        }




        public void UpdateOrder(OrderRequstDto orderDto, int id)
        {
            var order = _context.orders.Include(p=>p.Products).FirstOrDefault(p=>p.Id == id);
             order.TotalPrice = orderDto.TotalPrice;

            if (id == null)
            {
                throw new ArgumentException($"Order with {id} not found");
               
            }
            order.Products=orderDto.ProductRequstdto.Select(p=>new Product
            {
                Name = p.Name,
                Description = p.Description,
                stockQuantity=p.stockQuantity,

            }).ToList();
            _context.Update(order);
            _context.SaveChanges();
        }
    }
}
