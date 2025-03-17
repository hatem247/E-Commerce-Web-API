using Holistic_Mission.Data;
using Holistic_Mission.DTOs.CustomerDto;
using Holistic_Mission.DTOs.OrderDto;
using Holistic_Mission.DTOs.ProductDto;
using Holistic_Mission.DTOs.ShoppinCartDTO;
using Holistic_Mission.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Holistic_Mission.Repository.CustomerRepo
{
    public class CustomerRepo : ICustomerRepo
    {
        private readonly ApplicationDbContext _context;
        public CustomerRepo(ApplicationDbContext context) { 
            _context = context;
        }
        public void AddedCustomer(CustomerRequstDto customerRequstDto)
        {

            Customer Addcustomer = new Customer
            {
                Email = customerRequstDto.Email,
                Name = customerRequstDto.Name,
                phone=customerRequstDto.phone,
                ShoppingCart = new ShoppingCart
                {
                    NumOfItems = 0,
                }
            };
            _context.Add(Addcustomer);
            _context.SaveChanges();


            
        }

        public List<CustomerResponseDto> customerResponseDtos(CustomerResponseDto customerResponseDto)
        {
            var customerResponse = _context.customers
                                            .Include(s => s.ShoppingCart)
                                            .Include(o => o.Orders)
                                                .ThenInclude(p => p.Products)
                                            .ToList();

            return customerResponse.Select(customer => new CustomerResponseDto
            {
                Id=customer.Id,
                Name = customer.Name,
                Email = customer.Email,
                phone = customer.phone,
                Orders = customer.Orders.Select(o => new OrderRequstDto
                {
                    TotalPrice = o.TotalPrice,
                    ProductRequstdto = o.Products.Select(p => new ProductRequstDto
                    {
                        Description = p.Description,
                        Name = p.Name,
                        stockQuantity = p.stockQuantity,
                    }).ToList()
                }).ToList(),

                ShoppingCartdto = new ShoppingCartRequstDto
                    {
                        NumOfItems = customer.ShoppingCart.NumOfItems
                    }, 
            }).ToList();
        }


        public CustomerResponseDto getCustomerById(CustomerResponseDto id)
        {
            var customerData = _context.customers.Include(s => s.ShoppingCart)   
                                        .Include(o => o.Orders)
                                            .ThenInclude(p => p.Products)
                                        .FirstOrDefault(d => d.Id == id.Id);

            if (customerData == null)
            {
                return null; 
            }

            return new CustomerResponseDto
            {
                Id=customerData.Id,
                Name = customerData.Name,
                Email = customerData.Email,
                phone = customerData.phone,
                Orders = customerData.Orders.Select(o => new OrderRequstDto
                {
                    TotalPrice = o.TotalPrice,
                    ProductRequstdto = o.Products.Select(p => new ProductRequstDto
                    {
                        Description = p.Description,
                        Name = p.Name,
                        stockQuantity = p.stockQuantity
                    }).ToList()
                }).ToList(),

            
                ShoppingCartdto = customerData.ShoppingCart != null
                    ? new ShoppingCartRequstDto
                    {
                        NumOfItems = customerData.ShoppingCart.NumOfItems
                    }
                    : new ShoppingCartRequstDto
                    {
                        NumOfItems = 0 
                    }
            };
        }

    }
}

