using ApartmentManagementApi.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace ApartmentManagementApi.Application;

public class GetBills
{
    private readonly IBaseDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetBills(IBaseDbContext dbCcontext, IMapper mapper)
    {
        _dbContext = dbCcontext;
        _mapper = mapper;
    }

    public List<GetBillsViewModel> Handle()
    {
        var bills = _dbContext.Bills
            .Include(x => x.User)
            .OrderBy(x => x.Id)
            .ToList();
        List<GetBillsViewModel> viewModel = _mapper.Map<List<GetBillsViewModel>>(bills);

        return viewModel;
    }
}
