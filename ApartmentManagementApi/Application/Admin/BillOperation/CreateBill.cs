using ApartmentManagementApi.Models;
using AutoMapper;

namespace ApartmentManagementApi.Application;

public class CreateBill
{
    private readonly IBaseDbContext _dbCcontext;
    private readonly IMapper _mapper;
    public CreateBillViewModel model { get; set; }

    public CreateBill(IBaseDbContext dbContext, IMapper mapper)
    {
        _mapper = mapper;
        _dbCcontext = dbContext;
    }

    public void Handle()
    {
        var bill = _dbCcontext.Bills.SingleOrDefault(x => x.BillCreatedDate == model.BillCreatedDate && x.BillLastPayDate == model.BillLastPayDate && x.UserId == model.UserId);
        if (bill != null)
        {
            throw new InvalidOperationException("Bu Kullanıcıya Ait Fatura Zaten Mevcut");
        }

        bill = _mapper.Map<Bill>(model);

        _dbCcontext.Bills.Add(bill);
        _dbCcontext.SaveChanges();
    }
}
