using Interview.Web.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace Interview.Web.EntityFrameworkCore
{
    public class InventoryDbContext : DbContext, IInventoryDbContext
    {
        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }


        public InventoryDbContext(DbContextOptions<InventoryDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.InstanceId);
                entity.ToTable("Categories", "Instances");
                entity.Property(e => e.InstanceId).IsRequired();
                entity.Property(e => e.Name).IsRequired().HasMaxLength(64);
                entity.Property(e => e.Description).IsRequired().HasMaxLength(256);

            });

            // add other entities for other classes built out 
            
        }
    }
}
