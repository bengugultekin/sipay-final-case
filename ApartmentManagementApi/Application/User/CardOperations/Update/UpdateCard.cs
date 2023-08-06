using ApartmentManagementApi.Migrations;
using ApartmentManagementApi.Models;

namespace ApartmentManagementApi.Application.User;

public class UpdateCard
{
    private readonly IBaseDbContext _dbContext;
    public UpdateCardViewModel model { get; set; }
    public int CardId { get; set; }
    
    public UpdateCard(IBaseDbContext dbCcontext)
    {
        _dbContext = dbCcontext;
    }

    public void Handle()
    {
        var card = _dbContext.Cards.SingleOrDefault(x => x.Id == CardId);

        if (card == null)
        {
            throw new InvalidOperationException("Güncellenecek Kart Bilgisi Bulunamadı");
        }

        card.Number =  model.Number != default ? model.Number : card.Number;
        card.Cvc = model.Cvc != default ? model.Cvc : card.Cvc;
        card.LastUseDate = model.LastUseDate;

        _dbContext.SaveChanges();
    }
}
