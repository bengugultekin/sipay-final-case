using ApartmentManagementApi.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace ApartmentManagementApi.Application;

public class GetApartments
{
    private readonly IBaseDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetApartments(IBaseDbContext dbCcontext, IMapper mapper)
    {
        _dbContext = dbCcontext;
        _mapper = mapper;
    }

    public List<GetApartmentsViewModel> Handle()
    {
        var apartments = _dbContext.Apartments
            .Include(x => x.User)
            .OrderBy(x => x.Id)
            .ToList();
        List<GetApartmentsViewModel> viewModel = _mapper.Map<List<GetApartmentsViewModel>>(apartments);

        return viewModel;
    }
}
