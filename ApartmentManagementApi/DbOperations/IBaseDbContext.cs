using Microsoft.EntityFrameworkCore;

namespace ApartmentManagementApi;

public interface IBaseDbContext
{
    DbSet<User> Users { get; set; }

    int SaveChanges();
}
