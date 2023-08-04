namespace ApartmentManagementApi.Application.Admin;

public class DeleteApartment
{
    private readonly IBaseDbContext _dbCcontext;
    public int ApartmentId { get; set; }
    public DeleteApartment(IBaseDbContext dbContext)
    {
        _dbCcontext = dbContext;
    }

    public void Handle()
    {
        var apartment = _dbCcontext.Apartments.SingleOrDefault(x => x.Id == ApartmentId);
        if (apartment == null)
        {
            throw new InvalidOperationException("Silinecek Daire Bulunamadı");
        }
        
        _dbCcontext.Apartments.Remove(apartment);
        _dbCcontext.SaveChanges();
    }
}
