using ApartmentManagementApi.Application.Authorization;
using ApartmentManagementApi.Models;
using ApartmentManagementApi.TokenOperations;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ApartmentManagementApi.Controllers;

[ApiController]
[Route("[controller]s")]
public class AdminController : ControllerBase
{
    private readonly IBaseDbContext _dbContext;
    private readonly IMapper _mapper;
    private IConfiguration _configuration;

    public AdminController(IBaseDbContext dbContext, IMapper mapper, IConfiguration configuration)
    {
        _dbContext = dbContext;
        _mapper = mapper;
        _configuration = configuration;
    }

    [HttpPost]
    public IActionResult AddAdmin([FromBody] CreateAdminViewModel newAdmin)
    {
        CreateAdmin admin = new CreateAdmin(_dbContext, _mapper);
        admin.model = newAdmin;
        admin.Handle();
        return Ok();
    }

    [HttpPost("connect/token")]
    public ActionResult<Token> AddToken([FromBody] CreateTokenViewModel newToken)
    {
        CreateToken token = new CreateToken(_dbContext, _mapper, _configuration);
        token.model = newToken;
        var result = token.Handle();
        return result;
    }
}
