using ApartmentManagementApi.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace ApartmentManagementApi.Application.Admin;

public class GetUnreadMessages
{
    private readonly IBaseDbContext _dbCcontext;
    private readonly IMapper _mapper;

    public GetUnreadMessages(IBaseDbContext dbCcontext, IMapper mapper)
    {
        _dbCcontext = dbCcontext;
        _mapper = mapper;
    }

    public List<GetMessagesViewModel> Handle()
    {
        var messages = _dbCcontext.Messages
            .Include(x => x.User)
            .Where(x => x.IsReaded == false)
            .OrderBy(x => x.Id)
            .ToList();
        List<GetMessagesViewModel> viewModel = _mapper.Map<List<GetMessagesViewModel>>(messages);

        return viewModel;
    }
}
