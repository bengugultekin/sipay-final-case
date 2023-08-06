using ApartmentManagementApi.Migrations;
using ApartmentManagementApi.Models;
using AutoMapper;

namespace ApartmentManagementApi.Application.Admin;

public class UpdateUser
{
    private readonly IBaseDbContext _dbContext;
    public UpdateUserViewModel model { get; set; }
    public int UserId { get; set; }
    public UpdateUser(IBaseDbContext dbCcontext)
    {
        _dbContext = dbCcontext;
    }

    public void Handle()
    {
        var user = _dbContext.Users.SingleOrDefault(x => x.Id == UserId);

        if (user == null)
        {
            throw new InvalidOperationException("Güncellenecek Kullanıcı Bulunamadı");
        }


        user.NameSurname = !string.IsNullOrEmpty(model.NameSurname) ? model.NameSurname : user.NameSurname;
        user.Email = !string.IsNullOrEmpty(model.Email) ? model.Email : user.Email;
        user.PhoneNumber = !string.IsNullOrEmpty(model.PhoneNumber) ? model.PhoneNumber : user.PhoneNumber;
        user.PlateCode = !string.IsNullOrEmpty(model.PlateCode) ? model.PlateCode : user.PlateCode;

        _dbContext.SaveChanges();
    }
}
