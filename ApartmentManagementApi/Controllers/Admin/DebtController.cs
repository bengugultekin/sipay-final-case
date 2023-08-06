﻿using ApartmentManagementApi.Application;
using ApartmentManagementApi.Application.Admin;
using ApartmentManagementApi.Application.Admin.DebtOperations;
using ApartmentManagementApi.Models;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApartmentManagementApi.Controllers;

[Authorize]
[ApiController]
[Route("admin/[controller]s")]
public class DebtController : ControllerBase
{
    private readonly IBaseDbContext _dbContext;
    private readonly IMapper _mapper;

    public DebtController(IBaseDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    // Get All Debts From Query
    [HttpGet]
    public ActionResult GetDebtsAll()
    {
        GetDebts debts = new GetDebts(_dbContext, _mapper);
        var debtList = debts.Handle();
        return Ok(debtList);
    }

    // Get All Unpaid Debts From Query
    [HttpGet("unpaid-debts")]
    public ActionResult GetUnpaidDebtsAll()
    {
        GetUnpaidDebts debts = new GetUnpaidDebts(_dbContext, _mapper);
        var debtList = debts.Handle();
        return Ok(debtList);
    }

    // Get All Paid Debts From Query
    [HttpGet("paid-debts")]
    public ActionResult GetPaidDebtsAll()
    {
        GetPaidDebts debts = new GetPaidDebts(_dbContext, _mapper);
        var debtList = debts.Handle();
        return Ok(debtList);
    }

    // Get A Debts From Query
    [HttpGet("{id}")]
    public IActionResult GetDebtById(int id)
    {
        GetDebtDetailViewModel result;
        GetDebtDetail debt = new GetDebtDetail(_dbContext, _mapper);
        debt.DebtId = id;

        GetDebtDetailValidator validator = new GetDebtDetailValidator();
        validator.ValidateAndThrow(debt);

        result = debt.Handle();
        return Ok(result);
    }

    // Create Debt
    [HttpPost]
    public IActionResult AddDebt(CreateDebtViewModel model)
    {
        CreateDebt debt = new CreateDebt(_dbContext, _mapper);
        debt.model = model;

        CreateDebtValidator validator = new CreateDebtValidator();
        validator.ValidateAndThrow(debt);

        debt.Handle();
        return Ok();
    }

    // Update Debt
    [HttpPut("{id}")]
    public ActionResult UpdtDebt(int id, [FromBody] UpdateDebtViewModel updateDebt)
    {
        UpdateDebt debt = new UpdateDebt(_dbContext);
        debt.DebtId = id;
        debt.model = updateDebt;

        UpdateDebtValidator validator = new UpdateDebtValidator();
        validator.ValidateAndThrow(debt);

        debt.Handle();
        return Ok();
    }

    // Get Paid Debts Total Costs From Query
    [HttpGet("paid-debts-total-costs")]
    public ActionResult GetPaidDebtsTotalCosts()
    {
        GetPaidDebts debts = new GetPaidDebts(_dbContext, _mapper);
        var debtList = debts.Handle();
        decimal totalCost = 0;
        foreach (var debt in debtList)
        {
            totalCost = totalCost + debt.Cost;
        }
        return Ok(totalCost);
    }

    // Get Unpaid Debts Total Costs From Query
    [HttpGet("unpaid-debts-total-costs")]
    public ActionResult GetUnpaidDebtsTotalCosts()
    {
        GetUnpaidDebts debts = new GetUnpaidDebts(_dbContext, _mapper);
        var debtList = debts.Handle();
        decimal totalCost = 0;
        foreach (var debt in debtList)
        {
            totalCost = totalCost + debt.Cost;
        }
        return Ok(totalCost);
    }

    // Get Debts Total Costs From Query
    [HttpGet("debts-total-costs")]
    public ActionResult GetDebtsTotalCosts()
    {
        GetDebts debts = new GetDebts(_dbContext, _mapper);
        var debtList = debts.Handle();
        decimal totalCost = 0;
        foreach (var debt in debtList)
        {
            totalCost = totalCost + debt.Cost;
        }
        return Ok(totalCost);
    }

    // Delete Debt
    [HttpDelete("{id}")]
    public ActionResult DeleteDebtById(int id)
    {
        DeleteDebt debt = new DeleteDebt(_dbContext);
        debt.DebtId = id;

        DeleteDebtValidator validator = new DeleteDebtValidator();
        validator.Validate(debt);

        debt.Handle();
        return Ok();
    }
}
