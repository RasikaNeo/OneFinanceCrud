
using Microsoft.EntityFrameworkCore;
using OneFinanceCrud.Model;
using OneFinanceCrud.Models;

namespace OneFinanceCrud.Context
{
    public class ProductDbContext:DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> context) : base(context)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        public DbSet<User> Users { get; set; }
    }

}

