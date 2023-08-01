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
        CreateMap<User, GetUsersViewModel>()
           .ForMember(dest => dest.Bills, opt => opt.MapFrom(src => src.Bills.Select(b => new BillViewModel
           {
               Cost = b.Cost,
               BillCreatedDate = b.BillCreatedDate,
               BillLastPayDate = b.BillLastPayDate,
               BillPaidDate = b.BillPaidDate,
               IsPaid = b.IsPaid
           })));

        // Bills Mapping
        CreateMap<CreateBillViewModel, Bill>();
        CreateMap<Bill, GetBillsViewModel>()
            .ForMember(dest => dest.Customer, opt => opt.MapFrom(src => src.User.NameSurname));

    }
}
