using ApartmentManagementApi.Models;
using AutoMapper;

namespace ApartmentManagementApi.Application;

public class SendMessage
{
    private readonly IBaseDbContext _dbContext;
    private readonly IMapper _mapper;
    public int UserId { get; set; }
    public SentMessageViewModel model { get; set; }

    public SendMessage(IBaseDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public void Handle()
    {
        var message = _dbContext.Messages.SingleOrDefault(x => x.Title == model.Title && x.Content == model.Content);
        if (message != null) 
        {
            throw new InvalidOperationException("Bu Mesajı Daha Önce Gönderdiniz");
        }
        message = _mapper.Map<Message>(model);
        message.UserId = UserId;

        _dbContext.Messages.Add(message);
        _dbContext.SaveChanges();
    }
}
