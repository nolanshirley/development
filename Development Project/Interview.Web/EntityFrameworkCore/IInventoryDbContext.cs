using Interview.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace Interview.Web.EntityFrameworkCore
{
    public interface IInventoryDbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
