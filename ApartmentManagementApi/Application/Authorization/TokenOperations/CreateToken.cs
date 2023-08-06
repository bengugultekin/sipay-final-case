using ApartmentManagementApi.Models;
using ApartmentManagementApi.TokenOperations;
using AutoMapper;

namespace ApartmentManagementApi.Application.Authorization;

public class CreateToken
{
    private readonly IBaseDbContext _dbContext;
    private readonly IMapper _mapper;
    private readonly IConfiguration _configuration;
    public CreateTokenViewModel model { get; set; }

    public CreateToken(IBaseDbContext dbContext, IMapper mapper, IConfiguration configuration)
    {
        _dbContext = dbContext;
        _mapper = mapper;
        _configuration = configuration;
    }

    public Token Handle()
    {
        var admin = _dbContext.Admins.FirstOrDefault(x => x.Email == model.Email && x.Password == model.Password);
        if(admin != null) 
        {
            // Create Token
            TokenHandler handler = new TokenHandler(_configuration);
            Token token = handler.CreateAccessToken(admin);

            admin.RefreshToken = token.RefreshToken;
            admin.RefreshTokenExpireDate = token.Expiration.AddMinutes(5);

            _dbContext.SaveChanges();

            return token;
        }
        else 
        {
            throw new InvalidOperationException("Kullanıcı Adı - Şifre Hatalı");
        }
    }
}
