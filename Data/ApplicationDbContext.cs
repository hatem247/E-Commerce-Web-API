using Holistic_Mission.Models;
using Microsoft.EntityFrameworkCore;

namespace Holistic_Mission.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product>products { get; set; }
        public DbSet<Customer> customers { get; set; }
        public DbSet<Order> orders { get; set; }
        public DbSet<ShoppingCart> shoppingCarts { get; set; }

    }
}
