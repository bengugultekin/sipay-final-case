using ApartmentManagementApi.Application;
using ApartmentManagementApi.Application.User;
using ApartmentManagementApi.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ApartmentManagementApi.Controllers;


[ApiController]
[Route("[controller]s")]
public class BillController : ControllerBase
{
    private readonly IBaseDbContext _dbContext;
    private readonly IMapper _mapper;
    public BillController(IBaseDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    // Get All My Bills From Query
    [HttpGet("{id}")]
    public ActionResult GetMyAllBills(int id)
    {
        GetMyBillsViewModel result;
        GetMyBills bills = new GetMyBills(_dbContext, _mapper);
        bills.UserId = id;
        var billList = bills.Handle();
        return Ok(billList);
    }

    [HttpPut("{id}")]
    public IActionResult PayingBill(int id, [FromBody] PayBillViewModel model)
    {
        PayBill paying = new PayBill(_dbContext);
        paying.BillId = id;
        paying.model = model;
        paying.Handle();
        return Ok();
    }

}
