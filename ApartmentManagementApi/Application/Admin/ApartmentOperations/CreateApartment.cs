using ApartmentManagementApi.Models;
using AutoMapper;

namespace ApartmentManagementApi.Application;

public class CreateApartment
{
    private readonly IBaseDbContext _dbContext;
    private readonly IMapper _mapper;
    public CreateApartmentViewModel model { get; set; }

    public CreateApartment(IBaseDbContext dbContext, IMapper mapper)
    {
        _mapper = mapper;
        _dbContext = dbContext;
    }

    public void Handle()
    {
        var apartment = _dbContext.Apartments.SingleOrDefault(x => x.Block == model.Block && x.Floor == model.Floor && x.Number == model.Number);
        if (apartment != null)
        {
            throw new InvalidOperationException("Bu Daire Bilgileri Zaten Mevcut");
        }

        apartment = _mapper.Map<Apartment>(model);

        _dbContext.Apartments.Add(apartment);
        _dbContext.SaveChanges();
    }
}
