using ApartmentManagementApi.Models.User;
using AutoMapper;

namespace ApartmentManagementApi;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateUserViewModel, User>();
    }
}
