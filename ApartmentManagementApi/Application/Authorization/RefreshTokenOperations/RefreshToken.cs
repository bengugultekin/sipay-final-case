using ApartmentManagementApi.Models;
using ApartmentManagementApi.TokenOperations;
using AutoMapper;

namespace ApartmentManagementApi.Application.Authorization;

public class RefreshToken
{
    private readonly IBaseDbContext _dbContext;
    private readonly IConfiguration _configuration;
    public string refreshToken { get; set; }

    public RefreshToken(IBaseDbContext dbContext, IConfiguration configuration)
    {
        _dbContext = dbContext;
        _configuration = configuration;
    }

    public Token Handle()
    {
        var admin = _dbContext.Admins.FirstOrDefault(x => x.RefreshToken == refreshToken && x.RefreshTokenExpireDate > DateTime.Now);
        if (admin != null)
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
            throw new InvalidOperationException("Geçerli Bir Refresh Token Bulunamadı");
        }
    }
}
