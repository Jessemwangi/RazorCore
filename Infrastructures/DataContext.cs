using Microsoft.EntityFrameworkCore;
using RazorCore.Models;

namespace RazorCore.Infrastructures
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Product> products { get; set; }
        public DbSet<Category> categories { get; set; }
    }
}
