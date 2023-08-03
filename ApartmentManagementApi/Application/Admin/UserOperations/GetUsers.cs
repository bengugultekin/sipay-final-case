using ApartmentManagementApi.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace ApartmentManagementApi.Application;

public class GetUsers
{
    private readonly IBaseDbContext _dbCcontext;
    private readonly IMapper _mapper;

    public GetUsers(IBaseDbContext dbCcontext, IMapper mapper)
    {
        _dbCcontext = dbCcontext;
        _mapper = mapper;
    }

    public List<GetUsersViewModel> Handle()
    {
        var users = _dbCcontext.Users.Include(x => x.Bills).Include(x => x.Cards).OrderBy(x => x.Id).ToList();
        List<GetUsersViewModel> viewModel = _mapper.Map<List<GetUsersViewModel>>(users);
        return viewModel;
    }
}
