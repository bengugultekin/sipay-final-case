using ApartmentManagementApi.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace ApartmentManagementApi.Application;

public class GetBills
{
    private readonly IBaseDbContext _dbCcontext;
    private readonly IMapper _mapper;

    public GetBills(IBaseDbContext dbCcontext, IMapper mapper)
    {
        _dbCcontext = dbCcontext;
        _mapper = mapper;
    }

    public List<GetBillsViewModel> Handle()
    {
        var bills = _dbCcontext.Bills
            .Include(x => x.User)
            .OrderBy(x => x.Id)
            .ToList();
        List<GetBillsViewModel> viewModel = _mapper.Map<List<GetBillsViewModel>>(bills);

        return viewModel;
    }
}
