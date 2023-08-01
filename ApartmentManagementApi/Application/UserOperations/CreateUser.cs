using ApartmentManagementApi.Models.User;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace ApartmentManagementApi.Application;

public class CreateUser
{
    private readonly IBaseDbContext _dbCcontext;
    private readonly IMapper _mapper;
    public CreateUserViewModel model { get; set; }

    public CreateUser(IBaseDbContext dbCcontext, IMapper mapper)
    {
        _dbCcontext = dbCcontext;
        _mapper = mapper;
    }

    public void Handle()
    {
        var user = _dbCcontext.Users
            .SingleOrDefault(x => x.Email == model.Email);
        
        if (user != null)
            throw new InvalidOperationException("Kullanıcı Zaten Mevcut");

        user = _mapper.Map<User>(model);

        _dbCcontext.Users.Add(user);
        _dbCcontext.SaveChanges();
    }


}
