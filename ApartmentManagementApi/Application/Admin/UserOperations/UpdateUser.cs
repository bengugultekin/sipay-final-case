using ApartmentManagementApi.Migrations;
using ApartmentManagementApi.Models;
using AutoMapper;

namespace ApartmentManagementApi.Application.Admin;

public class UpdateUser
{
    private readonly IBaseDbContext _dbCcontext;
    public UpdateUserViewModel model { get; set; }
    public int UserId { get; set; }
    public UpdateUser(IBaseDbContext dbCcontext)
    {
        _dbCcontext = dbCcontext;
    }

    public void Handle()
    {
        var user = _dbCcontext.Users.SingleOrDefault(x => x.Id == UserId);

        if (user == null)
        {
            throw new InvalidOperationException("Güncellenecek Kullanıcı Bulunamadı");
        }

        user.NameSurname = model.NameSurname != default ? model.NameSurname : user.NameSurname;
        user.Email = model.Email != default ? model.Email : user.Email;
        user.PhoneNumber = model.PhoneNumber != default ? model.PhoneNumber : user.PhoneNumber;
        user.PlateCode = model.PlateCode != default ? model.PlateCode : user.PlateCode;

        _dbCcontext.SaveChanges();
    }
}
