using ApartmentManagementApi.Models;
using AutoMapper;

namespace ApartmentManagementApi.Application.Admin;

public class CreateMonthlyBills
{
    private readonly IBaseDbContext _dbContext;
    private readonly IMapper _mapper;
    public CreateMonthlyBillsViewModel model { get; set; }

    public CreateMonthlyBills(IBaseDbContext dbContext, IMapper mapper)
    {
        _mapper = mapper;
        _dbContext = dbContext;
    }

    public void Handle()
    {
        foreach (var userId in model.UsersId)
        {
            var user = _dbContext.Users.FirstOrDefault(x => x.Id == userId);
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

        _dbContext.Bills.Add(bill);
        }

        _dbContext.SaveChanges();
    }
}
