using ApartmentManagementApi.Models.User;
using AutoMapper;

namespace ApartmentManagementApi.Application.Admin;

public class DeleteUser
{
    private readonly IBaseDbContext _dbCcontext;
    public int UserId { get; set; }
    public DeleteUser(IBaseDbContext dbCcontext)
    {
        _dbCcontext = dbCcontext;
    }

    public void Handle()
    {
        var user = _dbCcontext.Users.SingleOrDefault(x => x.Id == UserId);

        if (user == null)
            throw new InvalidOperationException("Silinecek Kullanıcı Bulunamadı");


        _dbCcontext.Users.Remove(user);
        _dbCcontext.SaveChanges();
    }
}
