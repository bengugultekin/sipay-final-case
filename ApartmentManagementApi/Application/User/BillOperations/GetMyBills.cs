using ApartmentManagementApi.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace ApartmentManagementApi.Application.User;

public class GetMyBills
{
    private readonly IBaseDbContext _dbCcontext;
    private readonly IMapper _mapper;
    public int UserId { get; set; }

    public GetMyBills(IBaseDbContext dbCcontext, IMapper mapper)
    {
        _dbCcontext = dbCcontext;
        _mapper = mapper;
    }

    public List<GetMyBillsViewModel> Handle()
    {
        var bills = _dbCcontext.Bills
            .OrderBy(x => x.Id)
            .Where(x => x.UserId == UserId)
            .ToList();
        List<GetMyBillsViewModel> viewModel = _mapper.Map<List<GetMyBillsViewModel>>(bills);

        return viewModel;
    }
}
