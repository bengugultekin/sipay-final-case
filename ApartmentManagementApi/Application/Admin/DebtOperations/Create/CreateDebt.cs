using ApartmentManagementApi.Models;
using AutoMapper;

namespace ApartmentManagementApi.Application.Admin;

public class CreateDebt
{
    private readonly IBaseDbContext _dbContext;
    private readonly IMapper _mapper;

    public CreateDebtViewModel model;

    public CreateDebt(IBaseDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public void Handle()
    {
        var debt = _dbContext.Debts.SingleOrDefault(x => x.Title == model.Title && x.DebtLastPayDate == model.DebtLastPayDate && x.Cost == model.Cost && x.IsPaid == model.IsPaid);
        if (debt != null) 
        {
            throw new InvalidOperationException("Eklemeye Çalıştığınız Gider Daha Önce Zaten Eklenmiş");
        }

        debt = _mapper.Map<Debt>(model);
        _dbContext.Debts.Add(debt);
        _dbContext.SaveChanges();
    }
}
