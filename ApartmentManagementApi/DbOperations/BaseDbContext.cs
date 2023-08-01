using Microsoft.EntityFrameworkCore;

namespace ApartmentManagementApi;

public class BaseDbContext : DbContext, IBaseDbContext
{
    public BaseDbContext(DbContextOptions<BaseDbContext> options) : base(options)
    {

    }

    public DbSet<User> Users { get; set; }

    public override int SaveChanges()
    {
        return base.SaveChanges();
    }
}
