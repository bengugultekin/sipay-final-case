using ApartmentManagementApi.Models;
using AutoMapper;

namespace ApartmentManagementApi.Application.Admin;

public class CreateMonthlyBills
{
    private readonly IBaseDbContext _dbCcontext;
    private readonly IMapper _mapper;
    public CreateMonthlyBillsViewModel model { get; set; }

    public CreateMonthlyBills(IBaseDbContext dbContext, IMapper mapper)
    {
        _mapper = mapper;
        _dbCcontext = dbContext;
    }

    public void Handle()
    {
        foreach (var userId in model.UsersId)
        {
            var user = _dbCcontext.Users.FirstOrDefault(x => x.Id == userId);
            if (user == null)
            {
                throw new InvalidOperationException($"Kullanıcı ID'si {userId} olan kullanıcı bulunamadı.");
            }

            var bill = new Bill
            {
                UserId = userId,
                Cost = model.Cost,
                BillCreatedDate = model.BillCreatedDate,
                BillLastPayDate = model.BillLastPayDate,
                IsPaid = false
            };

        _dbCcontext.Bills.Add(bill);
        }

        _dbCcontext.SaveChanges();
    }
}
