using ApartmentManagementApi.Models;
using AutoMapper;

namespace ApartmentManagementApi.Application;

public class CreateCard
{
    private readonly IBaseDbContext _dbContext;
    private readonly IMapper _mapper;

    public CreateCardViewModel model { get; set; }

    public CreateCard(IBaseDbContext dbCcontext, IMapper mapper)
    {
        _dbContext = dbCcontext;
        _mapper = mapper;
    }

    public void Handle()
    {
        var card = _dbContext.Cards.SingleOrDefault(x => x.Number == model.Number);
        if (card != null) 
        {
            throw new InvalidOperationException("Kaydetmeye Çalıştığınız Kart Zaten Kayıtlı");
        }

        card = _mapper.Map<Card>(model);
        
        _dbContext.Cards.Add(card);
        _dbContext.SaveChanges();
    }
}
