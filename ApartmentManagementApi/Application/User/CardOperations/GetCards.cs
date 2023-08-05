using ApartmentManagementApi.Models;
using AutoMapper;

namespace ApartmentManagementApi.Application.User;

public class GetCards
{
    private readonly IBaseDbContext _dbContext;
    private readonly IMapper _mapper;
    public int UserId { get; set; }
    public GetCards(IBaseDbContext dbCcontext, IMapper mapper)
    {
        _dbContext = dbCcontext;
        _mapper = mapper;
    }

    public List<GetCardsViewModel> Handle()
    {
        var cards = _dbContext.Cards.Where(x => x.UserId == UserId).OrderBy(x => x.Id).ToList();
        List<GetCardsViewModel> viewModel = _mapper.Map<List<GetCardsViewModel>>(cards);
        return viewModel;
    }
}
