using Microsoft.EntityFrameworkCore;
using Pronia.Models;

namespace Pronia.DAL
{
    public class AppDbContext:DbContext
    {
      public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Slide> Slides { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<ProductImage> ProductImage { get; set; }
        public object Products { get; internal set; }
    }
}
