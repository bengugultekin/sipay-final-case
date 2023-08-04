using ApartmentManagementApi.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace ApartmentManagementApi.Application.Admin;

public class GetMessages
{
    private readonly IBaseDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetMessages(IBaseDbContext dbCcontext, IMapper mapper)
    {
        _dbContext = dbCcontext;
        _mapper = mapper;
    }

    public List<GetMessagesViewModel> Handle()
    {
        var messages = _dbContext.Messages
            .Include(x => x.User)
            .OrderBy(x => x.Id)
            .ToList();
        List<GetMessagesViewModel> viewModel = _mapper.Map<List<GetMessagesViewModel>>(messages);

        return viewModel;
    }
}
