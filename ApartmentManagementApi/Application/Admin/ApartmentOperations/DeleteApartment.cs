namespace ApartmentManagementApi.Application.Admin;

public class DeleteApartment
{
    private readonly IBaseDbContext _dbContext;
    public int ApartmentId { get; set; }
    public DeleteApartment(IBaseDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Handle()
    {
        var apartment = _dbContext.Apartments.SingleOrDefault(x => x.Id == ApartmentId);
        if (apartment == null)
        {
            throw new InvalidOperationException("Silinecek Daire Bulunamadı");
        }
        
        _dbContext.Apartments.Remove(apartment);
        _dbContext.SaveChanges();
    }
}
