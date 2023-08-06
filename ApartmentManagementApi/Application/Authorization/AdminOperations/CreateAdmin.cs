using ApartmentManagementApi.Models;
using AutoMapper;

namespace ApartmentManagementApi.Application.Authorization;

public class CreateAdmin
{
    private readonly IBaseDbContext _dbContext;
    private readonly IMapper _mapper;
    public CreateAdminViewModel model { get; set; }

    public CreateAdmin(IBaseDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public void Handle()
    {
        var user = _dbContext.Users.SingleOrDefault(x => x.Id == model.UserId);
        if (user == null)
        {
            throw new InvalidOperationException("Yönetici İzni Vermeye Çalıştığınız Kullanıcı Sistemde Bulunamadı");
        }
        var admin = _dbContext.Admins.SingleOrDefault(x => x.Email == model.Email);
        if (admin != null) 
        {
            throw new InvalidOperationException("Yönetici Zaten Mevcut");
        }
        if(model.Email != user.Email)
        {
            throw new InvalidOperationException("Yöneticiye Ait Eposta Adresi, Sistemdeki Kullanıcıya Ait Eposta Adresi İle Eşleşmiyor");
        }
        admin = _mapper.Map<ApartmentManagementApi.Admin>(model);

        _dbContext.Admins.Add(admin);
        _dbContext.SaveChanges();
    }
}
