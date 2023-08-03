using ApartmentManagementApi.Models;
using AutoMapper;

namespace ApartmentManagementApi.Application;

public class PayBill
{
    private readonly IBaseDbContext _dbContext;
    public PayBillViewModel model {  get; set; }
    public int BillId { get; set; }

    public PayBill(IBaseDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public void Handle()
    {
        var bill = _dbContext.Bills.SingleOrDefault(x => x.Id == BillId);
        if (bill == null) 
        {
            throw new InvalidOperationException("Ödemeye Çalıştığınız Fatura Mevcut Değil");
        }
        else if (bill.IsPaid == true) 
        {
            throw new InvalidOperationException("Ödemeye Çalıştığınız Fatura Zaten Ödenmiş");
        }

        var card = _dbContext.Cards.SingleOrDefault(x => x.Number == model.CardNumber && x.Cvc == model.CardCvc && x.LastUseDate == model.CardLastUseDate);
        if (card == null) 
        {
            throw new InvalidOperationException("Kart Bilgileriniz Hatalı");
        }

        bill.IsPaid = true;
        bill.BillPaidDate = DateTime.Now;

        _dbContext.SaveChanges();
    }
}
