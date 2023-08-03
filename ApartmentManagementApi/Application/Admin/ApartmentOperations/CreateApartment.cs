using ApartmentManagementApi.Models;
using AutoMapper;

namespace ApartmentManagementApi.Application;

public class CreateApartment
{
    private readonly IBaseDbContext _dbCcontext;
    private readonly IMapper _mapper;
    public CreateApartmentViewModel model { get; set; }

    public CreateApartment(IBaseDbContext dbContext, IMapper mapper)
    {
        _mapper = mapper;
        _dbCcontext = dbContext;
    }

    public void Handle()
    {
        var apartment = _dbCcontext.Apartments.SingleOrDefault(x => x.Block == model.Block && x.Floor == model.Floor && x.Number == model.Number);
        if (apartment != null)
        {
            throw new InvalidOperationException("Bu Daire Bilgileri Zaten Mevcut");
        }

        apartment = _mapper.Map<Apartment>(model);

        _dbCcontext.Apartments.Add(apartment);
        _dbCcontext.SaveChanges();
    }
}
