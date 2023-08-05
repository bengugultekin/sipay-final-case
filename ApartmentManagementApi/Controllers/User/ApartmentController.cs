using ApartmentManagementApi.Application.User;
using ApartmentManagementApi.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ApartmentManagementApi.Controllers;

[ApiController]
[Route("[controller]s")]
public class ApartmentController : ControllerBase
{
    private readonly IBaseDbContext _dbContext;
    private readonly IMapper _mapper;
    public ApartmentController(IBaseDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }
    // Get All My Bills From Query
    [HttpGet("{id}")]
    public ActionResult GetMyAllApartments(int id)
    {
        GetMyApartmentsViewModel result;
        GetMyApartments apartments = new GetMyApartments(_dbContext, _mapper);
        apartments.UserId = id;
        var apartmentList = apartments.Handle();
        return Ok(apartmentList);
    }
}
