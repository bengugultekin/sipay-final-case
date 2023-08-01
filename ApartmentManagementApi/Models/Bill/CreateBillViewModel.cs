namespace ApartmentManagementApi.Models;

public class CreateBillViewModel
{
    public int UserId { get; set; }
    public decimal Cost { get; set; }
    public DateTime BillCreatedDate { get; set; }
    public DateTime BillLastPayDate { get; set; }
    public bool IsPaid { get; set; } = false;
}
