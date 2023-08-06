using ApartmentManagementApi.Application;
using ApartmentManagementApi.Models;
using ApartmentManagementApi.Services;
using ApartmentManagementApi.Application.Admin;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
namespace ApartmentManagementApi.Controllers;

[ApiController]
[Route("admin/[controller]s")]
public class MailController : ControllerBase
{
    private readonly IEmailService _emailService;
    private readonly IBaseDbContext _dbContext;
    private readonly IMapper _mapper;
    public MailController(IBaseDbContext dbContext, IMapper mapper, IEmailService emailService)
    {
        _dbContext = dbContext;
        _mapper = mapper;
        _emailService = emailService;
    }
    [HttpPost("mail-for-bills")]
    public IActionResult SendEmail(EmailDto request)
    {
        //SendMailForBills bills = new SendMailForBills(_dbContext, _mapper);
        //var billList = bills.Handle();
        //foreach (var bill in billList)
        //{
        //    var user = _dbContext.Users.SingleOrDefault(x => x.NameSurname == bill.Customer);
        //    if (user == null) 
        //    {
        //        return BadRequest("Faturaya ait kullanıcı bulunamadı");
        //    }
        //    request.To = user.Email;
        //    _emailService.SendEmail(request);

        //}
        
        _emailService.SendEmail(request);
        return Ok();
    }
}
