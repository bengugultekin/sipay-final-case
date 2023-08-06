using ApartmentManagementApi.Models;
using AutoMapper;

namespace ApartmentManagementApi.Application.Admin;

public class GetUnpaidDebts
{
    private readonly IBaseDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetUnpaidDebts(IBaseDbContext dbCcontext, IMapper mapper)
    {
        _dbContext = dbCcontext;
        _mapper = mapper;
    }

    public List<GetDebtsViewModel> Handle()
    {
        var debts = _dbContext.Debts.Where(x => x.IsPaid == false).OrderBy(x => x.Id).ToList();
        List<GetDebtsViewModel> viewModel = _mapper.Map<List<GetDebtsViewModel>>(debts);
        return viewModel;
    }
}
