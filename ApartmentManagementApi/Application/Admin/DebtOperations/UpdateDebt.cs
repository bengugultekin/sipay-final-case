using ApartmentManagementApi.Migrations;
using ApartmentManagementApi.Models;

namespace ApartmentManagementApi.Application.Admin;

public class UpdateDebt
{
    private readonly IBaseDbContext _dbCcontext;
    public UpdateDebtViewModel model { get; set; }
    public int DebtId { get; set; }
    public UpdateDebt(IBaseDbContext dbCcontext)
    {
        _dbCcontext = dbCcontext;
    }

    public void Handle()
    {
        var debt = _dbCcontext.Debts.SingleOrDefault(x => x.Id == DebtId);

        if (debt == null)
        {
            throw new InvalidOperationException("Güncellenecek Gider Kaydı Bulunamadı");
        }

        debt.Title = !string.IsNullOrEmpty(model.Title) ? model.Title : debt.Title;
        debt.DebtLastPayDate = model.DebtLastPayDate;
        debt.DebtLastPayDate = model.DebtLastPayDate;
        debt.IsPaid = model.IsPaid;
        debt.Cost = model.Cost != default ? model.Cost : debt.Cost;

        _dbCcontext.SaveChanges();
    }
}
