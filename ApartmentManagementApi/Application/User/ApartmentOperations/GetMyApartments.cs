using ApartmentManagementApi.Models;
using AutoMapper;

namespace ApartmentManagementApi.Application.User;

public class GetMyApartments
{
    private readonly IBaseDbContext _dbContext;
    private readonly IMapper _mapper;
    public int UserId { get; set; }

    public GetMyApartments(IBaseDbContext dbCcontext, IMapper mapper)
    {
        _dbContext = dbCcontext;
        _mapper = mapper;
    }

    public List<GetMyApartmentsViewModel> Handle()
    {
        var apartment = _dbContext.Apartments
            .OrderBy(x => x.Id)
            .Where(x => x.UserId == UserId)
            .ToList();
        List<GetMyApartmentsViewModel> viewModel = _mapper.Map<List<GetMyApartmentsViewModel>>(apartment);

        return viewModel;
    }
}
