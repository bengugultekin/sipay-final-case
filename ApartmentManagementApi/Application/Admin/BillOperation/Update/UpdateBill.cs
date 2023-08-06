using ApartmentManagementApi.Models;

namespace ApartmentManagementApi.Application.Admin;

public class UpdateBill
{
    private readonly IBaseDbContext _dbContext;
    public UpdateBillViewModel model { get; set; }

    public int UserId { get; set; }
    public int BillId { get; set; }

    public UpdateBill(IBaseDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Handle()
    {
        var bill = _dbContext.Bills.SingleOrDefault(x => x.Id == BillId);
        if (bill == null) 
        {
            throw new InvalidOperationException("Güncellenecek Fatura Kaydı Bulunamadı");
        }
        if (UserId != 0)
        {
            var user = _dbContext.Users.SingleOrDefault(x => x.Id == UserId);
            if (user == null)
            {
                throw new InvalidOperationException("Güncellenecek Fatura İçin Eklediğiniz Kullanıcı Bulunamadı");
            }
        }
        //apartment.UserId = model.UserId != default ? model.UserId : apartment.UserId;
        //apartment.Block = !string.IsNullOrEmpty(model.Block) ? model.Block : apartment.Block;

        bill.UserId = model.UserId != default ? model.UserId : bill.UserId;
        bill.Cost = model.Cost != default ? model.Cost : bill.Cost;
        bill.BillCreatedDate = model.BillCreatedDate;
        bill.BillLastPayDate = model.BillLastPayDate;
        bill.BillPaidDate = model.BillPaidDate;
        bill.IsPaid = model.IsPaid;

        _dbContext.SaveChanges();

    }
}
