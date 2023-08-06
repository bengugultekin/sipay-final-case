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
           })))
           .ForMember(dest => dest.Cards, opt=>opt.MapFrom(src=> src.Cards.Select(b => new CardViewModel { Number = b.Number})));

        // Bills Mapping
        CreateMap<CreateBillViewModel, Bill>();
        CreateMap<Bill, GetBillsViewModel>()
            .ForMember(dest => dest.Customer, opt => opt.MapFrom(src => src.User.NameSurname));
        CreateMap<Bill, GetPaidBillsViewModel>()
            .ForMember(dest => dest.Customer, opt => opt.MapFrom(src => src.User.NameSurname));
        CreateMap<CreateMonthlyBillsViewModel, Bill>();
        CreateMap<Bill, GetBillDetailViewModel>()
            .ForMember(dest => dest.Customer, opt => opt.MapFrom(src => src.User.NameSurname));

        // GetMyBills Operations
        CreateMap<Bill, GetMyBillsViewModel>();

        // Apartments Mapping
        CreateMap<Apartment, GetApartmentsViewModel>()
            .ForMember(dest => dest.HomeOwner, opt => opt.MapFrom(src => src.User.NameSurname));
        CreateMap<CreateApartmentViewModel, Apartment>();
        CreateMap<Apartment, GetApartmentDetailViewModel>()
            .ForMember(dest => dest.HomeOwner, opt => opt.MapFrom(src => src.User.NameSurname));

        // Get My Apartments
        CreateMap<Apartment, GetMyApartmentsViewModel>();

        // Cards Mapping
        CreateMap<CreateCardViewModel, Card>();
        CreateMap<Card, GetCardsViewModel>();

        // Messages Mapping
        CreateMap<SentMessageViewModel, Message>();
        CreateMap<Message, GetMessagesViewModel>()
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.NameSurname))
            .ForMember(dest => dest.IsReaded, opt => opt.MapFrom(src => src.IsReaded));
        CreateMap<Message, GetMessageDetailViewModel>()
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.NameSurname));

        // Depts Mapping
        CreateMap<CreateDebtViewModel, Debt>();
        CreateMap<Debt, GetDebtsViewModel>();
        CreateMap<Debt, GetDebtDetailViewModel>();

        // Admin Mapping
        CreateMap<CreateAdminViewModel, Admin>();
    }
}
