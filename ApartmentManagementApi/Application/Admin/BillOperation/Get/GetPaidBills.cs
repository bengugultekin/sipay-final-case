using ApartmentManagementApi.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace ApartmentManagementApi.Application;

public class GetPaidBills
{
    private readonly IBaseDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetPaidBills(IBaseDbContext dbCcontext, IMapper mapper)
    {
        _dbContext = dbCcontext;
        _mapper = mapper;
    }

    public List<GetPaidBillsViewModel> Handle()
    {
        var bills = _dbContext.Bills
            .Include(x => x.User)
            .Where(x => x.IsPaid == true)
            .OrderBy(x => x.Id)
            .ToList();
        List<GetPaidBillsViewModel> viewModel = _mapper.Map<List<GetPaidBillsViewModel>>(bills);

        return viewModel;
    }
}
