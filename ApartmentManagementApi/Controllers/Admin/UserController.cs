﻿using ApartmentManagementApi.Application;
using ApartmentManagementApi.Application.Admin;
using ApartmentManagementApi.Application.Admin.UserOperations;
using ApartmentManagementApi.Models;
using ApartmentManagementApi.Models.User;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApartmentManagementApi;

[Authorize]
[ApiController]
[Route("admin/[controller]s")]
public class UserController : ControllerBase
{
    private readonly IBaseDbContext _dbContext;
    private readonly IMapper _mapper;

    public UserController(IBaseDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }


    // Create User
    [HttpPost]
    public IActionResult AddUser([FromBody] CreateUserViewModel model)
    {
        CreateUser user = new CreateUser(_dbContext, _mapper);
        user.model = model;

        CreateUserValidator validator = new CreateUserValidator();
        validator.ValidateAndThrow(user);

        user.Handle();
        return Ok();
    }

    // Get All Users From Query
    [HttpGet]
    public ActionResult GetUsers()
    {
        GetUsers users = new GetUsers(_dbContext, _mapper);
        var userList = users.Handle();
        return Ok(userList);
    }

    // Update User
    [HttpPut("{id}")]
    public ActionResult UpdtUser(int id, [FromBody] UpdateUserViewModel updateUser)
    {
        UpdateUser user = new UpdateUser(_dbContext);
        user.UserId = id;
        user.model = updateUser;

        UpdateUserValidator validator = new UpdateUserValidator();
        validator.ValidateAndThrow(user);

        user.Handle();
        return Ok();
    }

    // Delete User
    [HttpDelete]
    public ActionResult DeleteUserById(int id) 
    {
        DeleteUser user = new DeleteUser(_dbContext);
        user.UserId = id;

        DeleteUserValidator validator = new DeleteUserValidator();
        validator.ValidateAndThrow(user);

        user.Handle();
        return Ok();
    }
}
