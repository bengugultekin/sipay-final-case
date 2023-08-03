using Microsoft.EntityFrameworkCore;

namespace ApartmentManagementApi;

public interface IBaseDbContext
{
    DbSet<User> Users { get; set; }
    DbSet<Bill> Bills { get; set; }
    DbSet<Apartment> Apartments { get; set; }
    DbSet<Card> Cards { get; set; }
    DbSet<Message> Messages { get; set; }


    int SaveChanges();
}
