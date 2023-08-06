using ApartmentManagementApi.Models;
using AutoMapper;

namespace ApartmentManagementApi.Application;

public class CreateBill
{
    private readonly IBaseDbContext _dbContext;
    private readonly IMapper _mapper;
    public CreateBillViewModel model { get; set; }

    public CreateBill(IBaseDbContext dbContext, IMapper mapper)
    {
        _mapper = mapper;
        _dbContext = dbContext;
    }

    public void Handle()
    {
        var bill = _dbContext.Bills.SingleOrDefault(x => x.BillCreatedDate == model.BillCreatedDate && x.BillLastPayDate == model.BillLastPayDate && x.UserId == model.UserId);
        if (bill != null)
        {
            throw new InvalidOperationException("Bu Kullanıcıya Ait Fatura Zaten Mevcut");
        }

        bill = _mapper.Map<Bill>(model);

        _dbContext.Bills.Add(bill);
        _dbContext.SaveChanges();
    }
}
