using Microsoft.EntityFrameworkCore;

namespace ApartmentManagementApi;

public interface IBaseDbContext
{
    DbSet<User> Users { get; set; }
    DbSet<Bill> Bills { get; set; }

    int SaveChanges();
}
