namespace ApartmentManagementApi.Models;

public class CreateMonthlyBillsViewModel
{
    public List<int> UsersId { get; set; } = new List<int>();
    public decimal Cost { get; set; }
    public DateTime BillCreatedDate { get; set; }
    public DateTime BillLastPayDate { get; set; }
    public bool IsPaid { get; set; } = false;
}
