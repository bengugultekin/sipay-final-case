using ApartmentManagementApi.Application;
using ApartmentManagementApi.Application.Admin;
using ApartmentManagementApi.Models;
using ApartmentManagementApi.Models.User;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ApartmentManagementApi;

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
        user.Handle();
        return Ok();
    }

    // Delete User
    [HttpDelete]
    public ActionResult DeleteUserById(int id) 
    {
        DeleteUser user = new DeleteUser(_dbContext);
        user.UserId = id;
        user.Handle();
        return Ok();
    }
}
