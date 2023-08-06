using ApartmentManagementApi.Models.User;
using AutoMapper;

namespace ApartmentManagementApi.Application;

public class CreateUser
{
    private readonly IBaseDbContext _dbContext;
    private readonly IMapper _mapper;
    public CreateUserViewModel model { get; set; }

    public CreateUser(IBaseDbContext dbCcontext, IMapper mapper)
    {
        _dbContext = dbCcontext;
        _mapper = mapper;
    }

    public void Handle()
    {
        var user = _dbContext.Users
            .SingleOrDefault(x => x.Email == model.Email);
        
        if (user != null)
            throw new InvalidOperationException("Kullanıcı Zaten Mevcut");

        user = _mapper.Map<ApartmentManagementApi.User>(model);

        _dbContext.Users.Add(user);
        _dbContext.SaveChanges();
    }


}
