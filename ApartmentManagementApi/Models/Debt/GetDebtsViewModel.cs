namespace ApartmentManagementApi.Models;

public class GetDebtsViewModel
{
    public string Title { get; set; }
    public DateTime? DebtPaidDate { get; set; }
    public DateTime DebtLastPayDate { get; set; }
    public decimal Cost { get; set; }
    public bool IsPaid { get; set; }
}
