﻿using ApartmentManagementApi.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace ApartmentManagementApi.Application.Admin;

public class GetMessageDetail
{
    private readonly IBaseDbContext _dbCcontext;
    private readonly IMapper _mapper;
    public int MessageId { get; set; }

    public GetMessageDetail(IBaseDbContext dbCcontext, IMapper mapper)
    {
        _dbCcontext = dbCcontext;
        _mapper = mapper;
    }

    public GetMessageDetailViewModel Handle()
    {
        var message = _dbCcontext.Messages.Include(x => x.User).Where(msg => msg.Id == MessageId).SingleOrDefault();
        if (message == null) 
        {
            throw new InvalidOperationException("Mesaj Bulunamadı");
        }

        GetMessageDetailViewModel viewModel = _mapper.Map<GetMessageDetailViewModel>(message);

        if (message.IsReaded == false)
        {
            message.IsReaded = true;
            _dbCcontext.SaveChanges();
        }

        return viewModel;
    }
}
