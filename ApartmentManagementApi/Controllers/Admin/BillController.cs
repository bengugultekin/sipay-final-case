using ApartmentManagementApi.Application;
using ApartmentManagementApi.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ApartmentManagementApi;

[ApiController]
[Route("admin/[controller]s")]
public class BillController : ControllerBase
{
    private readonly IBaseDbContext _dbContext;
    private readonly IMapper _mapper;

    public BillController(IBaseDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    // Create Bill
    [HttpPost]
    public IActionResult AddBill(CreateBillViewModel model)
    {
        CreateBill bill = new CreateBill(_dbContext, _mapper);
        bill.model = model;
        bill.Handle();
        return Ok();
    }

    // Get All Bills From Query
    [HttpGet]
    public ActionResult GetBills()
    {
        GetBills bills = new GetBills(_dbContext, _mapper);
        var billList = bills.Handle();
        return Ok(billList);
    }

    // Get Paid Bills From Query
    [HttpGet("paid-bills")]
    public ActionResult GetPaidBills()
    {
        GetPaidBills bills = new GetPaidBills(_dbContext, _mapper);
        var billList = bills.Handle();
        return Ok(billList);
    }

    // Get Paid Bills From Query
    [HttpGet("paid-bills-costs")]
    public ActionResult GetPaidBillsCosts()
    {
        GetPaidBills bills = new GetPaidBills(_dbContext, _mapper);
        var billList = bills.Handle();
        decimal totalCost = 0;
        foreach (var bill in billList)
        {
            totalCost = totalCost + bill.Cost;
        }
        return Ok(totalCost);
    }
}
