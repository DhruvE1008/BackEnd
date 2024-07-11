using Microsoft.EntityFrameworkCore;
using IceCreamStore.Models;

namespace IceCreamStore.Data
{
public class IceCreamContext : DbContext
{
    public IceCreamContext(DbContextOptions<IceCreamContext> options) : base(options) { }
    public DbSet<Flavour> Flavours { get; set; }
    public DbSet<Order> Orders { get; set; }
}
}