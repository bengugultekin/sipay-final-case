using ApartmentManagementApi.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace ApartmentManagementApi.Application.Admin;

public class GetUnpaidBills
{
    private readonly IBaseDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetUnpaidBills(IBaseDbContext dbCcontext, IMapper mapper)
    {
        _dbContext = dbCcontext;
        _mapper = mapper;
    }

    public List<GetBillsViewModel> Handle()
    {
        var bills = _dbContext.Bills
            .Include(x => x.User)
            .Where(x => x.IsPaid == false)
            .OrderBy(x => x.Id)
            .ToList();
        List<GetBillsViewModel> viewModel = _mapper.Map<List<GetBillsViewModel>>(bills);

        return viewModel;
    }
}
