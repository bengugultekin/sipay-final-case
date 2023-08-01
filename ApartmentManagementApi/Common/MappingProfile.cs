using ApartmentManagementApi.Models;
using ApartmentManagementApi.Models.User;
using AutoMapper;

namespace ApartmentManagementApi;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Users Mapping
        CreateMap<CreateUserViewModel, User>();
        CreateMap<User, GetUsersViewModel>();
    }
}
