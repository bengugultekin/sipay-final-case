using ApartmentManagementApi.Models;
using AutoMapper;

namespace ApartmentManagementApi.Application.Admin;

public class GetDebts
{
    private readonly IBaseDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetDebts(IBaseDbContext dbCcontext, IMapper mapper)
    {
        _dbContext = dbCcontext;
        _mapper = mapper;
    }

    public List<GetDebtsViewModel> Handle()
    {
        var debts = _dbContext.Debts.OrderBy(x => x.Id).ToList();
        List<GetDebtsViewModel> viewModel = _mapper.Map<List<GetDebtsViewModel>>(debts);
        return viewModel;
    }
}
