namespace ApartmentManagementApi.Application.Admin;

public class DeleteDebt
{
    private readonly IBaseDbContext _dbContext;
    public int DebtId { get; set; }
    public DeleteDebt(IBaseDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Handle()
    {
        var debt = _dbContext.Debts.SingleOrDefault(x => x.Id == DebtId);
        if (debt == null)
        {
            throw new InvalidOperationException("Silinecek Borç Kaydı Bulunamadı");
        }

        _dbContext.Debts.Remove(debt);
        _dbContext.SaveChanges();
    }
}
