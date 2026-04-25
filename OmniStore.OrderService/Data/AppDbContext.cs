using Microsoft.EntityFrameworkCore;
using OmniStore.OrderService.Models;
namespace OmniStore.OrderService.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Order> Orders { get; set; }
    }
}
