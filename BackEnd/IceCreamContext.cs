using Microsoft.EntityFrameworkCore;

namespace IceCreamStore.DB
{
class IceCreamDb : DbContext
{
    public IceCreamDb(DbContextOptions options) : base(options) { }
    public DbSet<IceCream> IceCreams { get; set; } = null!;
}
}