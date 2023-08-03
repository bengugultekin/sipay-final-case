using ApartmentManagementApi.Application;
using ApartmentManagementApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApartmentManagementApi;

[ApiController]
[Route("[controller]s")]
public class PayBillController : ControllerBase
{
    private readonly IBaseDbContext _dbContext;

    public PayBillController(IBaseDbContext dbContext)
    {
        _dbContext = dbContext;
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
