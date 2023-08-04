using ApartmentManagementApi.Application.Admin;
using ApartmentManagementApi.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ApartmentManagementApi.Controllers;

[ApiController]
[Route("admin/[controller]s")]
public class MessageController : ControllerBase
{
    private readonly IBaseDbContext _dbContext;
    private readonly IMapper _mapper;

    public MessageController(IBaseDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    // Get All Messages From Query
    [HttpGet]
    public ActionResult GetMessages()
    {
        GetMessages messages = new GetMessages(_dbContext, _mapper);
        var messageList = messages.Handle();
        return Ok(messageList);
    }

    // Get A Message From Query
    [HttpGet("{id}")]
    public IActionResult GetMessageById(int id)
    {
        GetMessageDetailViewModel result;
        GetMessageDetail message = new GetMessageDetail(_dbContext, _mapper);
        message.MessageId = id;
        result = message.Handle();
        return Ok(result);
    }

    //Get Unread Messages
    [HttpGet("unread-messages")]
    public ActionResult GetUnreadedMessages()
    {
        GetUnreadMessages messages = new GetUnreadMessages(_dbContext, _mapper);
        var messageList = messages.Handle();
        return Ok(messageList);
    }
}
