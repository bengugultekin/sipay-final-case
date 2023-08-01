using ApartmentManagementApi.Application;
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

    [HttpPost]
    public IActionResult AddUser([FromBody] CreateUserViewModel model)
    {
        CreateUser user = new CreateUser(_dbContext, _mapper);
        user.model = model;
        user.Handle();
        return Ok();
    }
}
