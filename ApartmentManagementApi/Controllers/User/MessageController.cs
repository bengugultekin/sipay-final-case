using ApartmentManagementApi.Application;
using ApartmentManagementApi.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ApartmentManagementApi;

[ApiController]
[Route("[controller]s")]
public class MessageController : ControllerBase
{
    private readonly IBaseDbContext _dbContext;
    private readonly IMapper _mapper;

    public MessageController(IBaseDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }


    // Send Message
    [HttpPost]
    public IActionResult SendingMessage([FromBody] SentMessageViewModel model)
    {
        SendMessage message = new SendMessage(_dbContext, _mapper);
        message.model = model;
        message.Handle();
        return Ok();
    }
}
