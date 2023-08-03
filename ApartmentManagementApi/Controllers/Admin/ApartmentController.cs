using ApartmentManagementApi.Application;
using ApartmentManagementApi.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ApartmentManagementApi;

[ApiController]
[Route("admin/[controller]s")]
public class ApartmentController : ControllerBase
{
    private readonly IBaseDbContext _dbContext;
    private readonly IMapper _mapper;

    public ApartmentController(IBaseDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    // Create Bill
    [HttpPost]
    public IActionResult AddApartment(CreateApartmentViewModel model)
    {
        CreateApartment apartment = new CreateApartment(_dbContext, _mapper);
        apartment.model = model;
        apartment.Handle();
        return Ok();
    }

    // Get All Bills From Query
    [HttpGet]
    public ActionResult GetApartments()
    {
        GetApartments apartments = new GetApartments(_dbContext, _mapper);
        var apartmentList = apartments.Handle();
        return Ok(apartmentList);
    }
}
