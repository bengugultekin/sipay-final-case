using ApartmentManagementApi.Models.User;
using AutoMapper;

namespace ApartmentManagementApi.Application.Admin;

public class DeleteUser
{
    private readonly IBaseDbContext _dbContext;
    public int UserId { get; set; }
    public DeleteUser(IBaseDbContext dbCcontext)
    {
        _dbContext = dbCcontext;
    }

    public void Handle()
    {
        var user = _dbContext.Users.SingleOrDefault(x => x.Id == UserId);

        if (user == null)
            throw new InvalidOperationException("Silinecek Kullanıcı Bulunamadı");


        _dbContext.Users.Remove(user);
        _dbContext.SaveChanges();
    }
}
