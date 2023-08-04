﻿using ApartmentManagementApi.Models;
using AutoMapper;

namespace ApartmentManagementApi.Application.Admin;

public class GetDebtDetail
{
    private readonly IBaseDbContext _dbCcontext;
    private readonly IMapper _mapper;
    public int DebtId { get; set; }

    public GetDebtDetail(IBaseDbContext dbCcontext, IMapper mapper)
    {
        _dbCcontext = dbCcontext;
        _mapper = mapper;
    }

    public GetDebtDetailViewModel Handle()
    {
        var debt = _dbCcontext.Debts.SingleOrDefault(x => x.Id == DebtId);
        if (debt == null)
        {
            throw new InvalidOperationException("Gider Kaydı Bulunamadı");
        }

        GetDebtDetailViewModel viewModel = _mapper.Map<GetDebtDetailViewModel>(debt);

        return viewModel;
    }
}
