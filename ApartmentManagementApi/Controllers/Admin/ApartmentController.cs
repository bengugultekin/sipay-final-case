﻿using ApartmentManagementApi.Application;
using ApartmentManagementApi.Application.Admin;
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

    // Create Apartment
    [HttpPost]
    public IActionResult AddApartment(CreateApartmentViewModel model)
    {
        CreateApartment apartment = new CreateApartment(_dbContext, _mapper);
        apartment.model = model;
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
        apartment.Handle();
        return Ok();
    }

    // Delete Apartment
    [HttpDelete("{id}")]
    public ActionResult DeleteApartmentById(int id) 
    {
        DeleteApartment apartment = new DeleteApartment(_dbContext);
        apartment.ApartmentId = id;
        apartment.Handle();
        return Ok();
    }
}
