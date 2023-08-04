namespace ApartmentManagementApi.Models;

public class CreateDebtViewModel
{
    public string Title { get; set; }
    public DateTime? DebtPaidDate { get; set; }
    public DateTime DebtLastPayDate { get; set; }
    public decimal Cost { get; set; }
    public bool IsPaid { get; set; } = false;
}
