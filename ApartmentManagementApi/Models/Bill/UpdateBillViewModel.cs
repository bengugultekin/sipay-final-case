namespace ApartmentManagementApi.Models;

public class UpdateBillViewModel
{
    public int UserId { get; set; }
    public decimal Cost { get; set; }
    public DateTime BillCreatedDate { get; set; }
    public DateTime BillLastPayDate { get; set; }
    public DateTime? BillPaidDate { get; set; }
    public bool IsPaid { get; set; }
}
