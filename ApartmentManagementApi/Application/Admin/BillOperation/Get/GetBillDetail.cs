﻿using ApartmentManagementApi.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace ApartmentManagementApi.Application.Admin;

public class GetBillDetail
{
    private readonly IBaseDbContext _dbContext;
    private readonly IMapper _mapper;
    public int BillId { get; set; }

    public GetBillDetail(IBaseDbContext dbCcontext, IMapper mapper)
    {
        _dbContext = dbCcontext;
        _mapper = mapper;
    }

    public GetBillDetailViewModel Handle()
    {
        var bill = _dbContext.Bills
            .Include(x => x.User)
            .SingleOrDefault(x => x.Id == BillId);
        if (bill == null)
        {
            throw new InvalidOperationException("Fatura Bulunamadı");
        }

        GetBillDetailViewModel viewModel = _mapper.Map<GetBillDetailViewModel>(bill);

        return viewModel;
    }
}
