using ApartmentManagementApi.Migrations;
using ApartmentManagementApi.Models;

namespace ApartmentManagementApi.Application.Admin;

public class UpdateDebt
{
    private readonly IBaseDbContext _dbContext;
    public UpdateDebtViewModel model { get; set; }
    public int DebtId { get; set; }
    public UpdateDebt(IBaseDbContext dbCcontext)
    {
        _dbContext = dbCcontext;
    }

    public void Handle()
    {
        var debt = _dbContext.Debts.SingleOrDefault(x => x.Id == DebtId);

        if (debt == null)
        {
            throw new InvalidOperationException("Güncellenecek Gider Kaydı Bulunamadı");
        }

        debt.Title = !string.IsNullOrEmpty(model.Title) ? model.Title : debt.Title;
        debt.DebtLastPayDate = model.DebtLastPayDate;
        debt.DebtLastPayDate = model.DebtLastPayDate;
        debt.IsPaid = model.IsPaid;
        debt.Cost = model.Cost != default ? model.Cost : debt.Cost;

        _dbContext.SaveChanges();
    }
}
