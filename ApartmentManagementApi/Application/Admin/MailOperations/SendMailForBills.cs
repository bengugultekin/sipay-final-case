using ApartmentManagementApi.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace ApartmentManagementApi.Application.Admin;
public class SendMailForBills
{
    private readonly IBaseDbContext _dbContext;
    private readonly IMapper _mapper;
    public EmailDto Email { get; set; }

    public SendMailForBills(IBaseDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public List<GetBillsViewModel> Handle()
    {
        var bills = _dbContext.Bills
            .Include(x => x.User)
            .Where(x => x.BillLastPayDate < DateTime.Now)
            .OrderBy(x => x.Id)
            .ToList();
        List<GetBillsViewModel> viewModel = _mapper.Map<List<GetBillsViewModel>>(bills);

        return viewModel;

    }
}
