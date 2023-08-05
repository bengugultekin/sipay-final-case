namespace ApartmentManagementApi.Application.Admin;

public class DeleteBill
{
    private readonly IBaseDbContext _dbContext;
    public int BillId { get; set; }
    public DeleteBill(IBaseDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Handle()
    {
        var bill = _dbContext.Bills.SingleOrDefault(x => x.Id == BillId);
        if (bill == null)
        {
            throw new InvalidOperationException("Silinecek Fatura Kaydı Bulunamadı");
        }

        _dbContext.Bills.Remove(bill);
        _dbContext.SaveChanges();
    }
}
