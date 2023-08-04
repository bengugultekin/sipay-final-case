using ApartmentManagementApi.Models;
using AutoMapper;

namespace ApartmentManagementApi.Application.Admin;

public class GetPaidDebts
{
    private readonly IBaseDbContext _dbCcontext;
    private readonly IMapper _mapper;

    public GetPaidDebts(IBaseDbContext dbCcontext, IMapper mapper)
    {
        _dbCcontext = dbCcontext;
        _mapper = mapper;
    }

    public List<GetDebtsViewModel> Handle()
    {
        var debts = _dbCcontext.Debts.Where(x => x.IsPaid == true).OrderBy(x => x.Id).ToList();
        List<GetDebtsViewModel> viewModel = _mapper.Map<List<GetDebtsViewModel>>(debts);
        return viewModel;
    }
}
