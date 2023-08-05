using ApartmentManagementApi.Migrations;
using ApartmentManagementApi.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace ApartmentManagementApi.Application.Admin;

public class GetApartmentDetail
{
    private readonly IBaseDbContext _dbContext;
    private readonly IMapper _mapper;

    public int ApartmentId { get; set; }
    public GetApartmentDetail(IBaseDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public GetApartmentDetailViewModel Handle()
    {
        var apartment = _dbContext.Apartments
            .Include(x => x.User)
            .SingleOrDefault(x => x.Id == ApartmentId);
        if (apartment == null)
        {
            throw new InvalidOperationException("Daire Kaydı Bulunamadı");
        }

        GetApartmentDetailViewModel viewModel = _mapper.Map<GetApartmentDetailViewModel>(apartment);

        return viewModel;
    }
}
