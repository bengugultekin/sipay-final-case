using ApartmentManagementApi.Application;
using ApartmentManagementApi.Application.Admin;
using ApartmentManagementApi.Application.Admin.ApartmentOperations;
using ApartmentManagementApi.Models;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApartmentManagementApi;

[Authorize]
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

    // Create Apartment
    [HttpPost]
    public IActionResult AddApartment(CreateApartmentViewModel model)
    {
        CreateApartment apartment = new CreateApartment(_dbContext, _mapper);
        apartment.model = model;

        CreateApartmentValidator validator = new CreateApartmentValidator();
        validator.ValidateAndThrow(apartment);

        apartment.Handle();
        return Ok();
    }

    // Get All Apartment From Query
    [HttpGet]
    public ActionResult GetApartments()
    {
        GetApartments apartments = new GetApartments(_dbContext, _mapper);
        var apartmentList = apartments.Handle();
        return Ok(apartmentList);
    }

    // Get An Apartment by Id From Query
    [HttpGet("{id}")]
    public ActionResult GetApartmentById(int id)
    {
        GetApartmentDetail apartment = new GetApartmentDetail(_dbContext, _mapper);
        apartment.ApartmentId = id;

        GetApartmentDetailValidator validator = new GetApartmentDetailValidator();
        validator.ValidateAndThrow(apartment);

        var result = apartment.Handle();
        return Ok(result);
    }

    // Update Apartment
    [HttpPut("{id}")]
    public ActionResult UpdtApartment(int id, [FromBody] UpdateApartmentViewModel updateApartment)
    {
        UpdateApartment apartment = new UpdateApartment(_dbContext);
        apartment.ApartmentId = id;
        apartment.model = updateApartment;

        UpdateApartmentValidator validator = new UpdateApartmentValidator();
        validator.ValidateAndThrow(apartment);

        apartment.Handle();
        return Ok();
    }

    // Delete Apartment
    [HttpDelete("{id}")]
    public ActionResult DeleteApartmentById(int id) 
    {
        DeleteApartment apartment = new DeleteApartment(_dbContext);
        apartment.ApartmentId = id;

        DeleteApartmentValidator validator = new DeleteApartmentValidator();
        validator.ValidateAndThrow(apartment);

        apartment.Handle();
        return Ok();
    }
}
