using ApartmentManagementApi.Application;
using ApartmentManagementApi.Application.Admin;
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

    [HttpPost("monthly-bill")]
    public IActionResult AddMonthlyBill(CreateMonthlyBillsViewModel model)
    {
        CreateMonthlyBills bills = new CreateMonthlyBills(_dbContext, _mapper);
        bills.model = model;
        bills.Handle();
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

    // Get A Bill From Query
    [HttpGet("{id}")]
    public IActionResult GetBillById(int id)
    {
        GetBillDetailViewModel result;
        GetBillDetail bill = new GetBillDetail(_dbContext, _mapper);
        bill.BillId = id;
        result = bill.Handle();
        return Ok(result);
    }

    // Get Paid Bills From Query
    [HttpGet("paid-bills")]
    public ActionResult GetPaidBills()
    {
        GetPaidBills bills = new GetPaidBills(_dbContext, _mapper);
        var billList = bills.Handle();
        return Ok(billList);
    }

    [HttpGet("unpaid-bills")]
    public ActionResult GetUnpaidBillsAll()
    {
        GetUnpaidBills bills = new GetUnpaidBills(_dbContext, _mapper);
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

    // Get Unaid Bills From Query
    [HttpGet("unpaid-bills-costs")]
    public ActionResult GetUnpaidBillsCosts()
    {
        GetUnpaidBills bills = new GetUnpaidBills(_dbContext, _mapper);
        var billList = bills.Handle();
        decimal totalCost = 0;
        foreach (var bill in billList)
        {
            totalCost = totalCost + bill.Cost;
        }
        return Ok(totalCost);
    }
}
