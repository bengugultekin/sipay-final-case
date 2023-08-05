namespace ApartmentManagementApi.Application.User;

public class DeleteCard
{
    private readonly IBaseDbContext _dbContext;
    public int CardId { get; set; }
    public DeleteCard(IBaseDbContext dbCcontext)
    {
        _dbContext = dbCcontext;
    }

    public void Handle()
    {
        var card = _dbContext.Cards.SingleOrDefault(x => x.Id == CardId);

        if (card == null)
            throw new InvalidOperationException("Silinecek Kart Bilgisi Bulunamadı");


        _dbContext.Cards.Remove(card);
        _dbContext.SaveChanges();
    }
}
