using ApartmentManagementApi.Application;
using ApartmentManagementApi.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ApartmentManagementApi;

[ApiController]
[Route("[controller]s")]
public class CardController : ControllerBase
{
    private readonly IBaseDbContext _dbContext;
    private readonly IMapper _mapper;

    public CardController(IBaseDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }


    // Create User
    [HttpPost]
    public IActionResult AddCard([FromBody] CreateCardViewModel model)
    {
        CreateCard card = new CreateCard(_dbContext, _mapper);
        card.model = model;
        card.Handle();
        return Ok();
    }
}
