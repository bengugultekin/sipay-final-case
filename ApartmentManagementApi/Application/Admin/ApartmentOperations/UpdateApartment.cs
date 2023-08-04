using ApartmentManagementApi.Models;
using AutoMapper;

namespace ApartmentManagementApi.Application.Admin;

public class UpdateApartment
{
    private readonly IBaseDbContext _dbCcontext;
    public UpdateApartmentViewModel model { get; set; }
    public int ApartmentId { get; set; }
    public int UserId { get; set; }
    public UpdateApartment(IBaseDbContext dbContext)
    {
        _dbCcontext = dbContext;
    }

    public void Handle()
    {
        var apartment = _dbCcontext.Apartments.SingleOrDefault(x => x.Id == ApartmentId);

        if (apartment == null)
        {
            throw new InvalidOperationException("Güncellenecek Daire Bulunamadı");
        }
        if(UserId != 0)
        {
            var user = _dbCcontext.Users.SingleOrDefault(x => x.Id == UserId);
            if (user == null)
            {
                throw new InvalidOperationException("Güncellenecek Daire İçin Eklediğiniz Kullanıcı Bulunamadı");
            }
        }
        
        apartment.UserId = model.UserId != default ? model.UserId : apartment.UserId;
        apartment.Block = !string.IsNullOrEmpty(model.Block) ? model.Block : apartment.Block;
        apartment.Type = !string.IsNullOrEmpty(model.Type) ? model.Type : apartment.Type;
        apartment.Floor = model.Floor != default ? model.Floor : apartment.Floor;
        apartment.Number = model.Number != default ? model.Number : apartment.Number;
        apartment.IsEmpty = model.IsEmpty;
        
        _dbCcontext.SaveChanges();
    }
}
